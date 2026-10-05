# Longest Increasing Subsequence Solver

A high-performance C# .NET solution designed to calculate the earliest occurring Longest Increasing Subsequence from an arbitrary string sequence of whitespace-delimited integers.

## Prerequisites
- [.NET 8.0 SDK](https://microsoft.com) OR [Docker Desktop](https://docker.com)

## Local Machine Verification Steps

### 1. Execute Code Formatting Linting Check
Ensure codebase syntax matches formatting guidelines:
```bash
dotnet format --verify-no-changes
```

### 2. Run Solution Tests
Execute our custom test suite locally:
```bash
dotnet test
```

### 3. Generate Local Coverage Profiles
To view code execution paths and line diagnostics:
```bash
dotnet test --collect:"XPlat Code Coverage"
```

## Docker Containerization Verification

The solver is a class library, not a standalone executable. Building this SDK-based verification image restores dependencies, checks formatting, and runs the tests with coverage; it does not create a runtime image:

```bash
# Build and verify the project in Docker
docker build -t subsequence-solver:latest .
```
