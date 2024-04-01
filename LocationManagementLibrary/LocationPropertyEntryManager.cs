﻿

using DataAccessLayer.Interface;
using LocationManagementLibrary.Interfaces;
using Models;

namespace LocationManagementLibrary
{
    public class LocationPropertyEntryManager : ILocationPropertyEntryManager
    {
        private readonly ILocationManager _locationManager;
        public LocationPropertyEntryManager(ILocationManager locationManager)
        {
            _locationManager = locationManager;
        }

        public static void DisplayLocationList(List<LocationModel> locationList)
        {

            for (int i = 0; i < locationList.Count; i++)
            {
                Console.WriteLine($"{i + 2}.  {locationList[i].Name}");
            }
        }
        public string ChooseLocation( )
        {
            List<LocationModel> locationList = _locationManager.GetAll();
            Console.WriteLine("Locations:");
            Console.WriteLine("0. Exit");
            Console.WriteLine("1. Add New Location");
            DisplayLocationList(locationList);
            Console.Write("Choose Location from above options:");
            int option;
            int.TryParse(Console.ReadLine(), out option);
            if(option==0)
            {
                return "Abort";
            }
            if (option == 1)
            {
                Console.Write("Enter new Location:");
                string location = Console.ReadLine().ToUpper();
                LocationModel locationModel = new LocationModel();
                locationModel.Name = location;
                if(_locationManager.AddLocation(locationModel))
                {
                    Console.WriteLine("Location Added Successfully");
                    return locationModel.Name;
                }
                else
                {
                    Console.WriteLine("Entered Location is previously exists in the database.");
                   return ChooseLocation();
                }
                
            }
            if (option > 1 && option <= locationList.Count+1)
            {
                return locationList[option - 2].Name;
            }
            else
            {
                Console.WriteLine("Select option from the above list only");
                return ChooseLocation();
            }
        }
    }
}
