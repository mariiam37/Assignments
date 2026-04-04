//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Assignments
//{
//    public class ADV2
//    {
//        // 1. Product Model
//        public class Product
//        {
//            public int Id { get; set; }
//            public string Name { get; set; }
//            public string Category { get; set; }  // "Electronics", "Clothing", "Food", "Books"
//            public double Price { get; set; }
//            public int Stock { get; set; }
//        }

//        class Program
//        {
//            // 2. Product Catalog
//            static List<Product> catalog = new List<Product>
//            {
//                new Product { Id=1,  Name="Laptop",       Category="Electronics", Price=1200, Stock=10  },
//                new Product { Id=2,  Name="Phone",        Category="Electronics", Price=800,  Stock=25  },
//                new Product { Id=3,  Name="T-Shirt",      Category="Clothing",    Price=30,   Stock=100 },
//                new Product { Id=4,  Name="Jeans",        Category="Clothing",    Price=60,   Stock=50  },
//                new Product { Id=5,  Name="Chocolate",    Category="Food",        Price=5,    Stock=200 },
//                new Product { Id=6,  Name="Coffee Beans", Category="Food",        Price=15,   Stock=80  },
//                new Product { Id=7,  Name="C# Book",      Category="Books",       Price=45,   Stock=30  },
//                new Product { Id=8,  Name="Novel",        Category="Books",       Price=20,   Stock=60  },
//                new Product { Id=9,  Name="Headphones",   Category="Electronics", Price=150,  Stock=40  },
//                new Product { Id=10, Name="Jacket",       Category="Clothing",    Price=120,  Stock=15  },
//            };

//            /* TASK 01: Smart Product Search
//                 delegate used: Func<Product, bool>
//                 why: Func lets the caller pass any filter condition as a lambda so no need to change this method ever
//            */
//            static List<Product> SearchProducts(List<Product> products, Func<Product, bool> filter)
//            {
//                List<Product> result = new List<Product>();
//                foreach (var p in products)
//                {
//                    if (filter(p))
//                        result.Add(p);
//                }
//                return result;
//            }

//            /* TASK 03.1: Print Reports
//                 delegate used: Action<Product>
//                 why: Action is for operations that do something (here : print) but do not need to return a value
//            */
//            static void PrintReport(List<Product> products, Action<Product> printAction)
//            {
//                foreach (var p in products)
//                {
//                    printAction(p);
//                }
//            }

//            /* TASK 03.2: Transform Products
//                delegate used: Func<Product, string>
//                why: Func is used when we need to convert each product into something else and get the results back
//            */
//            static List<string> TransformProducts(List<Product> products, Func<Product, string> transform)
//            {
//                List<string> result = new List<string>();
//                foreach (var p in products)
//                {
//                    result.Add(transform(p));
//                }
//                return result;
//            }

//            /* TASK 03.3: Filter Products
//                delegate used: Predicate<Product>
//                why: Predicate is purpose built for filtering it takes one input and returns true or false
//            */
//            static List<Product> FilterProducts(List<Product> products, Predicate<Product> condition)
//            {
//                List<Product> result = new List<Product>();
//                foreach (var p in products)
//                {
//                    if (condition(p))
//                        result.Add(p);
//                }
//                return result;
//            }

//            static void Main(string[] args)
//            {
//                // TASK 01 - Search Products
//                // Search 1: All Electronics
//                Console.WriteLine("--- Electronics ---");
//                List<Product> electronics = SearchProducts(catalog, p => p.Category == "Electronics");
//                foreach (var p in electronics)
//                    Console.WriteLine($"{p.Name} - ${p.Price} (Stock: {p.Stock})");

//                // Search 2: Products cheaper than $50
//                Console.WriteLine("\n--- Under $50 ---");
//                List<Product> under50 = SearchProducts(catalog, p => p.Price < 50);
//                foreach (var p in under50)
//                    Console.WriteLine($"{p.Name} - ${p.Price} (Stock: {p.Stock})");

//                // Search 3: Products that are in stock (Stock > 0)
//                Console.WriteLine("\n--- In Stock ---");
//                List<Product> inStock = SearchProducts(catalog, p => p.Stock > 0);
//                foreach (var p in inStock)
//                    Console.WriteLine($"{p.Name} - ${p.Price} (Stock: {p.Stock})");

//                // Search 4: Clothing products under $100
//                Console.WriteLine("\n--- Clothing Under $100 ---");
//                List<Product> clothingUnder100 = SearchProducts(catalog, p => p.Category == "Clothing" && p.Price < 100);
//                foreach (var p in clothingUnder100)
//                    Console.WriteLine($"{p.Name} - ${p.Price} (Stock: {p.Stock})");

//                // TASK 03.1 - Print Reports
//                // Scenario 1: Short Report
//                Console.WriteLine("\n--- Short Report ---");
//                PrintReport(catalog, p => Console.WriteLine($"{p.Name} - ${p.Price}"));

//                // Scenario 2: Detailed Report
//                Console.WriteLine("\n--- Detailed Report ---");
//                PrintReport(catalog, p => Console.WriteLine($"[{p.Category}] {p.Name} | Price: ${p.Price} | Stock: {p.Stock}"));

//                // TASK 03.2 - Transform Products
//                // Scenario 3: Summary List
//                Console.WriteLine("\n--- Summary List ---");
//                List<string> summaries = TransformProducts(catalog, p => $"{p.Name} (${p.Price})");
//                foreach (var s in summaries)
//                    Console.WriteLine(s);

//                // Scenario 4: Price Labels
//                Console.WriteLine("\n--- Price Labels ---");
//                List<string> labels = TransformProducts(catalog, p => p.Price > 100
//                    ? $"{p.Name}: Expensive!"
//                    : $"{p.Name}: Affordable");
//                foreach (var label in labels)
//                    Console.WriteLine(label);

//                // TASK 03.3 - Filter Products
//                // Scenario 5: Low-Stock Alert (Stock < 20)
//                Console.WriteLine("\n--- Low-Stock Alert ---");
//                List<Product> lowStock = FilterProducts(catalog, p => p.Stock < 20);
//                foreach (var p in lowStock)
//                    Console.WriteLine($"[LOW STOCK] {p.Name}: only {p.Stock} left!");
//            }
//        }

//    }
//}
