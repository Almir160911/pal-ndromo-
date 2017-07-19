namespace Palindrome
{
    using System;

    public class ValidationResult
    {
        public string Palindrome { get; }

        public int Index { get; }

        public int Length { get; }

        public ValidationResult(string palindrome, int index, int length)
        {
            Palindrome = palindrome;
            Index = index;
            Length = length;
        }
    }
}
