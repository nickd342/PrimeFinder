@echo off
echo Prime Number Finder
echo ===================
echo.

echo Do you want to start finding primes? (y/n):
set /p choice=
if /i "%choice%" neq "y" (
    echo Operation cancelled.
    pause
    exit /b
)

echo Enter the upper limit to find primes up to:
set /p limit=

if %limit% LSS 2 (
    echo Invalid input. Please enter a number greater than 1.
    pause
    exit /b
)

echo.
echo Finding primes up to %limit%...
g++ -std=c++11 -O3 -Wall prime_finder.cpp -o prime_finder.exe
if %errorlevel% equ 0 (
    echo.
    prime_finder.exe
) else (
    echo Failed to compile the program.
)

pause