//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Assignments
//{
//    internal class ADV3
//    {
//        static void Main()
//        {
//            //Exercise 1
//            Console.WriteLine("===== Exercise 1: Student Grade Manager =====");
//            List<int> grades = new List<int> { 85, 92, 78, 95, 88, 70, 100, 65 };

//            Console.WriteLine("Grades: " + string.Join(", ", grades));
//            Console.WriteLine("Count: " + grades.Count);
//            Console.WriteLine("First: " + grades[0]);
//            Console.WriteLine("Last: " + grades[grades.Count - 1]);

//            grades.Sort();
//            Console.WriteLine("Sorted: " + string.Join(", ", grades));

//            int firstAbove90 = grades.First(g => g > 90);
//            Console.WriteLine("First grade above 90: " + firstAbove90);

//            List<int> failing = grades.Where(g => g < 75).ToList();
//            Console.WriteLine("Failing grades: " + string.Join(", ", failing));

//            grades.RemoveAll(g => g < 75);
//            Console.WriteLine("After removing failing: " + string.Join(", ", grades));

//            bool has100 = grades.Contains(100);
//            Console.WriteLine("Has grade 100? " + has100);

//            List<string> gradeStrings = grades.Select(g => "Grade: " + g).ToList();
//            Console.WriteLine("Grade strings: " + string.Join(", ", gradeStrings));


//            //Exercise 2
//            Console.WriteLine("\n===== Exercise 2: Leaderboard =====");
//            SortedDictionary<int, string> leaderboard = new SortedDictionary<int, string>();
//            leaderboard.Add(500, "Ahmed");
//            leaderboard.Add(200, "Sara");
//            leaderboard.Add(800, "Ali");
//            leaderboard.Add(350, "Mona");

//            Console.WriteLine("Leaderboard:");
//            foreach (var entry in leaderboard)
//                Console.WriteLine("  Score: " + entry.Key + " -> " + entry.Value);

//            Console.WriteLine("First key: " + leaderboard.Keys.First());
//            Console.WriteLine("First value: " + leaderboard.Values.First());

//            Console.WriteLine("Score 500 exists? " + leaderboard.ContainsKey(500));

//            if (leaderboard.TryGetValue(999, out string player999))
//                Console.WriteLine("Player at 999: " + player999);
//            else
//                Console.WriteLine("No player with score 999");

//            leaderboard.Remove(200);
//            Console.WriteLine("After removing score 200:");
//            foreach (var entry in leaderboard)
//                Console.WriteLine("  Score: " + entry.Key + " : " + entry.Value);


//            //Exercise 3
//            Console.WriteLine("\n===== Exercise 3: Phone Book =====");
//            Dictionary<string, string> phoneBook = new Dictionary<string, string>
//            {
//                { "Ahmed", "0101234567" },
//                { "Sara",  "0119876543" },
//                { "Ali",   "0121112233" },
//                { "Mona",  "0153334455" }
//            };

//            phoneBook["Youssef"] = "0166667788";
//            Console.WriteLine("Added Youssef");
//            try
//            {
//                phoneBook.Add("Ahmed", "0000000000");
//            }
//            catch (ArgumentException e)
//            {
//                Console.WriteLine("Error: " + e.Message);
//            }

//            bool added = phoneBook.TryAdd("Ahmed", "0000000000");
//            Console.WriteLine("TryAdd Ahmed succeeded? " + added);

//            if (phoneBook.ContainsKey("Khaled"))
//                Console.WriteLine("Found Khaled");
//            else
//                Console.WriteLine("Khaled not found");

//            string number = phoneBook.GetValueOrDefault("Khaled", "Not Found");
//            Console.WriteLine("Khaled's number: " + number);

//            Console.WriteLine("Keys:   " + string.Join(", ", phoneBook.Keys));
//            Console.WriteLine("Values: " + string.Join(", ", phoneBook.Values));


//            //Exercise 4
//            Console.WriteLine("\n===== Exercise 4: Unique Email Validator =====");
//            HashSet<string> emails = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

//            emails.Add("ahmed@test.com");
//            emails.Add("AHMED@test.com");
//            emails.Add("sara@test.com");
//            emails.Add("Sara@Test.Com");

//            Console.WriteLine("Email count: " + emails.Count);
//            // only 2 are stored because the comparer treats uppercase/lowercase as the same
//            Console.WriteLine("Explanation: only 2 unique emails because OrdinalIgnoreCase treats 'ahmed@test.com' and " +
//                "'AHMED@test.com' as the same with same for Sara");

//            HashSet<int> setA = new HashSet<int> { 1, 2, 3, 4, 5 };
//            HashSet<int> setB = new HashSet<int> { 4, 5, 6, 7, 8 };

//            HashSet<int> union = new HashSet<int>(setA);
//            union.UnionWith(setB);
//            Console.WriteLine("Union: " + string.Join(", ", union));

//            HashSet<int> intersect = new HashSet<int>(setA);
//            intersect.IntersectWith(setB);
//            Console.WriteLine("Intersect: " + string.Join(", ", intersect));

//            HashSet<int> except = new HashSet<int>(setA);
//            except.ExceptWith(setB);
//            Console.WriteLine("Except (A - B): " + string.Join(", ", except));

//            HashSet<int> small = new HashSet<int> { 1, 2 };
//            Console.WriteLine("{1,2} is subset of A? " + small.IsSubsetOf(setA));


//            //Exercise 5
//            Console.WriteLine("\n===== Exercise 5: Print Queue Simulator =====");

//            Queue<string> printQueue = new Queue<string>();
//            printQueue.Enqueue("Report.pdf");
//            printQueue.Enqueue("Invoice.pdf");
//            printQueue.Enqueue("Letter.docx");
//            printQueue.Enqueue("Resume.pdf");
//            printQueue.Enqueue("Photo.jpg");

//            Console.WriteLine("Queue: " + string.Join(", ", printQueue));
//            Console.WriteLine("Count: " + printQueue.Count);

//            Console.WriteLine("Next to print (Peek): " + printQueue.Peek());

//            while (printQueue.Count > 0)
//                Console.WriteLine("Printing: " + printQueue.Dequeue());

//            bool success = printQueue.TryDequeue(out string doc);
//            Console.WriteLine("TryDequeue on empty queue succeeded? " + success);


//            //Exercise 6
//            Console.WriteLine("\n===== Exercise 6: Browser History (Undo) =====");
//            Stack<string> history = new Stack<string>();

//            history.Push("google.com");
//            history.Push("github.com");
//            history.Push("stackoverflow.com");
//            history.Push("youtube.com");
//            history.Push("facebook.com");

//            Console.WriteLine("Current page (Peek): " + history.Peek());
//            Console.WriteLine("Going back...");
//            for (int i = 0; i < 3; i++)
//                Console.WriteLine("Left: " + history.Pop());

//            Console.WriteLine("Current page now: " + history.Peek());

//            history.Pop();
//            history.Pop();
//            bool popped = history.TryPop(out string url);
//            Console.WriteLine("TryPop on empty stack succeeded? " + popped);
//        }
//    }
//}
