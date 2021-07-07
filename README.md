# PersistentBits

Collection of components for handling persistent data.

## FileSystem

A very basic abstraction for a file system.
Provides simple objects and functions for traversing a file system,
reading and writing files.

```csharp
using Bridgefield.PersistentBits;

var filesystem = OS.FileSystem();

... inject into other components or add to dependency injection container of your choice
```
