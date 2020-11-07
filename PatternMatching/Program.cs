using System;

namespace PatternMatching
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Is x a letter? {'x'.IsLetter()}");

            string s = GetNullString();


            if (StringIsNullOrEmpty(s))
            {
                Console.WriteLine("A");
            }

            s = string.Empty;

            if (StringIsNullOrEmpty(s))
            {
                Console.WriteLine("B");
            }

            s = "Wellllll helloooooo there";

            if (StringIsNullOrEmpty(s))
            {
                Console.WriteLine("C");
            }
        }

        static string GetNullString()
        {
            return null;
        }

        static bool StringIsNullOrEmpty(string s) => s is not null and not "";


    }

    public static class CharExstensions
    {
        public static bool IsLetter(this char c) =>    
            c is >= 'a' and <= 'z' or >= 'A' and <= 'Z';

        public static bool IsLetterOrSeparator(this char c) =>
            c is (>= 'a' and <= 'z') or (>= 'A' and <= 'Z') or '.' or ',';

    }
}
