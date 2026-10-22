using GarageClassLibrary.Enums;
using GarageClassLibrary.Exceptions;
using GarageClassLibrary.Interfaces;

namespace GarageClassLibrary
{
    public class Garage(int numberOfParkingSpaces) : IGarage
    {
        private int numberOfVehicles = 0;

        private readonly Vehicle[] vehicles = new Vehicle[numberOfParkingSpaces];

        public bool IsEmpty => NumberOfVehicles == 0;

        public bool IsFull => NumberOfVehicles == numberOfParkingSpaces;

        public int NumberOfParkingSpaces => numberOfParkingSpaces;

        public int NumberOfVehicles => numberOfVehicles;

        public void AddVehicle(Vehicle vehicle)
        {
            if (IsFull)
            {
                throw new IndexOutOfRangeException("The garage is full.");
            }

            vehicles[numberOfVehicles] = vehicle;

            numberOfVehicles++;
        }

        public int CountVehicleType(VehicleType vehicleType)
        {
            var vehicleTypeName = vehicleType.ToString();

            var count = 0;

            for (var i = 0; i < numberOfVehicles; i++)
            {
                if (vehicles[i].GetType().Name == vehicleTypeName)
                {
                    count++;
                }
            }

            return count;
        }

        private int FindVehicleIndexByRegistrationNumber(string registrationNumber)
        {
            var index = Array.FindIndex(vehicles, 0,
                v => v != null
                && v.RegistrationNumber.Equals(registrationNumber, StringComparison.CurrentCultureIgnoreCase));

            if (index == -1)
            {
                throw new VehicleNotFoundException(registrationNumber);
            }

            return index;
        }

        public Vehicle[] FindVehiclesByNumberOfSeats(int numberOfSeats)
        {
            var foundVehicles = Array.FindAll(vehicles,
                v => v != null
                && v.NumberOfSeats == numberOfSeats);

            return foundVehicles;
        }

        public Vehicle FindVehicleByRegistrationNumber(string registrationNumber)
        {
            var index = FindVehicleIndexByRegistrationNumber(registrationNumber);

            return vehicles[index];
        }

        public Vehicle[] FindVehiclesByVehicleType(VehicleType vehicleType)
        {
            var foundVehicles = Array.FindAll(vehicles,
                v => v != null
                && v.GetType().Name.Equals(vehicleType.ToString()));

            return foundVehicles;
        }

        public Vehicle[] FindVehiclesByVehicleTypeAndFuelType(VehicleType vehicleType, FuelType fuelType)
        {
            var foundVehicles = Array.FindAll(vehicles, 
                v => v != null
                && v is MotorVehicle
                && v.GetType().Name.Equals(vehicleType.ToString())
                && (v as MotorVehicle)!.FuelType == fuelType);

            return foundVehicles;
        }

        public string GetStatusInfoString()
        {
            var infoLine = $"The garage has a total of {numberOfParkingSpaces} parking spaces.";

            if (IsEmpty)
            {
                infoLine += " The garage is empty.";
            }
            else if (IsFull)
            {
                infoLine += " The garage is full.";
            }
            else
            {
                infoLine += $" There are currently {numberOfVehicles}" + (numberOfVehicles == 1 ? " vehicle" : " vehicles") + " in the garage.";
            }

            return infoLine;
        }

        private Vehicle RemoveVehicleByIndex(int index)
        {
            var vehicle = vehicles[index];

            var tempVehicles = new Vehicle[numberOfParkingSpaces];

            for (int i = 0, j = 0; i < numberOfVehicles; i++)
            {
                if (i != index)
                {
                    tempVehicles[j] = vehicles[i];
                    j++;
                }
            }

            Array.Copy(tempVehicles, vehicles, tempVehicles.Length);

            numberOfVehicles--;

            return vehicle;
        }

        public Vehicle RemoveVehicleByRegistrationNumber(string registrationNumber)
        {
            if (IsEmpty)
            {
                throw new IndexOutOfRangeException("The garage is empty.");
            }

            var index = FindVehicleIndexByRegistrationNumber(registrationNumber);

            var vehicle = RemoveVehicleByIndex(index);

            return vehicle;
        }

        public void WriteVehicles()
        {
            for (var i = 0; i < numberOfVehicles; i++)
            {
                vehicles[i].Write();
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
