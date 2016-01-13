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
using System.Linq;
using System.Collections.Generic;

namespace SaintOswald.Libraries.Extensions.DateTimeExtensions
{
    /// <summary>
    /// Adds Extension Methods to DateTime to provide useful, reusable functionality
    /// </summary>
    public static class DateTimeExtensions
    {
        /// <summary>
        /// Holds a SortedList of relative time periods used for calculations
        /// </summary>
        static readonly SortedList<double, Func<double, string>> relativeTimePeriods = new SortedList<double, Func<double, string>>
        {
            [0.75] = (minutes) => "A few seconds",
            [1.5] = (minutes) => "A minute",
            [45] = (minutes) => $"{Math.Round(minutes)} minutes",
            [90] = (minutes) => "An hour",
            [(60 * 24)] = (minutes) => $"{Math.Round(Math.Abs(minutes / 60))} hours",
            [(60 * 48)] = (minutes) => "A day",
            [(60 * 24 * 30)] = (minutes) => $"{Math.Floor(Math.Abs(minutes / 1440))} days",
            [(60 * 24 * 60)] = (minutes) => "A month",
            [(60 * 24 * 365)] = (minutes) => $"{Math.Floor(Math.Abs(minutes / 43200))} months",
            [(60 * 24 * 365 * 2)] = (minutes) => "A year",
            [double.MaxValue] = (minutes) => $"{Math.Floor(Math.Abs(minutes / 525600))} years"
        };

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

        /// <summary>
        /// Returns the copyright for the specified DateTime value based on the given copyright start year.
        /// For example, a copyright start year of 2016 and a DateTime value of 2016 will return "2016".
        /// For a copyright start year of 2015 and a DateTime value of 2016 "2015 - 2016" will be returned
        /// </summary>
        /// <param name="dateTime">The DateTime value to return the copyright for</param>
        /// <param name="copyrightStartYear">The year in which copyright started</param>
        /// <returns>
        /// The copyright for the specified DateTime value
        /// </returns>
        /// <exception cref="System.ArgumentException">
        /// Thrown when the specified copyright start year is later than the given DateTime year
        /// </exception>
        public static string ToCopyright(this DateTime dateTime, int copyrightStartYear)
        {
            if(copyrightStartYear > dateTime.Year)
            {
                throw new ArgumentException("Copyright start year cannot be later than the DateTime year",
                                                nameof(copyrightStartYear));
            }

            return (copyrightStartYear == dateTime.Year) ? copyrightStartYear.ToString()
                                                         : ($"{copyrightStartYear} - {dateTime.Year}");
        }

        /// <summary>
        /// Returns the relative time from now (such as "A few seconds ago" or "5 minutes from now") for the
        /// specified DateTime value.  Note: Method is not locale aware and only returns results in English
        /// language format
        /// </summary>
        /// <param name="dateTime">The DateTime value to return the relative time for</param>
        /// <returns>
        /// The relative time for the specified DateTime value
        /// </returns>
        /// <seealso cref="!:http://stackoverflow.com/questions/11/how-can-relative-time-be-calculated-in-c/1141237#1141237"/>
        public static string ToRelativeTime(this DateTime dateTime)
        {
            double differenceMinutes = DateTime.Now.Subtract(dateTime).TotalMinutes;
            string suffix = " ago";

            // Are we dealing with a future time?
            if(differenceMinutes < 0)
            {
                differenceMinutes = Math.Abs(differenceMinutes);
                suffix = " from now";
            }

            return relativeTimePeriods.First(p => differenceMinutes < p.Key)
                                      .Value
                                      .Invoke(differenceMinutes) + suffix;
        }

        /// <summary>
        /// Returns a simple formatted representation of the specified DateTime value, such as
        /// "Today at HH:mm" if the DateTime value is today's date, "Yesterday at HH:mm" if the DateTime value
        /// is yesterday's date, "Wednesday at HH:mm" if the DateTime value day is up to 6 days ago and the day
        /// is a Wednesday or "dd/MM/yyyy at HH:mm" if the DateTime was earlier than 6 days ago.  Note: Method
        /// is not fully locale aware and only returns results in English language format even though dates and
        /// times will be returned according to the current locale
        /// </summary>
        /// <param name="dateTime">The DateTime value to return a simple formatted representation of</param>
        /// <returns>
        /// The simple formatted representation of the specified DateTime value
        /// </returns>
        public static string ToSimpleFormat(this DateTime dateTime)
        {
            if (dateTime.IsToday())
            {
                return $"Today at {dateTime.ToShortTimeString()}";
            }
            else if (dateTime.IsYesterday())
            {
                return $"Yesterday at {dateTime.ToShortTimeString()}";
            }
            else if (dateTime.IsLaterThan(DateTime.Today.AddDays(-6)))  // If it is within the last 6 days then return the name of the day
            {
                return $"{dateTime.ToString("dddd")} at {dateTime.ToShortTimeString()}";
            }
            else
            {
                return $"{dateTime.ToShortDateString()} at {dateTime.ToShortTimeString()}";
            }
        }
    }
}