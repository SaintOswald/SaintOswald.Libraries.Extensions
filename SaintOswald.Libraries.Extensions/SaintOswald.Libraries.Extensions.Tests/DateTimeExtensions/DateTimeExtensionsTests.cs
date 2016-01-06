/***********************************************************************************
 *
 * Saint Oswald: Libraries - Extensions Tests
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
            IsFalse(new DateTime(2016, 1, 6).IsEarlierThan(new DateTime(2015, 1, 6)));
            IsFalse(new DateTime(2016, 1, 6, 21, 46, 16).IsEarlierThan(new DateTime(2016, 1, 6, 21, 46, 16)));
        }
        #endregion
    }
}