﻿/***********************************************************************************
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

        /// <summary>
        /// Checks if the specified DateTime value is later than the given comparison date and time
        /// </summary>
        /// <param name="dateTime">The DateTime value to check</param>
        /// <param name="comparison">
        /// The comparison to check if the specified DateTime value is later than
        /// </param>
        /// <returns>
        /// True if the specified DateTime value is later than the given comparison, otherwise returns false
        /// </returns>
        public static bool IsLaterThan(this DateTime dateTime, DateTime comparison) => (dateTime > comparison);

        /// <summary>
        /// Checks if the specified DateTime value is the same as the given comparison date and time
        /// </summary>
        /// <param name="dateTime">The DateTime value to check</param>
        /// <param name="comparison">
        /// The comparison to check if the specified DateTime value is the same as
        /// </param>
        /// <returns>
        /// True if the specified DateTime value is the same as the given comparison, otherwise returns false
        /// </returns>
        public static bool IsSameAs(this DateTime dateTime, DateTime comparison) => (dateTime == comparison);

        /// <summary>
        /// Checks if the specified DateTime value is the same date (i.e. year, month and day) as the given
        /// comparison date and time
        /// </summary>
        /// <param name="dateTime">The DateTime value to check</param>
        /// <param name="comparison">
        /// The comparison to check if the specified DateTime value is the same date as
        /// </param>
        /// <returns>
        /// True if the specified DateTime value is the same date as the given comparison, otherwise returns false
        /// </returns>
        public static bool IsSameDateAs(this DateTime dateTime, DateTime comparison) => (dateTime.Date == comparison.Date);

        /// <summary>
        /// Checks if the specified DateTime value is the same time (i.e. hour, minute and second) as the given
        /// comparison date and time
        /// </summary>
        /// <param name="dateTime">The DateTime value to check</param>
        /// <param name="comparison">
        /// The comparison to check if the specified DateTime value is the same time as
        /// </param>
        /// <returns>
        /// True if the specified DateTime value is the same time as the given comparison, otherwise returns false
        /// </returns>
        public static bool IsSameTimeAs(this DateTime dateTime, DateTime comparison) => (dateTime.TimeOfDay == comparison.TimeOfDay);

        /// <summary>
        /// Checks if the specified DateTime value is a weekend (i.e. a Saturday or Sunday).  Note: Method is not
        /// culture aware and defines a weekend day as a Saturday or Sunday only
        /// </summary>
        /// <param name="dateTime">The DateTime value to check</param>
        /// <returns>
        /// True if the specified DateTime value is a weekend, otherwise returns false
        /// </returns>
        public static bool IsWeekend(this DateTime dateTime) => (dateTime.DayOfWeek == DayOfWeek.Saturday || dateTime.DayOfWeek == DayOfWeek.Sunday);

        /// <summary>
        /// Checks if the specified DateTime value is a weekday (i.e. not a Saturday or Sunday).  Note: Method is not
        /// culture aware and only defines a weekday as any day that is not a Saturday or Sunday
        /// </summary>
        /// <param name="dateTime">The DateTime value to check</param>
        /// <returns>
        /// True if the specified DateTime value is a weekday, otherwise returns false
        /// </returns>
        public static bool IsWeekday(this DateTime dateTime) => (!dateTime.IsWeekend());
    }
}