using AirlineInformationPanell.Classes;
using AirlineInformationPanell.Classes.Airline;
using AirlineInformationPanell.Classes.Passenger;
using static System.Console;

namespace AirlineInformationPanell
{
    internal class Program
    {
        static AirlineController air = new AirlineController();

        static InformationBoard iBoard = new InformationBoard();

        static PassangersController pass = new PassangersController();

        static bool go = true;

        public static void Main(string[] args)
        {
            Title = "Airline Information Panell";
            AddTestContent();
            
            while (go)
            {
                Actions();
            }

            ReadKey();
        }

        private static void Actions()
        {
            
            NewAction();

            WriteLine("Select an action:\nShow all flights:\t0,\nCreate a passenger:\t1,\nCreate flight:\t2,\nBuy ticket for the passenger:\t3,\nEdit airline:\t4,\nPassenger ticket management:\t5\nExit:\tx\n");

            var key = ReadLine();

            switch (key)
            {
                case "0":
                {
                    ShowAllAirline();
                    break;
                }
                case "1":
                {
                    CreatePaccanger();
                    break;
                }
                case "2":
                {
                    AddNewAirline();
                    break;
                }
                case "3":
                {
                    BayTicket();
                    break;
                }
                case "4":
                {
                    EditAirline();
                    break;
                }
                case "5":
                {
                    PassengerTicketManagement();
                    break;
                }
                case "x":
                {
                    go = false;
                    break;
                }
                default:
                {
                    WriteLine("No action selected");
                    break;
                }
            }

            //if (go == false)
            //    return;
        }

        private static void ShowAllAirline()
        {
            NewAction();
            iBoard.ViewAirline(air);
        }

        private static void AddNewAirline()
        {
            NewAction();
            WriteLine("To create new airline add in one line information in format:");
            WriteLine("Departed City,Arrived City,Departed Date - dd / mm / yy hh: mm,Arrived Date - dd / mm / yy hh: mm,Terminal Number,Gate Number,Plane type");
            var val = new string[7];
            val = ReadLine().Remove(' ').Split(',');
            air.AddAirline(val[2], val[3], val[0], val[1], int.Parse(val[4]), int.Parse(val[5]), byte.Parse(val[6]));
        }

        private static void CreatePaccanger()
        {
            NewAction();
            WriteLine("To create new passanger add in one line information in format:");
            WriteLine("First Name,LastName,Nationality,Passport Number,Birthday,Sex");
            var val = new string[6];
            val = ReadLine().Split(',');
            pass.AddPassanger(val[0], val[1],  val[2], val[3], val[4], byte.Parse(val[5]));
        }

        private static void BayTicket()
        {
            NewAction();
            WriteLine("To bay ticket add in one line information in format:");
            WriteLine(" Passanger Id,  ticket type,  airlineNumber");
            var val = new string[3];
            val = ReadLine().Remove(' ').Split(',');
            pass.BayTicket(air,int.Parse(val[0]), byte.Parse(val[1]), int.Parse(val[2]));
        }

        private static void EditAirline()
        {
            NewAction();
            WriteLine("Select an action:\nChange status:\t1\nRemove\t2\n");

            var key = ReadLine();

            switch (key)
            {
                case "1":
                {
                    ChangeAirlineStatus();
                    break;
                }
                case "2":
                {
                    RemoveAirline();
                    break;
                }
            }
        }

        private static void PassengerTicketManagement()
        {
            NewAction();
            WriteLine("Select an action:\nShow all tickets:\t1\nRemove ticket\t2\n");

            var key = ReadLine();

            switch (key)
            {
                case "1":
                {
                    ShowAllTickets();
                    break;
                }
                case "2":
                {
                    RemoveTicket();
                    break;
                }
            }
        }

        private static void ChangeAirlineStatus()
        {
            NewAction();
            WriteLine("To bay ticket add in one line information in format:");
            WriteLine(" Airline Number, Status number(Unknown - 1,CheckIn - 2,Closed - 3,Arrived - 4,Departed - 5,Canceled - 6,Expected - 7,Delayed - 8,InFlight - 9)");
            var val = new string[2];
            val = ReadLine().Remove(' ').Split(',');
            air.SetAirlineStatus(int.Parse(val[0]), byte.Parse(val[1]));
        }

        private static void RemoveAirline()
        {
            NewAction();
            WriteLine("To remove airline write they number:");
            WriteLine(" Airline Number: ");
            var val = ReadLine()?.Remove(' ');
            air.Remove(int.Parse(val));
            
        }

        private static void ShowAllTickets()
        {
            NewAction();
            WriteLine("To Show all passanger tickets write they number:");
            WriteLine(" Passanger number: ");
            var val = ReadLine()?.Remove(' ');
            iBoard.ViewAllPassangersTickets(pass, int.Parse(val));
        }

        private static void RemoveTicket()
        {
            NewAction();
            WriteLine("To remove ticket add in one line information in format:");
            WriteLine("Passanger Id, airlineNumber");
            var val = new string[2];
            val = ReadLine()?.Remove(' ').Split(',');
            pass.UnBayTicket(air, int.Parse(val[0]), int.Parse(val[1]));
        }

        private static void NewAction()
        {
            //Clear();
            WriteLine();
            //WriteLine(Title);
        }

        private static void AddTestContent()
        {
            air.AddAirline("01/12/2017 20:00", "02/12/2017 08:00", "City 1", "City 2", 1, 3, 2);
            air.AddAirline("01/12/2017 20:00", "02/12/2017 08:00", "City 1", "City 2", 1, 3, 1);
            air.AddAirline("01/12/2017 20:00", "02/12/2017 08:00", "City 1", "City 2", 1, 3, 2);
            air.AddAirline("01/12/2017 20:00", "02/12/2017 08:00", "City 1", "City 2", 1, 3, 1);
            air.AddAirline("01/12/2017 20:00", "02/12/2017 08:00", "City 1", "City 2", 1, 3, 2);
            air.AddAirline("01/12/2017 20:00", "02/12/2017 08:00", "City 1", "City 2", 1, 3, 1);
        }
    }
}