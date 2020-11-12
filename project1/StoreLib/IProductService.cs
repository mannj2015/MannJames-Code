using System.Collections.Generic;
using StoreDB.Models;

namespace StoreLib
{
    public interface IProductService
    {
        public void AddProduct(Product product);
        public void UpdateProduct(Product product);
        public Product GetProductByProductId(int productId);
        public Product GetProductByName(string productName);
        public List<Product> GetAllProducts();
        public void DeleteProduct(Product product);
    }
}