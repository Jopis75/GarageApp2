using GarageClassLibrary.Enums;
using System.Text;

namespace GarageClassLibrary
{
    public class Bus(string registrationNumber, float length, int numberOfSeats, int numberOfEngines, float cylinderVolume, FuelType fuelType, int numberOfPassengerSeats) : MotorVehicle(registrationNumber, length, numberOfSeats, numberOfEngines, cylinderVolume, fuelType)
    {
        public int NumberOfPassengerSeats
        {
            get
            {
                return numberOfPassengerSeats;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("NumberOfPassengerSeats must be greater than zero.");
                }

                numberOfPassengerSeats = value;
            }
        }

        public override string ToString()
        {
            return new StringBuilder().Append("Bus").Append($";{base.ToString()}").Append($";{numberOfPassengerSeats}").ToString();
        }

        public override void Write()
        {
            Console.WriteLine($"Vehicle type: {GetType().Name}");

            base.Write();

            Console.WriteLine($"Number of passenger seats: {numberOfPassengerSeats}");
        }
    }
}
