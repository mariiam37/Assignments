using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Assignments.OOP6;

namespace Assignments
{
    public partial class Cinema
    {
        public string CinemaName { get; set; }
        private Projector _projector;           // composition
        private Ticket[] _tickets = new Ticket[20];

        public Cinema(string name)
        {
            CinemaName = name;
            _projector = new Projector();
        }

        // Projector control
        public void OpenCinema()
        {
            Console.WriteLine($"=== {CinemaName} Opened ===");
            _projector.Start();
        }
        public void CloseCinema()
        {
            Console.WriteLine($"=== {CinemaName} Closed ===");
            _projector.Stop();
        }

        // Ticket management
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
        public void BookTicket(int ticketID)
        {
            var t = _tickets.FirstOrDefault(ticket => ticket != null && ticket.TicketID == ticketID);
            t?.Book();
        }
    }

    public static class TicketExtensions
    {
        public static string GenerateReceipt(this Ticket t)
        {
            return
              $@"========== RECEIPT ==========
Movie    : {t.MovieName}
Type     : {t.GetType().Name.Replace("Ticket", "")}
Price    : {t.Price}
Final    : {t.CalculateFinalPrice():F2}
Status   : {(t.IsBooked ? "Booked" : "Not Booked")}
=============================";
        }
        public static decimal TotalRevenue(this Ticket[] tickets)
        {
            return tickets.Where(t => t != null).Sum(t => t.CalculateFinalPrice());
        }
    }
}
