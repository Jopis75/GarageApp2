using GarageClassLibrary.Enums;

namespace GarageClassLibrary
{
    public class Boat(string registrationNumber, float length, int numberOfSeats, int numberOfEngines, float cylinderVolume, FuelType fuelType, float draft) : MotorVehicle(registrationNumber, length, numberOfSeats, numberOfEngines, cylinderVolume, fuelType)
    {
        public float Draft
        {
            get
            {
                return draft;
            }
            set
            {
                if (value <= 0.0f)
                {
                    throw new ArgumentException("Draft must be greater than zero.");
                }

                draft = value;
            }
        }

        public override void Write()
        {
            Console.WriteLine($"Vehicle type: {GetType().Name}");

            base.Write();

            Console.WriteLine($"Draft: {draft}");
        }
    }
}
