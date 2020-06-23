using Interpreter.Lexer;
using Interpreter.Tokens;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace InterpreterTest
{
    [TestClass]
    public class LexerTest
    {
        [TestMethod]
        public void SimpleTest()
        {
            string input = "=+(){},;";

            var expectedTokens = new List<Token>
            {
                new Token() { Type = Token.ASSIGN, Literal = "=" },
                new Token() { Type = Token.PLUS, Literal = "+" },
                new Token() { Type = Token.LPAREN, Literal = "(" },
                new Token() { Type = Token.RPAREN, Literal = ")" },
                new Token() { Type = Token.LBRACE, Literal = "{" },
                new Token() { Type = Token.RBRACE, Literal = "}" },
                new Token() { Type = Token.COMMA, Literal = "," },
                new Token() { Type = Token.SEMICOLON, Literal = ";" },
            };

            var lexer = new Lexer(input);

            foreach (var expToken in expectedTokens)
            {
                Token token = lexer.NextToken();

                Assert.AreEqual(expToken.Type, token.Type);
                Assert.AreEqual(expToken.Literal, token.Literal);
            }
        }


        [TestMethod]
        public void SourceTest()
        {
            string input = @"let five = 5;
let ten = 10;

let add = fn(x, y) {
    x + y;
};

let result = add(five, ten);
";
            var expectedTokens = new List<Token>
            {
                new Token (Token.LET, "let"),
                new Token (Token.IDENT, "five"),
                new Token (Token.ASSIGN, "="),
                new Token (Token.INT, "5"),
                new Token (Token.SEMICOLON, ";"),

                new Token (Token.LET, "let"),
                new Token (Token.IDENT, "ten"),
                new Token (Token.ASSIGN, "="),
                new Token (Token.INT, "10"),
                new Token (Token.SEMICOLON, ";"),

                new Token (Token.LET, "let"),
                new Token (Token.IDENT, "add"),
                new Token (Token.ASSIGN, "="),
                new Token (Token.FUNCTION, "fn"),
                new Token (Token.LPAREN, "("),
                new Token (Token.IDENT, "x"),
                new Token (Token.COMMA, ","),
                new Token (Token.IDENT, "y"),
                new Token (Token.RPAREN, ")"),
                new Token (Token.LBRACE, "{"),

                new Token (Token.IDENT, "x"),
                new Token (Token.PLUS, "+"),
                new Token (Token.IDENT, "y"),
                new Token (Token.SEMICOLON, ";"),
                new Token (Token.RBRACE, "}"),
                new Token (Token.SEMICOLON, ";"),

                new Token (Token.LET, "let"),
                new Token (Token.IDENT, "result"),
                new Token (Token.ASSIGN, "="),
                new Token (Token.IDENT, "add"),
                new Token (Token.LPAREN, "("),
                new Token (Token.IDENT, "five"),
                new Token (Token.COMMA, ","),
                new Token (Token.IDENT, "ten"),
                new Token (Token.RPAREN, ")"),
                new Token (Token.SEMICOLON, ";"),
                new Token (Token.EOF, "\0")
            };
            
            var lexer = new Lexer(input);

            foreach (var expToken in expectedTokens)
            {
                Token token = lexer.NextToken();
                if (token == null)
                {

                }

                Assert.AreEqual(expToken.Type, token.Type);
                Assert.AreEqual(expToken.Literal, token.Literal);
            }
        }
    }
}
