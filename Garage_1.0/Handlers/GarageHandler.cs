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

    
    public void ShowAllVehicles<T>(Garage<T> garage) where T : IVehicle
    {
        throw new NotImplementedException();
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