using Parkings.Garaget;
using Parkings.Handlers.IHandlers;

namespace Parkings.Handlers
{
   internal class Handler :  IHandler
    {
        Garage<Vehicle> garage;
        
        public Handler(uint i)
        {
            garage=new Garage<Vehicle>(i);
        }

        public Garage<Vehicle> GetGarage()
        {
            return garage;
        }
        public void AddVehicle(Vehicle v)
        {
            garage.AddVehicle(v);
        }

        public void DeleteVehicle(Vehicle v)
        {
            garage.DeleteVehicle(v);
        }
         public void AddSize(uint size)
        {
            garage.AddParkingSize(size);
        }

        public void Add(Vehicle v)
        {
            garage.AddVehicle(v);
        }
        public uint GetFree() => garage.GetFreePlaces();
        public uint GetMax() => garage.GetMaxPlaces();
        public string Status() => garage.GetStatus();
    }
}