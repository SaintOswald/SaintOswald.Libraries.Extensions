﻿/***********************************************************************************
 *
 * Saint Oswald: Libraries - Extensions
 *
 * Copyright (c) 2015, Saint Oswald
 *
 ***********************************************************************************
 *
 * LICENSED UNDER THE MIT LICENSE
 * SEE LICENSE FILE IN THE PROJECT ROOT FOR LICENSE INFORMATION
 *
 ***********************************************************************************/

using System;

namespace SaintOswald.Libraries.Extensions.DateTimeExtensions
{
    /// <summary>
    /// Adds Extension Methods to DateTime to provide useful, reusable functionality
    /// </summary>
    public static class DateTimeExtensions
    {
        /// <summary>
        /// Checks if the specified DateTime value is earlier than the given comparison date and time
        /// </summary>
        /// <param name="dateTime">The DateTime value to check</param>
        /// <param name="comparison">
        /// The comparison to check if the specified DateTime value is earlier than
        /// </param>
        /// <returns>
        /// True if the specified DateTime value is earlier than the given comparison, otherwise returns false
        /// </returns>
        public static bool IsEarlierThan(this DateTime dateTime, DateTime comparison) => (dateTime < comparison);
    }
}