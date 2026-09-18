// See https://aka.ms/new-console-template for more information
using Problem2;

Console.WriteLine("Hello, World!");

TranspositionCipher transpositionCipher = new("beauty");
var encryptedText = transpositionCipher.Encrypt("thisistheplaintext");
Console.WriteLine($"Enxrypted text: {encryptedText}");
var decryptedText = transpositionCipher.Decrypt(encryptedText);
Console.WriteLine($"Enxrypted text: {decryptedText}");
