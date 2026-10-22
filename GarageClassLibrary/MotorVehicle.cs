using GarageClassLibrary.Enums;

namespace GarageClassLibrary
{
    public abstract class MotorVehicle(string registrationNumber, float length, int numberOfSeats, int numberOfEngines, float cylinderVolume, FuelType fuelType) : Vehicle(registrationNumber, length, numberOfSeats)
    {
        public float CylinderVolume
        {
            get
            {
                return cylinderVolume;
            }
            set
            {
                if (value <= 0.0f)
                {
                    throw new ArgumentException("CylinderVolume must be a positive value.");
                }

                cylinderVolume = value;
            }
        }

        public FuelType FuelType
        {
            get
            {
                return fuelType;
            }
            set
            {
                fuelType = value;
            }
        }

        public int NumberOfEngines
        {
            get
            {
                return numberOfEngines;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("NumberOfEngines must be a positive value.");
                }

                numberOfEngines = value;
            }
        }

        public override void Write()
        {
            base.Write();

            Console.WriteLine($"Number of engines: {numberOfEngines}");
            Console.WriteLine($"Cylinder volumne: {cylinderVolume}");
            Console.WriteLine($"Fuel type: {fuelType}");
        }
    }
}
