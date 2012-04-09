using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComLib.Lang
{
    /// <summary>
    /// Interface for the language parser. This is reused for combinators and the core parser.
    /// </summary>
    public interface ILangParser
    {
        /// <summary>
        /// The token iterator.
        /// </summary>
        TokenIterator TokenIt { get; }

    }



    /// <summary>
    /// Marker interface for any type of plugin.
    /// </summary>
    public interface ILangPlugin
    {
        /// <summary>
        /// Whether or not this parser can handle the supplied token.
        /// </summary>
        /// <param name="current"></param>
        /// <returns></returns>
        bool CanHandle(Token current);
    }



    /// <summary>
    /// Interface for a plugin at the lexing level.
    /// </summary>
    public interface ILexPlugin : ILangPlugin
    {
        /// <summary>
        /// The lexer.
        /// </summary>
        Lexer Lexer { get; set; }


        /// <summary>
        /// Initialize the combinator.
        /// </summary>
        /// <param name="lexer">The main lexer</param>
        void Init(Lexer lexer);


        /// <summary>
        /// The tokens that are associated w/ this combinator.
        /// </summary>
        string[] Tokens { get; }


        /// <summary>
        /// Parses the expression.
        /// </summary>
        /// <returns></returns>
        Token[] Parse();
    }



    /// <summary>
    /// Interface for plugin that handles token after lexical analysis but before parsing of expressions.
    /// </summary>
    public interface ITokenPlugin : ILangPlugin
    {
        /// <summary>
        /// Initialize the combinator.
        /// </summary>
        /// <param name="parser">The core parser</param>
        /// <param name="tokenIt">The token iterator</param>
        void Init(Parser parser, TokenIterator tokenIt);


        /// <summary>
        /// The tokens that are associated w/ this combinator.
        /// </summary>
        string[] Tokens { get; }


        /// <summary>
        /// Parses the expression.
        /// </summary>
        /// <returns></returns>
        Token Parse();
    }



    /// <summary>
    /// Interface for a plugin at the parser/expression level.
    /// </summary>
    public interface IExpressionPlugin: ILangParser, ILangPlugin
    {
        /// <summary>
        /// Initialize the combinator.
        /// </summary>
        /// <param name="parser"></param>
        /// <param name="tokenIt"></param>
        void Init(Parser parser, TokenIterator tokenIt);


        /// <summary>
        /// Used for ordering of plugins.
        /// </summary>
        int Precedence { get; }


        /// <summary>
        /// Whether or not this combinator can be made into a statement.
        /// </summary>
        bool HasStatementSupport { get; }


        /// <summary>
        /// Whether or not to handle a new line as end of expression/statement.
        /// </summary>
        bool IsNewLineEndOfExpression { get; }


        /// <summary>
        /// The tokens starting the expression.
        /// </summary>
        string[] ExpressionTokens { get; }
       
       
        /// <summary>
        /// Parses an expression
        /// </summary>
        /// <returns></returns>
        Expression Parse();
    }
}
