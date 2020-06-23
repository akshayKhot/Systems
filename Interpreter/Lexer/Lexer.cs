using System;
using Interpreter.Tokens;
using System.Collections.Generic;
using System.Text;

namespace Interpreter.Lexer
{
    public class Lexer
    {
        public string Input { get; set; }

        // Current position in input
        // Points to current character (Ch)
        public int Position { get; set; }

        // Next reading position in input
        // Points to next character
        public int ReadPosition { get; set; }
        
        // Current character under examination
        // Pointed by Position
        public char Ch { get; set; }

        public Lexer(string input)
        {
            Input = input;
            ReadChar();
        }

        public Token NextToken()
        {
            Token next = null;

            switch (Ch)
            {
                case '=':
                    next = new Token(Token.ASSIGN, Ch);
                    break;
                case ';':
                    next = new Token(Token.SEMICOLON, Ch);
                    break;
                case '(':
                    next = new Token(Token.LPAREN, Ch);
                    break;
                case ')':
                    next = new Token(Token.RPAREN, Ch);
                    break;
                case ',':
                    next = new Token(Token.COMMA, Ch);
                    break;
                case '+':
                    next = new Token(Token.PLUS, Ch);
                    break;
                case '{':
                    next = new Token(Token.LBRACE, Ch);
                    break;
                case '}':
                    next = new Token(Token.RBRACE, Ch);
                    break;
                case '\0':
                    next = new Token(Token.EOF, '\0');
                    break;

                default:
                    break;
            }

            ReadChar();

            return next;
        }

        private void ReadChar()
        {
            // if next reading position exceeds the length
            // set the character to 0, otherwise advance
            if (ReadPosition >= Input.Length)
            {
                Ch = '\0';
            }
            else
            {
                Ch = Input[ReadPosition];
            }
             
            Position = ReadPosition;
            ReadPosition++;
        }

    }
}
