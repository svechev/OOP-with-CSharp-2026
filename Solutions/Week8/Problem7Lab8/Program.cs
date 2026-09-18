// See https://aka.ms/new-console-template for more information
namespace Problem7Lab8
{
    class Program
    {
        public delegate void myDel(int x);
        static void Main()
        {
            Console.WriteLine("\n Practice for some delegates:");
            myDel mahiro;
            mahiro = new myDel(y => ++y);


            Console.WriteLine("\nProblem 7A:");
            var enumerator = new Countdown();
            while (enumerator.MoveNext())
            {
                Console.Write($"{enumerator.Current} ");
            }
            enumerator.Reset();

            Console.WriteLine("\nProblem 7B:");
            var countEmbedded = new IEnumeratorEmbeddedClass.Countdown();
            while (countEmbedded.MoveNext())
            {
                Console.Write($"{countEmbedded.Current} ");
            }
            countEmbedded.Reset();

            Console.WriteLine("\nProblem 7C:");
            var countVirtual = new IEnumeratorVirtual.Countdown();
            while (countVirtual.MoveNext())
            {
                Console.Write($"{countVirtual.Current} ");
            }
            countVirtual.Reset();

            Console.WriteLine("\nProblem 7D:");
            IEnumeratorExplicit enumeratorExplicit = new IEnumeratorExplicit.Countdown();

            // this is the same thing with casting:

            //var countExplicit = new IEnumeratorExplicit.Countdown();
            //IEnumeratorExplicit enumeratorExplicit = (IEnumeratorExplicit)countExplicit;

            while (enumeratorExplicit.MoveNext())
            {
                Console.Write($"{enumeratorExplicit.Current} ");
            }
            enumeratorExplicit.Reset();

            Console.WriteLine("\nTest countdown inheritance:");
            var inheritCountdown = new InheritCountdown();

            while (inheritCountdown.MoveNext())
            {
                Console.Write($"{inheritCountdown.Current} ");
            }
            inheritCountdown.Reset();
        }
    }
    /// <summary>
    /// Inherit methods from IEnumeratorVirtual.Countdown
    /// </summary>
    class InheritCountdown : IEnumeratorVirtual.Countdown
    {
        int startValue = 17;

        public override object Current => startValue;
        public override bool MoveNext() => startValue-- > 0;
        public override void Reset() => startValue = 17;
    }
}