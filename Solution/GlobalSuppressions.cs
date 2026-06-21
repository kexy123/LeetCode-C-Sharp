// This file is used by Code Analysis to maintain SuppressMessage
// attributes that are applied to this project.
// Project-level suppressions either have no target or are given
// a specific target and scoped to a namespace, type, member, etc.

using System.Diagnostics.CodeAnalysis;

// All LeetCode C# snippets do not declare an explicit namespace,
// albeit it is called Solutions.
[assembly: SuppressMessage("Design", "CA1050:Declare types in namespaces", Justification = "<Pending>", Scope = "type", Target = "~T:Solution")]

// Will cause an error when compiling in the LeetCode editor.
[assembly: SuppressMessage("Performance", "CA1822:Mark members as static", Justification = "<Pending>", Scope = "type", Target = "~T:Solution")]
