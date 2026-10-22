using GarageClassLibrary;
using GarageClassLibrary.Enums;
using GarageClassLibrary.Interfaces;

namespace UnitTests
{
    public class GarageUnitTests
    {
        [Fact]
        public void TestAddVehicle()
        {
            // Arrange
            IGarage garage = new Garage(3);

            // Act
            garage.AddVehicle(new Car("ABC 12A", 4.0f, 4, 1, 2.0f, FuelType.Gasoline, 750.0f));
            garage.AddVehicle(new Truck("RTH 09T", 9.0f, 2, 1, 6.0f, FuelType.Gasoline, 40000.0f));

            // Assert
            Assert.Equal(2, garage.NumberOfVehicles);
        }

        [Fact]
        public void TestCountVehicleType()
        {
            // Arrange
            IGarage garage = new Garage(3);
            garage.AddVehicle(new Car("ABC 12A", 4.0f, 4, 1, 2.0f, FuelType.Gasoline, 750.0f));
            garage.AddVehicle(new Truck("RTH 09T", 9.0f, 2, 1, 6.0f, FuelType.Gasoline, 40000.0f));
            garage.AddVehicle(new Car("DEF 34B", 4.5f, 5, 1, 2.0f, FuelType.Gasoline, 750.0f));

            // Act
            var count = garage.CountVehicleType(VehicleType.Car);

            // Assert
            Assert.Equal(2, count);
        }

        [Fact]
        public void TestFindVehicleByRegistrationNumber()
        {
            // Arrange
            IGarage garage = new Garage(3);
            garage.AddVehicle(new Car("ABC 12A", 4.0f, 4, 1, 2.0f, FuelType.Gasoline, 750.0f));
            garage.AddVehicle(new Truck("RTH 09T", 9.0f, 2, 1, 6.0f, FuelType.Gasoline, 40000.0f));

            // Act
            var foundVehicle = garage.FindVehicleByRegistrationNumber("ABC 12A");

            // Assert
            Assert.Equal("ABC 12A", foundVehicle.RegistrationNumber);
        }

        [Fact]
        public void TestFindVehiclesByNumberOfSeats()
        {
            // Arrange
            IGarage garage = new Garage(3);
            garage.AddVehicle(new Car("ABC 12A", 4.0f, 4, 1, 2.0f, FuelType.Gasoline, 750.0f));
            garage.AddVehicle(new Truck("RTH 09T", 9.0f, 2, 1, 6.0f, FuelType.Gasoline, 40000.0f));
            garage.AddVehicle(new Car("DEF 34B", 4.5f, 5, 1, 2.0f, FuelType.Gasoline, 750.0f));

            // Act
            var foundVehicles = garage.FindVehiclesByNumberOfSeats(2);

            // Assert
            Assert.Single(foundVehicles);
            Assert.Equal("RTH 09T", foundVehicles[0].RegistrationNumber);
        }

        [Fact]
        public void TestFindVehiclesByVehicleType()
        {
            // Arrange
            IGarage garage = new Garage(3);
            garage.AddVehicle(new Car("ABC 12A", 4.0f, 4, 1, 2.0f, FuelType.Gasoline, 750.0f));
            garage.AddVehicle(new Truck("RTH 09T", 9.0f, 2, 1, 6.0f, FuelType.Gasoline, 40000.0f));
            garage.AddVehicle(new Car("DEF 34B", 4.5f, 5, 1, 2.0f, FuelType.Gasoline, 750.0f));

            // Act
            var foundVehicles = garage.FindVehiclesByVehicleType(VehicleType.Truck);

            // Assert
            Assert.Single(foundVehicles);
            Assert.Equal("RTH 09T", foundVehicles[0].RegistrationNumber);
        }

        [Fact]
        public void TestFindVehiclesByVehicleTypeAndFuelType()
        {
            // Arrange
            IGarage garage = new Garage(3);
            garage.AddVehicle(new Car("ABC 12A", 4.0f, 4, 1, 2.0f, FuelType.Gasoline, 750.0f));
            garage.AddVehicle(new Truck("RTH 09T", 9.0f, 2, 1, 6.0f, FuelType.Gasoline, 40000.0f));
            garage.AddVehicle(new Car("DEF 34B", 4.5f, 5, 1, 2.0f, FuelType.Gasoline, 750.0f));

            // Act
            var foundVehicles = garage.FindVehiclesByVehicleTypeAndFuelType(VehicleType.Truck, FuelType.Gasoline);

            // Assert
            Assert.Single(foundVehicles);
            Assert.Equal("RTH 09T", foundVehicles[0].RegistrationNumber);
        }

        [Fact]
        public void TestIsEmpty()
        {
            // Arrange
            IGarage garage = new Garage(3);
            garage.AddVehicle(new Car("ABC 12A", 4.0f, 4, 1, 2.0f, FuelType.Gasoline, 750.0f));

            // Act
            garage.RemoveVehicleByRegistrationNumber("ABC 12A");

            // Assert
            Assert.True(garage.IsEmpty);
        }

        [Fact]
        public void TestIsFull()
        {
            // Arrange
            IGarage garage = new Garage(3);

            // Act
            garage.AddVehicle(new Car("ABC 12A", 4.0f, 4, 1, 2.0f, FuelType.Gasoline, 750.0f));
            garage.AddVehicle(new Truck("RTH 09T", 9.0f, 2, 1, 6.0f, FuelType.Gasoline, 40000.0f));
            garage.AddVehicle(new Car("DEF 34B", 4.5f, 5, 1, 2.0f, FuelType.Gasoline, 750.0f));

            // Assert
            Assert.True(garage.IsFull);
        }

        [Fact]
        public void TestRemoveAll()
        {
            // Arrange
            IGarage garage = new Garage(3);
            garage.AddVehicle(new Car("ABC 12A", 4.0f, 4, 1, 2.0f, FuelType.Gasoline, 750.0f));
            garage.AddVehicle(new Truck("RTH 09T", 9.0f, 2, 1, 6.0f, FuelType.Gasoline, 40000.0f));
            garage.AddVehicle(new Car("DEF 34B", 4.5f, 5, 1, 2.0f, FuelType.Gasoline, 750.0f));

            // Act
            var removedVehicles = garage.RemoveAll();

            // Assert
            Assert.Equal(0, garage.NumberOfVehicles);
            Assert.Equal(3, removedVehicles.Count);
        }

        [Fact]
        public void TestRemoveVehicleByRegistrationNumber()
        {
            // Arrange
            IGarage garage = new Garage(3);
            garage.AddVehicle(new Car("ABC 12A", 4.0f, 4, 1, 2.0f, FuelType.Gasoline, 750.0f));
            garage.AddVehicle(new Truck("RTH 09T", 9.0f, 2, 1, 6.0f, FuelType.Gasoline, 40000.0f));

            // Act
            var vehicle = garage.RemoveVehicleByRegistrationNumber("ABC 12A");

            // Assert
            Assert.Equal(1, garage.NumberOfVehicles);
            Assert.Equal("ABC 12A", vehicle.RegistrationNumber);
        }
    }
}