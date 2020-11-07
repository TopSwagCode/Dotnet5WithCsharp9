using System;
using System.Collections.Generic;

namespace New
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> ints = new() { 1, 2, 3, 4 };

            Sum(1, 2, new());

            OutputOptions outputOptions = new() { ShouldOutputToConsole = true };

            Sum(2, 3, outputOptions);

            Sum(3, 4, new(true));
        }

        public static string Sum(int x, int y, OutputOptions outputOptions)
        {
            var sum = x + y;
            var response = $"{x}+{y}={sum}";
            if (outputOptions.ShouldOutputToConsole) Console.WriteLine(response);
            return response;
        }

    }

    public class OutputOptions
    {
        public OutputOptions(bool shouldOutputToConsole)
        {
            ShouldOutputToConsole = shouldOutputToConsole;
        }

        public OutputOptions()
        {
        }

        public bool ShouldOutputToConsole { get; set; }
    }
}
