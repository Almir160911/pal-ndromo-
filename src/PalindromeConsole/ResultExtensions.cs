namespace PalindromeConsole
{
    using Palindrome;

    public static class ResultExtensions
    {
        public static string Format(this ValidationResult result)
        {
            return $"Text: {result.Palindrome}, Index: {result.Index}, Length: {result.Length}";
        }
    }
}
