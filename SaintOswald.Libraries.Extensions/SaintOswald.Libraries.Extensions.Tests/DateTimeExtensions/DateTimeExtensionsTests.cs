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
    }
}