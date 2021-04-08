using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Deck
    {
        public List<Card> _deckList = new List<Card>(); //a list of Card class
        public int drawnCards = -1; //ammount of cards drawn. default -1 so that first card drawn is index 0

        public Deck() //initialize the deck with all 52 unique cards in order. then shuffle the deck
        {
            _deckList.Add(new Card(Card.ValueName.Ace, Card.SuitName.Clubs));
            _deckList.Add(new Card(Card.ValueName.Two, Card.SuitName.Clubs));
            _deckList.Add(new Card(Card.ValueName.Three, Card.SuitName.Clubs));
            _deckList.Add(new Card(Card.ValueName.Four, Card.SuitName.Clubs));
            _deckList.Add(new Card(Card.ValueName.Five, Card.SuitName.Clubs));
            _deckList.Add(new Card(Card.ValueName.Six, Card.SuitName.Clubs));
            _deckList.Add(new Card(Card.ValueName.Seven, Card.SuitName.Clubs));
            _deckList.Add(new Card(Card.ValueName.Eight, Card.SuitName.Clubs));
            _deckList.Add(new Card(Card.ValueName.Nine, Card.SuitName.Clubs));
            _deckList.Add(new Card(Card.ValueName.Ten, Card.SuitName.Clubs));
            _deckList.Add(new Card(Card.ValueName.Jack, Card.SuitName.Clubs));
            _deckList.Add(new Card(Card.ValueName.Queen, Card.SuitName.Clubs));
            _deckList.Add(new Card(Card.ValueName.King, Card.SuitName.Clubs));

            _deckList.Add(new Card(Card.ValueName.Ace, Card.SuitName.Diamonds));
            _deckList.Add(new Card(Card.ValueName.Two, Card.SuitName.Diamonds));
            _deckList.Add(new Card(Card.ValueName.Three, Card.SuitName.Diamonds));
            _deckList.Add(new Card(Card.ValueName.Four, Card.SuitName.Diamonds));
            _deckList.Add(new Card(Card.ValueName.Five, Card.SuitName.Diamonds));
            _deckList.Add(new Card(Card.ValueName.Six, Card.SuitName.Diamonds));
            _deckList.Add(new Card(Card.ValueName.Seven, Card.SuitName.Diamonds));
            _deckList.Add(new Card(Card.ValueName.Eight, Card.SuitName.Diamonds));
            _deckList.Add(new Card(Card.ValueName.Nine, Card.SuitName.Diamonds));
            _deckList.Add(new Card(Card.ValueName.Ten, Card.SuitName.Diamonds));
            _deckList.Add(new Card(Card.ValueName.Jack, Card.SuitName.Diamonds));
            _deckList.Add(new Card(Card.ValueName.Queen, Card.SuitName.Diamonds));
            _deckList.Add(new Card(Card.ValueName.King, Card.SuitName.Diamonds));

            _deckList.Add(new Card(Card.ValueName.Ace, Card.SuitName.Hearts));
            _deckList.Add(new Card(Card.ValueName.Two, Card.SuitName.Hearts));
            _deckList.Add(new Card(Card.ValueName.Three, Card.SuitName.Hearts));
            _deckList.Add(new Card(Card.ValueName.Four, Card.SuitName.Hearts));
            _deckList.Add(new Card(Card.ValueName.Five, Card.SuitName.Hearts));
            _deckList.Add(new Card(Card.ValueName.Six, Card.SuitName.Hearts));
            _deckList.Add(new Card(Card.ValueName.Seven, Card.SuitName.Hearts));
            _deckList.Add(new Card(Card.ValueName.Eight, Card.SuitName.Hearts));
            _deckList.Add(new Card(Card.ValueName.Nine, Card.SuitName.Hearts));
            _deckList.Add(new Card(Card.ValueName.Ten, Card.SuitName.Hearts));
            _deckList.Add(new Card(Card.ValueName.Jack, Card.SuitName.Hearts));
            _deckList.Add(new Card(Card.ValueName.Queen, Card.SuitName.Hearts));
            _deckList.Add(new Card(Card.ValueName.King, Card.SuitName.Hearts));

            _deckList.Add(new Card(Card.ValueName.Ace, Card.SuitName.Spades));
            _deckList.Add(new Card(Card.ValueName.Two, Card.SuitName.Spades));
            _deckList.Add(new Card(Card.ValueName.Three, Card.SuitName.Spades));
            _deckList.Add(new Card(Card.ValueName.Four, Card.SuitName.Spades));
            _deckList.Add(new Card(Card.ValueName.Five, Card.SuitName.Spades));
            _deckList.Add(new Card(Card.ValueName.Six, Card.SuitName.Spades));
            _deckList.Add(new Card(Card.ValueName.Seven, Card.SuitName.Spades));
            _deckList.Add(new Card(Card.ValueName.Eight, Card.SuitName.Spades));
            _deckList.Add(new Card(Card.ValueName.Nine, Card.SuitName.Spades));
            _deckList.Add(new Card(Card.ValueName.Ten, Card.SuitName.Spades));
            _deckList.Add(new Card(Card.ValueName.Jack, Card.SuitName.Spades));
            _deckList.Add(new Card(Card.ValueName.Queen, Card.SuitName.Spades));
            _deckList.Add(new Card(Card.ValueName.King, Card.SuitName.Spades));
            Shuffle();
        }
        private Random rng = new Random(); // random number generator

        public void Shuffle() //randomize the list of cards in the deck, decks are shuffled by default
        {
            int i = rng.Next(900)+100;//number of iterations between 100 and 1000
            
            while (i > 1) //shuffle loop that swaps two random cards
            {
                i--;
                int n1 = rng.Next(_deckList.Count);  //generate 2 random numbers up to _deckList.Count
                int n2 = rng.Next(_deckList.Count);
                Card tempCard = _deckList[n1]; // flip the two cards
                _deckList[n1] = _deckList[n2];
                _deckList[n2] = tempCard;
            }
        }
        public Card DrawCard() //return an instance of a card
        {
            if (drawnCards > _deckList.Count) //check if there are cards left in the deck first (we should never get this far)
            {
                drawnCards = _deckList.Count;
                return null; //idk what happens if this gets called. it should never be called
            }
            else //return the next card
            {
                drawnCards++;
                return _deckList[drawnCards];
            }
        }
        public void PrintDeck() // cycle through all cards in the deck and call PrintCard() on all of them
        {
            Console.WriteLine(); //start on a new line
            Console.CursorLeft = 1; // leave some space on the left-hand side of the screen

            foreach (var card in _deckList)
            {
                if (Console.BufferWidth - Console.CursorLeft < 14) //account for the width of the current console window before printing a new card to make sure we're not going offscreen.
                {
                    Console.CursorTop += 10; // if we would have gone off screen, start a new line of cards.
                    Console.CursorLeft = 1;
                    card.PrintCard();
                }
                else
                {
                    card.PrintCard(); //else just print the dang card
                }
                Console.CursorLeft += 2; // spaces between each card
                Console.CursorTop -= 6; // reset cursor to match top of previous card for neatness
            }
        }
    }
}
