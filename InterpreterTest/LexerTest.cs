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
        public void NextTokenTest()
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

            foreach(var expToken in expectedTokens)
            {
                Token token = lexer.NextToken();

                Assert.AreEqual(expToken.Type, token.Type);
                Assert.AreEqual(expToken.Literal, token.Literal);
            }
        }
    }
}
