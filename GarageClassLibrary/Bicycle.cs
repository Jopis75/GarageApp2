namespace GarageClassLibrary
{
    public class Bicycle(string registrationNumber, float length, int numberOfSeats, int numberOfGears) : Vehicle(registrationNumber, length, numberOfSeats)
    {
        public int NumberOfGears
        {
            get
            {
                return numberOfGears;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("NumberOfGears must be greater than zero.");
                }

                numberOfGears = value;
            }
        }

        public override void Write()
        {
            Console.WriteLine($"Vehicle type: {GetType().Name}");

            base.Write();

            Console.WriteLine($"Number of gears: {numberOfGears}");
        }
    }
}
