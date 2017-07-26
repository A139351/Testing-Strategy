Some ideas around how we might handle testing moving forward.

## AGL.Testing.xUnit
This would ultimately be stripped out in to a NuGet package. It provides a basic fixture to allow spinning up of an OWIN server for Isolated Integration Testing. This could be expanded upon to allow use with other testing frameworks if required.

## AGL.Sample.API.Unit.Tests
Basic Unit Tests. Nothing overly exciting to see here.

## AGL.Sample.API.Integration.Tests
An example of how we might run Isolated Integration Tests using an Owin Fixture and testing the actual outcome of actions, rather than internal implentation.

## AGL.Sample.API.BDD.Tests
Tests using BDDfy to provide reverse engineered BDD Syntax based on the way tests are written. There are two styles here:

1. Individual file for each "scenario" being tested. See `Features\Numeric\CalculatorController\AddTwoNumbers.cs`
2. Fluent tests written using a collection of "steps". See `Features\Numeric\CalculatorController\Fluent` folder.

## Core Ideals
- Minimise the amount of shared code while still providing easy to setup tests. Shared code often reduces the effectiveness of tests.
- Unit tests should test results, not implementation.
- Isolated Integration Tests should provide a level of End-to-End testing based on expected results, not internal implementation.
