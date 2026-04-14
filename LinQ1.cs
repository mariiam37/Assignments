//using System;
//using System.Linq;
//using Assignments.DataSource;

//namespace Assignments
//{
//    internal class LinQ1
//    {
//        public static void Main()
//        {
//            var ProductList = Data.ProductList;
//            var Customers = Data.CustomerList;

//            //Q1
//            var seafoodProducts = ProductList.Where(p => p.Category == "Seafood");
//            Console.WriteLine("QUESTION 1 : ");
//            foreach (var p in seafoodProducts)
//                Console.WriteLine(p.ProductName + " " + p.UnitPrice);
//            Console.WriteLine();

//            //Q2
//            var names = ProductList.Select(p => p.ProductName);
//            Console.WriteLine("QUESTION 2 : ");
//            foreach (var n in names)
//                Console.WriteLine(n);
//            Console.WriteLine();
            
//            //Q3
//            var sortedByPrice = ProductList.OrderBy(p => p.UnitPrice);
//            Console.WriteLine("QUESTION 3 : ");
//            foreach (var p in sortedByPrice)
//                Console.WriteLine(p.ProductName + " " + p.UnitPrice);
//            Console.WriteLine();

//            //Q4
//            var between = ProductList.Where(p => p.UnitPrice >= 10 && p.UnitPrice <= 30);
//            Console.WriteLine("QUESTION 4 : ");
//            foreach (var p in between)
//                Console.WriteLine(p.ProductName + " " + p.UnitPrice);
//            Console.WriteLine();

//            //Q5
//            var condimentsInStock = ProductList
//                .Where(p => p.UnitsInStock > 0 && p.Category == "Condiments");
//            Console.WriteLine("QUESTION 5 : ");
//            foreach (var p in condimentsInStock)
//                Console.WriteLine(p.ProductName);
//            Console.WriteLine();

//            //Q6
//            var anon = ProductList.Select(p => new
//            {
//                Name = p.ProductName,
//                Price = p.UnitPrice,
//                StockStatus = p.UnitsInStock > 0 ? "Available" : "Out of Stock"
//            });
//            Console.WriteLine("QUESTION 6 : ");
//            foreach (var p in anon)
//                Console.WriteLine(p.Name + " " + p.Price + " " + p.StockStatus);
//            Console.WriteLine();

//            //Q7
//            var withIndex = ProductList.Select((p, index) => new { p.ProductName, index });
//            Console.WriteLine("QUESTION 7 : ");
//            foreach (var p in withIndex)
//                Console.WriteLine((p.index + 1) + ". " + p.ProductName);
//            Console.WriteLine();

//            //Q8
//            var sorted = ProductList
//                .OrderBy(p => p.Category)
//                .ThenByDescending(p => p.UnitPrice);
//            Console.WriteLine("QUESTION 8 : ");
//            foreach (var p in sorted)
//                Console.WriteLine(p.Category + " " + p.ProductName + " " + p.UnitPrice);
//            Console.WriteLine();

//            //Q9
//            var beverages = ProductList
//                .Where(p => p.Category == "Beverages")
//                .OrderByDescending(p => p.UnitsInStock);
//            Console.WriteLine("QUESTION 9 : ");
//            foreach (var p in beverages)
//                Console.WriteLine(p.ProductName + " " + p.UnitsInStock);
//            Console.WriteLine();

//            //Q10
//            var ordersQuery =
//                from c in Customers
//                from o in c.Orders
//                where o.OrderDate.Year >= 1997
//                select new { c.CustomerID, o.OrderDate };
//            Console.WriteLine("QUESTION 10 : ");
//            foreach (var o in ordersQuery)
//                Console.WriteLine(o.CustomerID + " " + o.OrderDate);
//            Console.WriteLine();

//            //Q11
//            var pos = ProductList.Select((p, i) => new { p.ProductName, i });
//            Console.WriteLine("QUESTION 11 : ");
//            foreach (var p in pos)
//                Console.WriteLine((p.i + 1) + " " + p.ProductName);
//            Console.WriteLine();

//            //Q12
//            string[] Arr = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };

//            var sortedWords = Arr
//                .OrderBy(w => w.Length)
//                .ThenBy(w => w, StringComparer.OrdinalIgnoreCase);
//            Console.WriteLine("QUESTION 12 : ");
//            foreach (var w in sortedWords)
//                Console.WriteLine(w);
//            Console.WriteLine();

//            //Q13
//            string[] digits = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

//            var result = digits
//                .Where(d => d.Length > 1 && d[1] == 'i')
//                .Reverse();
//            Console.WriteLine("QUESTION 13 : ");
//            foreach (var d in result)
//                Console.WriteLine(d);
//        }
//    }
//}