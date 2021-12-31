# VehicleSpawnMenu
VehicleSpawnMenu is a resource for FiveM by Albo1125 that provides vehicle spawn menu functionality. It is available at [https://github.com/Albo1125/VehicleSpawnMenu](https://github.com/Albo1125/VehicleSpawnMenu)

## Installation & Usage
1. Download the latest release.
2. Unzip the VehicleSpawnMenu folder into your resources folder on your FiveM server.
3. Add the following to your server.cfg file:
```text
ensure VehicleSpawnMenu
```

4. Create a file called `vehicles.json` and save your menu setup to it. See below for further guidance.
5. Optionally, customise the command in `sv_VehicleSpawnMenu.lua`.

## Commands & Controls
* /vs - Opens the VehicleSpawnMenu.

## Customising your vehicles
Customise your vehicles in the `vehicles.json` file. You can add as many `SubCategories` and `VehicleSpawns` to the root array as you like. An example `vehicles.example.json` file is included.
JSON reference is as follows.

### SubCategory
* "Name" string indicating the (unique?) name of this SubCategory
* Either a "SubCategories" or "VehicleSpawns" array containing further SubCategory or VehicleSpawn entries.

### VehicleSpawn
If this is selected, a vehicle will be spawned with the appropriate properties.
* "Name" string indicating the display name of this VehicleSpawn
* "VehicleModelName" is the ingame model name/spawncode of this vehicle
* "Plate" the plate to set on this vehicle when it is spawned
* "LiveryNumber" optional number representing which livery to set on the vehicle when it is spawned.

## Improvements & Licencing
Please view the license. Improvements and new feature additions are very welcome, please feel free to create a pull request. As a guideline, please do not release separate versions with minor modifications, but contribute to this repository directly. However, if you really do wish to release modified versions of my work, proper credit is always required and you should always link back to this original source and respect the licence.

## Libraries used (many thanks to their authors)
* [CitizenFX.Core.Client](https://www.nuget.org/packages/CitizenFX.Core.Client)
* [Newtonsoft.Json](https://www.nuget.org/packages/newtonsoft.json/12.0.2)
* [NativeUI](https://github.com/citizenfx/NativeUI)