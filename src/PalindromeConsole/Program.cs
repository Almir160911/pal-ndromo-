namespace PalindromeConsole
{
    using System;
    using System.Linq;
    using System.Text;

    public class Program
    {
        public static void Main(string[] args)
        {
            var validator = new Palindrome.Validator();

            var word = args.FirstOrDefault();
            var results = validator.GetFrom(word).Take(3);

            foreach(var formattedResult in results.Select(result => result.Format()))
            {
                Console.WriteLine(formattedResult);
            }

        }
    }
}
