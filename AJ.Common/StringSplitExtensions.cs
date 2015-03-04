using System;
using System.Collections.Generic;

namespace AJ.Common
{
    /// <summary>
    ///   <para>
    /// Exposes extension methods string.SplitString(...) that replace string.Split(...) with implementations
    /// based on enumeration. The implementation is more efficient in terms of memory consumption.
    ///   </para>
    ///   <para>
    /// See https://ajdotnet.wordpress.com/2010/09/04/the-cost-of-string-split/ for background.
    ///   </para>
    /// </summary>
    public static class StringSplitExtensions
    {
        /// <summary>
        /// Returns a string array that contains the substrings in this instance that are delimited by
        /// elements of a specified Unicode character array.
        /// </summary>
        /// <param name="text">The text to be split.</param>
        /// <param name="separator">The characters used as separators.</param>
        /// <returns></returns>
        public static IEnumerable<string> SplitString(this string text, params char[] separator)
        {
            return StringSplitter.Split(text, separator, int.MaxValue, StringSplitOptions.None);
        }

        /// <summary>
        /// Returns a string array that contains the substrings in this instance that are delimited by
        /// elements of a specified Unicode character array. A parameter specifies the maximum number of
        /// substrings to return.
        /// </summary>
        /// <param name="text">The text to be split.</param>
        /// <param name="separator">The characters used as separators.</param>
        /// <param name="count">The count of returned strings; the last string will contain the un-split remainder.</param>
        /// <returns></returns>
        public static IEnumerable<string> SplitString(this string text, char[] separator, int count)
        {
            return StringSplitter.Split(text, separator, count, StringSplitOptions.None);
        }

        /// <summary>
        /// Returns a string array that contains the substrings in this string that are delimited by
        /// elements of a specified Unicode character array. A parameter specifies whether to return
        /// empty array elements.
        /// </summary>
        /// <param name="text">The text to be split.</param>
        /// <param name="separator">The characters used as separators.</param>
        /// <param name="options">Options to control the process.</param>
        /// <returns></returns>
        public static IEnumerable<string> SplitString(this string text, char[] separator, StringSplitOptions options)
        {
            return StringSplitter.Split(text, separator, int.MaxValue, options);
        }

        /// <summary>
        /// Returns a string array that contains the substrings in this string that are delimited by
        /// elements of a specified Unicode character array. Parameters specify the maximum number of
        /// substrings to return and whether to return empty array elements.
        /// </summary>
        /// <param name="text">The text to be split.</param>
        /// <param name="separator">The characters used as separators.</param>
        /// <param name="count">The count.</param>
        /// <param name="options">Options to control the process.</param>
        /// <returns></returns>
        public static IEnumerable<string> SplitString(this string text, char[] separator, int count, StringSplitOptions options)
        {
            return StringSplitter.Split(text, separator, count, options);
        }

        /// <summary>
        /// Returns a string array that contains the substrings in this string that are delimited by
        /// elements of a specified string array. A parameter specifies whether to return empty array
        /// elements.
        /// </summary>
        /// <param name="text">The text to be split.</param>
        /// <param name="separator">Strings used as separators.</param>
        /// <param name="options">Options to control the process.</param>
        /// <returns></returns>
        public static IEnumerable<string> SplitString(this string text, string[] separator, StringSplitOptions options)
        {
            return StringSplitter.Split(text, separator, int.MaxValue, options);
        }

        /// <summary>
        /// Returns a string array that contains the substrings in this string that are delimited by
        /// elements of a specified string array. Parameters specify the maximum number of substrings
        /// to return and whether to return empty array elements.
        /// </summary>
        /// <param name="text">The text to be split.</param>
        /// <param name="separator">Strings used as separators.</param>
        /// <param name="count">The count of returned strings; the last string will contain the un-split remainder.</param>
        /// <param name="options">Options to control the process.</param>
        /// <returns></returns>
        public static IEnumerable<string> SplitString(this string text, string[] separator, int count, StringSplitOptions options)
        {
            return StringSplitter.Split(text, separator, count, options);
        }
    }
}
