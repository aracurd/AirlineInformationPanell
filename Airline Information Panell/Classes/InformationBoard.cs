using System;
using System.Globalization;
using AirlineInformationPanell.Classes.Airline;
using AirlineInformationPanell.Classes.Helpers;
using AirlineInformationPanell.Classes.Passenger;

namespace AirlineInformationPanell.Classes
{
    public class InformationBoard 
    {
        public void ViewAirline(AirlineController airline)
        {
            Console.WriteLine(
                airline.Airlines.ToStringTable(
                    new[]
                    {
                        "Arrived at",
                        "Departed at",
                        "Flight number",
                        "City of arrival",
                        "City of departure",
                        "Terminal",
                        "Gate",
                        "Flight status",
                        "Plane"
                    },
                    plane => plane.Value.ArrivedDateTime,
                    plane => plane.Value.DepartedDateTime,
                    plane => plane.Value.Number,
                    plane => plane.Value.ArrivedCity,
                    plane => plane.Value.DepartedCity,
                    plane => plane.Value.TerminalNumber,
                    plane => plane.Value.GateNumber,
                    plane => plane.Value.Status,
                    plane=> plane.Value.Planes.Type
                )
            );
        }

        public void ViewAllPassangers(PassangersController passangers)
        {
            var faIR = new CultureInfo("fa-IR");
            Console.WriteLine(
                passangers.PassangersList.ToStringTable(
                    new[]
                    {
                        "Id",
                        "First Name",
                        "Last Name",
                        "Nationality,",
                        "Passport Number",
                        "Birthday",
                        "Sex"
                    },
                    pass => pass.Key,
                    pass => pass.Value.FirstName,
                    pass => pass.Value.LastName,
                    pass => pass.Value.Nationality,
                    pass => pass.Value.PassportNumber,
                    pass => pass.Value.Birthday.ToShortDateString(),
                    pass => pass.Value.Sex
                )
            );
        }

        public void ViewAllPassangersTickets(PassangersController passangers, int passangerId)
        {
            
            Console.WriteLine(
                passangers.PassangersList[passangerId].Tickets.ToStringTable(
                    new[]
                    {
                        //"Passanger Id",
                        "First Name",
                        "Last Name",
                        "Gate,",
                        "City of arrival",
                        "City of departure",
                        "Arrived at",
                        "Departed at",
                        "Ticket type"
                    },
                    //ticket => ticket.Passanger.PassangerId,
                    ticket => ticket.Passanger.FirstName,
                    ticket => ticket.Passanger.LastName,
                    ticket => ticket.Flight.GateNumber,
                    ticket => ticket.Flight.DepartedCity,
                    ticket => ticket.Flight.ArrivedCity,
                    ticket => ticket.Flight.ArrivedDateTime,
                    ticket => ticket.Flight.DepartedDateTime,
                    ticket => ticket.TicketType
                )
            );
        }
    }
}