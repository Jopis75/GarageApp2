using GarageClassLibrary.Enums;
using GarageClassLibrary.IO;

namespace UnitTests
{
    public class VehicleLineParserUnitTests
    {
        [Fact]
        public void TestParse()
        {
            // Arrange
            var vehicleLineParser = new VehicleLineParser();
            var lines = new string[]
            {
                "Bicycle;AFB 10H;1,1;1;5",
                "Motorcycle;HAC 26G;1,5;2;1;6,0;Gasoline;60,0",
                "Car;RTH 23T;4,2;4;1;6,0;Gasoline;750,0",
                "Truck;AGG 50H;8,5;4;1;6,0;Gasoline;32000,0"
            };

            // Act
            var vehicles = vehicleLineParser.Parse(lines);

            // Assert
            Assert.Equal(4, vehicles.Count);

            Assert.Equal(VehicleType.Bicycle.ToString(), vehicles[0].GetType().Name);
            Assert.Equal("AFB 10H", vehicles[0].RegistrationNumber);

            Assert.Equal(VehicleType.Motorcycle.ToString(), vehicles[1].GetType().Name);
            Assert.Equal("HAC 26G", vehicles[1].RegistrationNumber);

            Assert.Equal(VehicleType.Car.ToString(), vehicles[2].GetType().Name);
            Assert.Equal("RTH 23T", vehicles[2].RegistrationNumber);

            Assert.Equal(VehicleType.Truck.ToString(), vehicles[3].GetType().Name);
            Assert.Equal("AGG 50H", vehicles[3].RegistrationNumber);
        }

        [Fact]
        public void TestParseLine()
        {
            // Arrange
            var vehicleLineParser = new VehicleLineParser();
            string line = "Car;RTH 23T;4,2;4;1;6,0;Gasoline;750,0";

            // Act
            var vehicle = vehicleLineParser.ParseLine(line);

            // Assert
            Assert.Equal(VehicleType.Car.ToString(), vehicle.GetType().Name);
            Assert.Equal("RTH 23T", vehicle.RegistrationNumber);
        }
    }
}
