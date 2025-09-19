# Core.Persistence

A robust, extensible persistence layer for .NET 8 applications, providing generic repository abstractions and implementations using Entity Framework Core. This package simplifies data access, supports dynamic queries, and enables efficient paging, sorting, and filtering.

## Features

- Generic asynchronous repository interfaces (`IAsyncRepository`)
- Entity Framework Core repository base (`EfRepositoryBase`)
- Dynamic querying and filtering (`DynamicQuery`, `Filter`, `Sort`)
- Paging support (`Paginate`)
- Soft and hard delete operations
- Tracking and query filter control
- .NET 8 and C# 12 compatible

## Getting Started

### Installation

Add the package reference to your project:

Or clone the repository: git clone https://github.com/TheBekurt/Core.Packages.git

### Dependencies

- [Microsoft.EntityFrameworkCore](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore) (v9.0.9)
- [Microsoft.Data.SqlClient](https://www.nuget.org/packages/Microsoft.Data.SqlClient) (v6.1.1)
- [System.Linq.Dynamic.Core](https://www.nuget.org/packages/System.Linq.Dynamic.Core) (v1.6.7)

### Usage

1. **Define your entity:**

    ```csharp
    public class Product : Entity<Guid>
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
    ```

2. **Create your DbContext:**

    ```csharp
    public class AppDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
    }
    ```

3. **Implement the repository:**

    ```csharp
    public class ProductRepository : EfRepositoryBase<Product, Guid, AppDbContext>
    {
        public ProductRepository(AppDbContext context) : base(context) { }
    }
    ```

4. **Use the repository:**

    ```csharp
    var repo = new ProductRepository(context);
    var products = await repo.GetListAsync(p => p.Price > 10);
    ```

## API Overview

- `IAsyncRepository<TEntity, TEntityId>`: Generic async repository interface
- `EfRepositoryBase<TEntity, TEntityId, TContext>`: EF Core implementation
- `DynamicQuery`, `Filter`, `Sort`: Dynamic query support
- `Paginate<T>`: Paging result model

## Contributing

Contributions, issues, and feature requests are welcome!  
Please open an issue or submit a pull request.

## License

This project is licensed under the MIT License.

## Author

Maintained by [TheBekurt](https://github.com/TheBekurt).