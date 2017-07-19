namespace Palindrome.Tests
{
    using FluentAssertions;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;

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

            AssertThatGetFromReturnExpectedResult(word, expectedResults);
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

            AssertThatGetFromReturnExpectedResult(word, expectedResults);
        }

        [Test]
        [TestCaseSource(nameof(GetCasesForDescendingOrder))]
        public void GetFrom_ShouldReturnResultsInDescendingOrderByLengthOfPalindrome(string word, IEnumerable<ValidationResult> expectedResults)
        {
            AssertThatGetFromReturnExpectedResult(word, expectedResults);
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

        [Test]
        [TestCaseSource(nameof(GetCasesForIntersectedPalindromes))]
        public void GetFrom_ShouldReturnExpectedResultWhenPalindromeUsesSameLetters(string word, IEnumerable<ValidationResult> expectedResults)
        {
            AssertThatGetFromReturnExpectedResult(word, expectedResults);
        }

        private static IEnumerable<TestCaseData> GetCasesForIntersectedPalindromes()
        {
            var word = "123-321123";
            var expectedResults = new[]
            {
                new ValidationResult("123-321", 0, 7),
                new ValidationResult("321123", 4, 6)
            };
            yield return new TestCaseData(word, expectedResults);

            word = "noonono";
            expectedResults = new[]
            {
                new ValidationResult("onono", 2, 5),
                new ValidationResult("noon", 0, 4)
            };
            yield return new TestCaseData(word, expectedResults);
        }

        [Test]
        public void GetFrom_ShouldReturnThreeLongestPalindromes()
        {
            var word = "sqrrqabccbatudefggfedvwhijkllkjihxymnnmzpop";
            var expectedResults = new[]
            {
                new ValidationResult("hijkllkjih", 23, 10),
                new ValidationResult("defggfed", 13, 8),
                new ValidationResult("abccba", 5, 6)
            };
            var actualPalindromes = _validator.GetFrom(word).Take(3);
            actualPalindromes.ShouldBeEquivalentTo(expectedResults, config => config.WithStrictOrdering());
        }

        private void AssertThatGetFromReturnExpectedResult(string word, IEnumerable<ValidationResult> expected)
        {
            var actualPalindromes = _validator.GetFrom(word);
            actualPalindromes.ShouldBeEquivalentTo(expected, config => config.WithStrictOrdering());
        }
    }
}
