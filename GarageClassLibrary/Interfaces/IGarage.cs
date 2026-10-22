using GarageClassLibrary.Enums;

namespace GarageClassLibrary.Interfaces
{
    public interface IGarage
    {
        bool IsEmpty { get; }

        bool IsFull { get; }

        int NumberOfParkingSpaces { get; }

        int NumberOfVehicles { get; }

        void AddVehicle(Vehicle vehicle);

        int CountVehicleType(VehicleType vehicleType);

        Vehicle[] FindVehiclesByNumberOfSeats(int numberOfSeats);

        Vehicle[] FindVehiclesByVehicleType(VehicleType vehicleType);

        Vehicle[] FindVehiclesByVehicleTypeAndFuelType(VehicleType vehicleType, FuelType fuelType);

        Vehicle FindVehicleByRegistrationNumber(string registrationNumber);

        string GetStatusInfoString();

        Vehicle RemoveVehicleByRegistrationNumber(string registrationNumber);

        void WriteVehicles();

        void WriteVehicleTypeCount(VehicleType vehicleType);
    }
}
