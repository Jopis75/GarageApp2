namespace GarageClassLibrary.Interfaces
{
    public interface IVehicle
    {
        float Length { get; }

        int NumberOfSeats { get; }

        string RegistrationNumber { get; }
    }
}
