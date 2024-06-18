using Garage_1._0.Handlers;
using Garage_1._0.Models;

namespace Garage_1._0.UserInteraction.Menu;

public class InteractiveMenu
{
    private GarageHandler _garageHandler { get; }

    public InteractiveMenu(GarageHandler garageHandler)
    {
        _garageHandler = garageHandler;
    }
    

    public void MainMenu()
    {
        Console.WriteLine("Welcome to the garage!\n");
        int usrOperation;
        do
        {


            Console.WriteLine($"Choose the following:\n" +
                              $"1. Show all vehicles\n" +
                              $"2. Add a vehicle\n" +
                              $"3. Remove a vehicle\n" +
                              $"4. Find a vehicle based on the number plate\n" +
                              $"5. Search for specific vehicle or vehicles\n" +
                              $"6. Populate the garage with vehicles\n" +
                              $"7. Edit the size of the garage.\n" +
                              $"8. Exit ");
            usrOperation = UserInput.GetUserInput<int>();
            switch (usrOperation)
            {
                case 1:
                    _garageHandler.ShowAllVehicles();
                    break;
                case 2:
                    _garageHandler.AddVehicle<Vehicle>();
                    break;
                case 3:
                    _garageHandler.RemoveVehicle(UserInput.GetUserInput<string>());
                    break;
                case 4:
                    _garageHandler.FindNumberPlate(UserInput.GetUserInput<string>());
                    break;
                case 5:
                    _garageHandler.FindVehicle();
                    break;
                case 6:
                    _garageHandler.PopulateGarage();
                    break;
                case 7:
                    _garageHandler.SetGarageCapacity(UserInput.GetUserInput<int>());
                    break;
                case 8:
                    break;
                default:
                    Console.WriteLine("Invalid input, try again");
                    break;
                
            }
        } while (usrOperation != 8);
        
    }
        
}