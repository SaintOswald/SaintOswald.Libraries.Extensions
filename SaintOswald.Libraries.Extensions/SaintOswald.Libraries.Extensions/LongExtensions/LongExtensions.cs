/***********************************************************************************
 *
 * Saint Oswald: Libraries - Extensions
 *
 * Copyright (c) 2015 - 2016, Saint Oswald
 *
 ***********************************************************************************
 *
 * LICENSED UNDER THE MIT LICENSE
 * SEE LICENSE FILE IN THE PROJECT ROOT FOR LICENSE INFORMATION
 *
 ***********************************************************************************/

using System;

namespace SaintOswald.Libraries.Extensions.LongExtensions
{
    /// <summary>
    /// Adds Extension Methods to long to provide useful, reusable functionality
    /// </summary>
    public static class LongExtensions
    {
        /// <summary>
        /// Converts the specified byte value to human readable file size format
        /// </summary>
        /// <param name="bytes">The byte value to convert</param>
        /// <param name="decimals">The number of decimal places in the formatted value</param>
        /// <returns>
        /// The specified byte value formatted as a human readable file size string
        /// </returns>
        /// <exception cref="System.ArgumentOutOfRangeException">
        /// Thrown when the specified decimals value is less than 1 or greater than 28
        /// </exception>
        public static string ToFileSize(this long bytes, int decimals = 2)
        {
            if (decimals < 1 || decimals > 28)
            {
                throw new ArgumentOutOfRangeException(nameof(decimals), "Decimals must be at least 1 and no bigger than 28");
            }

            if (bytes >= 1099511627776)
            {
                return Math.Round(((decimal)bytes / 1024 / 1024 / 1024 / 1024), decimals) + " TB";
            }
            else if (bytes >= 1073741824)
            {
                return Math.Round(((decimal)bytes / 1024 / 1024 / 1024), decimals) + " GB";
            }
            else if (bytes >= 1048576)
            {
                return Math.Round(((decimal)bytes / 1024 / 1024), decimals) + " MB";
            }
            else if (bytes >= 1024)
            {
                return Math.Round(((decimal)bytes / 1024), decimals) + " KB";
            }
            else
            {
                return bytes + (bytes == 1 ? " byte" : " bytes");
            }
        }
    }
}