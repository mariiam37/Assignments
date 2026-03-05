using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Assignments
{
    public class OOP4
    {
        /*PART ONE - THEORITICAL QUESTIONS
        1. static binding : when the compiler knows what method to call before run time (over loading , method hiding)
           dynamic binding : method is resolved at run time based on actual object (overriding , virtual methods)

        2.method overloading : methods of same name but different parameters and different implementation
          method overriding : methods of same signature (same name , same parameters , same return type) but
                              with different implementation

        3. virtual : for parent class method this keyword allows method to be overridden
           override : for child class method this keyword replaces implementation of parent class method
        */

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
            private decimal _price;
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
            public decimal Price
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
            //tax calculated property
            public decimal PriceAfterTax => Math.Round(_price*1.14m, 1);
            //ticketID property
            public int TicketID => _ticketID;

            //full constructor
            public Ticket(string movieName, TicketType type, Seat seat, decimal price)
            {
                _movieName = movieName;
                _type = type;
                _seat = seat;
                _price = price;
            }

            // constructor with movie name and price : chains to the full constructor
            // default: Standard type, seat A1, price 50
            public Ticket(string movieName, decimal price)
                : this(movieName, TicketType.Standard, new Seat('A', 1), 50)
            {
                MovieName = movieName;
                Price = price;

                TicketCounter++;
                _ticketID = TicketCounter;
            }
            // CalcTotal: returns price + tax without changing the original Price
            public decimal CalcTotal(decimal taxPercent)
            {
                return Price + (Price * taxPercent / 100.0m);
            }

            // ApplyDiscount: deducts discount from Price if valid, sets it to 0
            public void ApplyDiscount(ref decimal discountAmount)
            {
                if (discountAmount > 0 && discountAmount <= Price)
                {
                    Price -= discountAmount;
                    discountAmount = 0;
                }
            }

            //override ToString()
            public override string ToString()
            {
                return $"Ticket #{TicketID} | Movie: {MovieName} " +
                    $"| Price: {Price} EGP |" +
                    $" After Tax: {PriceAfterTax:F2} EGP";
            }

            // GetTotalTicketsSold()
            public static int GetTotalTicketsSold()
            {
                return TicketCounter;
            }

            public virtual void PrintTicket()
            {
                Console.WriteLine ($"Ticket #{TicketID} | Movie: {MovieName} " +
                   $"| Price: {Price} EGP |" +
                   $" After Tax: {PriceAfterTax:F2} EGP");
            }

            public void SetPrice(decimal price)
            {
                Price = price;
                Console.WriteLine($"Setting price directly: {Price} EGP");
            }

            public void SetPrice(decimal price, decimal multiplier)
            {
                Price = price * multiplier;
                Console.WriteLine($"Setting price with multiplier: {price} x {multiplier} = {Price} EGP");
            }
        }

        // StandardTicket — adds SeatNumber (string).
        public class StandardTicket : Ticket
        {
            public string SeatNumber { get; set; }
            public StandardTicket(string movieName, decimal price, string seatNumber)
                     : base(movieName, price)
            {
                SeatNumber = seatNumber;
            }
            public override string ToString()
            {
                return base.ToString() + $" | Seat: {SeatNumber} | Type: Standard";
            }
            public override void PrintTicket()
            {
                base.PrintTicket();
                Console.WriteLine($"Seat Number: {SeatNumber}");
                Console.WriteLine("Type: Standard");
                Console.WriteLine();
            
            }
        }

        // VIPTicket — adds LoungeAccess (bool) and ServiceFee (decimal) = 50.
        public class VIPTicket : Ticket
        {
            public bool LoungeAccess { get; set; }
            public double ServiceFee => 50;
            public VIPTicket(string movieName, decimal price, bool loungeAccess)
                 : base(movieName, price)
            {
                LoungeAccess = loungeAccess;
            }
            public override string ToString()
            {
                return base.ToString() +
                       $" | Type: VIP | Lounge: {LoungeAccess} | Service Fee: {ServiceFee}";
            }

            public override void PrintTicket()
            {
                base.PrintTicket();
                Console.WriteLine($"Lounge Access: {LoungeAccess}");
                Console.WriteLine($"Service Fee: {ServiceFee}");
                Console.WriteLine("Type: VIP");
                Console.WriteLine();
            }
        }
        // IMAXTicket — adds Is3D (bool). If true, the price increases by 30 EGP.
        public class IMAXTicket : Ticket
        {
            public bool Is3D { get; set; }
            public IMAXTicket(string movieName, decimal price, bool is3D)
                : base(movieName, is3D ? price + 30 : price)
            {
                Is3D = is3D;
            }
            public override string ToString()
            {
                return base.ToString() +
                       $" | Type: IMAX | 3D: {Is3D}";
            }

            public override void PrintTicket()
            {
                base.PrintTicket();
                Console.WriteLine($"3D: {Is3D}");
                Console.WriteLine("Type: IMAX");
                Console.WriteLine();
            }
        }

        public class Projector
        {
            public void Start()
            {
                Console.WriteLine("Projector started.");
                Console.WriteLine();
            }
            public void Stop()
            {
                Console.WriteLine("Projector stopped.");
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
            public void PrintAllTickets()
            {
                foreach (var t in _tickets)
                {
                    if (t != null)
                        t.PrintTicket();
                }
            }
        }
        public static void ProcessTicket(Ticket t)
        {
            t.PrintTicket();
        }

        public class Program
        {
            static void Main()
            {
                var cinema = new Cinema("Cairo Cinema");
                cinema.OpenCinema();
                var standardTicket = new StandardTicket("Inception" , 150 , "A-5");
                var VIPTicket = new VIPTicket("Avengers" , 200 , true);
                var IMAXTicket = new IMAXTicket("Dune" , 180 , false);

                Console.WriteLine("======== SetPrice Test ========");
                standardTicket.SetPrice(150);
                standardTicket.SetPrice(100, 1.5m);
                Console.WriteLine();

                cinema.AddTicket( standardTicket );
                cinema.AddTicket(VIPTicket );
                cinema.AddTicket(IMAXTicket );

                Console.WriteLine("======== All Tickets ========");
                cinema.PrintAllTickets();

                Console.WriteLine("======== Process Single Ticket ========");
                ProcessTicket(VIPTicket);

                cinema.CloseCinema();
            }
        }
    }
}

