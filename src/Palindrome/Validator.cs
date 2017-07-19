namespace Palindrome
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Validator
    {
        public IEnumerable<ValidationResult> GetFrom(string word)
        {
            if (string.IsNullOrEmpty(word))
            {
                yield break;
            }

            var reservedIndexes = new List<Range>();
            var letters = word.ToCharArray();
            var upperBound = letters.GetUpperBound(0);

            for (int length = letters.Length; length > 0; length--)
            {
                for (int start = 0, end = length - 1; end <= upperBound; start++, end++)
                {
                    if (reservedIndexes.Any(indexes => start >= indexes.Start && end <= indexes.End))
                    {
                        continue;
                    }

                    if (IsPalindrome(letters, start, end))
                    {
                        reservedIndexes.Add(new Range(start, end));
                        yield return new ValidationResult(new string(letters, start, (end - start) + 1), start, (end - start) + 1);
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
    }
}
