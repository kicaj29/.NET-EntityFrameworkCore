# .NET-EntityFrameworkCore
Samples with EntityFrameworkCore

## EFcoreDeletingRows
Example shows that in EF Core 2.2.0 the same instance of DBContext can be manipulated between multiple ```SaveChanges()``` calls.
The same instance can be used within explicit transaction (```BeginTransaction()``` call) or implicit transaction (```dbContext.SaveChanges()``` call does commit operation).   
It did not work well in EF Core 2.0.0.
