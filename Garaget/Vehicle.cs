

namespace Parkings.Garaget
{
    internal abstract class Vehicle
    {
        public string registerNumber { get; set; }
        public string VehicleColor { get; set; }
        public string fueltype { get; set; }
        public int seats { get; set; }
        public Vehicle(string number, string color, string fuel, int seat)
        {
            registerNumber = number;
            VehicleColor = color;
            fueltype = fuel;
            seats = seat;
        }




        public virtual string Stats()
        {
            return $"License plate: {registerNumber} | Color: {VehicleColor} | Fueltype: {fueltype} | Number of seats: {seats} | ";
        }

    }

    class Car : Vehicle
    {
        public int wheel { get; set; }
        public Car(string n, string c, string f, int s, int wheel) : base(n, c, f, s)
        {
            this.wheel = wheel;
        }

        public override string Stats()
        {
            return base.Stats() + $"Number of wheels: {wheel}";
        }

    }

    class Motorcycle : Vehicle
    {
        public int wheel { get; set; }
        public Motorcycle(string n, string c, string f, int s, int wheel) : base(n, c, f, s)
        {
            this.wheel = wheel;
        }
    }
    class Boat : Vehicle
    {
        public Boat(string n, string c, string f, int s) : base(n, c, f, s)
        {

        }
    }
    /*
     class Airplane : Vehicle
     {
         public int wheel{get; set;}
         public Airplane(int wheel, string number, string color) : base(number,color)
         {
             this.wheel=wheel;
         }
     }


     public class Bus : Vehicle
     {

     }*/
}