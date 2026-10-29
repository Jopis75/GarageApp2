using GarageClassLibrary.Interfaces;

namespace GarageClassLibrary.IO.Interfaces
{
    public interface IGarageStreamWriter
    {
        int Write(StreamWriter streamWriter, IGarage garage);

        int Write(string path, IGarage garage);
    }
}
