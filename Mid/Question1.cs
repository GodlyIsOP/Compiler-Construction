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
            string customString = "x:0; y:1; z:userinput; result: x * y + z;";
            Console.WriteLine($"Processing string: \"{customString}\"");

            // Extract variables and values
            // Using student roll number 01: x = 0, y = 1
            double x01 = 0; // first digit of roll number
            double y = 1;   // second digit of roll number
            double z = 0;

            // Get user input for z (since it's marked as "userinput" in the string)
            Console.Write("\nEnter value for z: ");
            string zInput = Console.ReadLine();
            z = Convert.ToDouble(zInput);

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
