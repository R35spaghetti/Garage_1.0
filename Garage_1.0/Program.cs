using Garage_1._0.Features;
using Garage_1._0.Handlers;
using Garage_1._0.Handlers.Delegates;
using Garage_1._0.Models;
using Garage_1._0.UserInteraction.Menu;

Garage<Vehicle> garage = new Garage<Vehicle>(10);

GarageHandler garageHandler = new GarageHandler(garage, new GarageUserFilter(new GarageFilters(garage)));

InteractiveMenu interactiveMenu = new InteractiveMenu(garageHandler);
interactiveMenu.MainMenu();