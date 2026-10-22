using GarageClassLibrary.Enums;
using GarageClassLibrary.Exceptions;
using GarageClassLibrary.Interfaces;

namespace GarageClassLibrary
{
    public class Garage(int numberOfParkingSpaces) : IGarage
    {
        //private int numberOfVehicles = 0;

        private readonly List<Vehicle> vehicles = new(numberOfParkingSpaces);

        public bool IsEmpty => NumberOfVehicles == 0;

        public bool IsFull => NumberOfVehicles == numberOfParkingSpaces;

        public int NumberOfParkingSpaces => numberOfParkingSpaces;

        public int NumberOfVehicles => vehicles.Count;

        public void AddVehicle(Vehicle vehicle)
        {
            if (IsFull)
            {
                throw new IndexOutOfRangeException("The garage is full.");
            }

            vehicles.Add(vehicle);
        }

        public int CountVehicleType(VehicleType vehicleType)
        {
            var vehicleTypeName = vehicleType.ToString();

            var count = 0;

            foreach (var vehicle in vehicles)
            {
                if (vehicle.GetType().Name.Equals(vehicleTypeName))
                {
                    count++;
                }
            }

            return count;
        }

        //private int FindVehicleIndexByRegistrationNumber(string registrationNumber)
        //{
        //    var foundVehicle = vehicles.Find(v => v.RegistrationNumber.Equals(registrationNumber, StringComparison.CurrentCultureIgnoreCase));
            
        //    if (foundVehicle == null)
        //    {
        //        throw new VehicleNotFoundException(registrationNumber);
        //    }

        //    return foundVehicle;
        //}

        public IList<Vehicle> FindVehiclesByNumberOfSeats(int numberOfSeats)
        {
            var foundVehicles = vehicles.FindAll(v => v.NumberOfSeats == numberOfSeats);

            return foundVehicles;
        }

        public Vehicle FindVehicleByRegistrationNumber(string registrationNumber)
        {
            var foundVehicle = vehicles.Find(v => v.RegistrationNumber.Equals(registrationNumber, StringComparison.CurrentCultureIgnoreCase));

            if (foundVehicle == null)
            {
                throw new VehicleNotFoundException(registrationNumber);
            }

            return foundVehicle;
        }

        public IList<Vehicle> FindVehiclesByVehicleType(VehicleType vehicleType)
        {
            var foundVehicles = vehicles.FindAll(v => v.GetType().Name.Equals(vehicleType));

            return foundVehicles;
        }

        public IList<Vehicle> FindVehiclesByVehicleTypeAndFuelType(VehicleType vehicleType, FuelType fuelType)
        {
            var foundVehicles = vehicles.FindAll(v =>
                v.GetType().Name.Equals(vehicleType)
                && v is MotorVehicle
                && (v as MotorVehicle)!.FuelType == fuelType);

            return foundVehicles;
        }

        public string GetStatusString()
        {
            var statusString = $"The garage has a total of {numberOfParkingSpaces} parking spaces.";

            if (IsEmpty)
            {
                statusString += " The garage is empty.";
            }
            else if (IsFull)
            {
                statusString += " The garage is full.";
            }
            else
            {
                statusString += $" There are currently {vehicles.Count}" + (vehicles.Count == 1 ? " vehicle" : " vehicles") + " in the garage.";
            }

            return statusString;
        }

        public IList<Vehicle> RemoveAll()
        {
            var removedVehilces = vehicles;

            vehicles.RemoveAll(_ => true);

            return removedVehilces;
        }

        public Vehicle RemoveVehicleByRegistrationNumber(string registrationNumber)
        {
            if (IsEmpty)
            {
                throw new IndexOutOfRangeException("The garage is empty.");
            }

            var removedVehicle = FindVehicleByRegistrationNumber(registrationNumber);

            vehicles.Remove(removedVehicle);

            return removedVehicle;
        }

        public void WriteVehicles()
        {
            foreach (var vehicle in vehicles)
            {
                vehicle.Write();
                Console.WriteLine();
            }
        }

        public void WriteVehicleTypeCount(VehicleType vehicleType)
        {
            var count = CountVehicleType(vehicleType);

            Console.WriteLine($"Vehicle type: {vehicleType}");
            Console.WriteLine($"Count: {count}");
        }
    }
}
