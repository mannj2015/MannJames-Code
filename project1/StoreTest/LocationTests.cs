using Xunit;
using StoreDB.Models;
using StoreDB.Repos;
using StoreDB;
using System.Linq;
using System.Collections.Generic;

namespace StoreTest
{
    public class LocationTests
    {
        [Fact]
        public void GetAllLocations()
        {
            using var context = new StoreContext();
            ILocationRepo repo = new DBRepo(context);

            Location testLoc = new Location();
            testLoc.Street = "101";
            testLoc.StreetNumber = "Windsor Dr";
            testLoc.City = "Liverpool";
            testLoc.State = "Connecticut";
            testLoc.ZipCode = "19293";
            repo.AddLocation(testLoc);

            Assert.NotNull(repo.GetAllLocations());
            repo.DeleteLocation(testLoc);
        }
        [Fact]
        public void AddLocation()
        {
            using var context = new StoreContext();
            ILocationRepo repo = new DBRepo(context);

            Location testLoc = new Location();
            testLoc.Street = "101";
            testLoc.StreetNumber = "Windsor Dr";
            testLoc.City = "Liverpool";
            testLoc.State = "Connecticut";
            testLoc.ZipCode = "19293";
            repo.AddLocation(testLoc);

            Assert.NotNull(context.Locations.Single(q => q.LocationId == testLoc.LocationId));
            repo.DeleteLocation(testLoc);
        }
        [Fact]
        public void UpdateLocation()
        {
            using var context = new StoreContext();
            ILocationRepo repo = new DBRepo(context);

            Location testLoc = new Location();
            testLoc.Street = "101";
            testLoc.StreetNumber = "Windsor Dr";
            testLoc.City = "Liverpool";
            testLoc.State = "Connecticut";
            testLoc.ZipCode = "19293";
            repo.AddLocation(testLoc);

            testLoc.State = "MS";
            repo.UpdateLocation(testLoc);
            Assert.Equal("MS", testLoc.State);

            repo.DeleteLocation(testLoc);

        }
        [Fact]
        public void GetLocationById()
        {
            using var context = new StoreContext();
            ILocationRepo repo = new DBRepo(context);

            Location testLoc = new Location();
            testLoc.Street = "101";
            testLoc.StreetNumber = "Windsor Dr";
            testLoc.City = "Liverpool";
            testLoc.State = "Connecticut";
            testLoc.ZipCode = "19293";
            repo.AddLocation(testLoc);

            Assert.NotNull(repo.GetLocationById(testLoc.LocationId));
            repo.DeleteLocation(testLoc);
        }
    }
}
