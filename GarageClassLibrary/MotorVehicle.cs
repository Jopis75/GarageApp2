using GarageClassLibrary.Enums;
using System.Text;

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
                    throw new ArgumentException("CylinderVolume must be greater than zero..");
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
                    throw new ArgumentException("NumberOfEngines must be greater than zero.");
                }

                numberOfEngines = value;
            }
        }

        public override string ToString()
        {
            return new StringBuilder().Append(base.ToString()).Append($";{numberOfEngines}").Append($";{cylinderVolume}").Append($";{fuelType}").ToString();
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
