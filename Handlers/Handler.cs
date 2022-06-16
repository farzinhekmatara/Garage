using Parkings.Garaget;
using Parkings.Handlers.IHandlers;

namespace Parkings.Handlers
{
    internal class Handler : IHandler
    {
        Garage<Vehicle> garage;
        Garage2<Vehicle> garage2;

        public Handler(uint i)
        {
            garage = new Garage<Vehicle>(i);
            garage2 = new Garage2<Vehicle>(10);
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



        public void Test(string searchString)
        {
            foreach (var vehicle in garage2.GroupBy(v => v.GetType().Name))
            {
                Console.WriteLine($"{vehicle.Key} : {vehicle.Count()}");
            }


            var result = garage2.Where(v => v.fueltype == searchString || v.VehicleColor == searchString).ToList();


            foreach (var vehicle in result)
            {
                Console.WriteLine(vehicle.Stats());
            }
            // Car : 5
            // Airplane : 4
            // 
        }
    }
}