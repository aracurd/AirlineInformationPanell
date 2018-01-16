using System.Collections.Generic;
using AirlineInformationPanell.Enums;

namespace AirlineInformationPanell.Classes.Plane
{
    public class PlaneController
    {
        private readonly Dictionary<PlaneEnum, Plane> _planes = new Dictionary<PlaneEnum, Plane>()
        {
            {PlaneEnum.Boeing, new Plane{Type = PlaneEnum.Boeing, BSeats = 100, BSeatsPrice = 300, ESeats = 152, ESeatsPrice = 140}},
            {PlaneEnum.Airobus, new Plane{Type = PlaneEnum.Airobus, BSeats = 70, BSeatsPrice = 300, ESeats = 148, ESeatsPrice = 150}}
        };

        public Plane this[PlaneEnum key] => _planes[key];
    }
}