namespace PalindromeConsole
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        private const int REQUIRED_AMOUNT_OF_PALINDROMES = 3;

        public static void Main(string[] args)
        {
            var validator = new Palindrome.Validator();

            var word = args.FirstOrDefault();
            var formattedResults = validator.GetFrom(word)
                                            .Take(REQUIRED_AMOUNT_OF_PALINDROMES)
                                            .Select(result => result.Format());

            Print(formattedResults);
        }     
        
        private static void Print(IEnumerable<string> formattedResults)
        {
            foreach(var formattedResult in formattedResults)
            {
                Console.WriteLine(formattedResult);
            }
        }
    }
}
