using System;
using System.Collections.Generic;
using System.Text;

namespace OldPhonePadApp
{
    public static class OldPhonePad
    {
        private static readonly Dictionary<char, string> KeyMappings = new()
        {
            { '1', "" },
            { '2', "ABC" },
            { '3', "DEF" },
            { '4', "GHI" },
            { '5', "JKL" },
            { '6', "MNO" },
            { '7', "PQRS" },
            { '8', "TUV" },
            { '9', "WXYZ" },
            { '0', " " }
        };

        public static string Decode(string input)
        {
            if (string.IsNullOrWhiteSpace(input) || input[^1] != '#')
                throw new ArgumentException("Input must end with '#'.");

            var result = new StringBuilder();
            var buffer = new StringBuilder();
            char previous = '\0';

            foreach (char ch in input)
            {
                if (ch == '#')
                {
                    ProcessBuffer(buffer, result);
                    break;
                }

                if (ch == '*')
                {
                    ProcessBuffer(buffer, result);
                    if (result.Length > 0)
                        result.Length--;
                }
                else if (ch == ' ')
                {
                    ProcessBuffer(buffer, result);
                }
                else if (char.IsDigit(ch))
                {
                    if (buffer.Length == 0 || ch == previous)
                        buffer.Append(ch);
                    else
                    {
                        ProcessBuffer(buffer, result);
                        buffer.Append(ch);
                    }
                }

                previous = ch;
            }

            return result.ToString();
        }

        private static void ProcessBuffer(StringBuilder buffer, StringBuilder result)
        {
            if (buffer.Length == 0) return;

            char key = buffer[0];
            if (KeyMappings.TryGetValue(key, out string letters) && letters.Length > 0)
            {
                int index = (buffer.Length - 1) % letters.Length;
                result.Append(letters[index]);
            }

            buffer.Clear();
        }
    }
}
