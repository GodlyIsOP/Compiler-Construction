using System;
using System.Text.RegularExpressions;

namespace CustomStringProcessor
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Custom String Processor");
            Console.WriteLine("======================");

            // The custom string to process
            string customString = "x:userinput; y:userinput; z:4; result: x * y + z;";
            Console.WriteLine($"Processing string: \"{customString}\"");

            // Extract variables and values using regex
            // For requirement of using last two digits of student ID in variable name (01)
            double x01 = 0;
            double y = 0;
            double z = 0;

            // Extract z value from the string
            Match zMatch = Regex.Match(customString, @"z:(\d+)");
            if (zMatch.Success)
            {
                z = Convert.ToDouble(zMatch.Groups[1].Value);
            }

            // Get user input for x (since the string has "userinput")
            Console.Write("\nEnter value for x: ");
            string xInput = Console.ReadLine();
            x01 = Convert.ToDouble(xInput);

            // Get user input for y (since the string has "userinput")
            Console.Write("Enter value for y: ");
            string yInput = Console.ReadLine();
            y = Convert.ToDouble(yInput);

            // Extract the formula from the custom string
            Match formulaMatch = Regex.Match(customString, @"result: (.*?);");
            string formulaStr = "";
            if (formulaMatch.Success)
            {
                formulaStr = formulaMatch.Groups[1].Value;
                Console.WriteLine($"\nFormula: {formulaStr}");
            }

            // Perform the operation: result = x * y + z
            double result = x01 * y + z;

            // Display original variables with values and final result
            Console.WriteLine("\nOriginal Variables:");
            Console.WriteLine($"x = {x01}");
            Console.WriteLine($"y = {y}");
            Console.WriteLine($"z = {z}");
            Console.WriteLine($"Result = {result}");

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}
