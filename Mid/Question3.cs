using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace SymbolTablePalindrome
{
    // Class to represent a symbol table entry
    class Symbol
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Value { get; set; }
        public int LineNumber { get; set; }

        public override string ToString()
        {
            return $"{Name} | {Type} | {Value} | {LineNumber}";
        }
    }

    class Program
    {
        // Symbol table to store variables
        static List<Symbol> symbolTable = new List<Symbol>();
        static int lineCounter = 1;

        static void Main(string[] args)
        {
            Console.WriteLine("Symbol Table with Palindrome Validation");
            Console.WriteLine("======================================");
            Console.WriteLine("Enter variable declarations one line at a time (type 'EXIT' to quit):");

            string input;
            while ((input = Console.ReadLine()) != "EXIT")
            {
                ProcessLine(input);
                lineCounter++;
            }

            // Display the symbol table
            DisplaySymbolTable();

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }

        static void ProcessLine(string line)
        {
            // Pattern to match variable declarations like "int val33 = 999;"
            var match = Regex.Match(line, @"(\w+)\s+(\w+)\s*=\s*([^;]+);");
            
            if (match.Success)
            {
                string type = match.Groups[1].Value;
                string name = match.Groups[2].Value;
                string value = match.Groups[3].Value.Trim();

                // Check if the variable NAME contains a palindrome substring
                string palindromeFound = FindPalindromeSubstring(name, 3);
                
                if (!string.IsNullOrEmpty(palindromeFound))
                {
                    // Add to symbol table
                    symbolTable.Add(new Symbol
                    {
                        Name = name,
                        Type = type,
                        Value = value,
                        LineNumber = lineCounter
                    });
                    
                    Console.WriteLine($"Added: {name} (contains palindrome: '{palindromeFound}')");
                }
                else
                {
                    Console.WriteLine($"Skipped: {name} (no palindrome substring of length >= 3)");
                }
            }
            else
            {
                Console.WriteLine("Invalid declaration format. Expected: \"type name = value;\"");
            }
        }

        static string FindPalindromeSubstring(string str, int minLength)
        {
            // Custom implementation to find palindrome substrings
            for (int i = 0; i < str.Length; i++)
            {
                // Try all possible substring lengths starting from minLength
                for (int len = minLength; i + len <= str.Length; len++)
                {
                    bool isPalindrome = true;
                    string substr = str.Substring(i, len);
                    
                    // Check if this substring is a palindrome
                    for (int j = 0; j < len / 2; j++)
                    {
                        if (substr[j] != substr[len - j - 1])
                        {
                            isPalindrome = false;
                            break;
                        }
                    }
                    
                    if (isPalindrome)
                    {
                        return substr;
                    }
                }
            }
            
            return null;
        }

        static void DisplaySymbolTable()
        {
            Console.WriteLine("\nSymbol Table Contents:");
            Console.WriteLine("=====================================================");
            Console.WriteLine("| Variable Name | Type      | Value      | Line No. |");
            Console.WriteLine("=====================================================");
            
            foreach (var symbol in symbolTable)
            {
                Console.WriteLine($"| {symbol.Name,-13} | {symbol.Type,-9} | {symbol.Value,-10} | {symbol.LineNumber,-8} |");
            }
            
            Console.WriteLine("=====================================================");
            
            if (symbolTable.Count == 0)
            {
                Console.WriteLine("No valid entries in symbol table.");
            }
        }
    }
}
