# PrimeFinder

A simple and efficient prime number finder application.

## Features

- Uses the Sieve of Eratosthenes algorithm for optimal performance
- Interactive user interface with prompts
- Shows execution time
- Option to display all found primes

## How to Build and Run

### Prerequisites

- C++ compiler (g++, clang++, etc.)
- Make (for building)

### Building

```bash
make
```

### Running

```bash
make run
```

Or manually:
```bash
g++ -std=c++11 -O3 -Wall prime_finder.cpp -o prime_finder
./prime_finder
```

## Algorithm

The application uses the **Sieve of Eratosthenes** algorithm which is one of the most efficient ways to find all prime numbers up to a given limit. The time complexity is O(n log log n) and space complexity is O(n).

## Usage

1. Run the program
2. Confirm you want to start finding primes
3. Enter the upper limit for prime search
4. Choose whether to display all found primes
5. View results and execution time

## Example Output

```
Prime Number Finder
===================
Do you want to start finding primes? (y/n): y
Enter the upper limit to find primes up to: 100

Found 25 prime numbers up to 100
Time taken: 1 ms
Do you want to display all primes? (y/n): y

Prime Numbers:
--------------
     2      3      5      7     11     13     17     19     23     29 
    31     37     41     43     47     53     59     61     67     71 
    73     79     83     89     97 
```