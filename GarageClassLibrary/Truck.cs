using GarageClassLibrary.Enums;
using System.Text;

namespace GarageClassLibrary
{
    public class Truck(string registrationNumber, float length, int numberOfSeats, int numberOfEngines, float cylinderVolume, FuelType fuelType, float maxLoad) : MotorVehicle(registrationNumber, length, numberOfSeats, numberOfEngines, cylinderVolume, fuelType)
    {
        public float MaxLoad
        {
            get
            {
                return maxLoad;
            }
            set
            {
                if (value <= 0.0f)
                {
                    throw new ArgumentException("MaxLoad must be greater than zero.");
                }

                maxLoad = value;
            }
        }

        public override string ToString()
        {
            return new StringBuilder().Append("Truck").Append($";{base.ToString()}").Append($";{maxLoad}").ToString();
        }

        public override void Write()
        {
            Console.WriteLine($"Vehicle type: {GetType().Name}");

            base.Write();

            Console.WriteLine($"Max load: {maxLoad}");
        }
    }
}
