namespace GarageClassLibrary.IO.Interfaces
{
    public interface IVehicleLineParser
    {
        IList<Vehicle> Parse(string[] lines);
    }
}
