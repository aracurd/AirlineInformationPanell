using System;
using System.Collections.Generic;
using AirlineInformationPanell.Classes.Helpers;
using AirlineInformationPanell.Enums;

namespace AirlineInformationPanell.Classes.Airline
{
    public sealed class AirlineController
    {
        public void AddAirline(string departedDaT, string arrivedDaT, string departedCity, string arrivedCity,
            int terminalNumber, int gateNumber, byte plane)
        {
            var number = _helpers.NumberGenerator<Airline>(Airlines);
            Airlines.Add(number, new Airline(number, departedDaT, arrivedDaT, departedCity, arrivedCity, terminalNumber, gateNumber, (PlaneEnum)plane));
        }

        private readonly HelpersMethods _helpers = new HelpersMethods();

        public Dictionary<int, Airline> Airlines = new Dictionary<int, Airline>();
        
        public Airline this[int number] => Airlines[number];

        public bool SetAirlineStatus(int key, byte status)
        {
            if (!Airlines.ContainsKey(key))
            {
                Console.WriteLine("key error");
                return false;
            }

            Airlines[key].Status = (PlaineStatusEnum) status;
            return true;
        }

        public void Remove(int key) => Airlines.Remove(key);
 
        //ticket status enum (added, removed)
        public void UpdateAirline(int airNumber, byte ticketStatus, ClassEnum ticketType) 
        {
            var airLine = this[airNumber];

            switch (ticketStatus)
            {
                case 1:
                    if (ticketType == ClassEnum.Business || airLine.FreeBSeats != 0)
                    {
                        airLine.FreeBSeats--;
                        return;
                    }

                   if(airLine.FreeESeats != 0)
                        airLine.FreeESeats--;

                    break;
                case 2:
                    if (ticketType == ClassEnum.Business)
                        airLine.FreeBSeats++;
                    else
                        airLine.FreeESeats++;
                    break;
            }
        }
    }
}
