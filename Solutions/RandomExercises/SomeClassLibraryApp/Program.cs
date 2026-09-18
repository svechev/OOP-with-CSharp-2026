using SomeClassLibrary;

namespace SomeClassLibraryApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            SomeClass obj = new SomeClass("Mahiro");
            Console.WriteLine(obj.SomeProperty);
        }
    }
}
