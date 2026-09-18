namespace Homework3
{
    public class RouteCipherTest
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Testing route cipher.");

            // Initialize a route cipher object
            RouteCipher routeCipher = new RouteCipher(5);

            // Encrypt sample text
            var encryptedText = routeCipher.Encrypt("thisistheplaintext");
            Console.WriteLine($"Encrypted text : {encryptedText}");

            // Decrypt the encrypted text
            var decryptedText = routeCipher.Decrypt(encryptedText);
            Console.WriteLine($"Decrypted text : {decryptedText}");

        }
    }
}