using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleSpawnMenu
{
    /// <summary>
    /// Class that represents a specific category of vehicles to group.
    /// </summary>
    internal class VehicleCategory
    {
        public string Name;
        public List<VehicleCategory> SubCategories = new List<VehicleCategory>();
        public List<VehicleSpawnData> VehicleSpawns = new List<VehicleSpawnData>();

        public VehicleCategory(string name, List<VehicleCategory> subCategories, List<VehicleSpawnData> vehicleSpawns)
        {
            Name = name;
            SubCategories = subCategories;
            VehicleSpawns = vehicleSpawns;
        }
    }
}
