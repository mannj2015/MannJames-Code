using Xunit;
using StoreDB.Models;
using StoreDB.Repos;
using StoreDB;
using System.Linq;
using System.Collections.Generic;

namespace StoreTest
{
    public class ProductTests
    {

        [Fact]
        public void AddProduct()
        {
            using var context = new StoreContext();
            IProductRepo repo = new DBRepo(context);

            Product testProd2 = new Product();
            testProd2.Price = 1.00F;
            testProd2.ProductName = "testProd2";

            repo.AddProduct(testProd2);
            Assert.NotNull(context.Products.Single(q => q.ProductId == testProd2.ProductId));

            repo.DeleteProduct(testProd2);
        }

        [Fact]
        public void UpdateProduct()
        {
            using var context = new StoreContext();
            IProductRepo repo = new DBRepo(context);

            Product testProd = new Product();
            testProd.Price = 1.00F;
            testProd.ProductName = "testProd";
            repo.AddProduct(testProd);

            testProd.ProductName = "Something Different";
            repo.UpdateProduct(testProd);
            Assert.Equal("Something Different", testProd.ProductName);

            repo.DeleteProduct(testProd);
        }
        [Fact]
        public void GetProductById()
        {
            using var context = new StoreContext();
            IProductRepo repo = new DBRepo(context);

            Product testProd = new Product();
            testProd.Price = 1.00F;
            testProd.ProductName = "testProd";
            repo.AddProduct(testProd);

            Assert.NotNull(repo.GetProductById(testProd.ProductId));
            repo.DeleteProduct(testProd);
        }
        [Fact]
        public void GetProductByName()
        {
            using var context = new StoreContext();
            IProductRepo repo = new DBRepo(context);

            Product testProd3 = new Product();
            testProd3.Price = 3.00F;
            testProd3.ProductName = "3testProd";
            repo.AddProduct(testProd3);

            Assert.NotNull(repo.GetProductByName(testProd3.ProductName));
            repo.DeleteProduct(testProd3);
        }
        [Fact]
        public void GetAllProducts()
        {
            using var context = new StoreContext();
            IProductRepo repo = new DBRepo(context);

            Product testProd = new Product();
            testProd.Price = 1.00F;
            testProd.ProductName = "testProd";
            repo.AddProduct(testProd);

            List<Product> results = repo.GetAllProducts();
            repo.DeleteProduct(testProd);
        }
    }
}
