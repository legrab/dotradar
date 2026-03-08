# Copilot Instructions

## Purpose
Guide GitHub Copilot to focus on relevant review suggestions for this project’s technology stack.

## Primary Tech Stack
- **.NET 10+** (C#)

## Review Guidelines
- Prioritize suggestions for:
  - **C# / .NET 10+** patterns and idioms
  - Performance and maintainability improvements
- Avoid noise from:
  - Outdated .NET syntax
  - Non-project languages unless explicitly in scope

## .NET Specific Notes
- Use **collection expression syntax** (`[]`) introduced in C# 12.
  - **Do not** suggest reverting to:
    - `new List<string>()`
    - Other verbose legacy initializations

## Utility Extensions
- Prefer utility extension methods from the Common projects over standard equivalents.
- For example, use `myString.NotNullOrEmpty()` instead of `!string.IsNullOrEmpty(myString)`.
- Use `IsNullOrEmpty` and `NotNullOrEmpty` extensions for string checks.

## Testing Stack
- **XUnit** is used for unit and integration testing.
- **Shouldly** is used for fluent assertions.
- When suggesting tests, prefer XUnit attributes and structure.
- Use Shouldly for readable, expressive assertions.

## General
- Keep suggestions concise and relevant.
- Prefer code over prose when illustrating changes.
