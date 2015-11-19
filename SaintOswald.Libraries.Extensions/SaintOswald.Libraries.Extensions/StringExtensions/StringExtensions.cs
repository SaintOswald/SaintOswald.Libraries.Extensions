/***********************************************************************************
 *
 * Saint Oswald: Libraries - Extensions
 *
 * Copyright (c) 2015, Saint Oswald
 *
 ***********************************************************************************
 *
 * LICENSED UNDER THE MIT LICENSE
 * SEE LICENSE.TXT IN THE PROJECT ROOT FOR LICENSE INFORMATION
 *
 ***********************************************************************************/

using System;
using System.Text.RegularExpressions;

namespace SaintOswald.Libraries.Extensions.StringExtensions
{
    /// <summary>
    /// Adds Extension Methods to string to provide useful, reusable functionality
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Checks if the specified string is null or empty
        /// </summary>
        /// <param name="str">The string to check</param>
        /// <returns>True if the specified string is null or empty, otherwise returns false</returns>
        /// <seealso cref="System.String.IsNullOrEmpty(string)"/>
        public static bool IsNullOrEmpty(this string str) => string.IsNullOrEmpty(str);

        /// <summary>
        /// Checks if the specified string is null or white space
        /// </summary>
        /// <param name="str">The string to check</param>
        /// <returns>True if the specified string is null or whitespace, otherwise returns false</returns>
        /// <seealso cref="System.String.IsNullOrWhiteSpace(string)"/>
        public static bool IsNullOrWhiteSpace(this string str) => string.IsNullOrWhiteSpace(str);

        /// <summary>
        /// Trims trailing white space and punctuation characters from the specified string
        /// </summary>
        /// <param name="str">The string to trim</param>
        /// <returns>
        /// The specified string with trailing white space and punctuation characters removed
        /// </returns>
        public static string TrimEndWhiteSpaceAndPunctuation(this string str)
        {
            return Regex.Replace(str, @"[\W_]+$", "");
        }

        /// <summary>
        /// Trims leading white space and punctuation characters from the specified string
        /// </summary>
        /// <param name="str">The string to trim</param>
        /// <returns>
        /// The specified string with leading white space and punctuation characters removed
        /// </returns>
        public static string TrimStartWhiteSpaceAndPunctuation(this string str)
        {
            return Regex.Replace(str, @"^[\W_]+", "");
        }

        /// <summary>
        /// Truncates the specified string to the given maximum length.  The string will be returned
        /// as-is if it's length is shorter than or equal to the maximum length.  A truncated string
        /// will be suffixed with "..." and the truncated string plus the suffix will be no longer
        /// than the maximum length.  Trailing punctuation and white space will be removed from
        /// truncated strings
        /// </summary>
        /// <param name="str">The string to truncate</param>
        /// <param name="maximumLength">
        /// The maximum length of the truncated string - must be at least 3
        /// </param>
        /// <returns>The truncated string</returns>
        /// <exception cref="System.ArgumentException">
        /// Thrown when the specified maximum length is less than 3
        /// </exception>
        public static string Truncate(this string str, int maximumLength)
        {
            if (maximumLength < 3)
            {
                throw new ArgumentException("Truncate maximum length cannot be less than 3", nameof(maximumLength));
            }

            if (str.IsNullOrEmpty() || str.Length <= maximumLength) { return str; }

            return str.Substring(0, maximumLength - 3).TrimEndWhiteSpaceAndPunctuation() + "...";
        }

        /// <summary>
        /// Collapses white space in the specified string by replacing all non-space white space
        /// characters with a space (i.e. " ").  Replaces consecutive spaces with a single space
        /// and trims leading and trailing spaces
        /// </summary>
        /// <param name="str">The string to collapse white space for</param>
        /// <returns>The specified string with white space collapsed</returns>
        public static string CollapseWhiteSpace(this string str)
        {
            if (str.IsNullOrEmpty()) { return str; }

            // Replace all non-space white space characters with a single space
            string normalised = Regex.Replace(str, @"[^\S ]", " ");

            // Remove consecutive spaces
            return Regex.Replace(normalised, " {2,}", " ").Trim();
        }

        /// <summary>
        /// Returns everything before the first occurrence of the specified delimiter
        /// </summary>
        /// <param name="str">
        /// The string to return everything before the first occurrence of the specified delimiter for
        /// </param>
        /// <param name="delimiter">The delimiter to return everything before</param>
        /// <param name="culture">
        /// The String Comparison culture to use (optional - defaults to StringComparison.Ordinal)
        /// </param>
        /// <returns>
        /// Returns everything before the first occurrence of the specified delimiter if it exists
        /// within the given string, otherwise returns null
        /// </returns>
        /// <exception cref="System.ArgumentException">
        /// Thrown when the specified delimiter is null or empty
        /// </exception>
        public static string EverythingBeforeFirst(this string str, string delimiter, StringComparison culture = StringComparison.Ordinal)
        {
            if (delimiter.IsNullOrEmpty())
            {
                throw new ArgumentException("Delimiter cannot be null or empty", nameof(delimiter));
            }

            if (str.IsNullOrEmpty()) { return null; }

            int position = str.IndexOf(delimiter, culture);
            return (position <= 0) ? null : str.Substring(0, position);
        }

        /// <summary>
        /// Returns everything after the last occurrence of the specified delimiter
        /// </summary>
        /// <param name="str">
        /// The string to return everything after the last occurrence of the delimiter for
        /// </param>
        /// <param name="delimiter">The delimiter to return everything after</param>
        /// <param name="culture">
        /// The String Comparison culture to use (optional - defaults to StringComparison.Ordinal)
        /// </param>
        /// <returns>
        /// Returns everything after the last occurrence of the specified delimiter if it exists
        /// within the given string, otherwise returns null
        /// </returns>
        /// <exception cref="System.ArgumentException">
        /// Thrown when the specified delimiter is null or empty
        /// </exception>
        public static string EverythingAfterLast(this string str, string delimiter, StringComparison culture = StringComparison.Ordinal)
        {
            if (delimiter.IsNullOrEmpty())
            {
                throw new ArgumentException("Delimiter cannot be null or empty", nameof(delimiter));
            }

            if (str.IsNullOrEmpty()) { return null; }

            int position = str.LastIndexOf(delimiter, culture);
            return (position == -1 || position == str.Length - 1) ? null : str.Substring(position + delimiter.Length);
        }
    }
}