// Card.cs
// Card class represents a playing card.
namespace Deck 
{

    public class Card
    {
        public static readonly string[] faces = { "Ace", "Deuce", "Three", "Four", "Five", "Six",
         "Seven", "Eight", "Nine", "Ten", "Jack", "Queen", "King" };
        public static readonly string[] suits = { "Hearts", "Diamonds", "Clubs", "Spades" };

        private int face; // face of card ("Ace", "Deuce", ...)
        private int suit; // suit of card ("Hearts", "Diamonds", ...)

        public int Face
        {
            get => face;
            set => face = value >= 0 && value < faces.Length ? value : 0;
        }

        public int Suit
        {
            get => suit;
            set => suit = value >= 0 && value < suits.Length ? value : 0;
        }
        // two-parameter constructor initializes card's face and suit
        public Card(int cardFace, int cardSuit)
        {
            face = cardFace; // initialize face of card
            suit = cardSuit; // initialize suit of card
        } // end two-parameter Card constructor

        // return string representation of Card
        public override string ToString() =>
        $"{faces[face]} of {suits[suit]}";
        // end method ToString
    } // end class Card

}