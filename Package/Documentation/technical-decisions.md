---
uid: technical-decisions
---

# Technical Decisions

This page documents the key design decisions made in the **SLC-AS-GetViews** script, along with the rationale behind each choice.

## Interface-Based DataMiner Access (`IDms` / `IEngine`)

The script uses `IEngine` and `IDms` interfaces from the `Skyline.DataMiner.Core.DataMinerSystem` library rather than concrete implementations.

**Rationale:** Programming against interfaces decouples the script logic from the underlying DataMiner communication layer. This makes the code easier to unit test by substituting mock implementations, and ensures the script remains compatible with future changes to the DataMiner SDK without requiring logic rewrites.

## Recursive `ProcessViews` Design

View traversal is handled by a private `ProcessViews` method that calls itself for each level of child views:

```csharp
private void ProcessViews(IEngine engine, IEnumerable<IDmsView> views, int recursionLevel, int currentLevel)
```

The method carries both the user-configured `recursionLevel` ceiling and the `currentLevel` counter, stopping recursion when `currentLevel >= recursionLevel`.

**Rationale:** Recursion naturally mirrors the tree structure of DataMiner views. It avoids maintaining an explicit stack or queue, keeps the code concise, and makes it straightforward to reason about depth boundaries.

## `IndentationSpaces` Constant

Indentation width is defined as a named constant rather than a magic number:

```csharp
private const int IndentationSpaces = 2;
```

**Rationale:** A named constant makes the intent clear and allows the indentation style to be changed in one place without hunting through the method body.

## Default `RecursionLevel` of 1

When `RecursionLevel` is not provided or cannot be parsed as a valid integer, the script silently defaults to `1` (direct children only) rather than failing.

**Rationale:** Defaulting to the shallowest traversal is the safest option on large DataMiner systems, where a deep traversal from a high-level root view could produce an overwhelming number of log entries. The user can always opt into deeper traversal by explicitly setting the parameter.

## Exception Boundary Strategy (`ExitFail`)

All script logic is wrapped in a single `try/catch` block. Caught exceptions call `engine.ExitFail(...)` with a human-readable message; no exceptions are swallowed silently.

**Rationale:** DataMiner Automation scripts need to signal failure to the platform so that dependent workflows or correlated alarms can react correctly. `ExitFail` ensures the script is marked as failed in the Automation log rather than completing with a misleading success status.

## Input Validation Approach

Input validation follows three consistent patterns:

| Pattern | Usage |
|---|---|
| Null-coalescing (`?? "Name"`) | Provide safe defaults for optional parameters that may not be set at all. |
| `int.TryParse` | Parse numeric inputs without throwing, with a controlled fallback value. |
| `StringComparison.OrdinalIgnoreCase` | Compare the `RootViewInputType` string in a culture-invariant, case-insensitive way. |

**Rationale:** These patterns avoid unnecessary exceptions for predictable bad-input scenarios, keep the code readable, and ensure consistent behavior regardless of the locale of the DataMiner Agent running the script.
