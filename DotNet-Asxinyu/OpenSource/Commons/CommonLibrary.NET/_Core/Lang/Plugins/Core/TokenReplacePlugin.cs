using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ComLib.Lang;


namespace ComLib.Lang.Extensions
{
    
    /// <summary>
    /// Plugin for replacing tokens.
    /// </summary>
    public class TokenReplacePlugin : TokenPlugin
    {
        private string _replacementToken;
        private bool _matched;
        private int _matchedAdvanceCount;


        /// <summary>
        /// The maximum number of tokens that can be looked ahead for potential replacements.
        /// </summary>
        protected int _maxLookAhead = 4;

        
        /// <summary>
        /// List of replacement word to their values.
        /// </summary>
        protected string[,] _replacements;


        /// <summary>
        /// A map of the replacement words to their value.
        /// </summary>
        protected Dictionary<string, string> _replaceMap;


        /// <summary>
        /// Replacement map for single words.
        /// </summary>
        protected Dictionary<string, string> _replaceMapSingleWord;


        private const string Partial_Replacement = "partial replacement";
        

        /// <summary>
        /// Initialize
        /// </summary>
        public TokenReplacePlugin()
        {
        }


        /// <summary>
        /// Initialize multi-token replacements.
        /// </summary>
        /// <param name="replacements">The 2 dimension string array of text to their replacement values.</param>
        /// <param name="maxTokenLookAhead">The maximum tokens to look ahead for to seach for matching phrases.</param>
        public void Init(string[,] replacements, int maxTokenLookAhead)
        {
            _maxLookAhead = maxTokenLookAhead;
            _replacements = replacements;
            _replaceMap = new Dictionary<string, string>();
            _replaceMapSingleWord = new Dictionary<string, string>();
            for(int ndx = 0; ndx < replacements.GetLength(0); ndx++)
            {
                string tokenToReplace = (string)replacements.GetValue(ndx, 0);
                string replaceVal = (string)replacements.GetValue(ndx, 1);
                bool hasSpace = tokenToReplace.Contains(" ");
                bool mapHasToken = _replaceMap.ContainsKey(tokenToReplace);
                
                // Single word replacements "before" = "<"
                if (!hasSpace)
                {
                    _replaceMapSingleWord[tokenToReplace] = replaceVal;
                    continue;
                }

                // Multi-word replacements. "less than" = "<" "less than equal to" = "<="
                string[] tokens = tokenToReplace.Split(' ');
                string multiTokenWord = tokens[0];
                _replaceMap[multiTokenWord] = Partial_Replacement;

                for(int ndx2 = 1; ndx2 < tokens.Length; ndx2++)
                {
                    multiTokenWord += " " + tokens[ndx2];
                    bool isLastToken = ndx2 == tokens.Length - 1;

                    // 1. "less than" with "<"
                    // 2. "less than equal" "<="
                    bool replacementExists = _replaceMap.ContainsKey(multiTokenWord);
                    if ( !replacementExists && !isLastToken)                    
                        _replaceMap[multiTokenWord] = Partial_Replacement;
                    if ( isLastToken)
                        _replaceMap[multiTokenWord] = replaceVal;
                }
            }
        }


        /// <summary>
        /// Whether or not this can handle the token.
        /// </summary>
        /// <param name="current"></param>
        /// <returns></returns>
        public override bool CanHandle(Token current)
        {
            var t = _tokenIt.NextToken.Token;
            _matchedAdvanceCount = 1;
            int advanceCount = 1;
            string multiTokenWord = t.Text;
            _replacementToken = null;

            // Case 1: Check if single word replacement.
            if(IsSingleWordMatch(multiTokenWord))
            {
                 _matched = true;
                 _replacementToken = _replaceMapSingleWord[multiTokenWord];
                 return true;
            }

            // Case 2: Multi token replacement check:
            // Keep looking up to max look ahead times.
            while (advanceCount <= _maxLookAhead && !_tokenIt.IsEnded)
            {
                string multiTokenWordPeek = multiTokenWord + " " + _tokenIt.Peek(advanceCount).Token.Text;

                if (_replaceMap.ContainsKey(multiTokenWord))
                {
                    var replacement = _replaceMap[multiTokenWord];
                    var isNextWordApplicable = _replaceMap.ContainsKey(multiTokenWordPeek);

                    // Actual value to replace
                    if (!isNextWordApplicable && replacement != Partial_Replacement)
                    {
                        _replacementToken = replacement;
                        _matched = true;
                        _matchedAdvanceCount = advanceCount;
                    }
                }

                var token = _tokenIt.Peek(advanceCount);
                t = token.Token;
                advanceCount++;
                multiTokenWord += " " + t.Text;                                
            }
            return _matched;
        }


        
        /// <summary>
        /// run step 123.
        /// </summary>
        /// <returns></returns>
        public override Token Parse()
        {
            if (_matched && _matchedAdvanceCount > 1)
            {
                _tokenIt.Advance(_matchedAdvanceCount - 1);
            }
            var token = ComLib.Lang.Tokens.AllTokens[_replacementToken];            
            return token;
        }


        private bool IsSingleWordMatch(string multiTokenWord)
        {
            if (!_replaceMapSingleWord.ContainsKey(multiTokenWord)) return false;
            
            var token = _tokenIt.Peek();
            string combined = multiTokenWord + " " + token.Token.Text;
            if (!_replaceMap.ContainsKey(combined))
                return true;

            return false;
        }
    }
}
