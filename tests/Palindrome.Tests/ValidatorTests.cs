namespace Palindrome.Tests
{
    using FluentAssertions;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;

    [TestFixture]
    class ValidatorTests
    {
        private Validator _validator;

        [SetUp]
        public void SetUp()
        {
            _validator = new Validator();
        }

        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void GetFrom_ShouldReturnEmptyCollectionWhenGivenWordIsEmptyOrNull(string word)
        {
            var actualPalindromes = _validator.GetFrom(word);
            actualPalindromes.Should().BeEmpty();
        }

        [Test]
        [TestCase("a")]
        [TestCase("e")]
        public void GetFrom_ShouldReturnOneResultWhenWordIsOneLetterWord(string word)
        {
            var expectedResults = new[]
            {
                new ValidationResult(word, 0, 1)
            };

            var actualPalindromes = _validator.GetFrom(word);

            actualPalindromes.ShouldBeEquivalentTo(expectedResults);
        }

        [Test]
        [TestCase("testtset")]
        [TestCase("oneeno")]
        [TestCase("saippuakivikauppias")]
        public void GetFrom_ShouldReturnOneResultWhenWholeWordIsPalindrome(string word)
        {
            var expectedResults = new[]
            {
                new ValidationResult(word, 0, word.Length)
            };

            var actualPalindromes = _validator.GetFrom(word);

            actualPalindromes.ShouldBeEquivalentTo(expectedResults);
        }


        [Test]
        [TestCaseSource(nameof(GetCasesForDescendingOrder))]
        public void GetFrom_ShouldReturnResultsInDescendingOrderByLengthOfPalindrome(string word, IEnumerable<ValidationResult> expectedResults)
        {
            var actualPalindromes = _validator.GetFrom(word);
            actualPalindromes.ShouldBeEquivalentTo(expectedResults, config => config.WithStrictOrdering());
        }

        private static IEnumerable<TestCaseData> GetCasesForDescendingOrder()
        {
            var word = "noonab";
            var expectedResults = new[]
            {
                new ValidationResult("noon", 0, 4),
                new ValidationResult("a", 4, 1),
                new ValidationResult("b", 5, 1),
            };
            yield return new TestCaseData(word, expectedResults);

            word = "123321-abcdeedcba";
            expectedResults = new[]
            {
                new ValidationResult("abcdeedcba", 7, 10),
                new ValidationResult("123321", 0, 6),
                new ValidationResult("-", 6, 1)
            };
            yield return new TestCaseData(word, expectedResults);
        }
    }
}
