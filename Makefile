# Simple Makefile for PrimeFinder

CXX = g++
CXXFLAGS = -std=c++11 -O3 -Wall -Wextra

TARGET = prime_finder
SOURCE = prime_finder.cpp

$(TARGET): $(SOURCE)
	$(CXX) $(CXXFLAGS) -o $(TARGET) $(SOURCE)

run: $(TARGET)
	./$(TARGET)

clean:
	rm -f $(TARGET)

.PHONY: run clean