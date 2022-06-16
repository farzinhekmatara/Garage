using System.Collections;

namespace Parkings.Garaget
{
    internal class Garage2<T> : IEnumerable<T> where T : Vehicle
    {

        private T[] vehicles;

        public Garage2(int capacity)
        {
            vehicles = new T[capacity];
        }


        public bool Park(T vehicle)
        {
            for (int i = 0; i < vehicles.Length; i++)
            {
                if (vehicles[i] is null)
                {
                    vehicles[i] = vehicle;
                    return true;
                }
            }

            return false;
        }

        // [null, null, Bil]
        public bool Unpark(string regnr)
        {
            for (int i = 0; i < vehicles.Length; i++)
            {
                if (vehicles[i] is not null && vehicles[i].registerNumber == regnr)
                {
                    vehicles[i] = null;
                    return true;
                }
            }

            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < vehicles.Length; i++)
            {
                if (vehicles[i] is not null)
                {
                    yield return vehicles[i];
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
