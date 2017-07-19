namespace Palindrome.Tests
{
    using FluentAssertions;
    using NUnit.Framework;
    using PalindromeConsole;
    using System;
    using System.IO;
    using System.Text;

    [TestFixture]
    class AcceptenceTests
    {
        [Test]
        public void MainShouldPrintExpectedOutputBasedOnProvidedArgument()
        {
            var argument = "sqrrqabccbatudefggfedvwhijkllkjihxymnnmzpop";
            var expectedOutputBuilder = new StringBuilder();
            expectedOutputBuilder.AppendLine("Text: hijkllkjih, Index: 23, Length: 10");
            expectedOutputBuilder.AppendLine("Text: defggfed, Index: 13, Length: 8");
            expectedOutputBuilder.AppendLine("Text: abccba, Index: 5 Length: 6");
            var expectedOutput = expectedOutputBuilder.ToString();

            var actualOutputBuilder = new StringBuilder();
            using (var writer = new StringWriter(actualOutputBuilder))
            {
                Console.SetOut(writer);
                Program.Main(new[] { argument });
            }

            var actualOutput = actualOutputBuilder.ToString();
            actualOutput.Should().Be(expectedOutput);
        }
    }
}
