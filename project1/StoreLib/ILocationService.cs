using System;
using System.Collections.Generic;
using System.Text;
using StoreDB.Models;

namespace StoreLib
{
    public interface ILocationService
    {
        public void AddLocation(Location location);
        public void UpdateLocation(Location location);
        public Location GetLocationById(int id);
        public List<Location> GetLocationByState(string state);
        public List<Location> GetLocationByCity(string city);
        public List<Location> GetLocationByZipcode(string zipcode);
        public List<Location> GetAllLocations();
        public void DeleteLocation(Location location);
    }
}