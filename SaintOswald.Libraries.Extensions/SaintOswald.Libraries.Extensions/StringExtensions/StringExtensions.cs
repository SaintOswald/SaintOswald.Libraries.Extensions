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
        public static bool IsNullOrEmpty(this string str) => string.IsNullOrEmpty(str);
    }
}