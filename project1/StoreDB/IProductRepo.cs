using System.Collections.Generic;
using StoreDB.Models;

namespace StoreDB.Repos
{
    public interface IProductRepo
    {
        void AddProduct(Product product);
        void UpdateProduct(Product product);
        Product GetProductById(int productId);
        Product GetProductByName(string productName);
        List<Product> GetAllProducts();
        void DeleteProduct(Product product);
    }
}
