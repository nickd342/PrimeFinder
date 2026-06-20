#include <iostream>
#include <vector>
#include <chrono>
#include <cmath>

using namespace std;
using namespace chrono;

// Function to find all prime numbers up to a given limit using Sieve of Eratosthenes
vector<int> findPrimes(int limit) {
    if (limit < 2) return {};

    // Create a boolean array and initialize all entries as true
    vector<bool> isPrime(limit + 1, true);
    isPrime[0] = isPrime[1] = false; // 0 and 1 are not prime numbers

    // Sieve of Eratosthenes algorithm
    for (int i = 2; i * i <= limit; i++) {
        if (isPrime[i]) {
            // Mark all multiples of i as not prime
            for (long long j = (long long)i * i; j <= limit; j += i) {
                isPrime[j] = false;
            }
        }
    }

    // Collect all prime numbers
    vector<int> primes;
    for (int i = 2; i <= limit; i++) {
        if (isPrime[i]) {
            primes.push_back(i);
        }
    }

    return primes;
}

// Function to display primes in a formatted way
void displayPrimes(const vector<int>& primes) {
    if (primes.empty()) return;

    cout << "\nPrime Numbers:" << endl;
    cout << "--------------" << endl;

    const int perLine = 10;
    for (size_t i = 0; i < primes.size(); i++) {
        cout.width(6);
        cout << primes[i] << " ";
        if ((i + 1) % perLine == 0) {
            cout << endl;
        }
    }

    if (primes.size() % perLine != 0) {
        cout << endl;
    }
}

int main() {
    cout << "Prime Number Finder" << endl;
    cout << "===================" << endl;

    // Ask user if they want to run
    cout << "Do you want to start finding primes? (y/n): ";
    char choice;
    cin >> choice;

    if (choice != 'y' && choice != 'Y') {
        cout << "Operation cancelled." << endl;
        return 0;
    }

    // Get the range from user
    cout << "Enter the upper limit to find primes up to: ";
    int limit;
    cin >> limit;

    if (limit < 2) {
        cout << "Invalid input. Please enter a number greater than 1." << endl;
        return 1;
    }

    // Start timing
    auto start = high_resolution_clock::now();

    // Find primes
    vector<int> primes = findPrimes(limit);

    auto stop = high_resolution_clock::now();
    auto duration = duration_cast<milliseconds>(stop - start);

    cout << "\nFound " << primes.size() << " prime numbers up to " << limit << endl;
    cout << "Time taken: " << duration.count() << " ms" << endl;

    // Ask if user wants to see the primes
    cout << "Do you want to display all primes? (y/n): ";
    char displayChoice;
    cin >> displayChoice;

    if (displayChoice == 'y' || displayChoice == 'Y') {
        displayPrimes(primes);
    }

    cout << "\nPress any key to exit..." << endl;
    cin.ignore();
    cin.get();

    return 0;
}