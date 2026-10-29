using GarageClassLibrary.Extensions;
using GarageClassLibrary.IO.Interfaces;

namespace GarageClassLibrary.IO
{
    public class GarageStreamReader : IGarageStreamReader
    {
        public IList<Vehicle> Read(string path)
        {
            using var streamReader = new StreamReader(path);

            var lines = streamReader.ReadAllLines();

            var vehicles = new VehicleLineParser().Parse(lines);

            return vehicles;
        }
    }
}
