// DeckOfCards.cs
// DeckOfCards class represents a deck of playing cards.
using System;
using System.Net.Security;
using System.Runtime.ExceptionServices;
namespace Deck 
{
    public class DeckOfCards
    {
        private Card[] deck; // array of Card objects
        private int currentCard; // index of next Card to be dealt
        private const int NUMBER_OF_CARDS = 52; // constant number of Cards
        private Random randomNumbers; // random number generator

        // constructor fills deck of Cards

        Card[] handOfCards;
        int[] suitCounters;
        int[] faceCounters;

        public DeckOfCards()
        {
            suitCounters = new int[Card.suits.Length];
            faceCounters = new int[Card.faces.Length];

            handOfCards = new Card[5];

            deck = new Card[NUMBER_OF_CARDS]; // create array of Card objects
            currentCard = 0; // set currentCard so deck[ 0 ] is dealt first  
            randomNumbers = new Random(); // create random number generator

            // populate deck with Card objects
            for (int count = 0; count < deck.Length; count++)
                deck[count] =
                   new Card(count % 13, count / 13);
        } // end DeckOfCards constructor

        // shuffle deck of Cards with one-pass algorithm
        public void Shuffle()
        {
            // after shuffling, dealing should start at deck[ 0 ] again
            currentCard = 0; // reinitialize currentCard

            // for each Card, pick another random Card and swap them
            for (int first = 0; first < deck.Length; first++)
            {
                // select a random number between 0 and 51 
                int second = randomNumbers.Next(NUMBER_OF_CARDS);

                // swap current Card with randomly selected Card
                Card temp = deck[first];
                deck[first] = deck[second];
                deck[second] = temp;
            } // end for
        } // end method Shuffle

        // deal one Card
        public Card? DealCard()
        {
            // determine whether Cards remain to be dealt
            if (currentCard < deck.Length)
                return deck[currentCard++]; // return current Card in array
            else
                return null; // indicate that all Cards were dealt
        } // end method DealCard

        public void DealHand()
        {
            for (int i = 0; i < handOfCards.Length; i++)
            {
                handOfCards[i] = DealCard()!;
            }
        }

        public void InitCounters()
        {
            Array.Fill(suitCounters, 0);
            Array.Fill(faceCounters, 0);
        }

        public void DisplayHand()
        {
            for (int i = 0; i < handOfCards.Length; i++)
            {
                Console.WriteLine(handOfCards[i]);
            }
        }

        private int CountRepeats(int repeater)
        {
            int[] faces = new int[13];

            // count the faces
            for (int i = 0; i < handOfCards.Length; i++)
            {
                faces[handOfCards[i].Face]++;
            }

            int repeatsCount = 0;
            // check for a face that is seen "repeater" times
            for (int i = 0; i < faces.Length; i++)
            {
                if (faces[i] >= repeater)
                {
                    repeatsCount++;
                }
            }
            return repeatsCount;
        }

        public bool HasPair()
        {
            return CountRepeats(2) >= 1;
        }

        public bool HasTwoPairs()
        {
            return CountRepeats(2) >= 2;
        }

        public bool HasTriplet()
        {
            return CountRepeats(3) >= 1;
        }

        public bool HasQuadruplet()
        {
            return CountRepeats(4) >= 1;
        }

        public bool SameSuit()
        {
            int[] suits = new int[4];

            // count the suits
            for (int i = 0; i < handOfCards.Length; i++)
            {
                suits[handOfCards[i].Suit]++;
            }

            // check for a suit seen 5 times 
            for (int i = 0; i < suits.Length; i++)
            {
                if (suits[i] == 5)
                {
                    return true;
                }
            }
            return false;
        }

        public bool HasSequence()
        {
            int[] faces = new int[13];

            // count the faces
            for (int i = 0; i < handOfCards.Length; i++)
            {
                faces[handOfCards[i].Face]++;
            }

            // check for a sequence
            for (int i = 0; i < faces.Length; i++)
            {
                int first = faces[i];
                int second = faces[(i + 1) % 13];
                int third = faces[(i + 2) % 13];
                int fourth = faces[(i + 3) % 13];
                int fifth = faces[(i + 4) % 13];
                if (first == 1 && second == 1 && third == 1 && fourth == 1 && fifth == 1)
                {
                    return true;
                }
            }
            return false;
        }

        public bool HasFullHouse()
        {
            int[] suits = new int[4];

            // count the suits
            for (int i = 0; i < handOfCards.Length; i++)
            {
                suits[handOfCards[i].Suit]++;
            }

            // check for a suit seen 3 times + 2 times 
            for (int i = 0; i < suits.Length; i++)
            {
                for (int j = 0; j < suits.Length; j++)
                {
                    if (j == i) continue;
                    if (suits[i] == 2 && suits[j] == 3)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

    } // end class DeckOfCards
}
