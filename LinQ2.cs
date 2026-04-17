//using Assignments.DataSource;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Assignments
//{
//    internal class LinQ2
//    {
//        public static void Main()
//        {
//            var ProductList = Data.ProductList;
//            var Customers = Data.CustomerList;

//            //Q1
//            Console.WriteLine("Question 1:");
//            var top3 = ProductList
//            .OrderByDescending(p => p.UnitPrice)
//            .Take(3);

//            foreach (var p in top3)
//                Console.WriteLine(p.ProductName + " " + p.UnitPrice);
//            Console.WriteLine();

//            //Q2
//            Console.WriteLine("Question 2:");
//            var page2 = ProductList
//                .Skip(5)
//                .Take(5);

//            foreach (var p in page2)
//                Console.WriteLine(p.ProductName);
//            Console.WriteLine();

//            //Q3
//            Console.WriteLine("Question 3:");
//            var less25 = ProductList
//                .OrderBy(p => p.UnitPrice)
//                .TakeWhile(p => p.UnitPrice < 25);

//            foreach (var p in less25)
//                Console.WriteLine(p.ProductName + " " + p.UnitPrice);
//            Console.WriteLine();

//            //Q4
//            Console.WriteLine("Question 4:");
//            var allSeafoodInStock = ProductList
//                .Where(p => p.Category == "Seafood")
//                .All(p => p.UnitsInStock > 0);
//            Console.WriteLine(allSeafoodInStock);
//            Console.WriteLine();

//            //Q5
//            Console.WriteLine("Question 5:");
//            int[] ids = { 3, 9, 13, 18 };
//            var contains9 = ids.Contains(9);
//            Console.WriteLine(contains9);
//            Console.WriteLine();

//            //Q6
//            Console.WriteLine("Question 6:");
//            var grouped = ProductList.GroupBy(p => p.Category);
//            foreach (var g in grouped)
//            {
//                Console.WriteLine(g.Key + " Count: " + g.Count());
//            }
//            Console.WriteLine();

//            //Q7
//            Console.WriteLine("Question 7:");
//            var groupedNames = ProductList
//                .GroupBy(p => p.Category)
//                .Select(g => new { Category = g.Key, Names = g.Select(p => p.ProductName) });

//            foreach (var g in groupedNames)
//            {
//                Console.WriteLine(g.Category);
//                foreach (var name in g.Names)
//                    Console.WriteLine(name);
//            }
//            Console.WriteLine();

//            //Q8
//            Console.WriteLine("Question 8:");
//            var categories = ProductList
//                .GroupBy(p => p.Category)
//                .Where(g => g.Count() > 3);

//            foreach (var g in categories)
//                Console.WriteLine(g.Key);
//            Console.WriteLine();

//            //Q9
//            Console.WriteLine("Question 9:");
//            var customerGroups =
//                from c in Customers
//                group c by c.Country into g
//                select new
//                {
//                    Country = g.Key,
//                    Count = g.Count(),
//                    TotalOrderValue = g.SelectMany(c => c.Orders).Sum(o => o.Total)
//                };

//            foreach (var g in customerGroups)
//                Console.WriteLine(g.Country + " " + g.Count + " " + g.TotalOrderValue);
//            Console.WriteLine();

//            //Q10
//            Console.WriteLine("Question 10:");
//            var totalStock = ProductList.Sum(p => p.UnitsInStock);
//            Console.WriteLine(totalStock);
//            Console.WriteLine();

//            //Q11
//            Console.WriteLine("Question 11:");
//            var minPrice = ProductList.Min(p => p.UnitPrice);
//            var maxPrice = ProductList.Max(p => p.UnitPrice);

//            Console.WriteLine("Min: " + minPrice);
//            Console.WriteLine("Max: " + maxPrice);
//            Console.WriteLine();

//            //Q12
//            Console.WriteLine("Question 12:");
//            var distinctCategories = ProductList
//                .Select(p => p.Category)
//                .Distinct();

//            foreach (var c in distinctCategories)
//                Console.WriteLine(c);
//            Console.WriteLine();

//            //Q13
//            Console.WriteLine("Question 13:");
//            int[] setA = { 1, 3, 5, 7, 9, 11, 13 };
//            int[] setB = { 3, 6, 9, 12, 15, 13 };

//            var diff = setA.Except(setB);

//            foreach (var x in diff)
//                Console.WriteLine(x);
//            Console.WriteLine();

//            //Q14
//            Console.WriteLine("Question 14:");
//            string[] list1 = { "Germany", "France", "UK", "Spain" };
//            string[] list2 = { "france", "SPAIN", "Italy" };

//            var resultCountries = list1
//                .Except(list2, StringComparer.OrdinalIgnoreCase);

//            foreach (var c in resultCountries)
//                Console.WriteLine(c);
//            Console.WriteLine();

//            //Q15
//            Console.WriteLine("Question 15:");
//            var dict = ProductList.ToDictionary(p => p.ProductID);

//            if (dict.ContainsKey(18))
//            {
//                var p = dict[18];
//                Console.WriteLine(p.ProductName + " " + p.UnitPrice);
//            }
//            Console.WriteLine();

//            //Q16
//            Console.WriteLine("Question 16:");
//            var firstOver50 = ProductList.First(p => p.UnitPrice > 50);
//            Console.WriteLine(firstOver50.ProductName);
//            Console.WriteLine();

//            //Q17
//            Console.WriteLine("Question 17:");
//            var firstOver500 = ProductList.FirstOrDefault(p => p.UnitPrice > 500);

//            if (firstOver500 != null)
//                Console.WriteLine(firstOver500.ProductName);
//            else
//                Console.WriteLine("null");
//            Console.WriteLine();

//            //Q18
//            Console.WriteLine("Question 18:");
//            var table7 = Enumerable.Range(1, 10)
//                .Select(x => 7 * x);

//            foreach (var x in table7)
//                Console.WriteLine(x);
//            Console.WriteLine();

//            //Q19
//            Console.WriteLine("Question 19:");
//            var evens = Enumerable.Range(1, 30)
//                .Where(x => x % 2 == 0);

//            foreach (var x in evens)
//                Console.WriteLine(x);
//            Console.WriteLine();

//            //Q20
//            Console.WriteLine("Question 20:");
//            var concat = ProductList.Select(p => p.ProductName).Take(3)
//                .Concat(Customers.Select(c => c.CompanyName).Take(3));

//            foreach (var x in concat)
//                Console.WriteLine(x);
//            Console.WriteLine();

//            //Q21
//            Console.WriteLine("Question 21:");
//            var paired = ProductList
//                .Zip(Customers, (p, c) => p.ProductName + " sold to " + c.CompanyName);

//            foreach (var x in paired)
//                Console.WriteLine(x);
//            Console.WriteLine();

//        }
//    }
//}
