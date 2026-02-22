using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Assignments
{
    internal class OOP2
    {
        //PART ONE : THEORETICAL 
        //Q1:
        //a) 1. Owner and Balance are public fields so anyone can modify in their values 
        //   2. Withdraw function doesn't have validation for amount argument or Balance of the bank account

        //b) 1. make Owner and Balance private fields and use property , add validations for withdraw function
        public class BankAccount {
            private string _owner;
            private double _balance;
            public double Balance
            {
                get {
                    return _balance;
                }
                private set {
                    _balance = value;
                }
            }
            public double Owner { get; set; }
            public void Withdraw(double amount) {
                if (amount < 0)
                {
                    throw new ArgumentException("Invalid amount to withdraw");
                }
                else if (amount <= _balance)
                {
                    _balance -= amount;
                }
            }
        }
        //c) because it breaks encapsulation and allows uncontrolled access and doesn't allow validation control

        //Q2:
        // field : variable declared inside a class to store data
        // property : provides controlled access to a field using get and or set
        // a property can include logic : validations , calculations and exception handling
        public class Rectangle
        {
            private int length;
            private int width;
            public double Area => width * length;
        }

        //Q3:
        //a) this is called an Indexer and its purpose is to access objects like arrays through indeces

        //b) size is 5 (0,1,2,3,4) so index 10 is out of bounds and it will throw an exception IndexOutOfRangeException
        //and to make indexer safer i can add validation on index before preforming any action using it

        //c)yes class can have more than one indexer (overloading) if they have different parameters or parameter types
        //and it can be used for felxible access 
        public class StudentRegister
        {
            private string[] names = new string[5];
            public string this[int index]
            {
                get { return names[index]; }
                set { names[index] = value; }
            }
            public int this[string name]
            {
                get
                {
                    for (int i = 0; i < names.Length; i++)
                    {
                        if (names[i] == name)
                            return i;
                    }
                    return -1;
                }
            }
        }

        //Q4:
        //a) static means the variable belongs to the class itself and not a specific object of it and it is shared by all 
        //instances of Order and has only on copy in memory, Items is not static so each Order objects has its own value 
        //of Items 

        //b) no, because Items is not static it is an instance specific to an object and the static method won't
        //know which object the Items value belongs to 


        //PART TWO: PRACTICAL
        public enum TicketType
        {
            Standard = 0,
            VIP = 1,
            IMAX = 2
        }
        // Struct: Seat Location (value type)
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
        // Class: Ticket
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
            //tax calculated property
            public double PriceAfterTax => Math.Round(_price * 1.14, 1);
            //ticketID property
            public int TicketID => _ticketID;
            public Ticket()
            {
                TicketCounter++;
                _ticketID = TicketCounter;
            }

            //full constructor
            public Ticket(string movieName, TicketType type, Seat seat, double price)
            {
                _movieName = movieName;
                _type = type;
                _seat = seat;
                _price = price;
                TicketCounter++;
                _ticketID = TicketCounter;
            }

            // constructor with movie name only : chains to the full constructor
            // default: Standard type, seat A1, price 50
            public Ticket(string movieName)
                : this(movieName, TicketType.Standard, new Seat('A', 1), 50)
            {
            }
            // a. CalcTotal: returns price + tax without changing the original Price
            public double CalcTotal(double taxPercent)
            {
                return Price + (Price * taxPercent / 100);
            }

            // b. ApplyDiscount: deducts discount from Price if valid, sets it to 0
            public void ApplyDiscount(ref double discountAmount)
            {
                if (discountAmount > 0 && discountAmount <= Price)
                {
                    Price -= discountAmount;
                    discountAmount = 0;
                }
            }

            // c. PrintTicket: prints full ticket info
            public void PrintTicket(double taxPercent)
            {
                Console.WriteLine($"Movie    : {MovieName}");
                Console.WriteLine($"Type     : {Type}");
                Console.WriteLine($"Seat     : {Seat}");
                Console.WriteLine($"Price    : {Price:F2}");
                Console.WriteLine($"Total ({taxPercent}% tax) : {CalcTotal(taxPercent):F2}");
            }

            //2.c) GetTotalTicketsSold()
            public static int GetTotalTicketsSold()
            {
                return TicketCounter;
            }
        }
        public class Cinema
        {
            private Ticket[] tickets = new Ticket[20];
            public Ticket this[int index]
            {
                get
                {
                    if (index < 0 || index >= tickets.Length)
                        return null;

                    return tickets[index];
                }
                set
                {
                    if (index >= 0 && index < tickets.Length)
                        tickets[index] = value;
                }
            }
            public Ticket this[string name]
            {
                get
                {
                    for (int i = 0; i < tickets.Length; i++)
                    {
                        if (tickets[i].MovieName == name)
                        {
                            return tickets[i];
                        }
                    }
                    return null;
                }
            }
            public bool AddTicket(Ticket ticket)
            {
                for (int i = 0; i < tickets.Length; i++)
                {
                    if (tickets[i] == null)
                    {
                        tickets[i] = ticket;
                        return true;
                    }
                }
                return false;
            }
        }
        public static class BookingHelper {
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

        class Application
        {
            static void Main()
            {
                Cinema cinema = new Cinema();
                Console.WriteLine("======== Ticket Booking ========");
                int ticketNum = 1;
                while (ticketNum <= 3)
                {
                    Console.WriteLine("Enter data for Ticket: " + ticketNum);
                    ticketNum++;
                    Console.Write("Enter Movie Name: ");
                    string movieName = Console.ReadLine();

                    Console.Write("Enter Ticket Type (0 = Standard , 1 = VIP , 2 = IMAX ): ");
                    int typeInput = int.Parse(Console.ReadLine());
                    TicketType type = (TicketType)typeInput;

                    Console.Write("Enter Seat Row (A-Z): ");
                    char row = char.ToUpper(Console.ReadLine()[0]);

                    Console.Write("Enter Seat Number: ");
                    int seatNumber = int.Parse(Console.ReadLine());

                    Console.Write("Enter Price: ");
                    double price = double.Parse(Console.ReadLine());

                    Seat seat = new Seat(row, seatNumber);
                    Ticket t = new Ticket(movieName, type, seat, price);
                    cinema.AddTicket(t);
                    Console.WriteLine();
                }

                Console.WriteLine("======== All Tickets ========");
                for (int i = 0; i < ticketNum; i++)
                {
                    Ticket t = cinema[i];
                    if (t != null)
                    {
                        Console.WriteLine($" Ticket # {t.TicketID} | {t.MovieName} |" +
                            $" {t.Type} | Seat: {t.Seat} | Price: {t.Price} EGP | After Tax: {t.PriceAfterTax}");
                    }
                }
                Console.WriteLine("======== Search Movie by Name ========");
                Console.Write("Enter movie name to search: ");
                string searchName = Console.ReadLine();

                Ticket found = cinema[searchName];

                if (found != null)
                {
                    Console.WriteLine($"Found: Ticket # {found.TicketID} |" +
                        $" {found.MovieName} | {found.Type} | Seat: {found.Seat} | Price: {found.Price} EGP");
                }
                else
                {
                    Console.WriteLine("Movie not found.");
                }

                Console.WriteLine("======== Statistics ========");
                Console.WriteLine($"Total Tickets Sold: {Ticket.TicketCounter}");

                Console.WriteLine("Booking References:");
                Console.WriteLine(BookingHelper.GenerateBookingReference());
                Console.WriteLine(BookingHelper.GenerateBookingReference());

                double discountedTotal = BookingHelper.CalcGroupDiscount(5, 80);
                Console.WriteLine($"Group Discount Total (5 tickets × 80 EGP): {discountedTotal} EGP (10% applied)");

            }
        }
    }
}
