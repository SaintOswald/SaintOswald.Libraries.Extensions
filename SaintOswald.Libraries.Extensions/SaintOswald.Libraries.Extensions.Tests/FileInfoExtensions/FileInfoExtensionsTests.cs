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

using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Microsoft.VisualStudio.TestTools.UnitTesting.Assert;
using SaintOswald.Libraries.Extensions.FileInfoExtensions;

namespace SaintOswald.Libraries.Extensions.Tests.FileInfoExtensions
{
    [TestClass]
    public class FileInfoExtensionsTests
    {
        #region ToFileSize
        [TestMethod]
        public void TestLengthFormatted()
        {
            FileInfo file = new FileInfo("FileInfoExtensionsTestFile.txt");

            AreEqual(3327, file.Length);
            AreEqual("3.25 KB", file.LengthFormatted());

            file = null;
        }
        #endregion
    }
}