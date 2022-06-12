using Parkings.Handlers.IHandlers;
using Parkings.Ui;
using Parkings.Garaget;

namespace Parkings
{
    internal class InOutconsole : IUi
    {
        public string? GetInput()
        {
            return Console.ReadLine();
        }

        public void print_out(string message)
        {
            Console.WriteLine(message);
        }

        public uint NumberInput()
        {
            uint places;
            do
            {
                Console.Clear();
                Console.WriteLine("Antal Parkeringsplatser:(Större än 5 mindre än 100)");
                string? answer = Console.ReadLine();
                if (uint.TryParse(answer, out places))
                {
                    if (places <= 100 && places >= 5)
                        return places;
                }

            } while (true);
        }

        public void GetMenue(IHandler handler)
        {
            Console.WriteLine($"****  {handler.Status()} {handler.GetFree()}    Max platser: {handler.GetMax()}  ****");
            Console.WriteLine(
                "1. Print ut lista på alla fordon\n" +
                "2. Parkera fordon\n" +
                "3. Köra ut\n" +
                "4. Sök med registrerindnummer\n" +
                "5. Sök Car Boat Motorcycle\n" +
                "0. Avsluta");
        }

        public void ClearConsole()
        {
            Console.Clear();
        }

        public void printAllobject(IHandler appHandler)
        {
            Console.WriteLine($"**********  Lista på alla parkerade fordon  **********");
            foreach (Vehicle vehicle in appHandler.GetGarage())
            {
                if (vehicle != null)
                {
                    Console.WriteLine($"REG:{vehicle.registerNumber}   Color:{vehicle.VehicleColor} " +
                    $"   Bränsle:{vehicle.fueltype}   Sittplats:{vehicle.seats}");
                }
                //else 
                //Console.WriteLine("Ingen bil");
            }
        }
        public void PrintOneType(IHandler appHandler, string typ)
        {
            int count = 0;
            Console.WriteLine($"**********  Hittade fordon  **********");
            foreach (Vehicle vehicle in appHandler.GetGarage())
            {
                if (vehicle != null && vehicle is Car && typ.Equals("Car")) {
                    Console.WriteLine($"REG:{vehicle.registerNumber}   Color:{vehicle.VehicleColor} " +
                    $"   Bränsle:{vehicle.fueltype}   Sittplats:{vehicle.seats}");
                    count++;
                }
                else if (vehicle != null && vehicle is Boat && typ.Equals("Boat"))
                {
                    Console.WriteLine($"REG:{vehicle.registerNumber}   Color:{vehicle.VehicleColor} " +
                  $"   Bränsle:{vehicle.fueltype}   Sittplats:{vehicle.seats}");
                    count++;
                }
                else if (vehicle != null && vehicle is Motorcycle && typ.Equals("Motorcycle"))
                {
                    Console.WriteLine($"REG:{vehicle.registerNumber}   Color:{vehicle.VehicleColor} " +
                  $"   Bränsle:{vehicle.fueltype}   Sittplats:{vehicle.seats}");
                    count++;
                }
            }
            if (count == 0)
                Console.WriteLine("Det finns inget fordon");
        }

        public void printWithRegisternumber(IHandler appHandler, string reg)
        {
            int count = 0;
            Console.Clear();
            Console.WriteLine($"**********  Fordon med Registreringsnummer  {reg}**********");
            foreach (Vehicle vehicle in appHandler.GetGarage())
            {
                if (vehicle != null && vehicle.registerNumber.ToUpper().Equals(reg.Trim().ToUpper())) {
                    Console.WriteLine($"REG:{vehicle.registerNumber}   Color:{vehicle.VehicleColor} " +
                    $"   Bränsle:{vehicle.fueltype}   Sittplats:{vehicle.seats}");
                    count++;
                }
            }
            if (count == 0)
                Console.WriteLine("Det finns inget fordon");
        }

        public void ChechRegister(IHandler appHandler, string str)
        {
            if (appHandler.GetFree() == 0)
            {
                Console.WriteLine("Det finns ingen ledig plats.");
            }
            else if (appHandler.GetFree() > 0)
            {
                int count = 0;
                string[] fordon = str.Split(" ");
                foreach (Vehicle vehicle in appHandler.GetGarage())
                {
                    if (vehicle != null && vehicle.registerNumber.ToUpper().Equals(fordon[1].ToUpper()))
                    {
                        count++;
                    }
                }
                if (!fordon[0].ToUpper().Trim().Equals("CAR") && !fordon[0].Trim().ToUpper().Equals("BOAT") &&
                 !fordon[0].Trim().ToUpper().Equals("MOTORCYCLE"))
                    count++;
                if (count == 0)
                {
                    string type = setType(fordon[0]);
                    if (type.Equals("Car"))
                        appHandler.Add(new Car(fordon[1].ToUpper(), fordon[2].ToUpper(), fordon[3].ToUpper(), Int32.Parse(fordon[4]), Int32.Parse(fordon[5])));
                    if (type.Equals("Boat"))
                        appHandler.Add(new Boat(fordon[1].ToUpper(), fordon[2].ToUpper(), fordon[3].ToUpper(), Int32.Parse(fordon[4])));
                    if (type.Equals("Motorcycle"))
                        appHandler.Add(new Motorcycle(fordon[1].ToUpper(), fordon[2].ToUpper(), fordon[3].ToUpper(), Int32.Parse(fordon[4]), Int32.Parse(fordon[5])));
                    Console.WriteLine("---------- Fordon är parkerad ----------.");
                }
                if (count > 0)
                {
                    Console.WriteLine("Någt dick fel.Försök igen.");
                    return;
                }
            }
        }

            public string setType(string ObType)
            {
                if (ObType.Trim().ToUpper().Equals("CAR"))
                    ObType = "Car";
                if (ObType.Trim().ToUpper().Equals("BOAT"))
                    ObType = "Boat";
                if (ObType.Trim().ToUpper().Equals("MOTORCYCLE"))
                    ObType = "Motorcycle";
                return ObType;
            }

        }
}