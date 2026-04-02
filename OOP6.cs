//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Assignments
//{
//    public class OOP6
//    {
//        /*PART ONE - THEORTICAL
//        Q1: 
//        * abstraction :hiding the complex implementation details and showing only the important features of an object
//        * abstraction : hides implementation details , focuses on what an object does , using abstract classes and interfaces
//        * encapsulation : hides data , focuses on protecting data , using access modifiers
//        * example : abstraction is shown by the driver using simple controls in a car like the steering wheel and pedals 
//        without knowing how the engine works
//        encapsulation is shown by engine and fuel system being hidden and protected from direct access by the driver

//        Q2:
//        * abstract class : can have fields , can have implemented methods , a class can inherit from only one abstract class,
//        can have constructors
//        * interface class : can't have instance fields , methods are only declared(no implementation) usually ,
//        a class can implement multiple interfaces , can't have constructors
//        * use abstract class when: classes share common code ,we want default implementations ,we want to store fields
//        * use interface class when: we want to define a capability , multiple unrelated classes should implement it

//        Q3:
//        a) no , because we can't instantiate objects from abstract classes
//        b) * PowerConsmption() : is abstract because it must be overriden by each subclass (different appliances
//                                 have different power consumption)
//           * Status() : is virtual because it can be overriden and if not the base implementation will run
//           * Label() : is a concrete method that is fully implemented and can't be overriden 
//                       (designer wants a standard label format for all appliances)
//        c) it will run the base implementation of Appliances (Standby) because Status is a virtual method 
//           and Toaster didn't override it

//        Q4:
//        a) * partial class : allow a class definition to be split across multiple files
//           * for better organization , large classes become easier to maintain,
//             different developers can work on different parts
//        b) * partial method : method declared in one part of a partial class and can be implemented in another 
//           * the code will still compile , because partial methods are optional and if no implementation exist
//             the method call is removed by the compiler
//        c) * extension method : allows adding new methods to an existing class without modifying the original class
//           * rules : must be inside static class , method is static , first paramter must use (this) keyword
//        d) Log: result = 20
//           $20.00
//        */

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
//        public abstract class Ticket : IPrintable, IBookable, ICloneable
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
//            public abstract decimal CalculateFinalPrice();

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
//            public override decimal CalculateFinalPrice()
//            {
//                return Math.Round(Price * 1.14m, 2);
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
//            public override decimal CalculateFinalPrice()
//            {
//                return Math.Round(Price * 1.14m, 2); 
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
//            public override decimal CalculateFinalPrice()
//            {
//                return Math.Round(Price * 1.14m, 2);
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
//                // a. Cannot create plain Ticket (compiler prevents)
//                // Ticket t = new Ticket("Test", 100); // ERROR
//                Console.WriteLine("// Ticket t = new Ticket(\"Test\", 100);  // ERROR: Cannot create instance of abstract type 'Ticket'");

//                // b. Create each ticket type and book
//                var standard = new StandardTicket("Inception", 80, "A5");
//                var vip = new VIPTicket("Avengers", 200, true);
//                var imax = new IMAXTicket("Dune", 130, true);

//                standard.Book();
//                vip.Book();
//                imax.Book();

//                // c. Add tickets to cinema and print
//                cinema.AddTicket(standard);
//                cinema.AddTicket(vip);
//                cinema.AddTicket(imax);
//                cinema.PrintAllTickets();

//                // d. Polymorphism
//                Ticket[] tickets = { standard, vip, imax };
//                Console.WriteLine("\n--- Polymorphism: Final Price per Ticket ---");
//                foreach (var t in tickets)
//                    Console.WriteLine($"{t.GetType().Name} => Final Price: {t.CalculateFinalPrice():F2}");

//                // e. Extension method: receipt
//                Console.WriteLine("\n--- Extension Method: Receipt ---");
//                Console.WriteLine(vip.GenerateReceipt());

//                // f. Extension method: total revenue
//                Console.WriteLine("\n--- Extension Method: Total Revenue ---");
//                Console.WriteLine($"Total Revenue: {tickets.TotalRevenue():F2}");

//                //g.
//                cinema.CloseCinema();
//            }

//        }
//    }
//}
