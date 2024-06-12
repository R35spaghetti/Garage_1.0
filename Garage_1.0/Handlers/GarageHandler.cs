using System.Collections;
using Garage_1._0.Handlers.Contracts;
using Garage_1._0.Models;
using Garage_1._0.Models.Contracts;

namespace Garage_1._0.Handlers;

public class GarageHandler : IGarageHandler
{
    
    private Garage<Vehicle> _Garage { get;}

    public GarageHandler(Garage<Vehicle> garage)
    {
        _Garage = garage;
    }

    
    public void ShowAllVehicles()
    {
        IEnumerator enumerator = _Garage.GetEnumerator();

        while (enumerator.MoveNext())
        {
            try
            {
                var currentVehicle = enumerator.Current;
                Console.WriteLine(currentVehicle); 
            }
            catch (InvalidCastException)
            {
                Console.WriteLine("Vehicle not found");
            }
        }
    }

    public void ShowVehicleTypes()
    {
        throw new NotImplementedException();
    }

    public void RemoveVehicle()
    {
        throw new NotImplementedException();
    }

    public int SetGarageCapacity()
    {
        throw new NotImplementedException();
    }

    public void PopulateGarage()
    {
        throw new NotImplementedException();
    }

    public void FindNumberPlate()
    {
        throw new NotImplementedException();
    }

    public void FindVehicle()
    {
        throw new NotImplementedException();
    }
}