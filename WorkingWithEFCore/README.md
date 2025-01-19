# Working with EFCore

## Commands
```poweshell
dotnet ef dbcontext scaffold "Data Source=Northwind.db" Microsoft.EntityFrameworkCore.Sqlite --table Categories --table Products --output-dir AutoGenModels --namespace WorkingWithEFCore.AutoGen --data-annotations --context NorthwindDb

```