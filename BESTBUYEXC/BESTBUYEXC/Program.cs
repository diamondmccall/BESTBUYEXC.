
using System;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System.Data;
using BESTBUYEXC;

namespace BESTBUYEXC
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                 .SetBasePath(Directory.GetCurrentDirectory())
                 .AddJsonFile("appsettings.json")
                 .Build();

            string connString = config.GetConnectionString("DefaultConnection");

            IDbConnection conn = new MySqlConnection(connString);


            var repoProd = new DapperProductRepository(conn);
            var products = repoProd.GetAllProducts();

            Console.WriteLine("What is the name of your new product?");
            var prodName = Console.ReadLine();

            Console.WriteLine("What is the price of the product?");
            var prodPrice = double.Parse(Console.ReadLine());

            Console.WriteLine("What is the category ID?");
            var prodCatId = int.Parse(Console.ReadLine());

            repoProd.CreateProduct(prodName, prodPrice, prodCatId);



            foreach (var prod in products)
            {
                Console.WriteLine($"{prod.ProductID} {prod.Name} {prod.CategoryID} {prod.OnSale} {prod.Price} {prod.StockLevel}");
            }



            var repo = new DapperDepartmentRepository(conn);
            var departments = repo.GetAllDepartments();


            foreach (var dept in departments)
            {
                Console.WriteLine($"{dept.DepartmentID} {dept.Name}");
            }


            Console.WriteLine("What is the ProductID you would like to update?");
            var prodID = int.Parse(Console.ReadLine());

            Console.WriteLine("What is the new product name?");
            var newName = Console.ReadLine();

            repoProd.UpdateProductName (prodID, newName);


            Console.WriteLine("What is the product ID you would like to delete?");
            prodID = int.Parse(Console.ReadLine());

            repoProd.DeleteProduct(prodID);

        }
    }
}
