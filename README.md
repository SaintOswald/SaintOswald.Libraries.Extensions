# SaintOswald.Libraries.Extensions

A collection of useful, reusable Extension Methods for C#

## Installation

Install via NuGet Package Manager Console:

`PM> Install-Package SaintOswald.Libraries.Extensions`

## Usage

Include the relevant Extension Methods you wish to use, such as:

`using SaintOswald.Libraries.Extensions.StringExtensions;`

The included Extension Methods will then be available for use:

```c#
string title = "This is my title";
string slug = title.ToSlug();  // this-is-my-title
```

## Documentation

Documentation is available in the project [Wiki](https://github.com/SaintOswald/SaintOswald.Libraries.Extensions/wiki)

## Compatibility

Targets .NET Framework 4 or later