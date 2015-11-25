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
using System.Globalization;
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
        public void TestIsNullOrEmpty()
        {
            string s = null;
            IsTrue(s.IsNullOrEmpty());
            IsTrue("".IsNullOrEmpty());

            IsFalse("Test of IsNullOrEmpty".IsNullOrEmpty());
        }
        #endregion

        #region IsNullOrWhiteSpace
        [TestMethod]
        public void TestIsNullOrWhiteSpace()
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
        public void TestTrimEndWhiteSpaceAndPunctuation()
        {
            AreEqual("Test of trim end white space and punctuation", "Test of trim end white space and punctuation ".TrimEndWhiteSpaceAndPunctuation());
            AreEqual("Test of trim end white space and punctuation", $"Test of trim end white space and punctuation{Environment.NewLine}".TrimEndWhiteSpaceAndPunctuation());
            AreEqual("Test of trim end white space and punctuation", "Test of trim end white space and punctuation?".TrimEndWhiteSpaceAndPunctuation());
            AreEqual("Test of trim end white space and punctuation", "Test of trim end white space and punctuation? ! @ ".TrimEndWhiteSpaceAndPunctuation());
        }

        [TestMethod]
        public void TestTrimEndWhiteSpaceAndPunctuationOnlyStripsEndPunctuation()
        {
            AreEqual("?est of trim end white space and punc!uation", "?est of trim end white space and punc!uation!".TrimEndWhiteSpaceAndPunctuation());
        }

        [TestMethod]
        public void TestTrimEndWhiteSpaceAndPunctuationNullReturnsNull()
        {
            string s = null;
            IsNull(s.TrimEndWhiteSpaceAndPunctuation());
        }

        [TestMethod]
        public void TestTrimEndWhiteSpaceAndPunctuationEmptyReturnsEmpty()
        {
            AreEqual("", "".TrimEndWhiteSpaceAndPunctuation());
        }
        #endregion

        #region TrimStartWhiteSpaceAndPunctuation
        [TestMethod]
        public void TestTrimStartWhiteSpaceAndPunctuation()
        {
            AreEqual("Test of trim end white space and punctuation", " Test of trim end white space and punctuation".TrimStartWhiteSpaceAndPunctuation());
            AreEqual("Test of trim end white space and punctuation", $"{Environment.NewLine}Test of trim end white space and punctuation".TrimStartWhiteSpaceAndPunctuation());
            AreEqual("Test of trim end white space and punctuation", "?Test of trim end white space and punctuation".TrimStartWhiteSpaceAndPunctuation());
            AreEqual("Test of trim end white space and punctuation", "? ! @ Test of trim end white space and punctuation".TrimStartWhiteSpaceAndPunctuation());
        }

        [TestMethod]
        public void TestTrimStartWhiteSpaceAndPunctuationOnlyStripsStartPunctuation()
        {
            AreEqual("Test of trim end white space and punc!uation@", "!Test of trim end white space and punc!uation@".TrimStartWhiteSpaceAndPunctuation());
        }

        [TestMethod]
        public void TestTrimStartWhiteSpaceAndPunctuationNullReturnsNull()
        {
            string s = null;
            IsNull(s.TrimStartWhiteSpaceAndPunctuation());
        }

        [TestMethod]
        public void TestTrimStartWhiteSpaceAndPunctuationEmptyReturnsEmpty()
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

        [TestMethod]
        public void TestToTitleCaseSingleWord()
        {
            AreEqual("Test", "test".ToTitleCase());
        }

        [TestMethod]
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
        public void TestToTitleCaseSpecifyCulture()
        {
            AreEqual("İngilis Dili Danışmaq Edirsiniz?", "ingilis dili danışmaq edirsiniz?".ToTitleCase(new CultureInfo("az-Latn-AZ")));  // Azerbaijani
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

        #region ToUpperFirst
        [TestMethod]
        public void TestToUpperFirst()
        {
            AreEqual("Test", "test".ToUpperFirst());
        }

        [TestMethod]
        public void TestToUpperFirstSingleLetter()
        {
            AreEqual("T", "t".ToUpperFirst());
        }

        [TestMethod]
        public void TestToUpperFirstFirstLetterAlreadyInUppercase()
        {
            AreEqual("Test", "Test".ToUpperFirst());
        }

        [TestMethod]
        public void TestToUpperSpecifyCulture()
        {
            AreEqual("İngilis", "ingilis".ToUpperFirst(new CultureInfo("az-Latn-AZ")));  // Azerbaijani
        }

        [TestMethod]
        public void TestToUpperFirstNullReturnsNull()
        {
            string s = null;
            IsNull(s.ToUpperFirst());
        }

        [TestMethod]
        public void TestToUpperFirstEmptyReturnsEmpty()
        {
            AreEqual("", "".ToUpperFirst());
        }

        [TestMethod]
        public void TestToUpperFirstWhiteSpaceReturnsWhiteSpace()
        {
            AreEqual("   ", "   ".ToUpperFirst());
        }
        #endregion

        #region Repeat
        [TestMethod]
        public void TestRepeat()
        {
            AreEqual("-----", "-".Repeat(5));
        }

        [TestMethod]
        public void TestRepeatTwoRepetitions()
        {
            AreEqual("--", "-".Repeat(2));
        }

        [TestMethod]
        public void TestRepeatMultipleCharacters()
        {
            AreEqual("TestTestTest", "Test".Repeat(3));
        }

        [TestMethod]
        public void TestRepeatWhiteSpace()
        {
            AreEqual("   ", " ".Repeat(3));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestRepeatRepetitionsLessThan2ThrowsException()
        {
            "-".Repeat(1);
        }

        [TestMethod]
        public void TestRepeatNullReturnsNull()
        {
            string s = null;
            IsNull(s.Repeat(3));
        }

        [TestMethod]
        public void TestRepeatEmptyReturnsEmpty()
        {
            AreEqual("", "".Repeat(3));
        }

        [TestMethod]
        public void TestRepeatWhiteSpaceReturnsWhiteSpaces()
        {
            AreEqual("   ", " ".Repeat(3));
        }
        #endregion

        #region TryParseTo
        [TestMethod]
        public void TestTryParseTo()
        {
            AreEqual<int>(1, "1".TryParseTo<int>());
            AreEqual<uint>(1, "1".TryParseTo<uint>());
            AreEqual<Int16>(1, "1".TryParseTo<Int16>());
            AreEqual<UInt16>(1, "1".TryParseTo<UInt16>());
            AreEqual<Int32>(1, "1".TryParseTo<Int32>());
            AreEqual<UInt32>(1, "1".TryParseTo<UInt32>());
            AreEqual<Int64>(1, "1".TryParseTo<Int64>());
            AreEqual<UInt64>(1, "1".TryParseTo<UInt64>());
            AreEqual<short>(1, "1".TryParseTo<short>());
            AreEqual<ushort>(1, "1".TryParseTo<ushort>());
            AreEqual<long>(1, "1".TryParseTo<long>());
            AreEqual<ulong>(1, "1".TryParseTo<ulong>());

            AreEqual<float>(1.1f, "1.1".TryParseTo<float>());
            AreEqual<double>(1.1, "1.1".TryParseTo<double>());
            AreEqual<decimal>(1.1M, "1.1".TryParseTo<decimal>());
        }

        [TestMethod]
        public void TestTryParseToNegativeValues()
        {
            AreEqual<int>(-1, "-1".TryParseTo<int>());
            AreEqual<Int16>(-1, "-1".TryParseTo<Int16>());
            AreEqual<Int32>(-1, "-1".TryParseTo<Int32>());
            AreEqual<Int64>(-1, "-1".TryParseTo<Int64>());
            AreEqual<short>(-1, "-1".TryParseTo<short>());
            AreEqual<long>(-1, "-1".TryParseTo<long>());

            AreEqual<float>(-1.1f, "-1.1".TryParseTo<float>());
            AreEqual<double>(-1.1, "-1.1".TryParseTo<double>());
            AreEqual<decimal>(-1.1M, "-1.1".TryParseTo<decimal>());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestTryParseToParsingNotPossibleThrowsException()
        {
            "Test".TryParseTo<int>();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestTryParseToParsingNotPossibleAsValueTooLargeForTypeThrowsException()
        {
            "32768".TryParseTo<Int16>();  // Int16 maximum value is 32767
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestTryParseToParsingNotPossibleAsValueIsNegativeAndTypeIsUnsignedThrowsException()
        {
            "-1".TryParseTo<uint>();
        }
        #endregion

        #region RemoveDiacritics
        [TestMethod]
        public void TestRemoveDiacritics()
        {
            AreEqual("acdeeinorstuuyz", "áčďéěíňóřšťúůýž".RemoveDiacritics());  // Czech
            AreEqual("aaeeeeiiouuuy", "àâéèêëïîôùûüÿ".RemoveDiacritics());      // French
            AreEqual("aou", "äöü".RemoveDiacritics());                          // German
            AreEqual("aenzz", "ąęńźż".RemoveDiacritics());                      // Polish
            AreEqual("aaaaceeiooouu", "ãáàâçéêíõóôúü".RemoveDiacritics());      // Portuguese
            AreEqual("aaeo", "äåéö".RemoveDiacritics());                        // Swedish
        }

        [TestMethod]
        public void TestRemoveDiacriticsFromSentence()
        {
            AreEqual("Parlez-vous Francais?", "Parlez-vous Français?".RemoveDiacritics());
        }

        [TestMethod]
        public void TestRemoveDiacriticsNullReturnsNull()
        {
            string s = null;
            IsNull(s.RemoveDiacritics());
        }

        [TestMethod]
        public void TestRemoveDiacriticsEmptyReturnsEmpty()
        {
            AreEqual("", "".RemoveDiacritics());
        }

        [TestMethod]
        public void TestRemoveDiacriticsWhiteSpaceReturnsWhiteSpace()
        {
            AreEqual("   ", "   ".RemoveDiacritics());
        }
        #endregion

        #region ToSlug
        [TestMethod]
        public void TestToSlug()
        {
            AreEqual("test-to-slug", "Test to Slug".ToSlug());
        }

        [TestMethod]
        public void TestToSlugRemovesDiacritics()
        {
            AreEqual("test-to-slug", "Tést to Slug".ToSlug());
        }

        [TestMethod]
        public void TestToSlugConvertsToLowercase()
        {
            AreEqual("test-to-slug", "TEST TO SLUG".ToSlug());
        }

        [TestMethod]
        public void TestToSlugCollapsesWhiteSpace()
        {
            AreEqual("test-to-slug", "Test\tto\r\nSlug".ToSlug());
        }

        [TestMethod]
        public void TestToSlugReplacesSpacesWithHyphens()
        {
            AreEqual("test-to-slug", "Test to Slug".ToSlug());
        }

        [TestMethod]
        public void TestToSlugOnlyAllowsNonAlphaNumericCharactersOrHyphens()
        {
            AreEqual("test-to-slug", "/Test @to-Slug".ToSlug());
        }

        [TestMethod]
        public void TestToSlugTrims()
        {
            AreEqual("test-to-slug", "  Test to Slug  ".ToSlug());
        }

        [TestMethod]
        public void TestToSlugRemovesConsecutiveHyphens()
        {
            AreEqual("test-to-slug", "Test- -to- -Slug".ToSlug());
        }

        [TestMethod]
        public void TestToSlugRemovesLeadingHyphens()
        {
            AreEqual("test-to-slug", "-Test to Slug".ToSlug());
        }

        [TestMethod]
        public void TestToSlugRemovesTrailingHyphens()
        {
            AreEqual("test-to-slug", "Test to Slug-".ToSlug());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestToSlugStringNullThrowsException()
        {
            string s = null;
            s.ToSlug();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestToSlugStringEmptyThrowsException()
        {
            "".ToSlug();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestToSlugStringWhiteSpaceThrowsException()
        {
            "   ".ToSlug();
        }
        #endregion
    }
}