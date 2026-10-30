using GarageClassLibrary.Interfaces;

namespace GarageClassLibrary.IO
{
    public static class GarageStreamWriter
    {
        public static int Write(StreamWriter streamWriter, IGarage garage)
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

        public static int Write(string path, IGarage garage)
        {
            using var streamWriter = new StreamWriter(path);

            return Write(streamWriter, garage);
        }
    }
}
