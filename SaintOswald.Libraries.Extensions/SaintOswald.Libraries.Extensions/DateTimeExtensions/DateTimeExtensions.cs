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

        /// <summary>
        /// Checks if the specified DateTime value is today's date
        /// </summary>
        /// <param name="dateTime">The DateTime value to check</param>
        /// <returns>
        /// True if the specified DateTime value is today's date, otherwise returns false
        /// </returns>
        public static bool IsToday(this DateTime dateTime) => (dateTime.Date == DateTime.Today);

        /// <summary>
        /// Checks if the specified DateTime value is yesterday's date
        /// </summary>
        /// <param name="dateTime">The DateTime value to check</param>
        /// <returns>
        /// True if the specified DateTime value is yesterday's date, otherwise returns false
        /// </returns>
        public static bool IsYesterday(this DateTime dateTime) => (dateTime.Date == DateTime.Today.AddDays(-1));

        /// <summary>
        /// Checks if the specified DateTime value is tomorrow's date
        /// </summary>
        /// <param name="dateTime">The DateTime value to check</param>
        /// <returns>
        /// True if the specified DateTime value is tomorrow's date, otherwise returns false
        /// </returns>
        public static bool IsTomorrow(this DateTime dateTime) => (dateTime.Date == DateTime.Today.AddDays(1));

        /// <summary>
        /// Checks if the specified DateTime value is in the future
        /// </summary>
        /// <param name="dateTime">The DateTime value to check</param>
        /// <returns>
        /// True if the specified DateTime value is in the future, otherwise returns false
        /// </returns>
        public static bool IsInFuture(this DateTime dateTime) => (dateTime.IsLaterThan(DateTime.Now));

        /// <summary>
        /// Checks if the specified DateTime value is in the past
        /// </summary>
        /// <param name="dateTime">The DateTime value to check</param>
        /// <returns>
        /// True if the specified DateTime value is in the past, otherwise returns false
        /// </returns>
        public static bool IsInPast(this DateTime dateTime) => (dateTime.IsEarlierThan(DateTime.Now));

        /// <summary>
        /// Checks if the specified DateTime value is between the start and end comparison date and times
        /// </summary>
        /// <param name="dateTime">The DateTime value to check</param>
        /// <param name="startComparison">
        /// The start comparison to check if the specified DateTime value is between
        /// </param>
        /// <param name="endComparison">
        /// The end comparison to check if the specified DateTime value is between
        /// </param>
        /// <returns>
        /// True if the specified DateTime value is between the given start and end comparisons, otherwise
        /// returns false
        /// </returns>
        public static bool IsBetween(this DateTime dateTime, DateTime startComparison, DateTime endComparison) => (dateTime >= startComparison && dateTime <= endComparison);
    }
}