using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using ComLib.Lang;


namespace ComLib.Lang.Extensions
{

    /* *************************************************************************
    <doc:example>	
    // Fluent plugin allows methods to be called in different ways instead of the 
    // typicall <class>.<method>( <arg1> ,<arg2 etc )
   
    // Supported ways of calling methods:
    // 1. <method> <class> .
    // 2. <method> <class> <arg1> <arg2> .
    // 3. <class>  <arg1>  <method> .
    // 4. <method> <class> <arg1_name> : <arg1_value>, <arg2_name> : <arg2_value> .
    // 5. <method> <class> <arg1>, 
    
    // Examples
    activate user         
    delete file "c:\temp.txt".
    file "c:\temp.txt" exists.
    run program "msbuild.exe", solution: 'comlib.sln', mode: "debug", style: "rebuild all".
    
    // The above calls translate to:
    // 1. user.activate();
    // 2. File.Delete("c:\temp.txt");
    // 3. File.Exists("c:\temp.txt")
    // 4. Program.Run("msbuild.exe", solution: "comlib.sln', mode: "debug", style: "rebuild all");
    </doc:example>
    ***************************************************************************/

    /// <summary>
    /// Combinator for handles method/function calls in a more fluent way.
    /// </summary>
    class FluentPlugin : ExpressionPlugin
    {
        private static string[] _tokens = new string[] { "$IdToken" };
        private bool _enableMethodPartMatching;

        /// <summary>
        /// Initialize.
        /// </summary>
        public FluentPlugin() : this( false)
        {
        }


        /// <summary>
        /// Initialize.
        /// </summary>
        public FluentPlugin(bool enableMethodPartMatching)
        {
            _precedence = 2;
            _hasStatementSupport = true;
            _enableMethodPartMatching = enableMethodPartMatching;
        }


        /// <summary>
        /// The tokens that are supported for this combinator.
        /// </summary>
        public override string[] ExpressionTokens
        {
            get { return _tokens; }
        }


        /// <summary>
        /// This can not handle all idtoken based expressions.
        /// Only expressions with idtoken followed by idtoken.
        /// e.g.
        /// OK:
        ///     - delete file "c:\temp.txt".
        ///     - file delete "c:\temp.txt".
        /// NOT OK:
        ///     - file.delete("c:\temp.txt");
        ///     - delete("c:\temp.txt");
        /// </summary>
        /// <param name="current"></param>
        /// <returns></returns>
        public override bool CanHandle(Token current)
        {
            if (!(current is IdToken)) return false;

            // 1. activate user                 =>  idtoken idtoken         => user.activate();
            // 2. delete file 'c:\temp.txt'     =>  idtoken idtoken         => file.delete('c:\temp.txt');
            // 3. if file 'c:\temp.txt' exists  =>  idtoken <arg1> idtoken  => if file.exists('c:\temp.txt')
            var next = _tokenIt.Peek();
            if (next.Token == Tokens.Dot || next.Token == Tokens.LeftParenthesis) return false;
            if (next.Token is SymbolToken) return false;

            return true;
        }


        /* ****************************************************************************************
         * The following syntax can be supported via this Fluent expression combinator
         * 
         * 1. activate user.         
         * 2. move file "c:\temp.txt".
         * 3. file "c:\temp.txt" exists.
         * 3. run program "msbuild.exe", solution: 'comlib.sln', mode: "debug", style: "rebuild all".
         * 
         * 1. <method> <class> .
         * 2. <method> <class> <arg1> <arg2> .
         * 3. <class>  <arg1>  <method> .
         * 3. <method> <class> <arg1>, <arg1_name> : <arg1_value>, <arg2_name> : <arg2_value> .
         * 
        ***************************************************************************************** */
        /// <summary>
        /// Parses the fluent expression.
        /// </summary>
        /// <returns></returns>
        public override Expression Parse()
        {
            // - object method param
            // - method object param
            
            // 1. Get the class method names.
            // Name1 could be class name or method name. We don't know at this point.
            // other than the fact it is a method call.
            Expression name1 = ParseCallPart();
            string name1Name = _tokenIt.ExpectId(true);
            Expression name2 = null;
            Expression name3 = null;

            // Case 1: updateusers      => updateusers();
            if( _tokenIt.NextToken.Token == Tokens.Semicolon )
                return new FluentCallExpression(name1, null, null, null);

            // Case 2: activate user
            name2 = ParseCallPart();
            var n = _tokenIt.Peek();
            if (n.Token == Tokens.Semicolon)
            {
                _tokenIt.Advance();
                return new FluentCallExpression(name1, name2, null, null);
            }

            // Case 3: delete file tempFile;
            //         delete file "c:\temp.txt";
            _tokenIt.Advance();
            name3 = ParseCallPart();
            n = _tokenIt.Peek();
            if (n.Token == Tokens.Semicolon)
            {
                _tokenIt.Advance();
                return new FluentCallExpression(name1, name2, name3, null);
            }

            List<Expression> args = null;
            var fc = new FluentCallExpression(name1, name2, name3, args);

            if (n.Token == Tokens.Comma)
            {
                _parser.ParseParameters(fc, Tokens.Semicolon);
            }
            fc.EnableMethodPartMatching = _enableMethodPartMatching;
            return fc;
        }


