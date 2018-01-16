using System;
using System.Collections.Generic;
using System.Linq;
using AirlineInformationPanell.Classes.Airline;
using AirlineInformationPanell.Classes.Helpers;
using AirlineInformationPanell.Enums;

namespace AirlineInformationPanell.Classes.Passenger
{
    public class PassangersController
    {
        private readonly HelpersMethods _helpers = new HelpersMethods();

        public  IDictionary<int,Passenger> PassangersList { get; } = new Dictionary<int, Passenger>( );

        public  void AddPassanger(string fName, string lName, string nationality, string passportNumber, string birthday, byte sex)
        {
            var pId = _helpers.NumberGenerator<Passenger>(PassangersList);
            var passenger = new Passenger(pId, fName, lName, nationality, passportNumber, birthday, sex);
            PassangersList.Add(pId, passenger);
        }
        
        public void BayTicket(AirlineController airline, int passangerId, byte pType, int airlineNumber)
        {
            var type = (ClassEnum) pType;

            switch (type)
            {
                case ClassEnum.Business:
                    if (airline.Airlines[airlineNumber].FreeBSeats > 0)
                    {
                        PassangersList[passangerId].Tickets.Add(new Ticket(pType, PassangersList[passangerId],airline.Airlines[airlineNumber]));
                        return;
                    }
                    Console.WriteLine($"There are no seats for {type} class");
                    break;
                case ClassEnum.Economy:
                    if (airline.Airlines[airlineNumber].FreeBSeats > 0)
                    {
                        PassangersList[passangerId].Tickets.Add(new Ticket(pType, PassangersList[passangerId], airline.Airlines[airlineNumber]));
                        return;
                    }
                    Console.WriteLine($"There are no seats for {type} class");
                    break;
            }

            airline.UpdateAirline(airlineNumber, 1, type);  
        }

        public void UnBayTicket(AirlineController airline, int passangerId, int airlineNumber)
        {
            var item = PassangersList[passangerId].Tickets.FirstOrDefault(s => s.Flight.Number == airlineNumber);
            if (item != null)
            {
                var type = item.TicketType;
                PassangersList[passangerId].Tickets.Remove(item);

                airline.UpdateAirline(airlineNumber, 2, type);
            }
                
            return;
        }
    }
}