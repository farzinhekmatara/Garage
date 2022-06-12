

namespace Parkings.Garaget.IGaraget
{
     internal interface IGarage
    {        
        public void AddVehicle(Vehicle v);
        public void DeleteVehicle(Vehicle v);
        public void AddParkingSize(uint size);
        public uint GetFreePlaces();
        public uint GetMaxPlaces();
        public string GetStatus();

    }
}