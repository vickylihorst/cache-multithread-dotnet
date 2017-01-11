# cache-multithread-dotnet

This C# program creates multiple connections to InterSystems' Cache database in multiple threads using the ADO.NET Managed Provider classes.

The purpose of this program is to debug the .NET driver code, which requires at least 2 CachePoolManager.GetConnection() calls made at the same millisecond.

