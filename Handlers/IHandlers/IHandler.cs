using Parkings.Garaget;

namespace Parkings.Handlers.IHandlers
{
    internal interface IHandler
    {
        public void AddVehicle(Vehicle v);
        public void Add(Vehicle v);
        public uint GetFree();
        public uint GetMax();
        //public void Delete(Vehicle v);
        public void AddSize(uint size);
        public string  Status();
        public Garage<Vehicle> GetGarage();
    }
}