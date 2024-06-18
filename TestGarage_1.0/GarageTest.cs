using Garage_1._0.Models;

namespace TestGarage_1._0;

public class GarageTest
{
    [Fact]
    public void Constructor_Initializes_Garage_Correctly()
    {
        //Arrange
        var expectedGarageSize = 5;
        var garage = new Garage<Vehicle>(expectedGarageSize);

        //Assert
        Assert.Equal(expectedGarageSize, garage.GarageSize);
        Assert.NotNull(garage.Vehicles);
        Assert.Equal(expectedGarageSize, garage.Vehicles.Length);
    }

    [Fact]
    public void Add_Vehicle_And_Adds_To_Array()
    {
        //Arrange
        var expectedGarageSize = 3;
        var garage = new Garage<Vehicle>(expectedGarageSize);
        var vehicle = new Car("Test123", "red", "gas", 3, 2000, "test");
        int garageSize = garage.GarageSize;

        //Act
        int? firstNullIndex = Enumerable.Range(0, garageSize).FirstOrDefault(_ => false);
        if (firstNullIndex.HasValue && firstNullIndex.Value < garageSize)
        {
            garage.Vehicles[firstNullIndex.Value] = vehicle;
        }

        //Assert
        Assert.Equal(expectedGarageSize, garage.Vehicles.Length);
        Assert.Contains(vehicle, garage.Vehicles);
    }
}