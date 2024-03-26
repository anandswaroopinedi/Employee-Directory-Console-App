using EmployeeDirectoryConsoleApp.Presentation;
using EmployeeDirectoryConsoleApp.DataPresentation.Interface;
using EmployeeDirectoryConsoleApp.Interfaces;
using EmployeeDirectoryConsoleApp.Models;
using EmployeeDirectoryConsoleApp.StreamOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDirectoryConsoleApp.Services
{
    public class LocationManager:ILocationManager
    {
        private readonly ILocationOperations _locationOperations;
        public LocationManager(ILocationOperations locationOperations)
        {
            _locationOperations = locationOperations;
        }

        public void AddLocation(LocationModel location)
        {
            Console.Write("Enter new Location:");
            string loc=Console.ReadLine().ToUpper();
            if(!CheckLocationExists(loc))
            {
                location.Name = loc;
                StartApp.LocationList.Add(location);
                _locationOperations.write();
            }
        }
        public static bool CheckLocationExists(string loc)
        {
            for (int i = 0;i<StartApp.LocationList.Count;i++)
            {
                if (StartApp.LocationList[i].Name==loc)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
