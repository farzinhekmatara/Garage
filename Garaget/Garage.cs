using System.Collections;
using Parkings.Garaget.IGaraget;

namespace Parkings.Garaget
{
    internal class Garage<T> : IEnumerable , IGarage
    {
        private uint capacity { get; set; }
        private uint parking_size { get; set; }
        private int index{get; set;}
        public Vehicle[] vehicles{set; get;}
        public Garage(uint i)
        {
            vehicles=new Vehicle[i];
            capacity = i;
            parking_size = i;
            index=0;
        }
         
        
        public void DeleteVehicle(Vehicle v)
        {
            capacity++;
        }

        
        public void AddVehicle(Vehicle v)
        {
            vehicles[index] = v;
            capacity--;
            index++;
        }
          
        public void AddParkingSize(uint size)
        {
            capacity = size;
            parking_size = size;
        }

        public uint GetFreePlaces() => capacity;
        public string GetStatus() => capacity == 0 ? "Full:" : "Lediga platser:";
        public uint GetMaxPlaces() => parking_size;

        public GarageEnum GetEnumerator()
        {
            return new GarageEnum(vehicles);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator) GetEnumerator();
        }

        
       
    }
}