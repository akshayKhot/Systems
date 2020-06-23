using System;
using System.Collections.Generic;
using System.Text;

namespace Interpreter.Tokens
{
    public class Token
    {
        #region Constants

        public const string ILLEGAL = "ILLEGAL";
		public const string EOF = "EOF";

		// Identifiers + Literals
		public const string IDENT = "IDENT";
		public const string INT   = "INT";

		// Operators
		public const string ASSIGN = "=";
		public const string PLUS   = "+";

		// Delimiters
		public const string COMMA     = ",";
		public const string SEMICOLON = ";";
		public const string LPAREN    = "(";
		public const string RPAREN    = ")";
		public const string LBRACE    = "{";
		public const string RBRACE = "}";

		// Keywords
		public const string FUNCTION = "FUNCTION";
		public const string LET = "LET";

		#endregion

		private static readonly Dictionary<string, string> keywords = new Dictionary<string, string>() 
		{
			{ "fn", FUNCTION },
			{ "let", LET }
		};

		public Token() { }

		public Token(string type, string literal)
		{
			Type = type;
			Literal = literal;
		}

		public string Type { get; set; }

        public string Literal { get; set; }

		// Check if the given identifier is a keyword.
		// If yes, then return the keyword's constant
		// Otherwise, return IDENT, which is for all user-defined ids, such as five or ten. 
		public static string LookupIdentifier(string id)
        {
			if (keywords.ContainsKey(id))
            {
				return keywords[id];
            }

			return IDENT;
        }
    }
}
