using Garage_1._0.Enums;
using Garage_1._0.Models;

namespace Garage_1._0.Features.Managers;

public class GarageManager<T> where T : Vehicle
{
    private readonly Dictionary<GarageOptions.VehicleTypes, Garage<T>> _garageTypes = new();

    public Garage<T> GetGarageByType(GarageOptions.VehicleTypes vehicleType)
    {
        if (_garageTypes.TryGetValue(vehicleType, out var garage))
        {
            return garage;
        }
        else
        {
            return null;
        }
    }
    
    public void UpdateOrAddGarage(GarageOptions.VehicleTypes vehicleType, Garage<T> garage)
    {
        if (_garageTypes.ContainsKey(vehicleType))
        {
            _garageTypes[vehicleType] = garage;
        }
        else
        {
            _garageTypes.Add(vehicleType, garage);
        }
    }

    public Garage<T> InitializeGarage()
    {
        Garage<T> garage = new Garage<T>(0);
        foreach (var item in _garageTypes.Values)
        {
            garage.GarageSize += item.GarageSize;
            garage.Vehicles = item.Vehicles.ToArray();
        }
        
        return garage;
    }
}