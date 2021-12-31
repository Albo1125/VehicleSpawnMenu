# VehicleSpawnMenu
VehicleSpawnMenu is a resource for FiveM by Albo1125 that provides vehicle spawn menu functionality. It is freely available at [https://github.com/Albo1125/VehicleSpawnMenu](https://github.com/Albo1125/VehicleSpawnMenu)

## Installation & Usage
1. Download the latest release.
2. Unzip the VehicleSpawnMenu folder into your resources folder on your FiveM server.
3. Add the following to your server.cfg file:
```text
ensure VehicleSpawnMenu
```

4. Create a file called `vehicles.json` and save your menu setup to it. Every element in the root array must have a `Name` and can contain an array of `SubCategories` or `VehicleSpawns`. See `vehicles.example.json` for further guidance.
5. Optionally, customise the command in `sv_VehicleSpawnMenu.lua`.

## Commands & Controls
* /vs - Opens the VehicleSpawnMenu.

## Improvements & Licencing
Please view the license. Improvements and new feature additions are very welcome, please feel free to create a pull request. As a guideline, please do not release separate versions with minor modifications, but contribute to this repository directly. However, if you really do wish to release modified versions of my work, proper credit is always required and you should always link back to this original source and respect the licence.

## Libraries used (many thanks to their authors)
* [CitizenFX.Core.Client](https://www.nuget.org/packages/CitizenFX.Core.Client)
* [Newtonsoft.Json](https://www.nuget.org/packages/newtonsoft.json/12.0.2)
* [NativeUI](https://github.com/citizenfx/NativeUI)