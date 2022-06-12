using System.Collections;

namespace Parkings.Garaget
{
    internal class GarageEnum : IEnumerator
    {
        public Vehicle[] vehicles;
        int position = -1;
        public GarageEnum(Vehicle[] list)
        {
            vehicles=new Vehicle[list.Length+1];
            vehicles=list;
        }

        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }

    
    public Vehicle Current
    {
        get
        {
            try
            {
                return vehicles[position];
            }
            catch (IndexOutOfRangeException)
            {
                throw new InvalidOperationException();
            }
        }
    }
        public bool MoveNext()
        {
            position++;
            return (position <vehicles.Length);
        }

        public void Reset()
        {
            position = -1;
        }
    }
}