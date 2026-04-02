//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Assignments
//{
//    public partial class Cinema
//    {
//        public void PrintAllTickets()
//        {
//            Console.WriteLine("--- All Tickets (from Cinema.Reporting) ---");
//            foreach (var t in _tickets)
//            {
//                if (t != null)
//                    t.Print();
//            }
//        }

//        public void ShowStatistics()
//        {
//            decimal totalRevenue = _tickets.Where(t => t != null).Sum(t => t.CalculateFinalPrice());
//            Console.WriteLine($"\nTotal Revenue: {totalRevenue:F2}");
//        }
//    }
//}
