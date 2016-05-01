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
using SaintOswald.Libraries.Extensions.LongExtensions;

namespace SaintOswald.Libraries.Extensions.Tests.LongExtensions
{
    [TestClass]
    public class LongExtensionsTests
    {
        #region ToFileSize
        [TestMethod]
        public void TestToFileSize()
        {
            long bytes = 1099511627776;
            AreEqual("1 TB", bytes.ToFileSize());

            bytes = 1073741824;
            AreEqual("1 GB", bytes.ToFileSize());

            bytes = 1048576;
            AreEqual("1 MB", bytes.ToFileSize());

            bytes = 1024;
            AreEqual("1 KB", bytes.ToFileSize());

            bytes = 1;
            AreEqual("1 byte", bytes.ToFileSize());

            bytes = 0;
            AreEqual("0 bytes", bytes.ToFileSize());
        }

        [TestMethod]
        public void TestToFileSizeRoundsResult()
        {
            long bytes = 1715238139330;
            AreEqual("1.56 TB", bytes.ToFileSize());

            bytes = 1438814044;
            AreEqual("1.34 GB", bytes.ToFileSize());

            bytes = 1960837;
            AreEqual("1.87 MB", bytes.ToFileSize());

            bytes = 1351;
            AreEqual("1.32 KB", bytes.ToFileSize());
        }

        [TestMethod]
        public void TestToFileSizeSpecifyDecimals()
        {
            long bytes = 1723914605487;
            AreEqual("1.5678912 TB", bytes.ToFileSize(7));

            bytes = 1444000217;
            AreEqual("1.34483 GB", bytes.ToFileSize(5));

            bytes = 1967128;
            AreEqual("1.876 MB", bytes.ToFileSize(3));

            bytes = 1351;
            AreEqual("1.3 KB", bytes.ToFileSize(1));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestToFileSizeDecimalsLessThanOneThrowsException()
        {
            long bytes = 1715238139330;
            bytes.ToFileSize(0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestToFileSizeDecimalsGreaterThanTwentyEightThrowsException()
        {
            long bytes = 1715238139330;
            bytes.ToFileSize(29);
        }
        #endregion
    }
}