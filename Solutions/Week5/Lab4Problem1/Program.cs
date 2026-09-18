using Problem1Lab5;

public class Program
{
    public static void Main()
    {
        StudentClass sc = new StudentClass();
        sc.QueryHighScores(1, 90);
        sc.QueryNestedGroups();
        // Keep the console window open in debug mode. 
        Console.WriteLine("Press any key to exit");
        Console.ReadKey();
    }
}