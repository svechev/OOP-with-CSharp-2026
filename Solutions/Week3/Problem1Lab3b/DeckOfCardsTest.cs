// DeckOfCardsTest.cs
// Card shuffling and dealing application.
using System;
namespace Deck 
{
    public class DeckOfCardsTest
    {
        // execute application
        public static void Main(string[] args)
        {
            DeckOfCards myDeckOfCards = new DeckOfCards();
            myDeckOfCards.Shuffle(); // place Cards in random order

            myDeckOfCards.DealHand();
            myDeckOfCards.DisplayHand();

            Console.WriteLine();
            Console.WriteLine($"Has pair: {myDeckOfCards.HasPair()}");
            Console.WriteLine($"Has 2 pairs: {myDeckOfCards.HasTwoPairs()}");
            Console.WriteLine($"Has triplet: {myDeckOfCards.HasTriplet()}");
            Console.WriteLine($"Has quadruplet: {myDeckOfCards.HasQuadruplet()}");
            Console.WriteLine($"Has a sequence: {myDeckOfCards.HasSequence()}");
            Console.WriteLine($"Has a full house: {myDeckOfCards.HasFullHouse()}");

        } // end Main
    } // end class DeckOfCardsTest
}

