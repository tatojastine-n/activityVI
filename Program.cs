using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactDeduplicator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> names = new List<string>();
            Console.WriteLine("Contact List Processor");
            Console.WriteLine("Enter at least 15 names (some duplicates allowed):");
            Console.WriteLine("Type 'done' after entering at least 15 names");

            while (names.Count < 15)
            {
                Console.Write($"{names.Count + 1}. ");
                string input = Console.ReadLine()?.Trim(); // Handle null with null-conditional operator

                if (input.Equals("done", StringComparison.OrdinalIgnoreCase) && names.Count >= 15)
                    break;

                if (!string.IsNullOrWhiteSpace(input))
                {
                    names.Add(input);
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid name.");
                }
            }
            var distinctSortedNames = names
            .Distinct(StringComparer.OrdinalIgnoreCase)
            .OrderBy(name => name, StringComparer.OrdinalIgnoreCase)
            .ToList();

            Console.WriteLine("\nProcessed Contact List (No Duplicates, Sorted):");

            foreach (string name in distinctSortedNames)
            {
                Console.WriteLine($"- {name}");
            }
            Console.WriteLine($"\nTotal unique contacts: {distinctSortedNames.Count}");
        }
    }
}
