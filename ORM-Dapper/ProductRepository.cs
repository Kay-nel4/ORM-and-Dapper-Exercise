using System.Data;

using Dapper;
namespace ORM_Dapper;

public class ProductRepository : IProductRepository
{
    private readonly IDbConnection _connection;

    public ProductRepository(IDbConnection connection)
    {
        _connection = connection;
    }
    
    public IEnumerable<Product> GetAllProducts()
    {
        return _connection.Query<Product>("SELECT * FROM Products;");
    }

    public void CreateProduct(string name, double price, int categoryID, bool onSale, int stockLevel)
    {
        _connection.Execute("INSERT INTO products (Name, Price, CategoryID, OnSale, StockLevel) VALUES (@name, @price, @categoryID, @onSale, @stockLevel);", 
            new {name, price, categoryID, onSale, stockLevel});
    }

    public void UpdateProduct(string name, double price, int categoryID, bool onSale, int stockLevel, int productId)
    {
        _connection.Execute("UPDATE products SET Name = @name, Price = @price, CategoryID = @categoryId, OnSale = @onSale, StockLevel = @stockLevel WHERE ProductID = @productId;", 
            new {name, price, categoryID, onSale, stockLevel, productId});
    }

    public void DeleteProduct(int productID)
    {
        _connection.Execute("SELECT FROM reviews WHERE ProductID = @productID", new{productID});
        _connection.Execute("SELECT FROM sales WHERE ProductID = @productID", new{productID});
        _connection.Execute("SELECT FROM products WHERE ProductID = @productID", new{productID});
    }
}