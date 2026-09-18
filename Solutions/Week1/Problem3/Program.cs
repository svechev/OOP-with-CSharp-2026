internal class Program
{
    /// <summary>
    /// Encrypts the input number
    /// </summary>
    /// <param name="number"></param>
    /// <returns></returns>
    private static int Encrypt(int number)
    {
        int result = 0;

        // Declare the digits
        int d1;
        int d2;
        int d3;
        int d4;

        // Get the digits and transform them
        d1 = ( (number / 1000) + 7 ) % 10;
        number %= 1000;

        d2 = ((number / 100) + 7) % 10;
        number %= 100;

        d3 = ((number / 10) + 7) % 10;
        number %= 10;

        d4 = (number + 7) % 10;

        // Calculate the result
        result = d2 + (d1 * 10) + (d4 * 100) + (d3 * 1000);

        return result;
    }

    /// <summary>
    /// Decrypts the encrypted number
    /// </summary>
    /// <param name="number"></param>
    /// <returns></returns>
    private static int Decrypt(int number)
    {
        int result = 0;

        // Declare the digits
        int d1;
        int d2;
        int d3;
        int d4;

        // Get the digits and transform them
        d1 = ((number / 1000) + 3) % 10;
        number %= 1000;

        d2 = ((number / 100) + 3) % 10;
        number %= 100;

        d3 = ((number / 10) + 3) % 10;
        number %= 10;

        d4 = (number + 3) % 10;

        // Calculate the result
        result = d2 + (d1 * 10) + (d4 * 100) + (d3 * 1000);

        return result;
    }
    private static void Main(string[] args)
    {
        Console.Write("Enter a four digit number: ");

        // Get the number
        int input = Convert.ToInt32(Console.ReadLine());

        // Encryption
        int encrypted = Encrypt(input);
        Console.WriteLine($"Encrypted as: {encrypted}");

        // Encryption
        int decrypted = Decrypt(encrypted);
        Console.WriteLine($"Decrypted as: {decrypted}");
    }
}