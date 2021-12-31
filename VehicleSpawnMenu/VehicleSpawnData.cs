using CitizenFX.Core;
using CitizenFX.Core.Native;
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
    /// Model class containing all necessary information to spawn a vehicle.
    /// </summary>
    class VehicleSpawnData
    {
        public string Name, VehicleModelName, Plate;

        [DefaultValue(-1)]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public int LiveryNumber = -1;

        public VehicleSpawnData(string name, string vehicleModelName, string plate, int liveryNumber)
        {
            Name = name;
            VehicleModelName = vehicleModelName;
            Plate = plate;
            LiveryNumber = liveryNumber;
        }

        public async void Spawn()
        {
            Model model = new Model(VehicleModelName);
            await model.Request(10000);
            if (model.IsLoaded)
            {
                if (Game.PlayerPed.CurrentVehicle != null && Game.PlayerPed.CurrentVehicle.Exists())
                {
                    Game.PlayerPed.CurrentVehicle.IsPersistent = true;
                    Game.PlayerPed.CurrentVehicle.Delete();
                }

                Vehicle veh = await World.CreateVehicle(model, Game.PlayerPed.GetOffsetPosition(new Vector3(0, 1, 0)), Game.PlayerPed.Heading);

                if (veh != null && veh.Exists())
                {
                    API.SetVehicleNumberPlateText(veh.Handle, Plate);
                    Game.PlayerPed.SetIntoVehicle(veh, VehicleSeat.Driver);
                    veh.IsPersistent = true;
                    
                    veh.NeedsToBeHotwired = false;
                    veh.DirtLevel = 0;
                    veh.Repair();
                    if (LiveryNumber != -1)
                    {
                        API.SetVehicleLivery(veh.Handle, LiveryNumber);
                    }
                }
                else
                {
                    Debug.WriteLine("Could not spawn vehicle: " + VehicleModelName);
                }
            }
            else
            {
                Debug.WriteLine("Could not load model: " + VehicleModelName);
            }
        }
    }
}
