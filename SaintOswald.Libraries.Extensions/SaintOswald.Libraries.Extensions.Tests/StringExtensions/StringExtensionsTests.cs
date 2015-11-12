/***********************************************************************************
 *
 * Saint Oswald: Libraries - Extensions Tests
 *
 * Copyright (c) 2015, Saint Oswald
 *
 ***********************************************************************************
 *
 * LICENSED UNDER THE MIT LICENSE
 * SEE LICENSE.TXT IN THE PROJECT ROOT FOR LICENSE INFORMATION
 *
 ***********************************************************************************/

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Microsoft.VisualStudio.TestTools.UnitTesting.Assert;
using SaintOswald.Libraries.Extensions.StringExtensions;

namespace SaintOswald.Libraries.Extensions.Tests.StringExtensions
{
    [TestClass]
    public class StringExtensionsTests
    {
        #region IsNullOrEmpty
        [TestMethod]
        public void IsNullOrEmpty()
        {
            string s = null;
            IsTrue(s.IsNullOrEmpty());
            IsTrue("".IsNullOrEmpty());

            IsFalse("Test of IsNullOrEmpty".IsNullOrEmpty());
        }
        #endregion

        #region IsNullOrWhiteSpace
        [TestMethod]
        public void IsNullOrWhiteSpace()
        {
            string s = null;
            IsTrue(s.IsNullOrWhiteSpace());
            IsTrue("".IsNullOrWhiteSpace());
            IsTrue(" ".IsNullOrWhiteSpace());
            IsTrue(Environment.NewLine.IsNullOrWhiteSpace());

            IsFalse("Test of IsNullOrWhitespace".IsNullOrWhiteSpace());
        }
        #endregion

        #region TrimEndWhiteSpaceAndPunctuation
        [TestMethod]
        public void TrimEndWhiteSpaceAndPunctuation()
        {
            AreEqual("Test of trim end white space and punctuation", "Test of trim end white space and punctuation ".TrimEndWhiteSpaceAndPunctuation());
            AreEqual("Test of trim end white space and punctuation", $"Test of trim end white space and punctuation{Environment.NewLine}".TrimEndWhiteSpaceAndPunctuation());
            AreEqual("Test of trim end white space and punctuation", "Test of trim end white space and punctuation?".TrimEndWhiteSpaceAndPunctuation());
            AreEqual("Test of trim end white space and punctuation", "Test of trim end white space and punctuation? ! @ ".TrimEndWhiteSpaceAndPunctuation());
        }

        public void TrimEndWhiteSpaceAndPunctuationOnlyStripsEndPunctuation()
        {
            AreEqual("?est of trim end white space and punc!uation", "?est of trim end white space and punc!uation!".TrimEndWhiteSpaceAndPunctuation());
        }

        public void TrimEndWhiteSpaceAndPunctuationNullReturnsNull()
        {
            string s = null;
            IsNull(s.TrimEndWhiteSpaceAndPunctuation());
        }

        public void TrimEndWhiteSpaceAndPunctuationEmptyReturnsEmpty()
        {
            AreEqual("", "".TrimEndWhiteSpaceAndPunctuation());
        }
        #endregion

        #region TrimStartWhiteSpaceAndPunctuation
        [TestMethod]
        public void TrimStartWhiteSpaceAndPunctuation()
        {
            AreEqual("Test of trim end white space and punctuation", " Test of trim end white space and punctuation".TrimStartWhiteSpaceAndPunctuation());
            AreEqual("Test of trim end white space and punctuation", $"{Environment.NewLine}Test of trim end white space and punctuation".TrimStartWhiteSpaceAndPunctuation());
            AreEqual("Test of trim end white space and punctuation", "?Test of trim end white space and punctuation".TrimStartWhiteSpaceAndPunctuation());
            AreEqual("Test of trim end white space and punctuation", "? ! @ Test of trim end white space and punctuation".TrimStartWhiteSpaceAndPunctuation());
        }

        public void TrimStartWhiteSpaceAndPunctuationOnlyStripsStartPunctuation()
        {
            AreEqual("Test of trim end white space and punc!uatio@", "!Test of trim end white space and punc!uation@".TrimStartWhiteSpaceAndPunctuation());
        }

        public void TrimStartWhiteSpaceAndPunctuationNullReturnsNull()
        {
            string s = null;
            IsNull(s.TrimStartWhiteSpaceAndPunctuation());
        }

        public void TrimStartWhiteSpaceAndPunctuationEmptyReturnsEmpty()
        {
            AreEqual("", "".TrimStartWhiteSpaceAndPunctuation());
        }
        #endregion

        #region Truncate
        [TestMethod]
        public void TestTruncate()
        {
            AreEqual("Test of trun...", "Test of truncation".Truncate(15));
        }

        [TestMethod]
        public void TestTruncateStringShorterThanMaximumLengthReturnsOriginal()
        {
            AreEqual("Test of truncation", "Test of truncation".Truncate(100));
        }

        [TestMethod]
        public void TestTruncateStringEqualToMaximumLengthReturnsOriginal()
        {
            AreEqual("Test of truncation", "Test of truncation".Truncate(18));
        }

        [TestMethod]
        public void TestTruncateSuffixDoesNotExceedMaximumLength()
        {
            AreEqual("Test of trunca...", "Test of truncation".Truncate(17));
        }

        [TestMethod]
        public void TestTruncateStripsTrailingPunctuation()
        {
            AreEqual("Test of...", "Test of??????????truncation".Truncate(12));
        }

        [TestMethod]
        public void TestTruncateStripsTrailingWhiteSpace()
        {
            AreEqual("Test of...", "Test of          truncation".Truncate(12));
        }

        [TestMethod]
        public void TestTruncateNullReturnsNull()
        {
            string s = null;
            IsNull(s.Truncate(15));
        }

        [TestMethod]
        public void TestTruncateStringEmptyReturnsEmpty()
        {
            AreEqual("", "".Truncate(15));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestTruncateMaximumLengthLessThanThreeThrowsException()
        {
            "Test of truncation".Truncate(2);
        }
        #endregion
    }
}