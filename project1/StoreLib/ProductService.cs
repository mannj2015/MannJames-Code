using System.Collections.Generic;
using StoreDB.Repos;
using StoreDB.Models;

namespace StoreLib
{
    public class ProductService:IProductService
    {
        private IProductRepo repo;
        public ProductService(IProductRepo repo)
        {
            this.repo = repo;
        }

        public void AddProduct(Product product)
        {
            repo.AddProduct(product);
        }

        public void UpdateProduct(Product product)
        {
            repo.UpdateProduct(product);
        }
        public Product GetProductByProductId(int productId)
        {
            Product product = repo.GetProductById(productId);
            return product;
        }

        public Product GetProductByName(string productName)
        {
            Product product = repo.GetProductByName(productName);
            return product;
        }

        public List<Product> GetAllProducts()
        {
            List<Product> products = repo.GetAllProducts();
            return products;
        }
        public void DeleteProduct(Product product)
        {
            repo.DeleteProduct(product);
        }
    }
}
