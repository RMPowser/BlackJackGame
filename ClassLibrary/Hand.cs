using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Hand
    {
        public List<Card> _cards = new List<Card>();
        private int _score;

        public int GetScore() //calulate and return new score
        {
            _score = 0; //always start with zero
            int acesAdded = 0;
            for (int i = 0; i < _cards.Count; i++) //iterate through all cards and add their values to score
            {
                if (_cards[i]._value > 10) // if card is a face card, it counts as ten
                {
                    _score += 10;
                    for (int j = 0;  _score > 21;  j+=0)
                    {
                        if (acesAdded == 0)
                        {
                            break;
                        }
                        else
                        {
                            _score -= 10;
                            acesAdded--;
                        }
                    }
                }
                else if (_cards[i]._value == 1) // if counting an ace as 11 would cause the player to bust, count it as 1 instead
                {
                    _score += 11;
                    acesAdded+=1;
                    if (_score > 21)
                    {
                        _score -= 10;
                    }
                }
                else // add normally
                {
                    _score += _cards[i]._value;
                    for (int j = 0; _score > 21; j += 0)
                    {
                        if (acesAdded == 0)
                        {
                            break;
                        }
                        else
                        {
                            _score -= 10;
                            acesAdded--;
                        }
                    }
                }

            }
            return _score;
        }

        public void PrintHand() // cycle through all cards in the deck and call PrintCard() on all of them
        {
            foreach (var card in _cards)
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
        public void Reset()
        {
            for (int i = 0; _cards.Count > 0; i+=0)
            {
                _cards.RemoveAt(i);
            }
        }
    }
}
