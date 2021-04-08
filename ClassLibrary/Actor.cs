using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Actor
    {
        public Hand _hand = new Hand(); // the hand containing the cards and score of the player or dealer. 

        public void Hit(Deck deck) // draw a card from the deck and add it to the hand.
        {
            _hand._cards.Add(deck.DrawCard());
        }
    }
}
