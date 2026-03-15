//using System;
//using System.Buffers;
//using System.Collections.Generic;
//using System.Linq;
//using System.Runtime.CompilerServices;
//using System.Text;
//using System.Threading.Tasks;

//namespace Assignments
//{
//    public class OOP5
//    {
//        /*PART ONE - THEORITCAL QUESTIONS
//        Q1 : What is an interface in C#? Why do we use interfaces instead of depending on concrete classes directly?
//        Mention at least three benefits of using interfaces.
//        Q1: interface is a type that defines method signatures without their implementations
//         and classes that implement the interface must provide the implementation of methods,
//         because interfaces allow programs to depend on abstractions instead of specific implementations
//         1. loose coupling 2.polymorphism 3.better testing

//        Q2: a) only the shared Greet() method in Translator is executed
//            so there is no difference between English and Arabic Speaker

//            b) by using explicit interface implementation : 
//            class Translator : IEnglishSpeaker, IArabicSpeaker
//            {
//                void IEnglishSpeaker.Greet()
//                {
//                    Console.WriteLine("Hello");
//                }

//                void IArabicSpeaker.Greet()
//                {
//                    Console.WriteLine("Ahlan");
//                }
//            }
//            to allow different implementations of method with same signature
            
//            c)no, it can be accessed only through each interface refrence because we applied external interface 
//            implementation 


//        Q3: shallow copy :creates a new object but copies references of nested objects instead of
//            creating new one
//            deep copy: creates a completely independent copy of the object and all objects it references

//            use shallow copy when => objects contain only value types or shared references are acceptable
//            use deep copy when => objects contain reference types and must be fully independent
            
//            shallow copy risk: if the object contains reference fields then both objects will reference the
//            same inner object and changes in the nested object in one copy will affect the other


//        Q4: output : Dev - Testing
//                     QA	- Testing
//            because : Title is independent (value copy) and Dept is shared because
//            shallow copy copies the reference not the object
//         */

//        //PART TWO - PRACTICAL
//        public enum TicketType
//        {
//            Standard = 0,
//            VIP = 1,
//            IMAX = 2
//        }
//        public struct Seat
//        {
//            public char Row;
//            public int Number;
//            public Seat(char row, int number)
//            {
//                Row = row;
//                Number = number;
//            }
//            public override string ToString()
//            {
//                return $"{Row}{Number}";
//            }
//        }
//        public interface IPrintable
//        {
//            void Print();
//        }

//        public interface IBookable
//        {
//            bool Book();
//            bool Cancel();
//            bool IsBooked { get; }
//        }
//        public static class BookingHelper
//        {
//            private static int BookingCounter = 0;
//            public static double CalcGroupDiscount(int numberOfTickets, double pricePerTicket)
//            {
//                double total = numberOfTickets * pricePerTicket;
//                if (numberOfTickets >= 5)
//                {
//                    return total *= 0.90;
//                }
//                return total;
//            }
//            public static string GenerateBookingReference()
//            {
//                BookingCounter++;
//                return "BK-" + BookingCounter;
//            }
//            public static void PrintAll(IPrintable[] items)
//            {
//                foreach (var item in items)
//                {
//                    item.Print();
//                }
//            }
//        }
//        public class Ticket : IPrintable, IBookable, ICloneable
//        {
//            private string? _movieName;
//            private decimal _price;
//            private static int TicketCounter = 0;
//            private int _ticketID;
//            private bool _isBooked = false;

//            //MovieName Property
//            public string? MovieName
//            {
//                get { return _movieName; }
//                set
//                {
//                    if (!string.IsNullOrEmpty(value))
//                    {
//                        _movieName = value;
//                    }
//                }
//            }

//            //price property
//            public decimal Price
//            {
//                get { return _price; }
//                set
//                {
//                    if (value > 0)
//                    {
//                        _price = value;
//                    }
//                }
//            }
//            //tax calculated property
//            public decimal PriceAfterTax => Math.Round(_price * 1.14m, 1);
//            //ticketID property
//            public int TicketID => _ticketID;
//            //isBooked property
//            public bool IsBooked => _isBooked;

