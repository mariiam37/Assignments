using System;
using System.Diagnostics;
using System.Text;

class Assignment3
{
    static void Main()
    {
        //Question 1
        /*
        (a) because strings in C# are immutable so they can't be changed after creation
        every time productList += "PROD-" + i + "," runs C# creates a new string object in memory
        and copies the entire previous string into it then removes the old one
        after 5000 iterations we've created ~5,000 temporary string objects each larger than the last
        this is O(n^2) memory behavior and puts extra load on the GC
        */
        //(b)
        StringBuilder sb = new StringBuilder();
        for (int i = 1; i <= 5000; i++)
        {
            sb.Append("PROD-");
            sb.Append(i);
            sb.Append(',');
        }
        string productList = sb.ToString();
        //(c)
        // version A: string concat
        Stopwatch sw1 = Stopwatch.StartNew();
        string productListt = "";
        for (int i = 1; i <= 5000; i++)
            productListt += "PROD-" + i + ",";
        sw1.Stop();
        Console.WriteLine($"String concat : {sw1.ElapsedMilliseconds} ms");

        // Version B: StringBuilder
        Stopwatch sw2 = Stopwatch.StartNew();
        StringBuilder sbb = new StringBuilder();
        for (int i = 1; i <= 5000; i++)
        {
            sbb.Append("PROD-");
            sbb.Append(i);
            sbb.Append(',');
        }
        string productListSB = sb.ToString();
        sw2.Stop();
        Console.WriteLine($"StringBuilder : {sw2.ElapsedMilliseconds} ms");
        //results:
        // String concat : 150–400 ms
        // StringBuilder : 1–3 ms
        
        
        //Question 2
        Console.Write("Enter age: ");
        int age = int.Parse(Console.ReadLine());

        Console.Write("Enter day (1=Mon, 2=Tue, 3=Wed, 4=Thu, 5=Sun, 6=Fri, 7=Sat): ");
        int day = int.Parse(Console.ReadLine());

        Console.Write("Do you have a student ID? (yes/no): ");
        bool isStudent = Console.ReadLine().Trim().ToLower() == "yes";

        bool isWeekend = (day == 6 || day == 7);

        double price;
        string breakdown;

        //base price by age
        if (age < 5)
        {
            price = 0;
            breakdown = "Age < 5 → Free";
        }
        else if (age <= 12)
        {
            price = 30;
            breakdown = "Age 5–12 → 30 LE";
        }
        else if (age <= 59)
        {
            price = 50;
            breakdown = "Age 13–59 → 50 LE";
        }
        else
        {
            price = 25;
            breakdown = "Age 60+ → 25 LE";
        }

        //weekend charge (non-free tickets only)
        if (price > 0 && isWeekend)
        {
            price += 10;
            breakdown += $" + 10 LE weekend = {price} LE";
        }

        //student discount applied after charge
        if (price > 0 && isStudent)
        {
            double discount = price * 0.20;
            price -= discount;
            breakdown += $" − 20% student ({discount} LE) = {price} LE";
        }

        Console.WriteLine("\n Ticket Price Breakdown ");
        Console.WriteLine(breakdown);
        Console.WriteLine($"Final Price: {price:F2} LE");


        //Question 3
        //(a) traditional switch statement
        string fileExtension = ".pdf";
        string fileType;

        switch (fileExtension)
        {
            case ".pdf":
                fileType = "PDF Document";
                break;
            case ".docx":
            case ".doc":
                fileType = "Word Document";
                break;
            case ".xlsx":
            case ".xls":
                fileType = "Excel Spreadsheet";
                break;
            case ".jpg":
            case ".png":
            case ".gif":
                fileType = "Image File";
                break;
            default:
                fileType = "Unknown File Type";
                break;
        }
        Console.WriteLine(fileType);

        //(b) switch expression :
        string fileExtensionn = ".pdf";

        string fileTypee = fileExtension switch
        {
            ".pdf" => "PDF Document",
            ".docx" or ".doc" => "Word Document",
            ".xlsx" or ".xls" => "Excel Spreadsheet",
            ".jpg" or ".png" or ".gif" => "Image File",
            _ => "Unknown File Type"
        };
        Console.WriteLine(fileType);


        //Question 4
        int temperature = 35;
        string weatherAdvice =
            temperature < 0 ? "Freezing! Stay indoors." :
            temperature < 15 ? "Cold. Wear a jacket." :
            temperature < 25 ? "Pleasant weather." :
            temperature < 35 ? "Warm. Stay hydrated." :
                               "Hot! Avoid sun exposure.";

        Console.WriteLine(weatherAdvice); // Hot! Avoid sun exposure.
        /*
        i find if-else easier to read and debug
        use ternary for short and simple conditions and use if-else when there are many branches or 
        complex logic in each branch 
        */


        //Question 5
        int maxAttempts = 5;
        int attempts = 0;
        bool valid = false;

        do
        {
            attempts++;
            Console.Write($"\nAttempt {attempts}/{maxAttempts} - Enter password: ");
            string password = Console.ReadLine();

            bool hasUpper = false;
            bool hasDigit = false;
            bool hasSpace = false;

            foreach (char c in password)
            {
                if (char.IsUpper(c)) hasUpper = true;
                if (char.IsDigit(c)) hasDigit = true;
                if (char.IsWhiteSpace(c)) hasSpace = true;
            }

            bool longEnough = password.Length >= 8;
            valid = longEnough && hasUpper && hasDigit && !hasSpace;

            if (valid)
            {
                Console.WriteLine("Password accepted!");
            }
            else
            {
                Console.WriteLine("Invalid password. Rules violated:");
                if (!longEnough) Console.WriteLine("  - Must be at least 8 characters");
                if (!hasUpper) Console.WriteLine("  - Must have at least one uppercase letter");
                if (!hasDigit) Console.WriteLine("  - Must have at least one digit");
                if (hasSpace) Console.WriteLine("  - Must not contain spaces");

                if (attempts >= maxAttempts)
                    Console.WriteLine("\nAccount locked.");
            }

        } while (!valid && attempts < maxAttempts);


        //Question 6
        int[] scores = { 45, 92, 38, 76, 55, 91, 63, 88, 29, 100, 47, 72, 35, 85, 60 };

        // (a) all failing scores (below 50)
        Console.WriteLine("Failing scores:");
        foreach (int score in scores)
            if (score < 50)
                Console.WriteLine($"  {score}");
        // output: 45, 38, 29, 47, 35

        // (b) first score above 90 —> stop immediately
        Console.WriteLine("First score above 90:");
        foreach (int score in scores)
        {
            if (score > 90)
            {
                Console.WriteLine($"  Found: {score}");
                break; // stops searching
            }
        }
        // output: Found: 92

        // (c) average excluding absent (below 40)
        int total = 0, count = 0;
        foreach (int score in scores)
        {
            if (score >= 40)
            {
                total += score;
                count++;
            }
        }
        Console.WriteLine($"Average (excl. absent): {(double)total / count:F2}");
        // output: 71.08

        // (d) grade distribution
        int gradeA = 0, gradeB = 0, gradeC = 0, gradeD = 0, gradeF = 0;
        foreach (int score in scores)
        {
            if (score >= 90) gradeA++;
            else if (score >= 80) gradeB++;
            else if (score >= 70) gradeC++;
            else if (score >= 60) gradeD++;
            else gradeF++;
        }

        Console.WriteLine($"A (90-100): {gradeA}");
        Console.WriteLine($"B (80-89) : {gradeB}");
        Console.WriteLine($"C (70-79) : {gradeC}");
        Console.WriteLine($"D (60-69) : {gradeD}");
        Console.WriteLine($"F (< 60)  : {gradeF}");
        // A:3, B:2, C:2, D:2, F:6
    }
}