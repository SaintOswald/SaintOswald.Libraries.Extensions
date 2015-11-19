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

        #region CollapseWhiteSpace
        [TestMethod]
        public void TestCollapseWhiteSpace()
        {
            AreEqual("Test Collapse White Space", "Test\tCollapse\r\nWhite Space".CollapseWhiteSpace());
        }

        [TestMethod]
        public void TestCollapseWhiteSpaceTrimsSpaces()
        {
            AreEqual("Test Collapse White Space", " Test Collapse White Space ".CollapseWhiteSpace());
        }

        [TestMethod]
        public void TestCollapseWhiteSpaceTrimsMultipleSpaces()
        {
            AreEqual("Test Collapse White Space", "   Test Collapse White Space   ".CollapseWhiteSpace());
        }

        [TestMethod]
        public void TestCollapseWhiteSpaceTrimsNewlinesAndTabs()
        {
            AreEqual("Test Collapse White Space", "\nTest Collapse White Space\t".CollapseWhiteSpace());
        }

        [TestMethod]
        public void TestCollapseWhiteSpaceRemovesConsecutiveSpaces()
        {
            AreEqual("Test Collapse White Space", "Test  Collapse White Space".CollapseWhiteSpace());
            AreEqual("Test Collapse White Space", "Test \t  \t Collapse White Space".CollapseWhiteSpace());
        }

        [TestMethod]
        public void TestCollapseWhiteSpaceNullReturnsNull()
        {
            string s = null;
            IsNull(s.CollapseWhiteSpace());
        }

        [TestMethod]
        public void TestCollapseWhiteSpaceEmptyStringReturnsEmpty()
        {
            AreEqual("", "".CollapseWhiteSpace());
        }
        #endregion

        #region EverythingBeforeFirst
        [TestMethod]
        public void TestEverythingBeforeFirst()
        {
            AreEqual("test", "test@example.com".EverythingBeforeFirst("@"));
        }

        [TestMethod]
        public void TestEverythingBeforeFirstMultipleDelimitersReturnsBeforeFirst()
        {
            AreEqual("test", "test@something@example.com".EverythingBeforeFirst("@"));
        }

        [TestMethod]
        public void TestEverythingBeforeFirstMultiCharacterDelimiter()
        {
            AreEqual("tes", "test@example.com".EverythingBeforeFirst("t@e"));
        }

        [TestMethod]
        public void TestEverythingBeforeFirstDelimiterNotInStringReturnsNull()
        {
            IsNull("test@example.com".EverythingBeforeFirst("-"));
        }

        [TestMethod]
        public void TestEverythingBeforeFirstDelimiterFirstCharacterReturnsNull()
        {
            IsNull("test@example.com".EverythingBeforeFirst("t"));
        }

        [TestMethod]
        public void TestEverythingBeforeFirstSpecifyStringComparison()
        {
            IsNull("test@example.com".EverythingBeforeFirst("@E"));
            AreEqual("test", "test@example.com".EverythingBeforeFirst("@E", StringComparison.CurrentCultureIgnoreCase));
        }

        [TestMethod]
        public void TestEverythingBeforeFirstStringNullReturnsNull()
        {
            string s = null;
            IsNull(s.EverythingBeforeFirst("@"));
        }

        [TestMethod]
        public void TestEverythingBeforeFirstStringEmptyReturnsNull()
        {
            IsNull("".EverythingBeforeFirst("@"));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestEverythingBeforeFirstDelimiterNullThrowsException()
        {
            "test@example.com".EverythingBeforeFirst(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestEverythingBeforeFirstDelimiterEmptyThrowsException()
        {
            "test@example.com".EverythingBeforeFirst("");
        }
        #endregion

        #region EverythingAfterLast
        [TestMethod]
        public void TestEverythingAfterLast()
        {
            AreEqual("example.com", "test@example.com".EverythingAfterLast("@"));
        }

        [TestMethod]
        public void TestEverythingAfterLastMultipleDelimitersReturnsAfterLast()
        {
            AreEqual("example.com", "test@something@example.com".EverythingAfterLast("@"));
        }

        [TestMethod]
        public void TestEverythingAfterLastMultiCharacterDelimiter()
        {
            AreEqual("xample.com", "test@example.com".EverythingAfterLast("t@e"));
        }

        [TestMethod]
        public void TestEverythingAfterLastDelimiterNotInStringReturnsNull()
        {
            Assert.IsNull("test@example.com".EverythingAfterLast("-"));
        }

        [TestMethod]
        public void TestEverythingAfterLastDelimiterLastCharacterReturnsNull()
        {
            Assert.IsNull("test@example.com".EverythingAfterLast("m"));
        }

        [TestMethod]
        public void TestEverythingAfterLastSpecifyStringComparison()
        {
            IsNull("test@example.com".EverythingAfterLast("@E"));
            AreEqual("xample.com", "test@example.com".EverythingAfterLast("@E", StringComparison.CurrentCultureIgnoreCase));
        }

        [TestMethod]
        public void TestEverythingAfterLastStringNullReturnsNull()
        {
            string s = null;
            IsNull(s.EverythingAfterLast("@"));
        }

        [TestMethod]
        public void TestEverythingAfterLastStringEmptyReturnsNull()
        {
            IsNull("".EverythingAfterLast("@"));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestEverythingAfterLastDelimiterNullThrowsException()
        {
            "test@example.com".EverythingAfterLast(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestEverythingAfterLastDelimiterEmptyThrowsException()
        {
            "test@example.com".EverythingAfterLast("");
        }
        #endregion

        #region ValueOr
        [TestMethod]
        public void TestValueOr()
        {
            AreEqual("Test", "Test".ValueOr("Alternative"));
        }

        [TestMethod]
        public void TestValueOrReturnsAlternativeWhenNull()
        {
            string s = null;
            AreEqual("Alternative", s.ValueOr("Alternative"));
        }

        [TestMethod]
        public void TestValueOrReturnsAlternativeWhenEmpty()
        {
            AreEqual("Alternative", "".ValueOr("Alternative"));
        }

        [TestMethod]
        public void TestValueOrReturnsAlternativeWhenWhiteSpace()
        {
            AreEqual("Alternative", "   ".ValueOr("Alternative"));
        }
        #endregion

        #region ToPluralForCount
        [TestMethod]
        public void TestToPluralForCount()
        {
            AreEqual("Test", "Test".ToPluralForCount(1));   // There is 1 Test
            AreEqual("Tests", "Test".ToPluralForCount(0));  // There are 0 Tests
            AreEqual("Tests", "Test".ToPluralForCount(2));  // There are 2 Tests
        }

        [TestMethod]
        public void TestToPluralForCountNegativeCount()
        {
            AreEqual("Degrees", "Degree".ToPluralForCount(-1));   // It is -1 Degrees
        }

        [TestMethod]
        public void TestToPluralForCountValueNullReturnsNull()
        {
            string s = null;
            IsNull(s.ToPluralForCount(0));
            IsNull(s.ToPluralForCount(1));
            IsNull(s.ToPluralForCount(2));
        }

        [TestMethod]
        public void TestToPluralForCountValueEmptyReturnsEmpty()
        {
            AreEqual("", "".ToPluralForCount(-1));
            AreEqual("", "".ToPluralForCount(0));
            AreEqual("", "".ToPluralForCount(1));
            AreEqual("", "".ToPluralForCount(2));
        }

        [TestMethod]
        public void TestToPluralForCountSpecifyPluralForm()
        {
            AreEqual("Category", "Category".ToPluralForCount(1, "Categories"));    // There is 1 Category
            AreEqual("Categories", "Category".ToPluralForCount(0, "Categories"));  // There are 0 Categories
            AreEqual("Categories", "Category".ToPluralForCount(2, "Categories"));  // There are 2 Categories
        }

        [TestMethod]
        public void TestToPluralForCountPluralFormNullIsIgnored()
        {
            AreEqual("Tests", "Test".ToPluralForCount(2, null));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestToPluralForCountPluralFormEmptyThrowsException()
        {
            "Test".ToPluralForCount(1, "");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestToPluralForCountPluralFormWhiteSpaceThrowsException()
        {
            "Test".ToPluralForCount(1, " ");
        }
        #endregion

        #region ToTitleCase
        [TestMethod]
        public void TestToTitleCase()
        {
            AreEqual("Test Of To Title Case", "test of to title case".ToTitleCase());
        }

        public void TestToTitleCaseSingleWord()
        {
            AreEqual("Test", "test".ToTitleCase());
        }

        public void TestToTitleCaseSingleLetter()
        {
            AreEqual("T", "t".ToTitleCase());
        }

        [TestMethod]
        public void TestToTitleCaseAlreadyTitleCase()
        {
            AreEqual("Test Of To Title Case", "Test Of To Title Case".ToTitleCase());
        }

        [TestMethod]
        public void TestToTitleCaseAcronymNotModified()
        {
            AreEqual("This Is A HTML Test", "this is a HTML test".ToTitleCase());
        }

        [TestMethod]
        public void TestToTitleCaseWithLeadingAndTrailingSpaces()
        {
            AreEqual(" Test Of To Title Case ", " test of to title case ".ToTitleCase());
        }

        [TestMethod]
        public void TestToTitleCaseValueNullReturnsNull()
        {
            string s = null;
            IsNull(s.ToTitleCase());
        }

        [TestMethod]
        public void TestToTitleCaseValueEmptyReturnsEmpty()
        {
            AreEqual("", "".ToTitleCase());
        }

        [TestMethod]
        public void TestToTitleCaseValueWhiteSpaceReturnsWhiteSpace()
        {
            AreEqual("   ", "   ".ToTitleCase());
        }
        #endregion

        #region ToTitleCaseFirstWord
        [TestMethod]
        public void ToTitleCaseFirstWord()
        {
            AreEqual("Test of to title case first word", "test of to title case first word".ToTitleCaseFirstWord());
        }

        [TestMethod]
        public void ToTitleCaseFirstWordSingleWord()
        {
            AreEqual("Test", "test".ToTitleCaseFirstWord());
        }

        [TestMethod]
        public void ToTitleCaseFirstWordSingleLetter()
        {
            AreEqual("T", "t".ToTitleCaseFirstWord());
        }

        [TestMethod]
        public void ToTitleCaseFirstWordAlreadyTitleCase()
        {
            AreEqual("Test of to title case first word", "Test of to title case first word".ToTitleCaseFirstWord());
        }

        [TestMethod]
        public void ToTitleCaseFirstWordAcronymNotModified()
        {
            AreEqual("HTML test", "HTML test".ToTitleCaseFirstWord());
        }

        [TestMethod]
        public void ToTitleCaseFirstWordWithLeadingWhiteSpace()
        {
            AreEqual("   Test of to title case first word", "   test of to title case first word".ToTitleCaseFirstWord());
        }

        [TestMethod]
        public void ToTitleCaseFirstWordWithTrailingWhiteSpace()
        {
            AreEqual("Test of to title case first word   ", "test of to title case first word   ".ToTitleCaseFirstWord());
        }

        [TestMethod]
        public void ToTitleCaseFirstWordWithLeadingAndTrailingWhiteSpace()
        {
            AreEqual("   Test of to title case first word   ", "   test of to title case first word   ".ToTitleCaseFirstWord());
        }

        [TestMethod]
        public void ToTitleCaseFirstWordValueNullReturnsNull()
        {
            string s = null;
            IsNull(s.ToTitleCaseFirstWord());
        }

        [TestMethod]
        public void ToTitleCaseFirstWordValueEmptyReturnsEmpty()
        {
            AreEqual("", "".ToTitleCaseFirstWord());
        }

        [TestMethod]
        public void ToTitleCaseFirstWordValueWhiteSpaceReturnsWhiteSpace()
        {
            AreEqual("   ", "   ".ToTitleCaseFirstWord());
        }
        #endregion
    }
}