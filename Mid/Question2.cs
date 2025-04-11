using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace MiniLanguageParser
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Mini-Language Variable Extractor");
            Console.WriteLine("================================");
            Console.WriteLine("Enter your code (type 'END' on a new line when finished):");

            // Collect input code from user
            string inputCode = "";
            string line;
            while ((line = Console.ReadLine()) != "END")
            {
                inputCode += line + Environment.NewLine;
            }

            // Define the regex pattern:
            // - Variable declaration (var or float)
            // - Variable name starts with a, b, or c
            // - Variable name ends with digits
            // - Value contains a non-alphanumeric special character
            string pattern = @"(var|float)\s+([abc][a-zA-Z0-9]*\d+)\s*=\s*([^;]*?[^a-zA-Z0-9\s][^;]*);";
            
            var matches = Regex.Matches(inputCode, pattern);
            
            // Create a list to store the extracted variables
            var variables = new List<(string VarName, string SpecialSymbol, string TokenType)>();
            
            foreach (Match match in matches)
            {
                string tokenType = match.Groups[1].Value;
                string varName = match.Groups[2].Value;
                string fullValue = match.Groups[3].Value;
                
                
                // Extract special symbol from the value
                string specialSymbol = Regex.Match(fullValue, @"[^a-zA-Z0-9\s.]").Value;

                
                variables.Add((varName, specialSymbol, tokenType));
            }
            
            // Display the results in a table
            Console.WriteLine("\nResults:");
            Console.WriteLine("=======================================================");
            Console.WriteLine("| {0,-15} | {1,-15} | {2,-15} |", "VarName", "SpecialSymbol", "Token Type");
            Console.WriteLine("=======================================================");
            
            foreach (var variable in variables)
            {
                Console.WriteLine("| {0,-15} | {1,-15} | {2,-15} |", 
                    variable.VarName, 
                    variable.SpecialSymbol, 
                    variable.TokenType);
            }
            Console.WriteLine("=======================================================");
            
            if (variables.Count == 0)
            {
                Console.WriteLine("No matching variables found.");
            }
            
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}
