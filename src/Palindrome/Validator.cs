namespace Palindrome
{
    using System.Collections.Generic;
    using System.Linq;

    public class Validator
    {
        public IEnumerable<ValidationResult> GetFrom(string word)
        {
            if (string.IsNullOrEmpty(word))
            {
                return Enumerable.Empty<ValidationResult>();
            }

            var letters = word.ToCharArray();
            return GetPalindromes(letters);
        }

        private IEnumerable<ValidationResult> GetPalindromes(char[] letters)
        {
            var reservedIndexes = new List<Range>();
            var upperBound = letters.GetUpperBound(0);

            for (int length = letters.Length; length > 0; length--)
            {
                for (int start = 0, end = length - 1; end <= upperBound; start++, end++)
                {
                    if (reservedIndexes.Any(indexes => indexes.ContainsRangeOf(start, end)))
                    {
                        continue;
                    }

                    if (IsPalindrome(letters, start, end))
                    {
                        reservedIndexes.Add(new Range(start, end));
                        yield return CreateResult(letters, start, end);
                    }
                }
            }
        }

        private bool IsPalindrome(char[] letters, int startIndex, int endIndex)
        {
            for (; startIndex < endIndex; startIndex++, endIndex--)
            {
                if (letters[startIndex] != letters[endIndex])
                {
                    return false;
                }
            }

            return true;
        }

        private ValidationResult CreateResult(char[] letters, int start, int end)
        {
            var palindromeLength = (end - start) + 1;
            var palindrome = new string(letters, start, palindromeLength);

            return new ValidationResult(palindrome, start, palindromeLength);
        }
    }
}
