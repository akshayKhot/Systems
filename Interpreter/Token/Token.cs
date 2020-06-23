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

		public Token() { }

        public Token(string type, char literal)
        {
			Type = type;
			Literal = literal.ToString();
        }

        public string Type { get; set; }

        public string Literal { get; set; }
    }
}
