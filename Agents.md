# Agents.md

## Project Overview

CurrenSee is an API client library designed to interact with the FxRates API. It provides a simple and efficient way to see currency exchange rates.

## Project Structure

```text
-- root
  -- build.ps1 # Build script for the project
  -- Agents.md # You're reading this!
  -- README.md # Project overview and documentation
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

`build.ps1` is the project's build script. It has functions to compile, test, and build the CurrenSee library.