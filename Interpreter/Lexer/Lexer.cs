using System;
using Interpreter.Tokens;
using System.Collections.Generic;
using System.Text;
using System.Reflection.Metadata.Ecma335;

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
            Token next;

            SkipWhiteSpace();

            switch (Ch)
            {
                case '=':
                    next = new Token(Token.ASSIGN, Ch.ToString());
                    break;
                case ';':
                    next = new Token(Token.SEMICOLON, Ch.ToString());
                    break;
                case '(':
                    next = new Token(Token.LPAREN, Ch.ToString());
                    break;
                case ')':
                    next = new Token(Token.RPAREN, Ch.ToString());
                    break;
                case ',':
                    next = new Token(Token.COMMA, Ch.ToString());
                    break;
                case '+':
                    next = new Token(Token.PLUS, Ch.ToString());
                    break;
                case '{':
                    next = new Token(Token.LBRACE, Ch.ToString());
                    break;
                case '}':
                    next = new Token(Token.RBRACE, Ch.ToString());
                    break;
                case '\0':
                    next = new Token(Token.EOF, '\0'.ToString());
                    break;

                default:
                    if (IsLetter(Ch))
                    {
                        string literal = ReadIdentifier();
                        string type = Token.LookupIdentifier(literal);
                        next = new Token(type, literal);
                        return next;
                    } 
                    else if (IsDigit(Ch))
                    {
                        string type = Token.INT;
                        string literal = ReadNumber();
                        next = new Token(type, literal);
                        return next; 
                    }
                    else
                    {
                        next = new Token(Token.ILLEGAL, Ch.ToString());
                    }

                    break;
            }

            ReadChar();

            return next;
        }

        #region Private Methods

        private bool IsLetter(char ch)
        {
            bool isLetter = ('a' <= ch && ch >= 'z') || ('A' <= ch && ch >= 'Z') || ch == '_';

            return isLetter;
        }

        private string ReadIdentifier()
        {
            int start = Position;

            while (IsLetter(Ch))
                ReadChar();

            int length = Position - start;

            return Input.Substring(start, length);
        }

        private bool IsDigit(char ch)
        {
            bool isDigit = char.IsDigit(ch);

            return isDigit;
        }

        private string ReadNumber()
        {
            int start = Position;

            while (IsDigit(Ch)) 
                ReadChar();

            int length = Position - start;

            return Input.Substring(start, length);
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

        /* <summary>
           If whitespace, advance to next character. A whitespace is set of following characters.
            ' '      space 
            '\t'     horizontal tab 
            '\n'     newline
            '\v'     vertical tab 
            '\f'     feed 
            '\r'     carriage return 
        </summary> */
        private void SkipWhiteSpace()
        {
            while (char.IsWhiteSpace(Ch))
                ReadChar();
        }

        #endregion
    }
}
