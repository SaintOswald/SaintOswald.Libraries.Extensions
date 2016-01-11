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
        public static bool IsSameTimeAs(this DateTime dateTime, DateTime comparison)
            => (dateTime.TimeOfDay == comparison.TimeOfDay);

        /// <summary>
        /// Checks if the specified DateTime value is a weekend (i.e. a Saturday or Sunday).  Note: Method is not
        /// culture aware and defines a weekend day as a Saturday or Sunday only
        /// </summary>
        /// <param name="dateTime">The DateTime value to check</param>
        /// <returns>
        /// True if the specified DateTime value is a weekend, otherwise returns false
        /// </returns>
        public static bool IsWeekend(this DateTime dateTime)
            => (dateTime.DayOfWeek == DayOfWeek.Saturday || dateTime.DayOfWeek == DayOfWeek.Sunday);

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
        public static bool IsBetween(this DateTime dateTime, DateTime startComparison, DateTime endComparison)
            => (dateTime >= startComparison && dateTime <= endComparison);

        /// <summary>
        /// Checks if the specified DateTime value is the anniversary (i.e. the same month and day but
        /// at least one year later) of the comparison date and time
        /// </summary>
        /// <param name="dateTime">The DateTime value to check</param>
        /// <param name="comparison">
        /// The comparison to check if the specified DateTime value is the anniversary of
        /// </param>
        /// <returns>
        /// True if the specified DateTime value is the anniversary of the given comparison, otherwise
        /// returns false
        /// </returns>
        public static bool IsAnniversaryOf(this DateTime dateTime, DateTime comparison)
            => (dateTime.Year > comparison.Year
                            && dateTime.Month == comparison.Month
                            && dateTime.Day == comparison.Day);

        /// <summary>
        /// Returns a new DateTime instance representing the first day of the month for the specified
        /// DateTime value
        /// </summary>
        /// <param name="dateTime">The DateTime value to return the new DateTime for</param>
        /// <returns>
        /// A DateTime instance representing the first day of the month for the specified DateTime value
        /// </returns>
        public static DateTime ToFirstDayOfMonth(this DateTime dateTime)
            => (new DateTime(dateTime.Year, dateTime.Month, 1,
                             dateTime.Hour, dateTime.Minute, dateTime.Second, dateTime.Millisecond,
                             dateTime.Kind));

        /// <summary>
        /// Returns a new DateTime instance representing the last day of the month for the specified
        /// DateTime value
        /// </summary>
        /// <param name="dateTime">The DateTime value to return the new DateTime for</param>
        /// <returns>
        /// A DateTime instance representing the last day of the month for the specified DateTime value
        /// </returns>
        public static DateTime ToLastDayOfMonth(this DateTime dateTime)
            => (new DateTime(dateTime.Year, dateTime.Month, DateTime.DaysInMonth(dateTime.Year, dateTime.Month),
                             dateTime.Hour, dateTime.Minute, dateTime.Second, dateTime.Millisecond,
                             dateTime.Kind));

        /// <summary>
        /// Returns a new DateTime instance for the DateTime value with the time set to the specified hour,
        /// minute, second and (optionally) millisecond
        /// </summary>
        /// <param name="dateTime">The DateTime value to return the new DateTime for</param>
        /// <param name="hour">The hour to set the DateTime value to</param>
        /// <param name="minute">The minute to set the DateTime value to</param>
        /// <param name="second">The second to set the DateTime value to</param>
        /// <param name="millisecond">
        /// The millisecond to set the DateTime value to (optional).  If unspecified the millisecond value
        /// from the specified DateTime will be used
        /// </param>
        /// <returns>
        /// A DateTime instance for the DateTime value with the time set to the specified hour, minute, second
        /// and (optionally) millisecond
        /// </returns>
        public static DateTime ToTime(this DateTime dateTime, int hour, int minute, int second, int? millisecond = null)
            => (new DateTime(dateTime.Year, dateTime.Month, dateTime.Day,
                             hour, minute, second, (millisecond ?? dateTime.Millisecond),
                             dateTime.Kind));

        /// <summary>
        /// Returns a new DateTime instance for the DateTime value with the time set to the start of the day
        /// (i.e. 00:00:00:0000)
        /// </summary>
        /// <param name="dateTime">The DateTime value to return the new DateTime for</param>
        /// <returns>
        /// A DateTime instance for the DateTime value with the time set to the start of the day
        /// </returns>
        public static DateTime ToStartOfDay(this DateTime dateTime) => (dateTime.ToTime(0, 0, 0, 0));

        /// <summary>
        /// Returns a new DateTime instance for the DateTime value with the time set to the end of the day
        /// (i.e. 23:59:59:0999)
        /// </summary>
        /// <param name="dateTime">The DateTime value to return the new DateTime for</param>
        /// <returns>
        /// A DateTime instance for the DateTime value with the time set to the end of the day
        /// </returns>
        public static DateTime ToEndOfDay(this DateTime dateTime) => (dateTime.ToTime(23, 59, 59, 999));

        /// <summary>
        /// Returns a new DateTime instance for the DateTime value with the time set to midday (i.e. 12:00:00:0000)
        /// </summary>
        /// <param name="dateTime">The DateTime value to return the new DateTime for</param>
        /// <returns>
        /// A DateTime instance for the DateTime value with the time set to the end of the day
        /// </returns>
        public static DateTime ToMidday(this DateTime dateTime) => (dateTime.ToTime(12, 0, 0, 0));

        /// <summary>
        /// Returns a new DateTime instance for the DateTime value with the day set to the next occurrence
        /// of the specified day of week.  If the specified day of week day of week is the same as the
        /// given day of week (e.g. Monday and Monday) then the day 7 days from the DateTime value is
        /// returned
        /// </summary>
        /// <param name="dateTime">The DateTime value to return the new DateTime for</param>
        /// <param name="dayOfWeek">The next day of week occurrence to set the DateTime to</param>
        /// <returns>
        /// A DateTime instance for the DateTime value with the day set to the next occurrence
        /// of the specified day of week
        /// </returns>
        public static DateTime ToNext(this DateTime dateTime, DayOfWeek dayOfWeek)
        {
            int startDayOfWeek = (int)dateTime.DayOfWeek;
            int endDayOfWeek = (int)dayOfWeek;

            return (endDayOfWeek <= startDayOfWeek) ? dateTime.AddDays((endDayOfWeek + 7) - startDayOfWeek)
                                                    : dateTime.AddDays(endDayOfWeek - startDayOfWeek);
        }

        /// <summary>
        /// Returns a new DateTime instance for the DateTime value with the day set to the previous occurrence
        /// of the specified day of week.  If the specified day of week day of week is the same as the
        /// given day of week (e.g. Monday and Monday) then the day 7 days before the DateTime value is
        /// returned
        /// </summary>
        /// <param name="dateTime">The DateTime value to return the new DateTime for</param>
        /// <param name="dayOfWeek">The previous day of week occurrence to set the DateTime to</param>
        /// <returns>
        /// A DateTime instance for the DateTime value with the day set to the previous occurrence
        /// of the specified day of week
        /// </returns>
        public static DateTime ToPrevious(this DateTime dateTime, DayOfWeek dayOfWeek)
        {
            int startDayOfWeek = (int)dateTime.DayOfWeek;
            int endDayOfWeek = (int)dayOfWeek;

            return (endDayOfWeek >= startDayOfWeek) ? dateTime.AddDays((endDayOfWeek - 7) - startDayOfWeek)
                                                    : dateTime.AddDays(endDayOfWeek - startDayOfWeek);
        }
    }
}