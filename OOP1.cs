using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignments
{
    internal class OOP1
    {
        /*
        Q1 — Class vs Struct:
        the difference is that a class is a reference type (stored in the heap and assignment copies the reference) 
        but a struct is a value type (stored in the stack and assignment copies the actual value) 
        so if you copy a class object and change the copy the original changes too but in a struct
        the original stays unchanged
        */
        //struct definition (value type)
        struct PointStruct
        {
            public int X;
            public int Y;
        }

        //class definition (reference type)
        class PointClass
        {
            public int X;
            public int Y;
        }

        class Q1
        {
            static void Main()
            {
                //struct behavior
                PointStruct s1 = new PointStruct { X = 1, Y = 2 };
                PointStruct s2 = s1;   // s2 is a new COPY of s1
                s2.X = 99;
                Console.WriteLine("Struct (Value Type)");
                Console.WriteLine("s1.X = " + s1.X); // output: 1 ( s1 not affected )
                Console.WriteLine("s2.X = " + s2.X); // output: 99
                //class behavior
                PointClass c1 = new PointClass { X = 1, Y = 2 };
                PointClass c2 = c1;   // c2 points to the same object as c1
                c2.X = 99;
                Console.WriteLine("\nClass (Reference Type)");
                Console.WriteLine("c1.X = " + c1.X); // output: 99  ( c1 is affected )
                Console.WriteLine("c2.X = " + c2.X); // output: 99
            }
        }

        /*
        Q2 — Public vs Private:
        access modifiers control visibility of an attribute or class 
        * public members : accessible from anywhere in your code 
        * private members : only accessible from inside the class itself 
        */
        class BankAccount
        {
            public string OwnerName;    // accessible from anywhere
            private double _balance;    // only accessible inside this class
            public BankAccount(string owner, double initialBalance)
            {
               OwnerName = owner;
               _balance = initialBalance; //valid: we are inside the class
            }

            public void Deposit(double amount)
            {
                if (amount > 0)
                    _balance += amount;  // valid: inside the class
            }
        }

         class Q2
         {
            static void Main()
            {
               BankAccount account = new BankAccount("Alice", 1000);
               // public access
               Console.WriteLine(account.OwnerName); //works : public
               account.Deposit(500);
               // private access
               // Console.WriteLine(account._balance); //ERROR: private
               // account._balance = 9999;    //ERROR: private
                }
            }
         /*
         Q3 — Creating a Class Library in Visual Studio:
         you create a new "Class Library" project , write your reusable classes inside it,
         then build it to produce a (.dll) file
         to use it , you create a separate Console App project , add a Project Reference
         pointing to the library , add a using statement for its namespace , and then use its classes.

         Q4 — What is a Class Library and Why Use It:
         a class library is a compiled (.dll) file that packages reusable code with no entry point of its own 
         as it exists purely to be used by other projects 
         we use them for reusability and team collaboration (teams work on separate libraries independently),
         and easier testing (test the library alone).
         */


         //PART TWO

        // Enum: Ticket Type
        enum TicketType
        {
           Standard = 0,
           VIP = 1,
           IMAX = 2
        }
        // Struct: Seat Location (value type)
         struct Seat
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
        class Ticket
        {
           public string MovieName;
           public TicketType Type;
           public Seat Seat;
           private double Price;
           //full constructor
            public Ticket(string movieName, TicketType type, Seat seat, double price)
            {
               MovieName = movieName;
               Type = type;
               Seat = seat;
               Price = price;
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
        }

        // Console Application:  
        class Application
        {
           static void Main()
           {
                Console.Write("Enter Movie Name: ");
                string movieName = Console.ReadLine();

                 Console.Write("Enter Ticket Type (0 = Standard , 1 = VIP , 2 = IMAX ): ");
                 int typeInput = int.Parse(Console.ReadLine());
                 TicketType type = (TicketType)typeInput;

                 Console.Write("Enter Seat Row (A, B, C...): ");
                 char row = char.ToUpper(Console.ReadLine()[0]);

                 Console.Write("Enter Seat Number: ");
                 int seatNumber = int.Parse(Console.ReadLine());

                 Console.Write("Enter Price: ");
                 double price = double.Parse(Console.ReadLine());

                 Console.Write("Enter Discount Amount: ");
                 double discount = double.Parse(Console.ReadLine());

                 double taxPercent = 14;

                 //create ticket
                 Seat seat = new Seat(row, seatNumber);
                 Ticket ticket = new Ticket(movieName, type, seat, price);

                 //print ticket before discount
                 Console.WriteLine();
                 Console.WriteLine("---- Ticket Info ----");
                 ticket.PrintTicket(taxPercent);

                 //apply discount
                 double discountBefore = discount;
                 ticket.ApplyDiscount(ref discount);

                 //print ticket after discount
                 Console.WriteLine();
                 Console.WriteLine("---- After Discount ----");
                 Console.WriteLine($"Discount Before : {discountBefore:F2}");
                 Console.WriteLine($"Discount After  : {discount:F2}");
                 ticket.PrintTicket(taxPercent);
           }
        }

    }
}