//            //full constructor
//            public Ticket(string movieName, decimal price)
//            {
//                MovieName = movieName;             
//                Price = price;
//                TicketCounter++;
//                _ticketID = TicketCounter;
//            }

//            // CalcTotal: returns price + tax without changing the original Price
//            public decimal CalcTotal(decimal taxPercent)
//            {
//                return Price + (Price * taxPercent / 100.0m);
//            }

//            // ApplyDiscount: deducts discount from Price if valid, sets it to 0
//            public void ApplyDiscount(ref decimal discountAmount)
//            {
//                if (discountAmount > 0 && discountAmount <= Price)
//                {
//                    Price -= discountAmount;
//                    discountAmount = 0;
//                }
//            }

//            //override ToString()
//            public override string ToString()
//            {
//                return $"Ticket #{TicketID} | Movie: {MovieName} " +
//                    $"| Price: {Price} EGP |" +
//                    $" After Tax: {PriceAfterTax:F2} EGP";
//            }

//            // GetTotalTicketsSold()
//            public static int GetTotalTicketsSold()
//            {
//                return TicketCounter;
//            }

//            public virtual void PrintTicket()
//            {
//                Console.WriteLine($"Ticket #{TicketID} | Movie: {MovieName} " +
//                   $"| Price: {Price} EGP |" +
//                   $" After Tax: {PriceAfterTax:F2} EGP");
//            }

//            public void SetPrice(decimal price)
//            {
//                Price = price;
//                Console.WriteLine($"Setting price directly: {Price} EGP");
//            }

//            public void SetPrice(decimal price, decimal multiplier)
//            {
//                Price = price * multiplier;
//                Console.WriteLine($"Setting price with multiplier: {price} x {multiplier} = {Price} EGP");
//            }
//            //booking logic
//            public bool Book()
//            {
//                if (_isBooked)
//                    return false;

//                _isBooked = true;
//                return true;
//            }
//            public bool Cancel()
//            {
//                if (!_isBooked)
//                    return false;

//                _isBooked = false;
//                return true;
//            }
//            //implemented Iprintable
//            public virtual void Print()
//            {
//                Console.Write($"[Ticket #{TicketID}] {MovieName} | Price: {Price} | After Tax: {PriceAfterTax} |" +
//                    $" Booked: {(IsBooked ? "Yes" : "No")}");
//            }

//            // implemented cloning (deep copy)
//            public virtual object Clone()
//            {
//                return MemberwiseClone();
//            }
//        }

//        public class StandardTicket : Ticket
//        {
//            public string SeatNumber { get; set; }
//            public StandardTicket(string movieName, decimal price, string seatNumber)
//                     : base(movieName, price)
//            {
//                SeatNumber = seatNumber;
//            }
//            public override string ToString()
//            {
//                return base.ToString() + $" | Seat: {SeatNumber} | Type: Standard";
//            }
//            public override void Print()
//            {
//                Console.WriteLine($"[Ticket #{TicketID}] {MovieName} | Standard | Seat: {SeatNumber} | Price: {Price} |" +
//                    $" After Tax: {PriceAfterTax} | Booked: {(IsBooked ? "Yes" : "No")}");
//            }
//        }

//        // VIPTicket — adds LoungeAccess (bool) and ServiceFee (decimal) = 50.
//        public class VIPTicket : Ticket
//        {
//            public bool LoungeAccess { get; set; }
//            public double ServiceFee => 50;
//            public VIPTicket(string movieName, decimal price, bool loungeAccess)
//                 : base(movieName, price)
//            {
//                LoungeAccess = loungeAccess;
//            }
//            public override string ToString()
//            {
//                return base.ToString() +
//                       $" | Type: VIP | Lounge: {LoungeAccess} | Service Fee: {ServiceFee}";
//            }
//            public override void Print()
//            {
//                Console.WriteLine($"[Ticket #{TicketID}] {MovieName} | VIP | Lounge: {LoungeAccess} | Fee: {ServiceFee} |" +
//                    $" Price: {Price} | After Tax: {PriceAfterTax} | Booked: {(IsBooked ? "Yes" : "No")}");
//            }

