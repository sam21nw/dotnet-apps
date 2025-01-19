using Northwind.EntityModels;

using NorthwindDb db = new();
Console.WriteLine($"Provider: {db.Database.ProviderName}");

ConfigureConsole();

while (true)
{
    QueryingCategories();
    // GetRandomProduct();
    // FilteredIncludes();
    // QueryingProducts();
    // GettingOneProduct();
    // QueryingWithLike();

    string? input = Console.ReadLine();
    if (input?.ToLower() == "q") { break; }
}