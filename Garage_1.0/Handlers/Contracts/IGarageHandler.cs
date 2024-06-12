namespace Garage_1._0.Handlers.Contracts;

public interface IGarageHandler
{
    void ShowAllVehicles();
    void ShowVehicleTypes();
    void AddVehicle<T>(T vehicle);
    void RemoveVehicle();
    int SetGarageCapacity();
    void PopulateGarage();
    void FindNumberPlate();
    void FindVehicle();
}