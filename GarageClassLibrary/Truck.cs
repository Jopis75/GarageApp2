using GarageClassLibrary.Enums;

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
                    throw new ArgumentException("MaxLoad must be a positive value.");
                }

                maxLoad = value;
            }
        }

        public override void Write()
        {
            Console.WriteLine($"Vehicle type: {GetType().Name}");

            base.Write();

            Console.WriteLine($"Max load: {maxLoad}");
        }
    }
}
