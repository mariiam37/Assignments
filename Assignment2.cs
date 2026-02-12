using System;

class Assignment2
{
    static void Main()
    {
        #region Q1
        double d = 9.99;
        int x1 = (int)d;
        Console.WriteLine(x1); 
        //this prints 9 as double is casted into int so fraction is removed
        #endregion

        #region Q2
        int n = 5;
        double d2 = n / 2.0; 
        // this correctly calculates 5/2 = 2.5 as d2 is double not int
        Console.WriteLine(d2);
        #endregion

        #region Q3
        int age = int.Parse(Console.ReadLine());
        #endregion

        #region Q4
        //it throws exception : System.FormatException: Input string was not in a correct format.
        //because string has a character 'a' that can't be assigned into int 
        #endregion

        #region Q5
        string s5 = "12a";
        if (int.TryParse(s5, out int result5))
            Console.WriteLine(result5);
        else
            Console.WriteLine("Invalid");
        #endregion

        #region Q6
        //this prints 11 because object is casted into int in variable a so a = 10 then in output 
        // a+1 = 10+1 = 11
        #endregion

        #region Q7
        //this throws exception : System.InvalidCastException: Specified cast is not valid.
        //because o is a boxed int so we can't cast it directly into long it has to be unboxed first
        object o7 = 10;
        long x7 = (long)(int)o7; ;
        Console.WriteLine(x7);
        #endregion

        #region Q8
        object o8 = 10;
        long x8;
        try {
            x8 = Convert.ToInt64(o8);
        }
        catch {
            x8 = -1;
        }
        Console.WriteLine(x8);
        #endregion

        #region Q9
        //prints nothing because (name?.Length) is null so Console.WriteLine(null) prints nothing
        #endregion

        #region Q10
        //this will assign length = 0 because (name2?.Length) is null and the expression null ?? 0 returns 0
        //so length is assigned the value 0
        #endregion

        #region Q11
        //if value of s changes it can throw exception 
        string? s11 = null;
        if (int.TryParse(s11, out int x11))
            Console.WriteLine(x11);
        else
            Console.WriteLine(0);
        #endregion

        #region Q12
        //throws exception : System.NullReferenceException: Object reference not set to an instance of an object
        string? s12 = null;
        Console.WriteLine(s12?.Length ?? 0);
        #endregion

        #region Q13
        //this prints 0 because Convert.ToInt32(null) returns 0 
        #endregion

        #region Q14
        /*Result A: int.Parse(s)
         throws ArgumentNullException
         int.Parse() does not accept null because it expects a valid string
         Exception message: "Value cannot be null"
         Result B: Convert.ToInt32(s)
         Returns 0 (no exception)
         Convert.ToInt32() treats null as a special case and returns 0
         Prints: 0
        */
        #endregion

        #region Q15
        string? user = null;
        Console.WriteLine(user?.ToUpper() ?? "Guest");
        #endregion
    }
}
