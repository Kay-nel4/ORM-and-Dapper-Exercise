using System;
using System.Data;
using System.IO;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;
using ORM_Dapper;

//^^^^MUST HAVE USING DIRECTIVES^^^^

var config = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json")
    .Build();
string connString = config.GetConnectionString("DefaultConnection");
IDbConnection conn = new MySqlConnection(connString);

var departmentRepo = new DepartmenteRepository(conn);

//departmentRepo.AddDepartment("Practice");

var departments = departmentRepo.GetAllDepartments();
foreach (var dep in departments)
{
    Console.WriteLine($"Name: {dep.Name} | ID: {dep.DepartmentID}");
}
var prodRepo = new ProductRepository(conn);

//prodRepo.CreateProduct("Airwrap", 500, 2, false,4 );
//prodRepo.UpdateProduct("Dyson Airwrap", 550, 2,false,4, 941);
//prodRepo.DeleteProduct(941);

Console.ForegroundColor = ConsoleColor.Blue;
var products = prodRepo.GetAllProducts();
foreach (var product in products)
{
    Console.WriteLine($"Name: {product.Name} | ID: {product.ProductID} | Price: {product.Price} | CategoryID: {product.CategoryID} | OnSale: {product.OnSale} | Stock: {product.StockLevel}");
}
//Just wanted to see if the bool was working on the sale column.
//foreach (var product in products)
//    if (product.OnSale == false)
//    {
//        Console.WriteLine("Not on sale");
//    }
//    else
//    {
//        {
//            Console.WriteLine("On sale");
//        }
//    }

//Also trying to figure out why my lines are printing staggered and not just straight across.

