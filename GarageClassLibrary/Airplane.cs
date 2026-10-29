using GarageClassLibrary.Enums;
using System.Text;

namespace GarageClassLibrary
{
    public class Airplane(string registrationNumber, float length, int numberOfSeats, int numberOfEngines, float cylinderVolume, FuelType fuelType, float maxThrust) : MotorVehicle(registrationNumber, length, numberOfSeats, numberOfEngines, cylinderVolume, fuelType)
    {
        public float MaxThrust
        {
            get
            {
                return maxThrust;
            }
            set
            {
                if (value <= 0.0f)
                {
                    throw new ArgumentException("MaxThrust must be greater than zero.");
                }

                maxThrust = value;
            }
        }

        public override string ToString()
        {
            return new StringBuilder().Append("Airplane").Append($";{base.ToString()}").Append($";{maxThrust}").ToString();
        }

        public override void Write()
        {
            Console.WriteLine($"Vehicle type: {GetType().Name}");

            base.Write();

            Console.WriteLine($"Max thrust: {maxThrust}");
        }
    }
}
