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
using System.Text;
using System.Globalization;
using System.ComponentModel;
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
            if (str.IsNullOrEmpty()) { return str; }

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
            if (str.IsNullOrEmpty()) { return str; }

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
                throw new ArgumentException("Maximum length cannot be less than 3", nameof(maximumLength));
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
        /// <param name="comparisonType">
        /// The String Comparison Type to use (optional - defaults to StringComparison.Ordinal)
        /// </param>
        /// <returns>
        /// Returns everything before the first occurrence of the specified delimiter if it exists
        /// within the given string, otherwise returns null
        /// </returns>
        /// <exception cref="System.ArgumentException">
        /// Thrown when the specified delimiter is null or empty
        /// </exception>
        public static string EverythingBeforeFirst(this string str, string delimiter, StringComparison comparisonType = StringComparison.Ordinal)
        {
            if (delimiter.IsNullOrEmpty())
            {
                throw new ArgumentException("Delimiter cannot be null or empty", nameof(delimiter));
            }

            if (str.IsNullOrEmpty()) { return null; }

            int position = str.IndexOf(delimiter, comparisonType);
            return (position <= 0) ? null : str.Substring(0, position);
        }

        /// <summary>
        /// Returns everything after the last occurrence of the specified delimiter
        /// </summary>
        /// <param name="str">
        /// The string to return everything after the last occurrence of the delimiter for
        /// </param>
        /// <param name="delimiter">The delimiter to return everything after</param>
        /// <param name="comparisonType">
        /// The String Comparison Type to use (optional - defaults to StringComparison.Ordinal)
        /// </param>
        /// <returns>
        /// Returns everything after the last occurrence of the specified delimiter if it exists
        /// within the given string, otherwise returns null
        /// </returns>
        /// <exception cref="System.ArgumentException">
        /// Thrown when the specified delimiter is null or empty
        /// </exception>
        public static string EverythingAfterLast(this string str, string delimiter, StringComparison comparisonType = StringComparison.Ordinal)
        {
            if (delimiter.IsNullOrEmpty())
            {
                throw new ArgumentException("Delimiter cannot be null or empty", nameof(delimiter));
            }

            if (str.IsNullOrEmpty()) { return null; }

            int position = str.LastIndexOf(delimiter, comparisonType);
            return (position == -1 || position == str.Length - 1) ? null : str.Substring(position + delimiter.Length);
        }

        /// <summary>
        /// Returns the string value or the specified alternative if the string value is null, empty
        /// or white space
        /// </summary>
        /// <param name="str">The string to return either the value or the alternative for</param>
        /// <param name="alternative">
        /// The alternative value to return if the string value is null, empty or white space
        /// </param>
        /// <returns>
        /// The string value or the specified alternative if the string value is null, empty
        /// or white space
        /// </returns>
        public static string ValueOr(this string str, string alternative)
        {
            return (str.IsNullOrWhiteSpace()) ? alternative : str;
        }

        /// <summary>
        /// Returns the plural form of the specified string when the given count is less than or equal to 0
        /// or greater than 1.  The plural form is obtained by adding "s" to the specified string or by
        /// returning the given plural form when specified.  If the specified count is 1 the original string
        /// value is returned
        /// </summary>
        /// <param name="str">The string to return the plural form for</param>
        /// <param name="count">
        /// The count to determine if the plural or singular form of the specified string should be returned
        /// </param>
        /// <param name="pluralForm">The plural form to return for the given string (optional)</param>
        /// <returns>
        /// Returns either the specified string plus "s" or the optional specified plural form if the given
        /// count is less than or equal to 0 or greater than 1.  If the count is 1 then the original string
        /// value is returned
        /// </returns>
        /// <exception cref="System.ArgumentException">
        /// Thrown when plural form has been specified but is empty or white space
        /// </exception>
        public static string ToPluralForCount(this string str, int count, string pluralForm = null)
        {
            if (pluralForm != null && pluralForm.IsNullOrWhiteSpace())
            {
                throw new ArgumentException("Plural form cannot be empty or white space", nameof(pluralForm));
            }

            if (str.IsNullOrEmpty()) { return str; }

            return (count <= 0 || count > 1) ? (pluralForm ?? str + "s") : str;
        }

        /// <summary>
        /// Converts the specified string to title case by capitalising the first letter of each word
        /// using the culture of the current thread.  Words entirely in uppercase are treated as
        /// acronyms and not modified
        /// </summary>
        /// <param name="str">The string to convert to title case</param>
        /// <returns>The specified string converted to title case</returns>
        public static string ToTitleCase(this string str)
        {
            return (str.IsNullOrEmpty() ? str : CultureInfo.CurrentCulture.TextInfo.ToTitleCase(str));
        }

        /// <summary>
        /// /// Returns the specified string value repeated for the given number of repetitions
        /// </summary>
        /// <param name="str">The string value to repeat</param>
        /// <param name="repetitions">
        /// The number of repetitions to repeat the string for - must be at least 2
        /// </param>
        /// <returns>The specified string repeated for the given number of repetitions</returns>
        /// <exception cref="System.ArgumentException">
        /// Thrown when the specified repetitions is less than 2
        /// </exception>
        public static string Repeat(this string str, int repetitions)
        {
            if(repetitions < 2)
            {
                throw new ArgumentException("Repetitions cannot be less than 2", nameof(repetitions));
            }

            if (str.IsNullOrEmpty()) { return str; }

            return new StringBuilder().Insert(0, str, repetitions).ToString();
        }

        /// <summary>
        /// Attempts to parse the specified string value to the given type
        /// </summary>
        /// <typeparam name="T">The type to attempt to parse the string value to</typeparam>
        /// <param name="str">The string value to attempt to parse to the specified type</param>
        /// <returns>The string value parsed to the specified type</returns>
        /// <exception cref="System.ArgumentException">
        /// Thrown when the specified string value cannot be parsed to the given type
        /// </exception>
        public static T TryParseTo<T>(this string str)
        {
            Type typeToParseTo = typeof(T);
            TypeConverter typeConverter = TypeDescriptor.GetConverter(typeToParseTo);

            if(typeConverter != null && typeConverter.IsValid(str))
            {
                return (T)typeConverter.ConvertFromString(str);
            }
            else
            {
                throw new ArgumentException($"String '{str}' cannot be converted to type '{typeToParseTo}'", nameof(str));
            }
        }

        /// <summary>
        /// Attempts to remove diacritics from the specified string.  For example, an accented French
        /// character like "á" should be replaced with "a"
        /// </summary>
        /// <param name="str">The string to attempt to remove diacritics from</param>
        /// <returns>The string with diacritics removed</returns>
        /// <seealso cref="http://stackoverflow.com/questions/249087/how-do-i-remove-diacritics-accents-from-a-string-in-net/249126#249126"/>
        public static string RemoveDiacritics(this string str)
        {
            if (str.IsNullOrWhiteSpace()) { return str; }

            StringBuilder builder = new StringBuilder();

            foreach (char character in str.Normalize(NormalizationForm.FormD))
            {
                if(CharUnicodeInfo.GetUnicodeCategory(character) != UnicodeCategory.NonSpacingMark)
                {
                    builder.Append(character);
                }
            }

            return builder.ToString().Normalize(NormalizationForm.FormC);
        }
    }
}