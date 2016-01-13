/***********************************************************************************
 *
 * Saint Oswald: Libraries - Extensions Tests
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
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Microsoft.VisualStudio.TestTools.UnitTesting.Assert;
using SaintOswald.Libraries.Extensions.DateTimeExtensions;

namespace SaintOswald.Libraries.Extensions.Tests.DateTimeExtensions
{
    [TestClass]
    public class DateTimeExtensionsTests
    {
        #region IsEarlierThan
        [TestMethod]
        public void TestIsEarlierThan()
        {
            IsTrue(new DateTime(2016, 1, 6).IsEarlierThan(new DateTime(2016, 1, 7)));
            IsFalse(new DateTime(2016, 1, 7).IsEarlierThan(new DateTime(2016, 1, 6)));
        }

        [TestMethod]
        public void TestIsEarlierThanWithTime()
        {
            IsTrue(new DateTime(2016, 1, 6, 21, 46, 16).IsEarlierThan(new DateTime(2016, 1, 6, 22, 46, 16)));
            IsFalse(new DateTime(2016, 1, 6, 22, 46, 16).IsEarlierThan(new DateTime(2016, 1, 6, 21, 46, 16)));
        }

        [TestMethod]
        public void TestIsEarlierThanComparisonIdenticalReturnsFalse()
        {
            IsFalse(new DateTime(2016, 1, 6).IsEarlierThan(new DateTime(2016, 1, 6)));
            IsFalse(new DateTime(2016, 1, 6, 21, 46, 16).IsEarlierThan(new DateTime(2016, 1, 6, 21, 46, 16)));
        }
        #endregion

        #region IsLaterThan
        [TestMethod]
        public void TestIsLaterThan()
        {
            IsTrue(new DateTime(2016, 1, 6).IsLaterThan(new DateTime(2016, 1, 5)));
            IsFalse(new DateTime(2016, 1, 5).IsLaterThan(new DateTime(2016, 1, 6)));
        }

        [TestMethod]
        public void TestIsLaterThanWithTime()
        {
            IsTrue(new DateTime(2016, 1, 6, 22, 46, 16).IsLaterThan(new DateTime(2016, 1, 6, 21, 46, 16)));
            IsFalse(new DateTime(2016, 1, 6, 21, 46, 16).IsLaterThan(new DateTime(2016, 1, 6, 22, 46, 16)));
        }

        [TestMethod]
        public void TestIsLaterThanComparisonIdenticalReturnsFalse()
        {
            IsFalse(new DateTime(2016, 1, 6).IsLaterThan(new DateTime(2016, 1, 6)));
            IsFalse(new DateTime(2016, 1, 6, 21, 46, 16).IsLaterThan(new DateTime(2016, 1, 6, 21, 46, 16)));
        }
        #endregion

        #region IsSameAs
        [TestMethod]
        public void TestIsSameAs()
        {
            IsTrue(new DateTime(2016, 1, 6).IsSameAs(new DateTime(2016, 1, 6)));
            IsFalse(new DateTime(2016, 1, 6).IsSameAs(new DateTime(2016, 1, 7)));
        }

        [TestMethod]
        public void TestIsSameAsWithTime()
        {
            IsTrue(new DateTime(2016, 1, 6, 21, 46, 16).IsSameAs(new DateTime(2016, 1, 6, 21, 46, 16)));
            IsFalse(new DateTime(2016, 1, 6, 21, 46, 16).IsSameAs(new DateTime(2016, 1, 6, 22, 46, 16)));
        }
        #endregion

        #region IsSameDateAs
        [TestMethod]
        public void TestIsSameDateAs()
        {
            IsTrue(new DateTime(2016, 1, 6).IsSameDateAs(new DateTime(2016, 1, 6)));
            IsFalse(new DateTime(2016, 1, 6).IsSameDateAs(new DateTime(2016, 1, 7)));
        }

        [TestMethod]
        public void TestIsSameDateAsWithTime()
        {
            IsTrue(new DateTime(2016, 1, 6, 21, 46, 16).IsSameDateAs(new DateTime(2016, 1, 6, 21, 46, 16)));
            IsTrue(new DateTime(2016, 1, 6, 21, 46, 16).IsSameDateAs(new DateTime(2016, 1, 6, 22, 46, 16)));
            IsFalse(new DateTime(2016, 1, 6, 21, 46, 16).IsSameDateAs(new DateTime(2016, 1, 5, 21, 46, 16)));
        }
        #endregion

        #region IsSameTimeAs
        [TestMethod]
        public void TestIsSameTimeAs()
        {
            IsTrue(new DateTime(2016, 1, 6, 21, 46, 16).IsSameTimeAs(new DateTime(2016, 1, 6, 21, 46, 16)));
            IsTrue(new DateTime(2016, 1, 5, 21, 46, 16).IsSameTimeAs(new DateTime(2016, 1, 6, 21, 46, 16)));
            IsFalse(new DateTime(2016, 1, 6, 21, 46, 16).IsSameTimeAs(new DateTime(2016, 1, 7, 22, 46, 16)));
        }

        [TestMethod]
        public void TestIsSameTimeAsNoTimeSpecifiedUsesDefaultValue()
        {
            DateTime dateTime = new DateTime(2016, 1, 6);
            AreEqual(0, dateTime.Hour);
            AreEqual(0, dateTime.Minute);
            AreEqual(0, dateTime.Second);

            IsTrue(dateTime.IsSameTimeAs(new DateTime(2016, 1, 6)));
            IsTrue(dateTime.IsSameTimeAs(new DateTime(2016, 1, 5)));
            IsFalse(dateTime.IsSameTimeAs(new DateTime(2016, 1, 5, 21, 46, 16)));
        }
        #endregion

        #region IsWeekend
        [TestMethod]
        public void TestIsWeekend()
        {
            IsTrue(new DateTime(2016, 1, 2).IsWeekend());   // Saturday
            IsTrue(new DateTime(2016, 1, 3).IsWeekend());   // Sunday
            IsFalse(new DateTime(2016, 1, 4).IsWeekend());  // Monday
        }
        #endregion

        #region IsWeekday
        [TestMethod]
        public void TestIsWeekday()
        {
            IsTrue(new DateTime(2016, 1, 4).IsWeekday());   // Monday
            IsFalse(new DateTime(2016, 1, 3).IsWeekday());  // Sunday
            IsFalse(new DateTime(2016, 1, 2).IsWeekday());  // Saturday
        }
        #endregion

        #region IsToday
        [TestMethod]
        public void TestIsToday()
        {
            IsTrue(DateTime.Now.IsToday());
            IsFalse(DateTime.Now.AddDays(-1).IsToday());
            IsFalse(DateTime.Now.AddDays(1).IsToday());
        }
        #endregion

        #region IsYesterday
        [TestMethod]
        public void TestIsYesterday()
        {
            IsTrue(DateTime.Now.AddDays(-1).IsYesterday());
            IsFalse(DateTime.Now.IsYesterday());
            IsFalse(DateTime.Now.AddDays(-2).IsYesterday());
            IsFalse(DateTime.Now.AddDays(1).IsYesterday());
        }
        #endregion

        #region IsTomorrow
        [TestMethod]
        public void TestIsTomorrow()
        {
            IsTrue(DateTime.Now.AddDays(1).IsTomorrow());
            IsFalse(DateTime.Now.IsTomorrow());
            IsFalse(DateTime.Now.AddDays(-1).IsTomorrow());
            IsFalse(DateTime.Now.AddDays(2).IsTomorrow());
        }
        #endregion

        #region IsInFuture
        [TestMethod]
        public void TestIsInFuture()
        {
            IsTrue(DateTime.Now.AddDays(1).IsInFuture());
            IsTrue(DateTime.Now.AddSeconds(10).IsInFuture());
            IsFalse(DateTime.Now.AddDays(-1).IsInFuture());
            IsFalse(DateTime.Now.AddSeconds(-1).IsInFuture());
        }

        [TestMethod]
        public void TestIsInFutureNowReturnsFalse()
        {
            IsFalse(DateTime.Now.IsInFuture());
        }
        #endregion

        #region IsInPast
        [TestMethod]
        public void TestIsInPast()
        {
            IsTrue(DateTime.Now.AddDays(-1).IsInPast());
            IsTrue(DateTime.Now.AddSeconds(-10).IsInPast());
            IsFalse(DateTime.Now.AddDays(1).IsInPast());
            IsFalse(DateTime.Now.AddSeconds(1).IsInPast());
        }

        [TestMethod]
        public void TestIsInPastNowReturnsFalse()
        {
            IsFalse(DateTime.Now.IsInPast());
        }
        #endregion

        #region IsBetween
        [TestMethod]
        public void TestIsBetween()
        {
            IsTrue(new DateTime(2016, 1, 7).IsBetween(new DateTime(2016, 1, 1), new DateTime(2016, 12, 31)));
            IsFalse(new DateTime(2016, 1, 7).IsBetween(new DateTime(2015, 1, 1), new DateTime(2015, 12, 31)));
        }

        [TestMethod]
        public void TestIsBetweenWithTime()
        {
            IsTrue(new DateTime(2016, 1, 7, 18, 20, 12).IsBetween(new DateTime(2016, 1, 7, 0, 0, 0), new DateTime(2016, 1, 7, 23, 59, 59)));
            IsFalse(new DateTime(2016, 1, 7, 18, 20, 12).IsBetween(new DateTime(2016, 1, 7, 20, 0, 0), new DateTime(2016, 1, 7, 23, 59, 59)));
        }

        [TestMethod]
        public void TestIsBetweenIdenticalReturnsTrue()
        {
            IsTrue(new DateTime(2016, 1, 7).IsBetween(new DateTime(2016, 1, 7), new DateTime(2016, 1, 7)));
            IsTrue(new DateTime(2016, 1, 7, 18, 20, 12).IsBetween(new DateTime(2016, 1, 7, 18, 20, 12), new DateTime(2016, 1, 7, 18, 20, 12)));
        }
        #endregion

        #region IsAnniversaryOf
        [TestMethod]
        public void TestIsAnniversaryOf()
        {
            IsTrue(new DateTime(2016, 1, 11).IsAnniversaryOf(new DateTime(2015, 1, 11)));
            IsTrue(new DateTime(2016, 1, 11).IsAnniversaryOf(new DateTime(2014, 1, 11)));
            IsFalse(new DateTime(2016, 1, 12).IsAnniversaryOf(new DateTime(2015, 1, 11)));
        }

        [TestMethod]
        public void TestIsAnniversaryOfComparisonSameDateReturnsFalse()
        {
            IsFalse(new DateTime(2016, 1, 11).IsAnniversaryOf(new DateTime(2016, 1, 11)));
        }

        [TestMethod]
        public void TestIsAnniversaryOfComparisonLaterYearReturnsFalse()
        {
            IsFalse(new DateTime(2016, 1, 11).IsAnniversaryOf(new DateTime(2017, 1, 11)));
        }
        #endregion

        #region ToFirstDayOfMonth
        [TestMethod]
        public void TestToFirstDayOfMonth()
        {
            AreEqual(new DateTime(2016, 1, 1), new DateTime(2016, 1, 7).ToFirstDayOfMonth());
        }

        [TestMethod]
        public void TestToFirstDayOfMonthWithTime()
        {
            AreEqual(new DateTime(2016, 1, 1, 18, 47, 14), new DateTime(2016, 1, 7, 18, 47, 14).ToFirstDayOfMonth());
        }

        [TestMethod]
        public void TestToFirstDayOfMonthKeepsDateTimeKind()
        {
            AreEqual(DateTimeKind.Utc, new DateTime(2016, 1, 7, 18, 47, 14, DateTimeKind.Utc).ToFirstDayOfMonth().Kind);
        }
        #endregion

        #region ToLastDayOfMonth
        [TestMethod]
        public void TestToLastDayOfMonth()
        {
            AreEqual(new DateTime(2016, 1, 31), new DateTime(2016, 1, 7).ToLastDayOfMonth());
            AreEqual(new DateTime(2016, 4, 30), new DateTime(2016, 4, 7).ToLastDayOfMonth());
        }

        [TestMethod]
        public void TestToLastDayOfMonthLeapYear()
        {
            AreEqual(new DateTime(2016, 2, 29), new DateTime(2016, 2, 7).ToLastDayOfMonth());
            AreEqual(new DateTime(2015, 2, 28), new DateTime(2015, 2, 7).ToLastDayOfMonth());
        }

        [TestMethod]
        public void TestToLastDayOfMonthWithTime()
        {
            AreEqual(new DateTime(2016, 1, 31, 18, 47, 14), new DateTime(2016, 1, 7, 18, 47, 14).ToLastDayOfMonth());
        }

        [TestMethod]
        public void TestToLastDayOfMonthKeepsDateTimeKind()
        {
            AreEqual(DateTimeKind.Utc, new DateTime(2016, 1, 7, 18, 47, 14, DateTimeKind.Utc).ToLastDayOfMonth().Kind);
        }
        #endregion

        #region ToTime
        [TestMethod]
        public void TestToTime()
        {
            AreEqual(new DateTime(2016, 1, 7, 19, 20, 21), new DateTime(2016, 1, 7, 1, 2, 3).ToTime(19, 20, 21));
        }

        [TestMethod]
        public void TestToTimeSpecifyMillisecond()
        {
            AreEqual(new DateTime(2016, 1, 7, 19, 20, 21, 5), new DateTime(2016, 1, 7, 1, 2, 3, 1).ToTime(19, 20, 21, 5));
        }

        [TestMethod]
        public void TestToTimeUnspecifiedMillisecondUsesDateTimeValue()
        {
            AreEqual(new DateTime(2016, 1, 7, 19, 20, 21, 1), new DateTime(2016, 1, 7, 1, 2, 3, 1).ToTime(19, 20, 21));
        }

        [TestMethod]
        public void TestToTimeKeepsDateTimeKind()
        {
            AreEqual(DateTimeKind.Utc, new DateTime(2016, 1, 7, 1, 2, 3, DateTimeKind.Utc).ToTime(19, 20, 21).Kind);
        }
        #endregion

        #region ToStartOfDay
        [TestMethod]
        public void TestToStartOfDay()
        {
            AreEqual(new DateTime(2016, 1, 7, 0, 0, 0, 0), new DateTime(2016, 1, 7, 19, 34, 56, 178).ToStartOfDay());
        }

        [TestMethod]
        public void TestToStartOfDayKeepsDateTimeKind()
        {
            AreEqual(DateTimeKind.Utc, new DateTime(2016, 1, 7, 19, 34, 56, DateTimeKind.Utc).ToStartOfDay().Kind);
        }
        #endregion

        #region ToEndOfDay
        [TestMethod]
        public void TestToEndOfDay()
        {
            AreEqual(new DateTime(2016, 1, 7, 23, 59, 59, 999), new DateTime(2016, 1, 7, 19, 34, 56, 178).ToEndOfDay());
        }

        [TestMethod]
        public void TestToEndOfDayKeepsDateTimeKind()
        {
            AreEqual(DateTimeKind.Utc, new DateTime(2016, 1, 7, 19, 34, 56, DateTimeKind.Utc).ToEndOfDay().Kind);
        }
        #endregion

        #region ToMidday
        [TestMethod]
        public void TestToMidday()
        {
            AreEqual(new DateTime(2016, 1, 7, 12, 0, 0, 0), new DateTime(2016, 1, 7, 19, 34, 56, 178).ToMidday());
        }

        [TestMethod]
        public void TestToMiddayKeepsDateTimeKind()
        {
            AreEqual(DateTimeKind.Utc, new DateTime(2016, 1, 7, 19, 34, 56, DateTimeKind.Utc).ToMidday().Kind);
        }
        #endregion

        #region ToNext
        [TestMethod]
        public void TestToNext()
        {
            DateTime next = new DateTime(2016, 1, 7).ToNext(DayOfWeek.Friday);

            AreEqual(DayOfWeek.Friday, next.DayOfWeek);
            AreEqual(8, next.Day);

            next = next.ToNext(DayOfWeek.Sunday);
            AreEqual(DayOfWeek.Sunday, next.DayOfWeek);
            AreEqual(10, next.Day);
        }

        [TestMethod]
        public void TestToNextWithTime()
        {
            DateTime next = new DateTime(2016, 1, 7, 19, 48, 15).ToNext(DayOfWeek.Friday);

            AreEqual(DayOfWeek.Friday, next.DayOfWeek);
            AreEqual(new DateTime(2016, 1, 8, 19, 48, 15), next);
        }

        [TestMethod]
        public void TestToNextDayOfWeekIsSameReturnsNextOccurrence()
        {
            DateTime next = new DateTime(2016, 1, 7).ToNext(DayOfWeek.Thursday);

            AreEqual(DayOfWeek.Thursday, next.DayOfWeek);
            AreEqual(14, next.Day);
        }
        #endregion

        #region ToPrevious
        [TestMethod]
        public void TestToPrevious()
        {
            DateTime next = new DateTime(2016, 1, 7).ToPrevious(DayOfWeek.Wednesday);

            AreEqual(DayOfWeek.Wednesday, next.DayOfWeek);
            AreEqual(6, next.Day);

            next = next.ToPrevious(DayOfWeek.Monday);
            AreEqual(DayOfWeek.Monday, next.DayOfWeek);
            AreEqual(4, next.Day);
        }

        [TestMethod]
        public void TestToPreviousWithTime()
        {
            DateTime next = new DateTime(2016, 1, 7, 19, 52, 34).ToPrevious(DayOfWeek.Wednesday);

            AreEqual(DayOfWeek.Wednesday, next.DayOfWeek);
            AreEqual(new DateTime(2016, 1, 6, 19, 52, 34), next);
        }

        [TestMethod]
        public void TestToPreviousDayOfWeekIsSameReturnsPreviousOccurrence()
        {
            DateTime next = new DateTime(2016, 1, 7).ToPrevious(DayOfWeek.Thursday);

            AreEqual(DayOfWeek.Thursday, next.DayOfWeek);
            AreEqual(31, next.Day);
        }
        #endregion

        #region ToCopyright
        [TestMethod]
        public void TestToCopyright()
        {
            AreEqual("2016", new DateTime(2016, 11, 1).ToCopyright(2016));
            AreEqual("2015 - 2016", new DateTime(2016, 11, 1).ToCopyright(2015));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestToCopyrightCopyrightStartYearLaterThanDateTimeYearThrowsException()
        {
            AreEqual("2016", new DateTime(2016, 11, 1).ToCopyright(2017));
        }
        #endregion

        #region ToRelativeTime
        [TestMethod]
        public void TestToRelativeTime()
        {
            AreEqual("A few seconds ago", DateTime.Now.AddSeconds(-1).ToRelativeTime());
            AreEqual("A few seconds from now", DateTime.Now.AddSeconds(1).ToRelativeTime());

            AreEqual("A minute ago", DateTime.Now.AddMinutes(-1).ToRelativeTime());
            AreEqual("A minute from now", DateTime.Now.AddMinutes(1).ToRelativeTime());

            AreEqual("2 minutes ago", DateTime.Now.AddMinutes(-2).ToRelativeTime());
            AreEqual("2 minutes from now", DateTime.Now.AddMinutes(2).ToRelativeTime());

            AreEqual("An hour ago", DateTime.Now.AddHours(-1).ToRelativeTime());
            AreEqual("An hour from now", DateTime.Now.AddHours(1).ToRelativeTime());

            AreEqual("2 hours ago", DateTime.Now.AddHours(-2).ToRelativeTime());
            AreEqual("2 hours from now", DateTime.Now.AddHours(2).ToRelativeTime());

            AreEqual("A day ago", DateTime.Now.AddDays(-1).ToRelativeTime());
            AreEqual("A day from now", DateTime.Now.AddDays(1).ToRelativeTime());

            AreEqual("2 days ago", DateTime.Now.AddDays(-2).ToRelativeTime());
            AreEqual("2 days from now", DateTime.Now.AddDays(2).ToRelativeTime());

            AreEqual("A month ago", DateTime.Now.AddDays(-30).ToRelativeTime());
            AreEqual("A month from now", DateTime.Now.AddDays(30).ToRelativeTime());

            AreEqual("2 months ago", DateTime.Now.AddDays(-60).ToRelativeTime());
            AreEqual("2 months from now", DateTime.Now.AddDays(60).ToRelativeTime());

            AreEqual("A year ago", DateTime.Now.AddDays(-365).ToRelativeTime());
            AreEqual("A year from now", DateTime.Now.AddDays(365).ToRelativeTime());

            AreEqual("2 years ago", DateTime.Now.AddDays(-365 * 2).ToRelativeTime());
            AreEqual("2 years from now", DateTime.Now.AddDays(365 * 2).ToRelativeTime());
        }
        #endregion
    }
}