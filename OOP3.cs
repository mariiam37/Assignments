using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Assignments.OOP3;

namespace Assignments
{
    internal class OOP3
    {
        //PART ONE - THEORETICAL QUESTIONS
        //Q1:
        //a) Composition
        //b) Association
        //c) Inheritance
        //d) Aggregation
        //e) Dependency

        //Q2:
        //a) Yes , No
        //b) protected internal has access inside the same assembly or a derived class
        //   private protected has access inside the same assembly and a derived class
        //c) sealed when applied to a class prevents it from inheritance  
        //   but on a method prevents it from overriding again
        //d) yes you can create object from a sealed class as it only prevents inheritance

        //PART TWO - PRACTICAL
        public enum TicketType
        {
            Standard = 0,
            VIP = 1,
            IMAX = 2
        }
        public struct Seat
        {
            public char Row;
            public int Number;
            public Seat(char row, int number)
            {
                Row = row;
                Number = number;
            }
            public override string ToString()
            {
                return $"{Row}{Number}";
            }
        }
        public static class BookingHelper
        {
            public static int BookingCounter = 0;
            public static double CalcGroupDiscount(int numberOfTickets, double pricePerTicket)
            {
                double total = numberOfTickets * pricePerTicket;
                if (numberOfTickets >= 5)
                {
                    return total *= 0.90;
                }
                return total;
            }
            public static string GenerateBookingReference()
            {
                BookingCounter++;
                return "BK-" + BookingCounter;
            }
        }
        public class Ticket
        {
            private string _movieName;
            private TicketType _type;
            private Seat _seat;
            private double _price;
            public static int TicketCounter = 0;
            private int _ticketID;
            //MovieName Property
            public string MovieName
            {
                get { return _movieName; }
                set
                {
                    if (!string.IsNullOrEmpty(value))
                    {
                        _movieName = value;
                    }
                }
            }
            //ticket and seat properties
            public TicketType Type
            {
                get { return _type; }
                set { _type = value; }
            }

            public Seat Seat
            {
                get { return _seat; }
                set { _seat = value; }
            }

            //price property
            public double Price
            {
                get { return _price; }
                set
                {
                    if (value > 0)
                    {
                        _price = value;
                    }
                }
            }
            //c)tax calculated property
            public double PriceAfterTax => Math.Round(_price * 1.14, 1);
            //ticketID property
            public int TicketID => _ticketID;

            //full constructor
            public Ticket(string movieName, TicketType type, Seat seat, double price)
            {
                _movieName = movieName;
                _type = type;
                _seat = seat;
                _price = price;
            }

            //b) constructor with movie name and price : chains to the full constructor
            // default: Standard type, seat A1, price 50
            public Ticket(string movieName, double price)
                : this(movieName, TicketType.Standard, new Seat('A', 1), 50)
            {
                MovieName = movieName;
                Price = price;

                TicketCounter++;
                _ticketID = TicketCounter;
            }
            // CalcTotal: returns price + tax without changing the original Price
            public double CalcTotal(double taxPercent)
            {
                return Price + (Price * taxPercent / 100.0);
            }

            // ApplyDiscount: deducts discount from Price if valid, sets it to 0
            public void ApplyDiscount(ref double discountAmount)
            {
                if (discountAmount > 0 && discountAmount <= Price)
                {
                    Price -= discountAmount;
                    discountAmount = 0;
                }
            }

            //d)override ToString()
            public override string ToString()
            {
                return $"Ticket #{TicketID} | Movie: {MovieName} " +
                    $"| Price: {Price} EGP |" +
                    $" After Tax: {PriceAfterTax:F2} EGP";
            }

            //e) GetTotalTicketsSold()
            public static int GetTotalTicketsSold()
            {
                return TicketCounter;
            }
        }

        //2.a) StandardTicket — adds SeatNumber (string).
        public class StandardTicket : Ticket
        {
            public string SeatNumber { get; set; }
            public StandardTicket(string movieName, double price, string seatNumber)
                     : base(movieName, price)
            {
                SeatNumber = seatNumber;
            }
            public override string ToString()
            {
                return base.ToString() + $" | Seat: {SeatNumber} | Type: Standard";
            }
        }

        //2.b) VIPTicket — adds LoungeAccess (bool) and ServiceFee (decimal) = 50.
        public class VIPTicket : Ticket
        {
            public bool LoungeAccess { get; set; }
            public double ServiceFee => 50;
            public VIPTicket(string movieName, double price, bool loungeAccess)
                 : base(movieName, price)
            {
                LoungeAccess = loungeAccess;
            }
            public override string ToString()
            {
                return base.ToString() +
                       $" | Type: VIP | Lounge: {LoungeAccess} | Service Fee: {ServiceFee}";
            }
        }
        //2.c)  IMAXTicket — adds Is3D (bool). If true, the price increases by 30 EGP.
        public class IMAXTicket : Ticket
        {
            public bool Is3D { get; set; }
            public IMAXTicket(string movieName, double price, bool is3D)
                : base(movieName, is3D ? price + 30 : price)
            {
                Is3D = is3D;
            }
            public override string ToString()
            {
                return base.ToString() +
                       $" | Type: IMAX | 3D: {Is3D}";
            }
        }

        //3. 
        public class Projector
        {   
            public void Start()
            {
                Console.WriteLine("Projector started");
            }
            public void Stop()
            {
                Console.WriteLine("Projector stopped");
            }
        }
        public class Cinema
        {
            public string CinemaName { get; set; }

            private Projector _projector;   // composition
            private Ticket[] _tickets = new Ticket[20];

            public Cinema(string name)
            {
                CinemaName = name;
                _projector = new Projector(); 
            }
            //c.
            public void OpenCinema()
            {
                Console.WriteLine($"======== {CinemaName} Opened =======");
                _projector.Start();
            }

            public void CloseCinema()
            {
                Console.WriteLine($"======== {CinemaName} Closed ========");
                _projector.Stop();
            }
            //a.
            public void AddTicket(Ticket t)
            {
                for (int i = 0; i < _tickets.Length; i++)
                {
                    if (_tickets[i] == null)
                    {
                        _tickets[i] = t;
                        return;
                    }
                }
                Console.WriteLine("Cinema is full!");
            }
            //b.
            public void PrintAllTickets()
            {
                Console.WriteLine("===== All Tickets =====");
                foreach (var t in _tickets)
                {
                    if (t != null)
                        Console.WriteLine(t);
                }
            }
        }

        //4.
        class Program
        {
            static void Main()
            {
                Cinema cinema = new Cinema("Cairo Cinema");
                cinema.OpenCinema();

                StandardTicket standard = new StandardTicket("Inception", 120, "A5");
                VIPTicket vip = new VIPTicket("Avatar 2", 200, true);
                IMAXTicket imax = new IMAXTicket("Interstellar", 180, true);

                cinema.AddTicket(standard);
                cinema.AddTicket(vip);
                cinema.AddTicket(imax);

                cinema.PrintAllTickets();

                Console.WriteLine("======== Statistics ========");
                Console.WriteLine($"Total Tickets Created: {Ticket.GetTotalTicketsSold()}");
                Console.WriteLine("Booking References:");
                Console.WriteLine(BookingHelper.GenerateBookingReference());
                Console.WriteLine(BookingHelper.GenerateBookingReference());
                double discountedTotal = BookingHelper.CalcGroupDiscount(5, 100);
                Console.WriteLine($"Group Discount Total (5 × 100): {discountedTotal} EGP (10% off)");

                cinema.CloseCinema();
            }
        }

    }
}
