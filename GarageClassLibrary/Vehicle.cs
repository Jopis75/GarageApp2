using GarageClassLibrary.Interfaces;

namespace GarageClassLibrary
{
    public abstract class Vehicle(string registrationNumber, float length, int numberOfSeats) : IVehicle
    {
        public float Length
        {
            get
            {
                return length;
            }
            set
            {
                if (value <= 0.0f)
                {
                    throw new ArgumentException("Length must be a positive value.");
                }

                length = value;
            }
        }

        public int NumberOfSeats
        {
            get
            {
                return numberOfSeats;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("NumberOfSeats must be a positive value.");
                }

                numberOfSeats = value;
            }
        }

        public string RegistrationNumber
        {
            get
            {
                return registrationNumber;
            }
        }

        public virtual void Write()
        {
            Console.WriteLine($"Registration number: {registrationNumber}");
            Console.WriteLine($"Length: {length}");
            Console.WriteLine($"Number of seats: {numberOfSeats}");
        }
    }
}
