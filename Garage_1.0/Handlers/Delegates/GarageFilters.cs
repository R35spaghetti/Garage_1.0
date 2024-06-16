using Garage_1._0.Models;

namespace Garage_1._0.Handlers.Delegates;

public class GarageFilters
{
    private Garage<Vehicle> _garage { get; }


    public GarageFilters(Garage<Vehicle> garage)
    {
        _garage = garage;
    }

    private delegate void VehicleFilter(Dictionary<string, string> filters);


    public void ApplyVehicleFilters(Dictionary<string, string> filters)
    {
        VehicleFilter filterDelegate = FilterVehicles;

        filterDelegate(filters);
    }

    private void FilterVehicles(Dictionary<string, string> filters)
    {
        var filteredVehicles = _garage.Vehicles.OfType<Vehicle>().Where(vehicle =>
            filters.All(filter =>
                string.IsNullOrEmpty(filter.Value) ||
                vehicle.GetType().GetProperty(filter.Key)?.GetValue(vehicle, null)?.ToString() == filter.Value));

        foreach (var vehicle in filteredVehicles)
        {
            Console.WriteLine($"{vehicle}");
        }
    }
}