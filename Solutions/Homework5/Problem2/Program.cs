// See https://aka.ms/new-console-template for more information
namespace Problem2
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Problem 2A:");
            var enumerator = new Countdown();
            while (enumerator.MoveNext())
            {
                Console.Write($"{enumerator.Current} ");
            }
            enumerator.Reset();

            Console.WriteLine("\nProblem 2B:");
            var countEmbedded = new IEnumeratorEmbeddedClass.Countdown();
            while (countEmbedded.MoveNext())
            {
                Console.Write($"{countEmbedded.Current} ");
            }
            countEmbedded.Reset();

            Console.WriteLine("\nProblem 2C:");
            var countVirtual = new IEnumeratorVirtual.Countdown();
            while (countVirtual.MoveNext())
            {
                Console.Write($"{countVirtual.Current} ");
            }
            countVirtual.Reset();

            Console.WriteLine("\nProblem 2D:");
            IEnumeratorExplicit enumeratorExplicit = new IEnumeratorExplicit.Countdown();
            
            while (enumeratorExplicit.MoveNext())
            {
                Console.Write($"{enumeratorExplicit.Current} ");
            }
            enumeratorExplicit.Reset();

            Console.WriteLine("\nTest countdown inheritance:");
            var inheritCountdown = new CountdownWithOverride();

            while (inheritCountdown.MoveNext())
            {
                Console.Write($"{inheritCountdown.Current} ");
            }
            inheritCountdown.Reset();
        }
    }
    
    
}