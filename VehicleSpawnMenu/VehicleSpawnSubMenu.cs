using CitizenFX.Core;
using NativeUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleSpawnMenu
{
    internal class VehicleSpawnSubMenu
    {
        public UIMenuItem PreviousMenuItem;
        public UIMenu UISubMenu;        
        public Dictionary<UIMenuItem, VehicleCategory> itemToCategory = new Dictionary<UIMenuItem, VehicleCategory>();
        public Dictionary<UIMenuItem, VehicleSpawnData> itemToSpawn = new Dictionary<UIMenuItem, VehicleSpawnData>();      

        public VehicleCategory category;

        public VehicleSpawnSubMenu(VehicleCategory category, bool initial = false)
        {
            this.category = category;
            if (initial)
            {
                PreviousMenuItem = new UIMenuItem(category.Name);
            }
            else
            {
                PreviousMenuItem = new UIMenuItem(category.Name);
            }
            UISubMenu = new UIMenu(category.Name, "Vehicles");

            Debug.WriteLine(category.ToString());
            if (category.SubCategories != null)
            {
                foreach (VehicleCategory subcat in category.SubCategories)
                {
                    UIMenuItem item = new UIMenuItem(subcat.Name);
                    UISubMenu.AddItem(item);
                    itemToCategory[item] = subcat;
                }
            }

            if (category.VehicleSpawns != null)
            {
                foreach (VehicleSpawnData spawndata in category.VehicleSpawns)
                {
                    UIMenuItem item = new UIMenuItem(spawndata.Name);
                    item.Description = "Plate: " + spawndata.Plate;
                    UISubMenu.AddItem(item);
                    itemToSpawn[item] = spawndata;
                }
            }

            UISubMenu.MouseControlsEnabled = false;
            UISubMenu.MouseEdgeEnabled = true;

            //Add a custom event handler to every loadout's UIMenuItem that creates a custom menu for that loadout and shows it.
            UISubMenu.OnItemSelect += (sender, selectedItem, index) =>
            {
                sender.Visible = false;
                if (itemToCategory.ContainsKey(selectedItem))
                {
                    //Populate submenu
                    VehicleSpawnSubMenu selectedSubMenu = new VehicleSpawnSubMenu(itemToCategory[selectedItem]);
                    selectedSubMenu.UISubMenu.ParentMenu = UISubMenu;
                    
                    if (!VehicleSpawnMenu.PopulatedMenus.Contains(selectedSubMenu.UISubMenu))
                    {
                        VehicleSpawnMenu.PopulatedMenus.Add(selectedSubMenu.UISubMenu);
                    }
                    VehicleSpawnMenu.RefreshMenuPool();                    

                    selectedSubMenu.UISubMenu.Visible = true;
                }
                else if (itemToSpawn.ContainsKey(selectedItem))
                {
                    //Spawn the vehicle.
                    VehicleSpawnData selectedSpawn = itemToSpawn[selectedItem];
                    selectedSpawn.Spawn();
                    sender.DisableInstructionalButtons(true);
                }            
            };

            this.UISubMenu.RefreshIndex();
        }
    }
}
