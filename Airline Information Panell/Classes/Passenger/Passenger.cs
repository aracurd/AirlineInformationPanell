using System;
using System.Collections.ObjectModel;
using AirlineInformationPanell.Classes.Helpers;
using AirlineInformationPanell.Enums;

namespace AirlineInformationPanell.Classes.Passenger
{

    public sealed class Passenger
    {
        private readonly HelpersMethods _helpers = new HelpersMethods();

        public Passenger(int passangerId, string firstName, string lastName, string nationality, string passportNumber, 
            string birthday, byte sex)
        {
            PassangerId = passangerId;
            FirstName = firstName;
            LastName = lastName;
            Nationality = nationality;
            PassportNumber = passportNumber;
            _helpers.StringToDateTime(birthday, out Birthday);
            Sex = (SexEnum)sex;
            Tickets = new ObservableCollection<Ticket>();
        }

        public int PassangerId;

        public string FirstName;

        public string LastName;

        public string Nationality;

        public string PassportNumber;

        public DateTime Birthday;

        public SexEnum Sex;

        public ObservableCollection<Ticket> Tickets { get; set; }
    }
}