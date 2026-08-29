[![](https://img.shields.io/nuget/v/soenneker.blazor.utils.ids.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.blazor.utils.ids/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.blazor.utils.ids/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.blazor.utils.ids/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.blazor.utils.ids.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.blazor.utils.ids/)
[![](https://img.shields.io/badge/Demo-Live-blueviolet?style=for-the-badge&logo=github)](https://soenneker.github.io/soenneker.blazor.utils.ids)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.blazor.utils.ids/codeql.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.blazor.utils.ids/actions/workflows/codeql.yml)

# Soenneker.Blazor.Utils.Ids

A lightweight ID generator for consistent identity across the UI for Blazor components.

## Install

```bash
dotnet add package Soenneker.Blazor.Utils.Ids
```

## Quick start

```csharp
using Soenneker.Blazor.Utils.Ids;

var result = BlazorIdGenerator.New("value");
```

Generates a new unique, human-readable ID using the specified prefix.

## What you get

- `BlazorIdGenerator` — A lightweight ID generator for consistent identity across the UI for Blazor components.

## API at a glance

| API | What it does | Result / important behavior |
| --- | --- | --- |
| `BlazorIdGenerator.New(prefix)` | Generates a new unique, human-readable ID using the specified prefix. | A unique ID in the format "{prefix}-{number}", where `number` is a monotonically increasing value. |
| `BlazorIdGenerator.Child(parentId, suffix)` | Creates a derived child ID by appending a suffix to an existing parent ID. | A new ID in the format "{parentId}-{suffix}". |

## Important behavior

- `BlazorIdGenerator.New(prefix)`: The generated ID is guaranteed to be unique within the current process and is suitable for use in DOM elements and ARIA relationships. The numeric portion is generated using a thread-safe incrementing counter.
- `BlazorIdGenerator.New(prefix)`: Thrown when `prefix` is null, empty, or consists only of whitespace.
- `BlazorIdGenerator.Child(parentId, suffix)`: This method is typically used to generate related element IDs (e.g., trigger, content, label) that share a common root identifier for accessibility and structural consistency.
- `BlazorIdGenerator.Child(parentId, suffix)`: Thrown when `parentId` or `suffix` is null, empty, or consists only of whitespace.
