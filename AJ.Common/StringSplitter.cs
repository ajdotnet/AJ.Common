// Source: https://github.com/ajdotnet/AJ.Common
using System;
using System.Collections.Generic;
using System.Linq;

namespace AJ.Common
{
    /// <summary>
    /// worker class; implements the logic for <see cref="StringSplitExtensions"/>.
    /// </summary>
    static class StringSplitter
    {
        public static IEnumerable<string> Split(string text, char[] separator, int count, StringSplitOptions options)
        {
            Guard.AssertCondition(count >= 0, "count", "count cannot be negative!");

            Func<string, int, int> getMatchLength;
            if ((separator == null) || (separator.Length == 0))
                getMatchLength = (text1, index1) => GetWhiteSpaceMatchLength(text1, index1);
            else
                getMatchLength = (text1, index1) => GetCharMatchLength(text1, index1, separator);

            return Split(text, getMatchLength, count, options);
        }

        public static IEnumerable<string> Split(string text, string[] separator, int count, StringSplitOptions options)
        {
            Guard.AssertCondition(count >= 0, "count", "count cannot be negative!");

            Func<string, int, int> getMatchLength;
            if ((separator == null) || (separator.Length == 0))
                getMatchLength = (text1, index1) => GetWhiteSpaceMatchLength(text1, index1);
            else
                getMatchLength = (text1, index1) => GetStringMatchLength(text1, index1, separator);

            return Split(text, getMatchLength, count, options);
        }

        static IEnumerable<string> Split(string text, Func<string, int, int> getMatchLength, int count, StringSplitOptions options)
        {
            bool removeEmpty = (options == StringSplitOptions.RemoveEmptyEntries);

            // *** special cases
            if (text == null)
                yield break;
            if (count < 1)
                yield break;
            if (text == string.Empty)
            {
                if (!removeEmpty)
                    yield return string.Empty;
                yield break;
            }
            if (count == 1)
            {
                yield return text;
                yield break;
            }

            // *** loop over input text
            int startIndex = 0;
            string part;
            int matchLength;
            int currentCount = 0;
            // todo: while-schleife
            for (int textIndex = 0; textIndex < text.Length; ++textIndex)
            {
                // loop until separator is found
                matchLength = getMatchLength(text, textIndex);
                if (matchLength == 0)
                    continue;

                if (startIndex == textIndex)
                {
                    // two seperators followed immediately each other
                    if (!removeEmpty)
                    {
                        yield return string.Empty;
                        ++currentCount;
                    }
                }
                else
                {
                    // return sub string
                    part = text.Substring(startIndex, textIndex - startIndex);
                    yield return part;
                    ++currentCount;
                }

                startIndex = textIndex + matchLength; // matchLength off to skip whitespace/delimiter
                textIndex += matchLength - 1; // skip separator (1 off because of ++ in for)
                if (currentCount >= count - 1) // 1 off, because of the remaining text
                    break;
            }

            // *** process remaining text
            if (startIndex == text.Length)
            {
                if (!removeEmpty)
                    yield return string.Empty;
            }
            if (startIndex < text.Length)
            {
                part = text.Substring(startIndex);
                yield return part;
            }
        }

        private static int GetWhiteSpaceMatchLength(string text, int index)
        {
            return char.IsWhiteSpace(text[index]) ? 1 : 0;
        }

        private static int GetCharMatchLength(string text, int index, char[] separator)
        {
            return separator.Contains(text[index]) ? 1 : 0;
        }

        private static int GetStringMatchLength(string text, int startIndex, string[] separator)
        {
            foreach (string sep in separator)
            {
                if (string.IsNullOrEmpty(sep))
                    continue;
                if (string.CompareOrdinal(text, startIndex, sep, 0, sep.Length) == 0)
                    return sep.Length;
            }
            return 0;
        }
    }
}
