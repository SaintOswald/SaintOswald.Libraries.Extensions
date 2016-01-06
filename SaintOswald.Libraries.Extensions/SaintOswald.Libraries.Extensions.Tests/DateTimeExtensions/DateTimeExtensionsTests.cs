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
    }
}