        private Expression ParseCallPart()
        {
            Expression part = null;
            if (_tokenIt.NextToken.Token is IdToken)
                part = new VariableExpression(_tokenIt.NextToken.Token.Text);

            else if (_tokenIt.NextToken.Token is LiteralToken)
                part = new ConstantExpression(_tokenIt.NextToken.Token.Text);

            _parser.SetScriptPosition(part, _tokenIt.NextToken);
            return part;
        }
    }



    /// <summary>
    /// A fluent method call expression.
    /// </summary>
    public class FluentCallExpression : Expression, IParameterExpression
    {
        private string _name1;
        private Expression _name1Exp;
        private Expression _name2;
        private Expression _name3;
        private List<Expression> _args;
        private bool _enableMethodPartMatching = false;

        /// <summary>
        /// Initialize
        /// </summary>
        /// <param name="name1">First function call part, must be either class / method name.</param>
        /// <param name="name2">2nd function call part, could be either argument or class / method name</param>
        /// <param name="name3">3rd function call part, could be either argument or class / method name</param>
        /// <param name="args"></param>
        public FluentCallExpression(Expression name1, Expression name2, Expression name3, List<Expression> args)
        {
            _name1Exp = name1;
            _name1 = ((VariableExpression)name1).Name;
            _name2 = name2;
            _name3 = name3;
            _args = args;
        }


        /// <summary>
        /// List of expressions.
        /// </summary>
        public List<Expression> ParamListExpressions { get; set; }


        /// <summary>
        /// List of arguments.
        /// </summary>
        public List<object> ParamList { get; set; }


        /// <summary>
        /// Whether or not the try matching method parts.
        /// </summary>
        public bool EnableMethodPartMatching { get { return _enableMethodPartMatching; } set { _enableMethodPartMatching = value; } }
        

        /// <summary>
        /// Evaluate
        /// </summary>
        /// <returns></returns>
        public override object Evaluate()
        {
            _name1Exp.Ctx = this.Ctx;
            if(_name2 != null) _name2.Ctx = this.Ctx;
            if(_name3 != null) _name3.Ctx = this.Ctx;

            FunctionCallExpression fce = BuildFunctionCall();
            fce.Ctx = this.Ctx;
            fce.Ref = this.Ref;
            fce.Scope = this.Ctx.Scope;
            if (this.ParamListExpressions != null && this.ParamListExpressions.Count > 0)
            {
                foreach (var exp in this.ParamListExpressions)
                    fce.ParamListExpressions.Add(exp);
            }

            if (fce.NameExp != null)
            {
                fce.NameExp.Ctx = this.Ctx;
                fce.NameExp.Ref = this.Ref;
                fce.Scope = this.Ctx.Scope;
            }

            var result = fce.Evaluate();
            return result;
        }


        /*
         *  Case 1. func                                        notify
         *  Case 2. func parameter                              notify      'group1'         
         *  Case 3. func parameter parameter			        print 	    'kishore' 			'reddy'
         *  Case 4. class  method 		                        user  	    IsRegisteredFor 	
         *  Case 5. method class  		                        activate    user
         *  Case 6. class parameter method                      user        'kreddy'            exists
         *  Case 7. method parameter class			            activate    'admin'		        Role
         *  Case 8. class methodPart methodPart [parameter]     notify	    user				of elections
         *  Case 9. methodPart class methodPart [parameter]	    notify 	    user				of elections 'nystate'
        */
        private FunctionCallExpression BuildFunctionCall()
        {
            FunctionCallExpression fce = new FunctionCallExpression();
            bool has2ndName = _name2 != null;
            bool has3rdName = _name3 != null;
            string methodName = "";

            // Case 1, 2, 3: activate 'kreddy';
            if (Ctx.Functions.Contains(_name1) || Ctx.ExternalFunctions.Contains(_name1))
            {
                fce.Name = _name1;
                if(_name2 != null ) fce.ParamListExpressions.Add(_name2);
                if (_name3 != null) fce.ParamListExpressions.Add(_name3);
                return fce;
            }
            
            // Case 4: class method    => User Deleteall
            if (has2ndName && IsClassMember(_name1, _name2, ref methodName))
            {
                fce.NameExp = new MemberAccessExpression(_name1Exp, methodName, false);
                if (_name3 != null) fce.ParamListExpressions.Add(_name3);
                return fce;
            }

            // Case 5: method class    => Activate User
            if (has2ndName && IsClassMember(_name2, _name1, ref methodName))
            {
                fce.NameExp = new MemberAccessExpression(_name2, methodName, false);
                if (_name3 != null) fce.ParamListExpressions.Add(_name3);
                return fce;
            }            

            // Case 6: class parameter method
            if (has3rdName && IsClassMember(_name1, _name3, ref methodName))
            {
                fce.NameExp = new MemberAccessExpression(_name1Exp, methodName, false);
                fce.ParamListExpressions.Add(_name2);
                return fce;
            }

            // Case 7: method parameter class
            if (has3rdName && IsClassMember(_name3, _name1, ref methodName))
            {
                fce.NameExp = new MemberAccessExpression(_name3, methodName, false);
                fce.ParamListExpressions.Add(_name2);
                return fce;
            }

            if (_name2 is VariableExpression && _name3 is VariableExpression && _enableMethodPartMatching)
            {
                // Case 8: class methodpart methodpart  e.g. if user has been notified
                string methodpart = ((VariableExpression)_name2).Name + ((VariableExpression)_name3).Name;

                // maximum 4 method parts. 
                var result = CanMatchMethod(_name1, methodpart, 2);
                if (result.Success)
                {
                    fce.NameExp = new MemberAccessExpression(_name1Exp, result.Item, false);
                }

                // Case 9: method class method method
                methodpart = _name1 + ((VariableExpression)_name3).Name;
                string classOrInstance = ((VariableExpression)_name2).Name;
                // maximum 4 method parts. 
                result = CanMatchMethod(classOrInstance, methodpart, 2);

                if (result.Success)
                {
                    fce.NameExp = new MemberAccessExpression(_name2, result.Item, false);
                }
            }
            else
                throw new LangException("syntax", "Unknown action/method call", Ref.ScriptName, Ref.LineNumber, Ref.CharPosition);

            return fce;
        }


