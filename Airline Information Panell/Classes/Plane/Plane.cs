using AirlineInformationPanell.Enums;

namespace AirlineInformationPanell.Classes.Plane
{
    public sealed class Plane
    {
        public PlaneEnum Type;

        //Business sits count
        public int BSeats;
        
        public double BSeatsPrice;

        //Economy sits count
        public int ESeats;

        public double ESeatsPrice;

        public int GetSeats(byte key)
        {
            if (key == 1)
                return BSeats;

            if (key == 2)
                return ESeats;

            return 0;
        }
    }
}