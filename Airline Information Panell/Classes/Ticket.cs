using AirlineInformationPanell.Enums;

namespace AirlineInformationPanell.Classes
{
    public class Ticket
    {
        public Ticket(byte ticketType, Passenger.Passenger passanger, Airline.Airline flight)
        {
            TicketType = (ClassEnum)ticketType;
            Passanger = passanger;
            Flight = flight;
        }

        public Passenger.Passenger Passanger;
        
        public ClassEnum TicketType;

        public Airline.Airline Flight;
    }
}