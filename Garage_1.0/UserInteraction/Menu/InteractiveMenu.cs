using Garage_1._0.Handlers.Contracts;
using Garage_1._0.Models;

namespace Garage_1._0.UserInteraction.Menu;

public class InteractiveMenu
{
    private IGarageHandler _garageHandler { get; }

    public InteractiveMenu(IGarageHandler garageHandler)
    {
        _garageHandler = garageHandler;
    }
    

    public void MainMenu()
    {
        int usrOperation;
        do
        {


            Console.WriteLine($"Choose the following:\n" +
                              $"1. Show all vehicles\n" +
                              $"2. Add a vehicle\n" +
                              $"3. Remove a vehicle\n" +
                              $"4. Find a vehicle based on the number plate\n" +
                              $"5. Search for specific vehicles\n" +
                              $"6. Populate the garage with vehicles\n" +
                              $"7. Edit the size of the garage, press 0 to return to the main menu.\n" +
                              $"8. Show vehicles and their amount in the garage\n" +
                              $"9. Exit ");
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
                    Console.Clear();
                    _garageHandler.RemoveVehicle(UserInput.GetUserInput<string>());
                    break;
                case 4:
                    Console.Clear();
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
                    _garageHandler.ShowVehicleTypes();
                    break;
                case 9:
                    break;
                default:
                    Console.WriteLine("Invalid input, try again");
                    break;
                
            }
        } while (usrOperation != 9);
        
    }
        
}