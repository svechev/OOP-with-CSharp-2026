
public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Compute cosine with approximation");

        double accuracy = 0.0001;
        double term = 1;
        int termCount = 1;
        double computerCos = term;
        double x = Math.PI / 6;

        do
        { 
            term = -term * x * x / ( (termCount * 2) * (termCount*2 - 1) ) ;
            termCount++;
            computerCos += term;
        } 
        while (Math.Abs(term) > accuracy);

        Console.WriteLine($"Accurate Cosine: {Math.Cos(x)} ");
        Console.WriteLine($"Approximate Cosine: {computerCos}");
    }
}