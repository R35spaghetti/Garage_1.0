namespace Garage_1._0.Handlers.Contracts;

public interface IGarageHandler
{
    void ShowAllVehicles();
    void ShowVehicleTypes();
    void AddVehicle<T>(T vehicle);
    void RemoveVehicle();
    void SetGarageCapacity(int size);
    void PopulateGarage();
    void FindNumberPlate();
    void FindVehicle();
}