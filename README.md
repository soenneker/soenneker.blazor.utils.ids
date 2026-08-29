[![](https://img.shields.io/nuget/v/soenneker.blazor.utils.ids.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.blazor.utils.ids/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.blazor.utils.ids/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.blazor.utils.ids/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.blazor.utils.ids.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.blazor.utils.ids/)
[![](https://img.shields.io/badge/Demo-Live-blueviolet?style=for-the-badge&logo=github)](https://soenneker.github.io/soenneker.blazor.utils.ids)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.blazor.utils.ids/codeql.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.blazor.utils.ids/actions/workflows/codeql.yml)

# Soenneker.Blazor.Utils.Ids

A thread-safe, allocation-conscious generator for related DOM IDs in Blazor components.

It produces readable process-unique IDs such as `email-42` and derived IDs such as `email-42-label`, making it useful for `id`, `for`, `aria-labelledby`, and `aria-describedby` relationships.

## Installation

```bash
dotnet add package Soenneker.Blazor.Utils.Ids
```

No service registration is required.

## Generate once per component instance

Store the generated ID in a field so it remains stable across renders:

```razor
@using Soenneker.Blazor.Utils.Ids

<label id="@_labelId" for="@_inputId">Email</label>
<input id="@_inputId" aria-labelledby="@_labelId" />

@code {
    private string _inputId = null!;
    private string _labelId = null!;

    protected override void OnInitialized()
    {
        _inputId = BlazorIdGenerator.New("email");
        _labelId = BlazorIdGenerator.Child(_inputId, "label");
    }
}
```

Do not call `New` directly in Razor markup, a computed property, or `BuildRenderTree`; each call consumes a new number and would change the element ID on subsequent renders.

## Generate related IDs

```csharp
string rootId = BlazorIdGenerator.New("dialog");
string titleId = BlazorIdGenerator.Child(rootId, "title");
string contentId = BlazorIdGenerator.Child(rootId, "content");
```

`Child` only concatenates the parent and suffix. It does not reserve or independently guarantee uniqueness, so use distinct suffixes beneath a unique parent.

Prefixes, parent IDs, and suffixes must be non-empty and cannot contain whitespace. Other characters are preserved. If an ID is later embedded in a CSS selector, escape it with `CSS.escape` rather than assuming every valid DOM ID is a valid unescaped CSS identifier.

## Uniqueness and rendering boundaries

`New` uses one atomic, monotonically increasing counter for the process. Values are unique among calls in that process, but they are not stable across application restarts and are not coordinated across multiple server processes or browser tabs.

Server prerendering and client-side rendering run in different processes. Do not expect a newly generated client ID to reproduce the server value. When continuity across that boundary matters, persist the value with Blazor state transfer or derive it from stable application data.

The numeric suffix is predictable. These IDs are for UI identity, not secrets, authorization checks, CSRF protection, public resource identifiers, or security tokens.
