using StoreDB.Models;
using StoreDB.Repos;
using System.Collections.Generic;

namespace StoreLib
{
    public class LocationService:ILocationService
    {
        private ILocationRepo repo;
        public LocationService(ILocationRepo repo)
        {
            this.repo = repo;
        }

        public void AddLocation(Location location)
        {
            repo.AddLocation(location);
        }
        public void UpdateLocation(Location location)
        {
            repo.UpdateLocation(location);
        }
        public Location GetLocationById(int id)
        {
            return repo.GetLocationById(id);
        }
        public List<Location> GetLocationByState(string state)
        {
            List<Location> results = repo.GetLocationByState(state);
            return results;
        }
        public List<Location> GetLocationByCity(string city)
        {
            List<Location> results = repo.GetLocationByCity(city);
            return results;
        }
        public List<Location> GetLocationByZipcode(string zipcode)
        {
            List<Location> results = repo.GetLocationByZipcode(zipcode);
            return results;
        }
        public List<Location> GetAllLocations()
        {
            List<Location> results = repo.GetAllLocations();
            return results;
        }
        public void DeleteLocation(Location location)
        {
            repo.DeleteLocation(location);
        }
    }
}
