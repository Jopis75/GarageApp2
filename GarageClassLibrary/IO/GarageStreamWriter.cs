using GarageClassLibrary.Interfaces;
using GarageClassLibrary.IO.Interfaces;

namespace GarageClassLibrary.IO
{
    public class GarageStreamWriter : IGarageStreamWriter
    {
        public int Write(StreamWriter streamWriter, IGarage garage)
        {
            var count = 0;

            foreach (var vehicle in garage.Vehicles)
            {
                var x = vehicle.ToString();
                streamWriter.WriteLine(vehicle.ToString());

                count++;
            }

            streamWriter.Flush();

            return count;
        }

        public int Write(string path, IGarage garage)
        {
            using var streamWriter = new StreamWriter(path);

            return Write(streamWriter, garage);
        }
    }
}
