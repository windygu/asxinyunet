using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComLib.Lang
{
    /// <summary>
    /// Uses the Lexer to parse script in terms of sequences of Statements and Expressions;
    /// Each statement and expression is a sequence of Tokens( see Lexer )
    /// Main method is Parse(script) and ParseStatement();
    /// 
    /// 1. var name = "kishore";
    /// 2. if ( name == "kishore" ) print("true");
    /// 
    /// Statements:
    /// 
    /// VALUE:         TYPE:
    /// 1. AssignmentStatement ( "var name = "kishore"; )
    /// 2. IfStatement ( "if (name == "kishore" ) { print ("true"); }
    /// </summary>
    public class Parser : ParserBase, ILangParser
    {
        /// <summary>
        /// Initialize the context.
        /// </summary>
        /// <param name="context"></param>
        public Parser(Context context) : base(context)
        {
        }


        /// <summary>
        /// Parses the script into statements and expressions.
        /// </summary>
        /// <param name="script">Script text</param>
        /// <param name="scope">Scope object</param>
        public List<Statement> Parse(string script, Scope scope = null)
        {
            // 1. Initalize data members
            Init(script, scope);

            // 2. Convert script to sequence of tokens.
            Tokenize();

            // 3. Initialize the combinators.
            _context.Plugins.ForEach<IExpressionPlugin>( plugin => plugin.Init(this, _tokenIt));
            _context.Plugins.ForEach<ITokenPlugin>(plugin => plugin.Init(this, _tokenIt));

            // 4. Move to first token
            _tokenIt.Advance();

            while (true)
            {
                if (_tokenIt.NextToken.Token == Token.EndToken)
                    break;
                
                // Get next statement.
                var stmt = ParseStatement();

                // Limit case:
                _context.Limits.CheckParserStatement(stmt);

                if (stmt != null)
                {                    
                    // Add to list of statements.
                    _statements.Add(stmt);
                }
                // Go to next token.
                _tokenIt.Advance();
            }
            return _statements;
        }


        /// <summary>
        /// Executes all the statements in the script.
        /// </summary>
        public void Execute()
        {
            // Check number of statements.
            if (_statements == null || _statements.Count == 0) return;

            // Reset the lang state ( loop limits, recursion limits etc. )
            this._context.State.Reset();
            foreach (var stmt in _statements)
            {
                stmt.Execute();
            }
        }        


        #region Parse Statments
        private Statement ParseStatement()
        {
            _state.StatementNested++;
            Statement stmt = null;
            TokenData stmtToken = _tokenIt.NextToken;
            Token nexttoken = _tokenIt.NextToken.Token;

            _context.Limits.CheckParserStatementNested(_tokenIt.NextToken, _state.StatementNested);

            // var
            if (nexttoken == Tokens.Var)
            {
                stmt = ParseVar();
            }
            else if (_context.Plugins.ContainsStmt(nexttoken.Text))
            {
                stmt = ParseCombinatorStatement();
            }
            else if (nexttoken is IdToken)
            {
                stmt = ParseIdBasedStatement();
            }
            else if (nexttoken == Tokens.If)
            {
                stmt = ParseIf();
            }
            else if (nexttoken == Tokens.While)
            {
                stmt = ParseWhile();
            }
            else if (nexttoken == Tokens.For)
            {
                stmt = ParseFor();
            }
            else if (nexttoken == Tokens.Function)
            {
                stmt = ParseFunctionDeclaration();
            }
            else if (nexttoken == Tokens.Return)
            {
                stmt = ParseReturn();
            }
            else if (nexttoken == Tokens.Try)
            {
                stmt = ParseTryCatch();
            }
            else if (nexttoken == Tokens.Throw)
            {
                stmt = ParseThrow();
            }
            else if (nexttoken == Tokens.Break)
            {
                stmt = new BreakStatement();
                _tokenIt.Expect(Tokens.Break);
                _tokenIt.Expect(Tokens.Semicolon, false);
            }
            else if (nexttoken == Tokens.Continue)
            {
                stmt = new ContinueStatement();
                _tokenIt.Expect(Tokens.Continue);
                _tokenIt.Expect(Tokens.Semicolon, false);
            }
            else if (nexttoken != Tokens.NewLine
                    && nexttoken != Tokens.CommentSLine
                    && nexttoken != Tokens.CommentMLine)
                throw _tokenIt.BuildSyntaxUnexpectedTokenException();
            if(stmt != null)
            {
                SetScriptPosition(stmt, stmtToken);
                stmt.Ctx = _context;
            }
            _state.LastStmt = stmt;

            _state.StatementNested--;
            return stmt;
        }


        /// <summary>
        /// // 1. var name;
        /// 2. var age = 21;
        /// 3. var canDrink = age >= 21;
        /// 4. var canVote = CanVote(age);
        /// </summary>
        /// <returns></returns>
        private Statement ParseVar()
        {
            return ParseAssignment(true);
        }


        /// <summary>
        /// 1. var name;
        /// 2. var age = 21;
        /// 3. canDrink = age >= 21;
        /// 4. canVote = CanVote(age);
        /// </summary>
        /// <returns></returns>
        private Statement ParseAssignment(bool expectVar, bool expectId = true, Expression varExp = null)
        {
            string name = null;
            if (expectVar) _tokenIt.Expect(Tokens.Var);
            if (expectId)
            {
                name = _tokenIt.ExpectId();
                varExp = new VariableExpression(name);
            }

            // Case 1: var name;
            if (_tokenIt.NextToken.Token == Tokens.Semicolon) return new AssignmentStatement(expectVar, varExp, null);

            // Case 2: var name = <expression>
            Expression valueExp = null;
            if (_tokenIt.NextToken.Token == Tokens.Assignment)
            {
                _tokenIt.Advance();
                valueExp = ParseExpression(Terminators.ExpVarDeclarationEnd, true);
            }
            // ; ? only 1 declaration / initialization.
            if (_tokenIt.NextToken.Token == Tokens.Semicolon)            
                return new AssignmentStatement(expectVar, varExp, valueExp){ Ctx = _context };
            
            // Multiple 
            // Example 1: var a,b,c;
            // Example 2: var a = 1, b = 2, c = 3;
            _tokenIt.Expect(Tokens.Comma, true);
            var declarations = new List<Tuple<Expression, Expression>>();
            declarations.Add(new Tuple<Expression,Expression>(varExp, valueExp));

            while(true)
            {
                // Reset to null.
                varExp = null; valueExp = null;
                name = _tokenIt.ExpectId();
                varExp = new VariableExpression(name);
               
                // , or expression?
                if (_tokenIt.NextToken.Token == Tokens.Assignment)
                {
                    _tokenIt.Advance();
                    valueExp = ParseExpression(Terminators.ExpVarDeclarationEnd, true);
                }
                // Add to list
                declarations.Add(new Tuple<Expression, Expression>(varExp, valueExp));
                                
                if (_tokenIt.NextToken.Token == Tokens.Semicolon || _tokenIt.NextToken.Token == Token.EndToken)
                    break;

                _tokenIt.Expect(Tokens.Comma);
            }
            return new AssignmentStatement(expectVar, declarations);
        }


        private Statement ParseIf()
        {
            IfStatement stmt = new IfStatement();
            var statements = new List<Statement>();

            // While ( condition expression )
            _tokenIt.Expect(Tokens.If);
            
            // Parse the if
            ParseConditionalStatement(stmt);

            // Check for next 2 tokens for "else and else if".
            var nToken = _tokenIt.Peek();

            // Handle "else if" and/or else
            if (nToken != null && nToken.Token == Tokens.Else)
            {
                // _tokenIt.NextToken = "else"
                _tokenIt.Advance();
                _tokenIt.Advance();

                // What's after else? 
                // 1. "if"      = else if statement
                // 2. "{"       = multi  line else
                // 3. "nothing" = single line else
                // Peek 2nd token for else if.
                var token = _tokenIt.NextToken;
                if (_tokenIt.NextToken.Token == Tokens.If)
                {
                    stmt.Else = ParseIf() as BlockStatement;
                }
                else // Multi-line or single line else
                {                    
                    var elseStmt = new BlockStatement();
                    ParseBlock(elseStmt);
                    elseStmt.Ctx = _context;
                    stmt.Else = elseStmt;
                    SetScriptPosition(stmt.Else, token);
                }
            }
            return stmt;
        }

        
        /// <summary>
        /// Parses a while statment.
        /// </summary>
        /// <returns></returns>
        private Statement ParseWhile()
        {
            LoopStatement stmt = new LoopStatement();
            
            // While ( condition expression )
            _tokenIt.Expect(Tokens.While);
            ParseConditionalStatement(stmt);
            return stmt;
        }


        private Statement ParseTryCatch()
        {
            var stmt = new TryCatchStatement();
            var statements = new List<Statement>();

            _tokenIt.Expect(Tokens.Try);
            ParseBlock(stmt);
            _tokenIt.ExpectMany(Tokens.RightBrace, Tokens.Catch, Tokens.LeftParenthesis);

            stmt.ErrorName = _tokenIt.ExpectId();
            _tokenIt.Expect(Tokens.RightParenthesis);
            ParseBlock(stmt.Catch);
            stmt.Ctx = _context;
            stmt.Catch.Ctx = _context;            
            return stmt;
        }


        private Statement ParseThrow()
        {
            _tokenIt.Expect(Tokens.Throw);
            var exp = ParseExpressionPart(Terminators.ExpSemicolonEnd);
            return new ThrowStatement() { Exp = exp };
        }


        private Statement ParseFor()
        {
            _tokenIt.ExpectMany(Tokens.For, Tokens.LeftParenthesis);
            var ahead = _tokenIt.Peek(1);
            if (ahead.Token == Tokens.In) return ParseForIn();

            return ParseForLoop();
        }


        private Statement ParseForLoop()
        {
            ForLoopStatement stmt = new ForLoopStatement();
            var statements = new List<Statement>();

            // While ( condition expression )
            // Parse while condition
            var start = ParseStatement();
            _tokenIt.Advance();
            var condition = ParseExpression(Terminators.ExpSemicolonEnd);
            _tokenIt.Advance();
            string name = _tokenIt.ExpectId();
            var increment = ParseUnary(name, false);
            _tokenIt.Expect(Tokens.RightParenthesis);
            stmt.Init(start, condition, increment);
            ParseBlock(stmt);            
            return stmt;
        }


        private Statement ParseForIn()
        {   
            var varname = _tokenIt.ExpectId();
            _tokenIt.Expect(Tokens.In);
            var sourcename = _tokenIt.ExpectId();
            _tokenIt.Expect(Tokens.RightParenthesis);

            var stmt = new ForEachStatement(varname, sourcename);
            ParseBlock(stmt);
            return stmt;
        }


        private Statement ParseFunctionDeclaration()
        {
            var stmt = new FunctionDeclarationStatement();
            stmt.Function.Ctx = _context;
            SetScriptPosition(stmt.Function, _tokenIt.NextToken);

            _tokenIt.Expect(Tokens.Function);

            var name = _tokenIt.ExpectId(false, true);
            bool expectRightParenthesis = true;
            var nextToken = _tokenIt.Peek();
            var argNames = new List<string>();

            // 1. function "apply" {
            if (nextToken.Token == Tokens.LeftBrace)
            {
                expectRightParenthesis = false;
                _tokenIt.Advance();
            }
            // 2. function apply ( name, age ) {            
            else
            {
                _tokenIt.AdvanceAndExpect(Tokens.LeftParenthesis);
                argNames = ParseNames();
            }
            
            stmt.Function.Init(name, argNames);
            
            // Match ")"
            if(expectRightParenthesis) _tokenIt.Expect(Tokens.RightParenthesis);
            ParseBlock(stmt.Function);
            
            return stmt;
        }


        /// <summary>
        /// Parses a combinator into a statement.
        /// </summary>
        /// <returns></returns>
        private Statement ParseCombinatorStatement()
        {
            var token = _tokenIt.NextToken.Token;
            var plugin = _context.Plugins.GetStmt(token.Text);
            var exp = plugin.Parse();
            exp.Ctx = _context;
            _tokenIt.Advance(1, false);
            
            // New line signifying end of expression?
            if (plugin.IsNewLineEndOfExpression && _tokenIt.NextToken.Token != Tokens.NewLine)
                throw _tokenIt.BuildSyntaxExpectedTokenException("line return");

            else if (!plugin.IsNewLineEndOfExpression) 
                _tokenIt.Expect(Tokens.Semicolon, false);

            return new ExpressionStatement(exp);
        }


        /// <summary>
        /// Parses an id based statement.
        /// - user = 'john';
        /// - activateuser();
        /// - ndx++;
        /// 
        /// Complex:
        ///     - users[0] = new User();
        ///     - user.name = 'john';
        ///     - getuser().name = 'john';
        /// </summary>
        /// <returns></returns>
        private Statement ParseIdBasedStatement()
        {
            string name = _tokenIt.ExpectId(false);
            Expression exp = null;

            // Forward check for assignments on
            var aheadToken = _tokenIt.Peek();
            if (aheadToken.Token == Tokens.Dot || aheadToken.Token == Tokens.LeftBracket || aheadToken.Token == Tokens.LeftParenthesis)
            {               
                exp = ParseIdExpression(name);
                if (exp is FunctionCallExpression)
                {
                    _tokenIt.Advance();
                    _tokenIt.Expect(Tokens.Semicolon, false);
                    return new FunctionCallStatement(exp);
                }
            }
            _tokenIt.Advance();
            if (_tokenIt.NextToken.Token == Tokens.Assignment)
            {
                exp = exp ?? new VariableExpression(name);
                return ParseAssignment(false, false, exp);
            }            
            else // ++ -- += *= /= -=
            {
                return ParseUnary(name);
            }
            throw _tokenIt.BuildSyntaxExpectedTokenException("identifier");
        }


        private Statement ParseReturn()
        {
            var stmt = new ReturnStatement();
            _tokenIt.Expect(Tokens.Return);
            if (_tokenIt.NextToken.Token == Tokens.Semicolon)
                return stmt;

            var exp = ParseExpression(Terminators.ExpSemicolonEnd);
            _tokenIt.Expect(Tokens.Semicolon, false);
            stmt.Exp = exp;
            return stmt;
        }


        private BlockStatement ParseBlock(BlockStatement block)
        {
            // { statemnt1; statement2; }
            bool isMultiLine = false;

            // Check for single line block 
            if (_tokenIt.NextToken.Token == Tokens.LeftBrace) isMultiLine = true;
            if (block == null) block = new BlockStatement();

            // Case 1: Single line block.
            if (!isMultiLine)
            {
                var stmt = ParseStatement();
                stmt.Ctx = _context;
                stmt.Parent = block;
                block.Statements.Add(stmt);
                return block;
            }

            // Case 2: Multi-line block
            _tokenIt.Expect(Tokens.LeftBrace);
            while (true)
            {
                // Check for end of statment or invalid end of script.
                if (IsEndOfStatementOrEndOfScript(Tokens.RightBrace))
                    break;

                var stmt = ParseStatement();
                stmt.Parent = block;
                stmt.Ctx = _context;

                // Parse statement by statement.
                block.Statements.Add(stmt);

                // Go to next token.
                _tokenIt.Advance();
            }
            
            _tokenIt.Expect(Tokens.RightBrace, false);

            return block;
        }


        /// <summary>
        /// Parses unary
        /// 1. ndx++
        /// 2. ndx--
        /// 3. ndx += 2 
        /// 4. ndx -= 2
        /// 5. ndx *= 2
        /// 6. ndx /= 2
        /// </summary>
        /// <param name="name"></param>
        /// <param name="useSemicolonAsTerminator"></param>
        /// <returns></returns>
        private Statement ParseUnary(string name, bool useSemicolonAsTerminator = true)
        {
            Operator op = Tokens.ToOp(_tokenIt.NextToken.Token.Text);
            var opToken = _tokenIt.NextToken;
            double incrementValue = 1;
            AssignmentStatement stmt = null;
            _tokenIt.Advance();

            // ++ -- 
            if (_tokenIt.NextToken.Token == Tokens.Semicolon)
            {
                var u1 = new UnaryExpression(name, incrementValue, op, _context);
                SetScriptPosition(u1, opToken);
                stmt = new AssignmentStatement(false, new VariableExpression(name), u1);
                _tokenIt.Expect(Tokens.Semicolon, false);
            }
            else // += -= *= -=
            {
                var endTokens = useSemicolonAsTerminator ? Terminators.ExpSemicolonEnd : Terminators.ExpParenthesisEnd;
                var exp = ParseExpression(endTokens);
                var u2 = new UnaryExpression(name, exp, op, _context);
                SetScriptPosition(u2, opToken);
                stmt = new AssignmentStatement(false, new VariableExpression(name), u2);
            }
            stmt.Ctx = _context;
            return stmt;
        }


        /// <summary>
        /// Parses a sequence of expressions
        /// 1. expression AND expression
        /// 2. expression OR  expression
        /// 3. expression
        /// </summary>
        /// <param name="endTokens"></param>
        /// <param name="combineEndTokensWithExpPartEndTokens"></param>
        /// <returns></returns>
        public Expression ParseExpression(IDictionary<Token, bool> endTokens, bool combineEndTokensWithExpPartEndTokens = false)
        {
            Expression exp = null;
            var partEnd = Terminators.ExpPartEnd;
            if (combineEndTokensWithExpPartEndTokens)
            {
                partEnd = new Dictionary<Token, bool>(Terminators.ExpPartEnd);
                foreach (var pair in endTokens)
                    partEnd[pair.Key] = pair.Value;
            }

            while (true)
            {                
                // Break for loop
                if (endTokens.ContainsKey(_tokenIt.NextToken.Token) || _tokenIt.NextToken.Token == Token.EndToken)
                    break;

                exp = ParseExpressionPart(partEnd);

                // Break for loop
                if (endTokens.ContainsKey(_tokenIt.NextToken.Token) || _tokenIt.NextToken.Token == Token.EndToken)
                    break;
                
                this._tokenIt.Advance();
            }
            return exp;
        }


        /// <summary>
        /// Parses an expression.
        /// </summary>
        /// <param name="endTokens"></param>
        /// <param name="resetExpressionCount">Whether or not the reset the expression count.</param>
        /// <returns></returns>
        public Expression ParseExpressionPart(IDictionary<Token, bool> endTokens, bool resetExpressionCount = true)
        {
            if(resetExpressionCount) _state.ExpressionCount = 0;
            Expression exp = ParseExpressionPart2(endTokens);
            _state.LastExpPart = exp;            
            _state.ExpressionCount = 0;
            return exp;
        }


        /// <summary>
        /// Parses the following type of expressions:
        /// 
        /// 1. constant : 21, true, false, 'user01', null, 34.56
        /// 2. id       : currentUser
        /// 3. array    : [
        /// 4. map      : {
        /// 5. oper     : + - * / > >= == != ! etc.
        /// 6. new      : new 
        /// </summary>
        /// <param name="endTokens"></param>
        /// <param name="handleMathOperator">Whether or not to handle the mathematical expressions.</param>
        /// <param name="handleSingleExpression">Whether or not to handle only 1 expression.</param>
        /// <param name="enablePlugins">Whether or not the enable usage of plugins just for parsing current expression</param>
        /// <returns></returns>
        public Expression ParseExpressionPart2(IDictionary<Token, bool> endTokens, bool handleMathOperator = true, bool handleSingleExpression = false, bool enablePlugins = true)
        {
            Expression exp = null;
            bool hasPlugins = _context.Plugins.TotalExpressions > 0;
            bool hasLiteralBasedPlugins = _context.Plugins.HasLiteralTokenPlugins;
            bool hasTokenReplacePlugins = _context.Plugins.HasTokenBasedPlugins;

            // Build up a list of tokens
            // e.g. <const> <op> <var> <op> <var> <op> <const> ;
            //      21        <  age   &&   role  ==   "admin";
            while (true)
            {
                // CHECK_LIMITS: +1 because 0 based count
                _context.Limits.CheckParserExpression(_state.LastExpPart, _state.ExpressionCount + 1);
       
                // Break for loop
                if (IsEndOfExpressionPart(exp, endTokens) || _tokenIt.IsEnded)
                    break;

                var token = _tokenIt.NextToken.Token;
                var tokenData = _tokenIt.NextToken;

                // Token replacements                
                if (enablePlugins && hasTokenReplacePlugins && _context.Plugins.CanHandleTok(token))
                {
                    var plugin = _context.Plugins.GetTok(token);
                    token = plugin.Parse();
                    tokenData = _tokenIt.NextToken;
                    _tokenIt.NextToken.Token = token;
                }                

                // 1. Check for combinators.
                if (enablePlugins && hasPlugins && _context.Plugins.CanHandleExp(token))
                {
                    var combinator = _context.Plugins.GetExp(token);
                    exp = combinator.Parse();
                    exp.Ctx = _context;
                    _state.ExpressionCount++;
                }
                // 2. true / false / "name" / 123 / null;
                else if (token is LiteralToken)
                {
                    exp = token == Tokens.Null 
                        ? new ConstantExpression(LNull.Instance)
                        : new ConstantExpression(token.Value);
                    exp.Ctx = _context;
                    _state.ExpressionCount++;
                }                
                // 3. name / age / isActive
                else if (token is IdToken)
                {
                    exp = ParseIdExpression();
                    exp.Ctx = _context;
                    _state.ExpressionCount++;
                }
                // 4. [ Array
                else if (token == Tokens.LeftBracket)
                {
                    _state.ExpressionCount++;
                    exp = ParseArray();
                    var ahead = _tokenIt.Peek();
                    if (_tokenIt.NextToken.Token == Tokens.RightBracket && ahead.Token == Tokens.RightBracket)
                        _tokenIt.Advance();  
                }
                // 5. { Map
                else if (token == Tokens.LeftBrace)
                {
                    _state.ExpressionCount++;
                    exp = ParseMap();
                    // Prevent nested }} from breaking parsing.
                    var ahead = _tokenIt.Peek();
                    if (_tokenIt.NextToken.Token == Tokens.RightBrace && ahead.Token == Tokens.RightBrace)
                        _tokenIt.Advance();                 
                }
                // 6. new
                else if (token == Tokens.New)
                {
                    exp = ParseNewExpression();
                    exp.Ctx = _context;
                    _state.ExpressionCount++;
                }
                // 7. Not !
                else if (token == Tokens.LogicalNot)
                {
                    var op = Tokens.ToOp(token.Text);
                    _tokenIt.Advance();
                    var right = ParseExpressionPart2(endTokens);
                    exp = new UnaryExpression(string.Empty, right, op, _context);
                    SetScriptPosition(exp, tokenData);
                    exp.Ctx = _context;
                }
                // 8. Symbol ( * / + - < <= > >= == != && || )
                else if (token is SymbolToken && handleMathOperator)
                {
                    if(exp != null) SetScriptPosition(exp, tokenData);
                    exp = ParseExpressionsWithPrecedence(endTokens, exp);
                    exp.Ctx = _context;
                }
                // 9. Interpolated token "${first} name ${last} name".
                else if (token is InterpolatedToken)
                {
                    exp = ParseInterpolatedExpression((InterpolatedToken)token);
                    exp.Ctx = _context;
                    _state.ExpressionCount++;
                }
                else if (token is KeywordToken)
                {
                    throw _tokenIt.BuildSyntaxUnexpectedTokenException();
                }
                SetScriptPosition(exp, tokenData);
                
                // Break loop.
                if (IsEndOfExpressionPart(exp, endTokens) || handleSingleExpression || _tokenIt.IsEnded)
                    break;

                // Next token
                this._tokenIt.Advance();
            }
            return exp;
        }


        /// <summary>
        /// Parses an interpolated token into a set of tokens making up an interpolated expression.
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public Expression ParseInterpolatedExpression(InterpolatedToken t)
        {
            var iexp = new InterpolatedExpression();
            
            // Convert each token in the interpolated string, need to convert it into
            // it's own expression.
            foreach (var tokenData in t.Tokens)
            {
                var token = tokenData.Token;
                Expression exp = null;

                // 1. true / false / "name" / 123 / null;
                if (token is LiteralToken)
                {
                    exp = token == Tokens.Null
                        ? new ConstantExpression(LNull.Instance)
                        : new ConstantExpression(token.Value);
                    exp.Ctx = _context;
                    _state.ExpressionCount++;
                }
                // 2. ${first + 'abc'} or ${ result / 2 + max }
                else if (token is InterpolatedToken)
                {
                    var tokenIterator = new TokenIterator();
                    tokenIterator.Init(((InterpolatedToken)token).Tokens, 1, 100);
                    tokenIterator.Advance();
                    var exisiting = _tokenIt;

                    // a. Temporarily set the token iterator for the parser to the one for the interpolation.
                    _tokenIt = tokenIterator;

                    // b. Now parse only the tokens supplied.
                    exp = ParseExpressionPart2(null);

                    // c. Reset the token iterator to the global one for the entire script.
                    _tokenIt = exisiting;
                }
                iexp.Add(exp);                
            }
            return iexp;
        }


        /// <summary>
        /// This is an implementation of the Shunting Yard Algorithm to handle expressions
        /// with operator precedence.
        /// </summary>
        /// <param name="endTokens"></param>
        /// <param name="initial"></param>
        /// <returns></returns>
        private Expression ParseExpressionsWithPrecedence(IDictionary<Token, bool> endTokens, Expression initial)
        {
            Expression finalExp = null;
            var token = _tokenIt.NextToken.Token;
            var tokenData = _tokenIt.NextToken;
            List<TokenData> ops = new List<TokenData>();
            List<object> stack = new List<object>();
            if(initial != null) stack.Add(initial);
            int lastPrecendence = 0;
            int leftParenCount = 0;
            bool continueParsing = true;            

            while ((Terminators.ExpMathShuntingYard.ContainsKey(token) || continueParsing) && !_tokenIt.IsEnded)
            {
                int lastOpIndex = ops.Count - 1;
                TokenData lastOp = lastOpIndex < 0 ? null : ops[lastOpIndex];

                // Termination case 1: Avoid handling ) when doing math expressions inside a function call.
                // Termination case 2: Avoid handling ) of an if / while statement.
                // Termination case 3: End token - invalid script.
                if (token == Tokens.RightParenthesis && _state.IsInFunctionCall && leftParenCount == 0) break;
                if (token == Tokens.RightParenthesis && leftParenCount == 0) break;
                if (token == Token.EndToken) break;

                bool isOp = Tokens.IsOp(token.Text);
                // Expression.
                if( !isOp || token == Tokens.LogicalNot )
                {
                    // Must be followed by an expression.
                    var exp = ParseExpressionPart2(endTokens, false, true);
                    stack.Add(exp);
                    continueParsing = false;
                } 
                // Operator ( * / + - ( ) > >= < <= == != && || 
                else if(isOp)
                {
                    continueParsing = token != Tokens.RightParenthesis;
                    // Get precedence of the current operator token.
                    int precendence = Tokens.Precedence(token.Text);

                    // Need to always have the last precedence ( last op on the ops stack ).
                    if (ops.Count > 0) lastPrecendence = Tokens.Precedence(ops[ops.Count - 1].Token.Text);

                    // 1st op.
                    if (ops.Count == 0)
                    {
                        ops.Add(tokenData);
                        if (token == Tokens.LeftParenthesis) leftParenCount++;
                    }
                    // (
                    // This is the highest precedence.
                    else if (token == Tokens.LeftParenthesis)
                    {
                        ops.Add(tokenData);
                        leftParenCount++;
                    }
                    // Inside parenthesis ( last token "(" and current token is "+"
                    else if (lastOpIndex >= 0 && lastOp.Token == Tokens.LeftParenthesis)
                    {
                        ops.Add(tokenData);
                    }
                    // ) 
                    // 1. Make sure parenthesesis count match up.
                    // 2. Restructure the postfix ??
                    else if (token == Tokens.RightParenthesis)
                    {
                        // Invalid.
                        if (leftParenCount == 0) throw _tokenIt.BuildSyntaxExpectedTokenException(Tokens.LeftParenthesis.Text);

                        // Keep popping operators off the operator stack until "(" is hit.
                        // Then remove the ")"
                        int lastIndexToPop = ops.Count - 1;
                        bool foundParen = false;
                        while (lastIndexToPop >= 0)
                        {
                            if (ops[lastIndexToPop].Token == Tokens.LeftParenthesis)
                            {
                                foundParen = true;
                                break;
                            }
                            TokenData op = ops[lastIndexToPop];
                            ops.RemoveAt(lastIndexToPop);
                            stack.Add(op);
                            lastIndexToPop--;
                        }
                        if (!foundParen) throw _tokenIt.BuildSyntaxExpectedTokenException(Tokens.LeftParenthesis.Text);
                        // Get rid of "(" on the op stack.
                        ops.RemoveAt(lastIndexToPop);
                        leftParenCount--;
                    }
                    // * / higher than + -
                    // Add operator to postfix stack
                    else if (precendence > lastPrecendence)
                    {
                        //stack.Add(tokenData);
                        ops.Add(tokenData);
                    }
                    // * / have same precedence.
                    // 1. Move the previous op to postfix stack.
                    // 2. Add the current op to the ops stack.
                    else if (precendence <= lastPrecendence)
                    {
                        // * / have same precedence so add last from ops into stack.                    
                        TokenData op = ops[lastOpIndex];
                        ops.RemoveAt(lastOpIndex);
                        stack.Add(op);
                        ops.Add(tokenData);
                    }
                }         
                // Now move to next token.
                _tokenIt.Advance();                
                tokenData = _tokenIt.NextToken;
                token = _tokenIt.NextToken.Token;
            }

            // Last rule ops left ?
            if (ops.Count > 0)
                for(int ndx = ops.Count - 1; ndx >= 0; ndx--)
                    stack.Add(ops[ndx]);
            
            int index = 0;
            while (index < stack.Count && stack.Count > 0)
            {
                if (!(stack[index] is TokenData))
                {
                    index++;
                }
                else
                {
                    // Token
                    var left = stack[index - 2] as Expression;
                    var right = stack[index - 1] as Expression;
                    TokenData tdata = stack[index] as TokenData;
                    Token top = tdata.Token;
                    Operator op = Tokens.ToOp(top.Text);
                    Expression exp = null;

                    if (Tokens.IsMath(op))
                        exp = new BinaryExpression(left, op, right);
                    else if (Tokens.IsConditional(op))
                        exp = new ConditionExpression(left, op, right);
                    else if (Tokens.IsCompare(op))
                        exp = new CompareExpression(left, op, right);

                    exp.Ctx = _context;
                    SetScriptPosition(exp, tdata);
                    stack.RemoveRange(index - 2, 2);
                    index = index - 2;
                    stack[index] = exp;
                    index++;
                }
            }
            finalExp = stack[0] as Expression;
            return finalExp;
        }


        private bool IsEndOfExpressionPart(Expression lastExp, IDictionary<Token, bool> endTokens)
        {
            // End of script?
            if (_tokenIt.NextToken.Token == Token.EndToken) return true;

            // Need to peek.
            TokenData ahead = _tokenIt.Peek();
            if(ahead == null) return true;

            // In the Case 2 below, not end of expression as we need to "+" to it.
            // Case 1: inc(inc(1));  
            // Case 2: inc(inc() + 1);
            // Case 3: a[b[0]]
            // Case 4: { address: { city: 'ny' } }
            if (lastExp is FunctionCallExpression) return endTokens.ContainsKey(ahead.Token);
            if (lastExp is IndexExpression) return endTokens.ContainsKey(ahead.Token);

            // Case 5: For interpolated expressions.
            if (endTokens == null) return false;

            bool isend = endTokens.ContainsKey(_tokenIt.NextToken.Token);
            return isend;
        }


        /// <summary>
        /// [ "user01", true, false, 123, 45.6, 'company.com']
        /// </summary>
        /// <returns></returns>
        private Expression ParseArray()
        {
            _tokenIt.Expect(Tokens.LeftBracket);

            // list of each item in the array.
            var items = new List<Expression>();

            while (true)
            {
                // Stop when ] is hit
                if (IsEndOfStatementOrEndOfScript(Tokens.RightBracket))
                    break;

                // This is an empty item ',,'
                if (_tokenIt.NextToken.Token == Tokens.Comma)
                    items.Add(null);
                else 
                    items.Add(ParseExpressionPart(Terminators.ExpArrayDeclareEnd, false));

                // More items? 
                if (_tokenIt.NextToken.Token == Tokens.Comma)
                    _tokenIt.Advance();
            }
            
            return new DataTypeExpression(items);
        }


        /// <summary>
        /// { Name: "user01", IsActive: true, IsAdmin: false, Id: 123, Sales: 45.6, Company: 'company.com' }
        /// </summary>
        /// <returns></returns>
        private Expression ParseMap()
        {
            _tokenIt.Expect(Tokens.LeftBrace);

            // list of each item in the array.
            var items = new List<Tuple<string, Expression>>();

            while (true)
            {
                // Stop when } is hit
                if (IsEndOfStatementOrEndOfScript(Tokens.RightBrace))
                    break;

                // Check for error: Format must be <key> : <value>
                // Example 1: "Name" : "kishore" 
                // Example 2: Name   : "kishore"
                string key = string.Empty;
                if (!(_tokenIt.NextToken.Token is LiteralToken || _tokenIt.NextToken.Token is IdToken))
                {
                    throw _tokenIt.BuildSyntaxExpectedTokenException("Text based key for map");
                }
                // 1. Get key (text)
                key = _tokenIt.NextToken.Token.Text;
                _tokenIt.Advance();

                // 2. Expect ":"
                _tokenIt.Expect(Tokens.Colon);

                // 3. Get value (expression)
                var exp = ParseExpressionPart(Terminators.ExpMapDeclareEnd, false);
                items.Add(new Tuple<string, Expression>(key, exp));

                // More items? 
                if (_tokenIt.NextToken.Token == Tokens.Comma)
                    _tokenIt.Advance();
            }
            return new DataTypeExpression(items);
        }


        /// <summary>
        /// Parses function expression :
        /// 1. getAdminUser()
        /// 2. getUser(1)
        /// 3. getUserByNameOrEmail("user01", "kishore@company.com")
        /// </summary>
        /// <param name="nameExp">Expression representing the function name.</param>
        /// <returns></returns>
        private Expression ParseFuncExpression(Expression nameExp)
        {
            _tokenIt.Expect(Tokens.LeftParenthesis);
            var paramMap = new Dictionary<string, object>();
            var paramList = new List<Expression>();
            var funcExp = new FunctionCallExpression();
            funcExp.NameExp = nameExp;
            _state.FunctionCall++;
            _context.Limits.CheckParserFuncCallNested(_tokenIt.NextToken, _state.FunctionCall);

            ParseParameters(funcExp);
            _tokenIt.Expect(Tokens.RightParenthesis, false);
            funcExp.ParamMap = paramMap;
            funcExp.Ctx = _context;
            _state.FunctionCall--;

            return funcExp;
        }


        /// <summary>
        /// Handles the parsing of "new" expressions to create new instances of some object.
        /// </summary>
        /// <returns></returns>
        private Expression ParseNewExpression()
        {
            _tokenIt.Expect(Tokens.New);
            string typeName = _tokenIt.ExpectId();
            var exp = new NewExpression() { TypeName = typeName };
            _tokenIt.Expect(Tokens.LeftParenthesis);
            _state.FunctionCall++;
            ParseParameters(exp);
            _tokenIt.Expect(Tokens.RightParenthesis, _state.IsInFunctionCall);
            _state.FunctionCall--;
            return exp;
        }


        /// <summary>
        /// Parses an Id based expression:
        /// 1. user         : variable
        /// 2. getUser()    : function call
        /// 3. users[       : index expression
        /// 4. user.name    : member access
        /// 
        /// ASSIGNMENT:						EXPRESSION:						
        /// result = 2;						result					-> variableexpression				
        /// items[0] = 'kishore';			items[0]				-> indexexpression( variableexpression  | name)
        /// getuser();					    getuser()				-> functionexpression()
        /// user.age = 30;					user.age				-> memberexpression( variableexpression | name/member )
        /// items[0].name = 'kishore';		items[0].name			-> memberexpression( indexexpression( variableexpression ) )
        /// getuser()[0] = 0;				getuser()[0]			-> indexexpression( functionexpression )
        /// user.name.last = 'kishore';		user.name.last			-> memberexpression( memberexpression )
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Expression ParseIdExpression(string name = null)
        {
            Expression exp = null;
            var aheadToken = _tokenIt.Peek();
            var currentName = string.IsNullOrEmpty(name) ? _tokenIt.NextToken.Token.Text : name;
            
            // Case 1: array[0], functionName(), user.name
            exp = new VariableExpression(currentName);
            exp.Ctx = _context;
            int memberAccess = 0;

            while (aheadToken.Token == Tokens.LeftParenthesis || aheadToken.Token == Tokens.LeftBracket || aheadToken.Token == Tokens.Dot)
            {
                // Move to next token "[", "(", "."
                _tokenIt.Advance();

                // Case 2: "("- function call
                if (_tokenIt.NextToken.Token == Tokens.LeftParenthesis)
                {
                    exp = ParseFuncExpression(exp);
                    _tokenIt.Expect(Tokens.RightParenthesis, false);                    
                }

                // Case 3: "[" - indexing
                else if (_tokenIt.NextToken.Token == Tokens.LeftBracket)
                {
                    _tokenIt.Advance();
                    _state.IndexExp++;

                    // Get index exp ( n+1 ) or n, etc.
                    var index = ParseExpressionPart(Terminators.ExpBracketEnd);
                    _tokenIt.Expect(Tokens.RightBracket, false);

                    _state.IndexExp--;
                    // Note: if = sign then property access should return a property info.
                    // otherwise get the value of the property.
                    bool isAssignment = _tokenIt.Peek().Token == Tokens.Assignment;                    
                    exp = new IndexExpression(exp, index, isAssignment);
                }
            
                // Case 4: "." - member access
                else if (_tokenIt.NextToken.Token == Tokens.Dot)
                {
                    _tokenIt.Advance();
                    var member = _tokenIt.ExpectId(false);

                    // Note: if = sign then property access should return a property info.
                    // otherwise get the value of the property.
                    bool isAssignment = _tokenIt.Peek().Token == Tokens.Assignment;
                    exp = new MemberAccessExpression(exp, member, isAssignment);
                }
                exp.Ctx = _context;
                memberAccess++;

                // Check limit.
                _context.Limits.CheckParserMemberAccess(exp, memberAccess);

                aheadToken = _tokenIt.Peek();                
            }
            return exp;
        }
        #endregion


        private ConditionalBlockStatement ParseConditionalStatement(ConditionalBlockStatement stmt, string textToEndCondition = "then")
        {
            if (stmt == null) stmt = new ConditionalBlockStatement(null, null);

            // Case 1: if ( <expression> ) 
            // Case 2: if   <expression> then
            bool hasParenthesis = _tokenIt.NextToken.Token == Tokens.LeftParenthesis;
            var terminator = hasParenthesis ? Terminators.ExpParenthesisEnd : Terminators.ExpThenEnd;

            if( hasParenthesis ) 
                _tokenIt.Expect(Tokens.LeftParenthesis);

            _state.Conditional++;
            
            var condition = ParseExpression(terminator);

            if (hasParenthesis)
                _tokenIt.Expect(Tokens.RightParenthesis);
            else
                _tokenIt.Expect(Tokens.Then);

            stmt.Condition = condition;
            stmt.Ctx = _context;
            _state.Conditional--;

            // Parse the block of statements.
            ParseBlock(stmt);
            return stmt;
        }


        /// <summary>
        /// Parses arguments.
        /// </summary>
        /// <param name="pexp"></param>
        /// <param name="endToken">Optional token to represent the end token.</param>
        public void ParseParameters(IParameterExpression pexp, Token endToken = null)
        {
            if (endToken == null)
                endToken = Tokens.RightParenthesis;

            int totalParameters = 0;
            while (true)
            {
                // Check for end of statment or invalid end of script.
                if (IsEndOfStatementOrEndOfScript(endToken))
                    break;

                if (_tokenIt.NextToken.Token == Tokens.Comma)
                {
                    _tokenIt.Advance();
                }

                var exp = ParseExpression(Terminators.ExpFuncExpEnd, true);
                pexp.ParamListExpressions.Add(exp);

                totalParameters++;

                _context.Limits.CheckParserFunctionParams(exp, totalParameters);

                // Case 1: adduser( getuser(1), "kishore");
                //         The ")" from getuser will be interpreted as ")" for "adduser"
                if (exp is FunctionCallExpression && _tokenIt.NextToken.Token == Tokens.RightParenthesis)
                    _tokenIt.Advance();

                // Check for end of statment or invalid end of script.
                if (IsEndOfStatementOrEndOfScript(endToken))
                    break;

                // Go to next token.
                _tokenIt.Advance();                
            }
        }
    }
}
