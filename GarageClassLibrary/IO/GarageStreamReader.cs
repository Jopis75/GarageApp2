using GarageClassLibrary.Enums;
using GarageClassLibrary.IO.Interfaces;
using GarageClassLibrary.Validators;

namespace GarageClassLibrary.IO
{
    public class GarageStreamReader : IGarageStreamReader
    {
        public IList<Vehicle> Read(string path)
        {
            using var streamReader = new StreamReader(path);

            List<Vehicle> vehicles = [];

            var done = false;

            while (done == false)
            {
                var line = streamReader.ReadLine();

                if (line == null)
                {
                    done = true;
                }
                else
                {
                    var vehicle = ParseLine(line);

                    vehicles.Add(vehicle);
                }
            }

            return vehicles;
        }

        private Bicycle ParseBicycle(string line)
        {
            string[] fields = line.Split(";", StringSplitOptions.RemoveEmptyEntries);

            if (fields.Length != 5)
            {
                throw new ArgumentException("");
            }

            if (fields[0].Equals("Bicycle") == false)
            {
                throw new ArgumentException("");
            }

            if (RegistrationNumberValidator.Validate(fields[1]) == false)
            {
                throw new ArgumentException("");
            }

            var registrationNumber = fields[1];

            if (float.TryParse(fields[2], out var length) == false || !(length > 0.0f))
            {
                throw new ArgumentException("");
            }

            if (int.TryParse(fields[3], out var numberOfSeats) == false || !(numberOfSeats > 0))
            {
                throw new ArgumentException("");
            }

            if (int.TryParse(fields[4], out var numberOfGears) == false || !(numberOfGears > 0))
            {
                throw new ArgumentException("");
            }

            var bicycle = new Bicycle(registrationNumber, length, numberOfSeats, numberOfGears);

            return bicycle;
        }

        private Bicycle ParseMotorcycle(string line)
        {
            throw new NotImplementedException();
        }

        private Car ParseCar(string line)
        {
            string[] fields = line.Split(";", StringSplitOptions.RemoveEmptyEntries);

            if (fields.Length != 8)
            {
                throw new ArgumentException("");
            }

            if (fields[0].Equals("Car") == false)
            {
                throw new ArgumentException("");
            }

            if (RegistrationNumberValidator.Validate(fields[1]) == false)
            {
                throw new ArgumentException("");
            }

            var registrationNumber = fields[1];

            if (float.TryParse(fields[2], out var length) == false)
            {
                throw new ArgumentException("");
            }

            if (int.TryParse(fields[3], out var numberOfSeats) == false)
            {
                throw new ArgumentException("");
            }

            if (int.TryParse(fields[4], out var numberOfEngines) == false)
            {
                throw new ArgumentException("");
            }

            if (float.TryParse(fields[5], out var cylinderVolume) == false)
            {
                throw new ArgumentException("");
            }

            if (Enum.TryParse<FuelType>(fields[6], out var fuelType) == false)
            {
                throw new ArgumentException("");
            }

            if (float.TryParse(fields[7], out var maxTrailerWeight) == false)
            {
                throw new ArgumentException("");
            }

            var car = new Car(registrationNumber, length, numberOfSeats, numberOfEngines, cylinderVolume, fuelType, maxTrailerWeight);

            return car;
        }

        private Bicycle ParseTruck(string line)
        {
            throw new NotImplementedException();
        }

        private Bicycle ParseBus(string line)
        {
            throw new NotImplementedException();
        }

        private Bicycle ParseBoat(string line)
        {
            throw new NotImplementedException();
        }

        private Bicycle ParseAirplane(string line)
        {
            throw new NotImplementedException();
        }

        private Vehicle ParseLine(string line)
        {
            string[] fields = line.Split(";", StringSplitOptions.RemoveEmptyEntries);

            if (Enum.TryParse<VehicleType>(fields[0], out var vehicleType) == false)
            {
                throw new ArgumentException("");
            }

            return vehicleType switch
            {
                VehicleType.Bicycle => ParseBicycle(line),
                VehicleType.Motorcycle => ParseMotorcycle(line),
                VehicleType.Car => ParseCar(line),
                VehicleType.Truck => ParseTruck(line),
                VehicleType.Bus => ParseBus(line),
                VehicleType.Boat => ParseBoat(line),
                VehicleType.Airplane => ParseAirplane(line),
                _ => throw new ArgumentException("")
            };
        }
    }
}
