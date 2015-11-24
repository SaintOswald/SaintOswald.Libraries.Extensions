# SaintOswald.Libraries.Extensions

A collection of useful, reusable Extension Methods for C#

## Usage

Include the relevant Extension Methods you wish to use, such as:

`using SaintOswald.Libraries.Extensions.StringExtensions;`

The included Extension Methods will then be available for use:

```c#
string title = "This is my title";
string slug = title.ToSlug();  // this-is-my-title
```

## Compatibility

Due to the use of new C# 6.0 features .NET Framework 4.6 is required