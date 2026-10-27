namespace GarageClassLibrary.IO.Interfaces
{
    public interface IGarageStreamReader
    {
        IList<Vehicle> Read(string path);
    }
}
