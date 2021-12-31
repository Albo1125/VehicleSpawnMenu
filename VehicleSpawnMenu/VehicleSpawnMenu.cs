using CitizenFX.Core;
using CitizenFX.Core.Native;
using NativeUI;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace VehicleSpawnMenu
{
    public class VehicleSpawnMenu : BaseScript
    {
        public static MenuPool _menuPool = new MenuPool();
        private static UIMenu mainMenu;
        private static List<VehicleSpawnSubMenu> mainSubMenus = new List<VehicleSpawnSubMenu>();
        protected bool initialized = false;

        public static List<UIMenu> PopulatedMenus = new List<UIMenu>();

        public VehicleSpawnMenu()
        {
            mainMenu = new UIMenu("Vehicles", "");
            _menuPool.Add(mainMenu);
            PopulatedMenus.Add(mainMenu);

            //Deserialize the loadouts.json file.
            string resourceName = API.GetCurrentResourceName();
            string categories = API.LoadResourceFile(resourceName, "vehicles.json");

            VehicleCategory[] MainCategories = JsonConvert.DeserializeObject<VehicleCategory[]>(categories, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto,
                
            });

            //Create a submenu for every 'main' category.
            //Add every main submenu to the main menu.
            foreach (VehicleCategory cat in MainCategories)
            {
                VehicleSpawnSubMenu submenu = new VehicleSpawnSubMenu(cat, true);
                mainSubMenus.Add(submenu);
                
                mainMenu.AddItem(submenu.PreviousMenuItem);
                mainMenu.BindMenuToItem(submenu.UISubMenu, submenu.PreviousMenuItem);

                PopulatedMenus.Add(submenu.UISubMenu);
                _menuPool.Add(submenu.UISubMenu);    
                submenu.UISubMenu.RefreshIndex();
            }

            //Disable mouse controls and refresh the indexes.
            mainMenu.MouseControlsEnabled = false;
            mainMenu.MouseEdgeEnabled = true;
            mainMenu.RefreshIndex();
            _menuPool.RefreshIndex();

            //Add an event handler for the /av command.
            EventHandlers["VehicleSpawnMenu:ShowMenu"] += new Action<dynamic>((dynamic) =>
            {
                mainMenu.Visible = true;
            });

            Main();
        }

        /// <summary>
        /// Re-add all menus to a new instance of the menupool to prevent NativeUI issues.
        /// </summary>
        public static void RefreshMenuPool()
        {
            _menuPool = new MenuPool();
            foreach (UIMenu men in PopulatedMenus)
            {
                _menuPool.Add(men);
                
            }
            _menuPool.RefreshIndex();
        }

        private async Task Main()
        {
            while (true)
            {
                await Delay(0);
                _menuPool.ProcessMenus();
            }
        }
    }
}
