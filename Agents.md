# Agents.md

## Project Overview

CurrenSee is an API client library designed to interact with the FxRates API. It provides a simple and efficient way to see currency exchange rates.

## Project Structure

```text
-- root
  -- build.ps1 # Build script for the project
  -- Agents.md # You're reading this!
  -- README.md # Project overview and documentation
  -- src
    -- CurrenSee # Main library project
      -- Endpoints # Each subfolder contains class and interface representing an endpoint
        -- Currencies
        -- LatestExchangeRate
      -- Models # Models for deserializing JSON responses
      -- Network # Reusable HttpClient implementation
    -- CurrenSee.CommandLine # Demo command line application
    -- CurrenSee.Tests # Unit tests for the CurrenSee library
```

## Development Commands

`build.ps1` is the project's build script. It is located in the root of the project. It has functions to compile, test, and build the CurrenSee library.

### Available Commands

- Check for compile-time errors: `. .\build.ps1; Compile;`
- Run unit tests: `. .\build.ps1; UnitTests;`
- Create a dev build: `. .\build.ps1; PrivateBuild;`
- Create a production build: `. .\build.ps1; PublicBuild;`

## Coding Style

- When creating constants, use `PascalCase` the `const` keyword in the declaration.
- Method names and auto properties should use `PascalCase`.
- Private fields should use `camelCase`.

## Forbidden Actions

- Do not delete code modules that you have not created.

## Testing Guidelines

- Always use the "Arrange, Act, Assert" pattern in unit tests.
- Declare expected values as constants in the "Arrange" section of each test method.
- Mock dependencies in the "Arrange" section of each test method.
- Call methods in the "Act" section of each test method.
- Do not place method calls in assertion statements.
- Perform assertions in the "Assert" section of each test method.
- Store actual values from method calls in variables before asserting.
- Pass variables containing actual values from method calls to assertion statements.
- Keep unit tests within the scope of the class/interface being tested, i.e., if testing the CurrenSeeClient class, do not test the CurrenciesEndpoint class.
- When writing tests for endpoints that can potentially return hundreds or thousands of items, mock a much smaller subset of data to test.
- If starting with a new test file, clean up any unused boilerplate after implementing tests.

### Testing-related Libraries

- NUnit (test harness and runner)
- Shouldly (library for writing assertions)
- NSubstitute (library for mocking dependencies)
