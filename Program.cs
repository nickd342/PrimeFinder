using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace PrimeFinder
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Prime Number Finder");
            Console.WriteLine("===================");

            // Ask user if they want to run
            Console.Write("Do you want to start finding primes? (y/n): ");
            string input = Console.ReadLine()?.ToLower();

            if (input != "y" && input != "yes")
            {
                Console.WriteLine("Operation cancelled.");
                return;
            }

            // Get the range from user
            Console.Write("Enter the upper limit to find primes up to: ");
            if (int.TryParse(Console.ReadLine(), out int limit) && limit > 1)
            {
                var stopwatch = Stopwatch.StartNew();

                // Find primes using Sieve of Eratosthenes for efficiency
                var primes = FindPrimes(limit);

                stopwatch.Stop();

                Console.WriteLine($"\nFound {primes.Count} prime numbers up to {limit}");
                Console.WriteLine($"Time taken: {stopwatch.ElapsedMilliseconds} ms");

                // Ask if user wants to see the primes
                Console.Write("Do you want to display all primes? (y/n): ");
                string displayInput = Console.ReadLine()?.ToLower();

                if (displayInput == "y" || displayInput == "yes")
                {
                    DisplayPrimes(primes);
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number greater than 1.");
            }

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }

        /// <summary>
        /// Finds all prime numbers up to the specified limit using Sieve of Eratosthenes
        /// </summary>
        /// <param name="limit">The upper limit to find primes up to</param>
        /// <returns>List of prime numbers</returns>
        static List<int> FindPrimes(int limit)
        {
            if (limit < 2) return new List<int>();

            // Create a boolean array and initialize all entries as true
            bool[] isPrime = new bool[limit + 1];
            for (int i = 2; i <= limit; i++)
            {
                isPrime[i] = true;
            }

            // Sieve of Eratosthenes algorithm
            for (int i = 2; i * i <= limit; i++)
            {
                if (isPrime[i])
                {
                    // Mark all multiples of i as not prime
                    for (int j = i * i; j <= limit; j += i)
                    {
                        isPrime[j] = false;
                    }
                }
            }

            // Collect all prime numbers
            List<int> primes = new List<int>();
            for (int i = 2; i <= limit; i++)
            {
                if (isPrime[i])
                {
                    primes.Add(i);
                }
            }

            return primes;
        }

        /// <summary>
        /// Displays the list of primes in a formatted way
        /// </summary>
        /// <param name="primes">List of prime numbers to display</param>
        static void DisplayPrimes(List<int> primes)
        {
            if (primes.Count == 0) return;

            Console.WriteLine("\nPrime Numbers:");
            Console.WriteLine("--------------");

            int perLine = 10;
            for (int i = 0; i < primes.Count; i++)
            {
                Console.Write($"{primes[i],6} ");
                if ((i + 1) % perLine == 0)
                {
                    Console.WriteLine();
                }
            }

            if (primes.Count % perLine != 0)
            {
                Console.WriteLine();
            }
        }
    }
}