//            // override clone to create independent object
//            public override object Clone()
//            {
//                return new VIPTicket(MovieName, Price, LoungeAccess);
//            }
//        }
        
//        public class IMAXTicket : Ticket
//        {
//            public bool Is3D { get; set; }
//            public IMAXTicket(string movieName, decimal price, bool is3D)
//                : base(movieName, is3D ? price : price)
//            {
//                Is3D = is3D;
//            }
//            public override string ToString()
//            {
//                return base.ToString() +
//                       $" | Type: IMAX | 3D: {Is3D}";
//            }

//            public override void Print()
//            {
//                Console.WriteLine($"[Ticket #{TicketID}] {MovieName} | IMAX | 3D: {Is3D} | Price: {Price} |" +
//                    $" After Tax: {PriceAfterTax} | Booked: {(IsBooked ? "Yes" : "No")}");
//            }
//        }

//        public class Projector
//        {
//            public void Start()
//            {
//                Console.WriteLine("Projector started.");
//                Console.WriteLine();
//            }
//            public void Stop()
//            {
//                Console.WriteLine("Projector stopped.");
//            }
//        }
//        public class Cinema
//        {
//            public string CinemaName { get; set; }

//            private Projector _projector;   // composition
//            private Ticket[] _tickets = new Ticket[20];

//            public Cinema(string name)
//            {
//                CinemaName = name;
//                _projector = new Projector();
//            }
//            public void OpenCinema()
//            {
//                Console.WriteLine($"=== {CinemaName} Opened ===");
//                _projector.Start();
//            }

//            public void CloseCinema()
//            {
//                Console.WriteLine($"=== {CinemaName} Closed ===");
//                _projector.Stop();
//            }
//            public void AddTicket(Ticket t)
//            {
//                for (int i = 0; i < _tickets.Length; i++)
//                {
//                    if (_tickets[i] == null)
//                    {
//                        _tickets[i] = t;
//                        return;
//                    }
//                }
//                Console.WriteLine("Cinema is full!");
//            }
//            public void PrintAllTickets()
//            {
//                Console.WriteLine("--- All Tickets ---");

//                foreach (var t in _tickets)
//                {
//                    if (t != null)
//                        t.Print(); // interface method
//                }
//            }
//        }
//        public static void ProcessTicket(Ticket t)
//        {
//            t.PrintTicket();
//        }
//        public class Program 
//        {
//            static void Main()
//            {
//                var cinema = new Cinema("Cinema");
//                cinema.OpenCinema();

//                var standard = new StandardTicket("Inception", 80, "A5");
//                var vip = new VIPTicket("Avengers", 200, true);
//                var imax = new IMAXTicket("Dune", 130, true);

//                // book tickets
//                standard.Book();
//                vip.Book();
//                imax.Book();

//                cinema.AddTicket(standard);
//                cinema.AddTicket(vip);
//                cinema.AddTicket(imax);

//                cinema.PrintAllTickets();

//                // clone test
//                Console.WriteLine("\n--- Clone Test ---");

//                var clone = (VIPTicket)vip.Clone();
//                clone.MovieName = "Interstellar";

//                Console.Write("Original : ");
//                vip.Print();

//                Console.Write("Clone    : ");
//                clone.Print();

//                // cancel test
//                Console.WriteLine("\n--- After Cancellation ---");

//                standard.Cancel();
//                standard.Print();

//                // helper test
//                Console.WriteLine("\n--- BookingHelper.PrintAll ---");

//                IPrintable[] arr = { standard, vip, imax };

//                BookingHelper.PrintAll(arr);

//                cinema.CloseCinema();
//            }


//        }

//    }
//}
