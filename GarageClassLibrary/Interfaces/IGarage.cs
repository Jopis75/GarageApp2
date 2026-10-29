using GarageClassLibrary.Enums;

namespace GarageClassLibrary.Interfaces
{
    public interface IGarage
    {
        bool IsEmpty { get; }

        bool IsFull { get; }

        int NumberOfParkingSpaces { get; }

        int NumberOfVehicles { get; }

        IReadOnlyList<Vehicle> Vehicles { get; }

        void AddVehicle(Vehicle vehicle);

        int CountVehicleType(VehicleType vehicleType);

        IList<Vehicle> FindVehiclesByNumberOfSeats(int numberOfSeats);

        IList<Vehicle> FindVehiclesByVehicleType(VehicleType vehicleType);

        IList<Vehicle> FindVehiclesByVehicleTypeAndFuelType(VehicleType vehicleType, FuelType fuelType);

        Vehicle FindVehicleByRegistrationNumber(string registrationNumber);

        string StatusString();

        IList<Vehicle> RemoveAll();

        Vehicle RemoveVehicleByRegistrationNumber(string registrationNumber);

        bool VehicleExists(string registrationNumber);

        void WriteVehicles();

        void WriteVehicleTypeCount(VehicleType vehicleType);
    }
}
