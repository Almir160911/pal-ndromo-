namespace Palindrome.Tests
{
    using FluentAssertions;
    using NUnit.Framework;
    using PalindromeConsole;
    using System;
    using System.Collections.Generic;

    [TestFixture]
    class ResultExtensionsTests
    {
        [Test]
        [TestCaseSource(nameof(GetTestCases))]
        public void Format_ShouldReturnFormattedValuesOfGivenResult(ValidationResult result, string expectedText)
        {
            var formatted = result.Format();
            formatted.Should().Be(expectedText);
        }

        private static IEnumerable<TestCaseData> GetTestCases()
        {
            yield return new TestCaseData(new ValidationResult("test", 0, 4), "Text: test, Index: 0, Length: 4");
            yield return new TestCaseData(new ValidationResult("abbaabba", 4, 8), "Text: abbaabba, Index: 4, Length: 8");
            yield return new TestCaseData(new ValidationResult("other-test", 45, 10), "Text: other-test, Index: 45, Length: 10");
        }
    }
}
