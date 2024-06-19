using Garage_1._0.Features;
using Garage_1._0.Handlers;
using Garage_1._0.Handlers.Delegates;
using Garage_1._0.Models;
using Garage_1._0.UserInteraction;
using Garage_1._0.UserInteraction.Menu;
Console.WriteLine("Welcome to the garage!\n" +
                  "Enter the size of the garage\n" +
                  "Value must be above 0!");
Garage<Vehicle> garage;
do
{
    garage = new Garage<Vehicle>(UserInput.GetUserInput<int>());
} while (garage.GarageSize == 0);


GarageHandler garageHandler = new GarageHandler(garage, new GarageUserFilter(new GarageFilters(garage)));

InteractiveMenu interactiveMenu = new InteractiveMenu(garageHandler);
interactiveMenu.MainMenu();