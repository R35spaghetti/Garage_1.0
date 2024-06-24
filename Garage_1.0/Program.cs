using Garage_1._0.Enums;
using Garage_1._0.Features;
using Garage_1._0.Features.Managers;
using Garage_1._0.Handlers;
using Garage_1._0.Handlers.Delegates;
using Garage_1._0.Models;
using Garage_1._0.UserInteraction;
using Garage_1._0.UserInteraction.Menu;
Console.WriteLine("Welcome to the garage!\n" +
                  "Enter the size of the garage\n" +
                  "Value must be above 0!");
Garage<Vehicle> garage = new Garage<Vehicle>(UserInput.GetUserInput<int>());
GarageUserFilter garageUserFilter = new GarageUserFilter(new GarageFilters(garage));
GarageManager garageManager = new GarageManager();
var garageHandler = new GarageHandler(
    garage,
    garageUserFilter,
    garageManager
);
garageManager.AddGarage(GarageOptions.VehicleTypes.VEHICLE, garage);
var interactiveMenu = new InteractiveMenu(garageHandler);
interactiveMenu.MainMenu();