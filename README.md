[![](https://img.shields.io/nuget/v/soenneker.blazor.utils.ids.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.blazor.utils.ids/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.blazor.utils.ids/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.blazor.utils.ids/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.blazor.utils.ids.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.blazor.utils.ids/)
[![](https://img.shields.io/badge/Demo-Live-blueviolet?style=for-the-badge&logo=github)](https://soenneker.github.io/soenneker.blazor.utils.ids)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.blazor.utils.ids/codeql.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.blazor.utils.ids/actions/workflows/codeql.yml)

# ![](https://user-images.githubusercontent.com/4441470/224455560-91ed3ee7-f510-4041-a8d2-3fc093025112.png) Soenneker.Blazor.Utils.Ids
### A lightweight ID generator for consistent identity across the UI for Blazor components.

## Installation

```bash
dotnet add package Soenneker.Blazor.Utils.Ids
```

## Setup

Register services in `Program.cs`:

```csharp
builder.Services.AddBlazorIdGeneratorAsScoped();
```

Inject the higher-level utility where you need it:

```csharp
@inject IBlazorIdGenerator Ids
```

## Usage

Initialize the package once before first use:

```csharp
await Ids.Initialize();
```