        private bool IsClassMember(string classNameOrInstanceVar, Expression memberExp, ref string methodName)
        {
            if (!(memberExp is VariableExpression)) return false;
            if (!Ctx.Types.Contains(classNameOrInstanceVar) && !Ctx.Scope.Contains(classNameOrInstanceVar)) 
                return false;

            var memberName = ((VariableExpression)memberExp).Name;
            var obj = Ctx.Scope.Get<object>(classNameOrInstanceVar);

            // Check member.
            var type = obj.GetType();
            var members = type.GetMember(memberName, BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance | BindingFlags.IgnoreCase);
            if (members != null && members.Length > 0)
            {
                methodName = members[0].Name;
                return true;
            }

            return false;
        }


        private bool IsClassMember(Expression classNameOrInstanceVar, string memberName, ref string methodName)
        {
            if (!(classNameOrInstanceVar is VariableExpression)) return false;
            string classNameOrInstanceName = ((VariableExpression)classNameOrInstanceVar).Name;
            if (!Ctx.Types.Contains(classNameOrInstanceName) && !Ctx.Scope.Contains(classNameOrInstanceName)) 
                return false;

            var obj = Ctx.Scope.Get<object>(classNameOrInstanceName);

            // Check member.
            var type = obj.GetType();
            var members = type.GetMember(memberName, BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance | BindingFlags.IgnoreCase);
            if (members != null && members.Length > 0)
            {
                methodName = members[0].Name;
                return true;
            }

            return false;
        }


        private bool IsClassMember(string classNameOrInstanceName, string memberName, ref string methodName)
        {
            if (!Ctx.Types.Contains(classNameOrInstanceName) && !Ctx.Scope.Contains(classNameOrInstanceName)) 
                return false;

            var obj = Ctx.Scope.Get<object>(classNameOrInstanceName);

            // Check member.
            var type = obj.GetType();
            var members = type.GetMember(memberName, BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance | BindingFlags.IgnoreCase);
            if (members != null && members.Length > 0)
            {
                methodName = members[0].Name;
                return true;
            }
            return false;
        }


        private BoolMessageItem<string> CanMatchMethod(string classNameOrInstanceVar, string methodPartStart, int maxParameterToCheckAsMethodParts)
        {
            string methodName = "";
            if (IsClassMember(classNameOrInstanceVar, methodPartStart, ref methodName))
                return new BoolMessageItem<string>(methodName, true, string.Empty);

            if (ParamListExpressions == null || ParamListExpressions.Count == 0)
                return new BoolMessageItem<string>(methodName, false, string.Empty);

            bool found = false;
            int indexOfLastMethodPart = 0;

            // Check matching method parts.
            for (int ndx = 0; ndx < maxParameterToCheckAsMethodParts; ndx++)
            {
                var exp = ParamListExpressions[ndx] as VariableExpression;
                if (exp == null)
                    break;

                methodPartStart += exp.Name;
                if (IsClassMember(classNameOrInstanceVar, methodPartStart, ref methodName))
                {
                    found = true;
                    methodPartStart = methodName;
                    indexOfLastMethodPart = ndx;
                    break;
                }
            }
            if (!found) return new BoolMessageItem<string>(methodPartStart, false, string.Empty);

            // Trim the parameters.
            ParamListExpressions.RemoveRange(0, indexOfLastMethodPart + 1);
            return new BoolMessageItem<string>(methodPartStart, true, string.Empty);
        }
    }
}
