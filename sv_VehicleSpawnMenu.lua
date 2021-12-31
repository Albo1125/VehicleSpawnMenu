function openMenu(source, args, rawCommand)
	TriggerClientEvent("VehicleSpawnMenu:ShowMenu", source)
end

RegisterCommand('vs', openMenu, false)