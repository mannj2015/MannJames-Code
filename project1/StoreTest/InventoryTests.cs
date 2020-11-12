using Xunit;
using StoreDB.Models;
using StoreDB.Repos;
using StoreDB;
using System.Linq;
using System.Collections.Generic;

namespace StoreTest
{
    public class InventoryTests
    {
        [Fact]
        public void AddInventoryItem()
        {
            using var context = new StoreContext();
            IInventoryItemRepo repo = new DBRepo(context);

            InventoryItem testII = new InventoryItem();
            testII.LocationId = 1;
            testII.ProductId = 2;
            testII.Quantity = 10;

            repo.AddInventoryItem(testII);

            Assert.NotNull(context.Products.Single(q => q.ProductId == testII.ProductId));
            repo.DeleteInventoryItem(testII);
        }
        [Fact]
        public void UpdateII()
        {
            using var context = new StoreContext();
            IInventoryItemRepo repo = new DBRepo(context);
            
            InventoryItem testII = new InventoryItem();
            testII.LocationId = 1;
            testII.ProductId = 2;
            testII.Quantity = 10;
            repo.AddInventoryItem(testII);

            testII.Quantity = 42;
            repo.UpdateInventoryItem(testII);

            Assert.Equal(42, testII.Quantity);
            repo.DeleteInventoryItem(testII);
        }
/*        [Fact]
        public void GetIIById()
        {
            using var context = new StoreContext();
            IInventoryItemRepo repo = new DBRepo(context);

            InventoryItem testII = new InventoryItem();
            testII.LocationId = 1;
            testII.ProductId = 2;
            testII.Quantity = 10;
            repo.AddInventoryItem(testII);

            Assert.NotNull(repo.GetInventoryItemById(testII.IIId));
            repo.DeleteInventoryItem(testII);
        }*/
        [Fact]
        public void GetAllIIById()
        {
            using var context = new StoreContext();
            IInventoryItemRepo repo = new DBRepo(context);

            InventoryItem testII = new InventoryItem();
            testII.LocationId = 1;
            testII.ProductId = 2;
            testII.Quantity = 10;
            repo.AddInventoryItem(testII);

            Assert.NotNull(repo.GetInventoryItemById(testII.IIId));
            repo.DeleteInventoryItem(testII);
        }
        [Fact]
        public void GetItemByLocAndProdId()
        {
            using var context = new StoreContext();
            IInventoryItemRepo repo = new DBRepo(context);

/*            InventoryItem testII = new InventoryItem();
            testII.LocationId = 1;
            testII.ProductId = 2;
            testII.Quantity = 10;
            repo.AddInventoryItem(testII);*/

            repo.GetItemByLocationIdProductId(1,1);
            //repo.DeleteInventoryItem(testII);
        }
    }
}
