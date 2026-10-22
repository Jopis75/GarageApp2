using GarageClassLibrary.Enums;

namespace GarageClassLibrary
{
    public class Car(string registrationNumber, float length, int numberOfSeats, int numberOfEngines, float cylinderVolume, FuelType fuelType, float maxTrailerWeight) : MotorVehicle(registrationNumber, length, numberOfSeats, numberOfEngines, cylinderVolume, fuelType)
    {
        public float MaxTrailerWeight
        {
            get
            {
                return maxTrailerWeight;
            }
            set
            {
                if (value <= 0.0f)
                {
                    throw new ArgumentException("MaxTrailerWeight must be a positive value.");
                }

                maxTrailerWeight = value;
            }
        }

        public override void Write()
        {
            Console.WriteLine($"Vehicle type: {GetType().Name}");

            base.Write();

            Console.WriteLine($"Max trailer weight: {maxTrailerWeight}");
        }
    }
}
