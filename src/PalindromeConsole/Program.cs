namespace PalindromeConsole
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main(string[] args)
        {
            var validator = new Palindrome.Validator();

            var word = args.FirstOrDefault();
            var formattedResults = validator.GetFrom(word).Take(3).Select(result => result.Format());

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
