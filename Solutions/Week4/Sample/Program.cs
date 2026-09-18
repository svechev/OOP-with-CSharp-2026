using System.Collections;
using System.Linq;
using Problem1;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Caesar Encryption");

        CaesarCipher caesarCipher = new(3);

        var encryptedText = caesarCipher.Encrypt("TOY");

        Console.WriteLine($"Encrypted text: {encryptedText}");
        Console.WriteLine($"Decrypted text: {caesarCipher.Decrypt(encryptedText)}");


    }

}
