using System;
using System.Collections.Generic;
using System.Linq;
using AirlineInformationPanell.Enums;
using AirlineInformationPanell.Classes.Helpers;

namespace AirlineInformationPanell.Classes.Airline
{
    public sealed class Airline
    {
        public Airline(int number, string departedDaT, string arrivedDaT, string departedCity, string arrivedCity,
            int terminalNumber, int gateNumber, PlaneEnum planeType)
        {
            var helper = new HelpersMethods();
            Number = number;
            DepartedCity = departedCity;
            ArrivedCity = arrivedCity;
            TerminalNumber = terminalNumber;
            Planes =  new Plane.PlaneController()[planeType];
            helper.StringToDateTime(departedDaT, out DepartedDateTime);
            helper.StringToDateTime(arrivedDaT, out ArrivedDateTime);
            GateNumber = gateNumber;
            Status = SetAirlineStatus();
            FreeBSeats = Planes.BSeats;
            FreeESeats = Planes.ESeats;
        }

        #region Aitline Info rows

            public readonly int Number;

            public DateTime DepartedDateTime;

            public DateTime ArrivedDateTime;

            public readonly string DepartedCity;

            public readonly string ArrivedCity;

            public readonly int TerminalNumber;

            public readonly int GateNumber;

            public PlaineStatusEnum Status;

            public Plane.Plane Planes;

            public int FreeBSeats;

            public int FreeESeats;

        #endregion

        public PlaineStatusEnum SetAirlineStatus(byte val = 1) => Status = (PlaineStatusEnum) val;
    }
}