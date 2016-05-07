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

using System.IO;
using SaintOswald.Libraries.Extensions.LongExtensions;

namespace SaintOswald.Libraries.Extensions.FileInfoExtensions
{
    /// <summary>
    /// Adds Extension Methods to FileInfo to provide useful, reusable functionality
    /// </summary>
    public static class FileInfoExtensions
    {
        /// <summary>
        /// Returns the file length in human readable file size format
        /// </summary>
        /// <returns>
        /// The file length formatted as a human readable file size string
        /// </returns>
        public static string LengthFormatted(this FileInfo file)
        {
            return file.Length.ToFileSize();
        }
    }
}