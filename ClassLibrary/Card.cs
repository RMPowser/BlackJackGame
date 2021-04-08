using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Card
    {
        public enum SuitName {Clubs = 1, Diamonds = 2, Hearts = 3, Spades = 4} //enum of all possible suits
        public enum ValueName {Ace = 1, Two = 2, Three = 3, Four = 4, Five = 5, Six = 6, Seven = 7, Eight = 8, Nine = 9, Ten = 10, Jack = 11, Queen = 12, King = 13} //enum of all possible face values
        public int _value; //value of current card. Ace, Two, Three, Four, Five, King, etc. represented as a unique number from enum ValueName.
        public string _suit; //suit of current card.
        private string _printString;
        public Card(ValueName Value, SuitName Suit)
        {
            switch (Value)
            {
                case ValueName.Ace:
                    _value = 1;
                    break;
                case ValueName.Two:
                    _value = 2;
                    break;
                case ValueName.Three:
                    _value = 3;
                    break;
                case ValueName.Four:
                    _value = 4;
                    break;
                case ValueName.Five:
                    _value = 5;
                    break;
                case ValueName.Six:
                    _value = 6;
                    break;
                case ValueName.Seven:
                    _value = 7;
                    break;
                case ValueName.Eight:
                    _value = 8;
                    break;
                case ValueName.Nine:
                    _value = 9;
                    break;
                case ValueName.Ten:
                    _value = 10;
                    break;
                case ValueName.Jack:
                    _value = 11;
                    break;
                case ValueName.Queen:
                    _value = 12;
                    break;
                case ValueName.King:
                    _value = 13;
                    break;
            }
            switch (Suit)
            {
                case SuitName.Hearts:
                    _suit = "Hearts";
                    break;
                case SuitName.Clubs:
                    _suit = "Clubs";
                    break;
                case SuitName.Diamonds:
                    _suit = "Diamonds";
                    break;
                case SuitName.Spades:
                    _suit = "Spades";
                    break;
            }
        }
        public void PrintCardBack() // print the back of a card
        {

            _printString =
                    " Taco      " +
                    "           " +
                    "           " +
                    " ~Casinos~ " +
                    "           " +
                    "           " +
                    "      Taco ";

            for (int i = 0; i < _printString.Length; i++) //print loop for a back of card. Index 'i' should always stop at 77 because thats the length of every cards _printString.
            {
                Console.BackgroundColor = ConsoleColor.DarkGray;// the card back is dark red
                Console.ForegroundColor = ConsoleColor.White; 
                if (i % 11 == 0 && i != 0) // if we've reached the end of a line in the _printString, move to the next line and continue printing
                {
                    Console.CursorLeft -= 11;
                    Console.CursorTop += 1;
                }
                Console.Write(_printString[i]); // cycle through the entire string printing the correct amount of whitespace in between each symbol.
            }

            //reset console colors when finished
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }
        public void PrintCard() // specify the layout and pattern of the card with a string. all cards are 11x7. V is value and S is suit. 1, J, Q, and K all share 1's _printString.
        {
            if (_value == 1 || _value == 11 || _value == 12 || _value == 13)
            {
                _printString =
                    " V         " +
                    "           " +
                    "           " +
                    "     S     " +
                    "           " +
                    "           " +
                    "         V " ;
                PrintMethod();
            }
            if (_value == 2)
            {
                _printString =
                    " V         " +
                    "     S     " +
                    "           " +
                    "           " +
                    "           " +
                    "     S     " +
                    "         V ";
                PrintMethod();
            }
            if (_value == 3)
            {
                _printString =
                    " V         " +
                    "     S     " +
                    "           " +
                    "     S     " +
                    "           " +
                    "     S     " +
                    "         V ";
                PrintMethod();
            }
            if (_value == 4)
            {
                _printString =
                    " V         " +
                    "   S   S   " +
                    "           " +
                    "           " +
                    "           " +
                    "   S   S   " +
                    "         V ";
                PrintMethod();
            }
            if (_value == 5)
            {
                _printString =
                    " V         " +
                    "   S   S   " +
                    "           " +
                    "     S     " +
                    "           " +
                    "   S   S   " +
                    "         V ";
                PrintMethod();
            }
            if (_value == 6)
            {
                _printString =
                    " V         " +
                    "   S   S   " +
                    "           " +
                    "   S   S   " +
                    "           " +
                    "   S   S   " +
                    "         V ";
                PrintMethod();
            }
            if (_value == 7)
            {
                _printString =
                    " V         " +
                    "   S   S   " +
                    "     S     " +
                    "   S   S   " +
                    "           " +
                    "   S   S   " +
                    "         V ";
                PrintMethod();
            }
            if (_value == 8)
            {
                _printString =
                    " V         " +
                    "   S   S   " +
                    "     S     " +
                    "   S   S   " +
                    "     S     " +
                    "   S   S   " +
                    "         V ";
                PrintMethod();
            }
            if (_value == 9)
            {
                _printString =
                    " V         " +
                    "   S   S   " +
                    "   S   S   " +
                    "     S     " +
                    "   S   S   " +
                    "   S   S   " +
                    "         V ";
                PrintMethod();
            }
            if (_value == 10 )
            {
                _printString =
                    " V         " +
                    "   S   S   " +
                    "   S   S   " +
                    "   S   S   " +
                    "   S   S   " +
                    "   S   S   " +
                    "         V ";
                PrintMethod();
            }
        }
        private void PrintMethod() //how to actually print a single card to the screen
        {
            bool hasWrittenFirstNumber = false; // need to know this so that the second number prints correctly because the first and second number are treated differently if the card is a 10

            switch (_suit)// figure out our text printing color
            {
                case "Hearts":
                case "Diamonds":
                    Console.ForegroundColor = ConsoleColor.Red; //red for hearts and diamonds
                    break;
                case "Clubs":
                case "Spades":
                    Console.ForegroundColor = ConsoleColor.Black; // black for clubs and spades
                    break;
            }

            for (int i = 0; i < _printString.Length; i++) //print loop for a single card. Index 'i' should always stop at 77 because thats the length of every cards _printString.
            {
                Console.BackgroundColor = ConsoleColor.White; // the card background is always white
                if (i % 11 == 0 && i != 0) // if we've reached the end of a line in the _printString, move to the next line and continue printing
                {
                    Console.CursorLeft -= 11; 
                    Console.CursorTop += 1;
                }
                if (_printString[i] == 'S') // if we find an S in the _printString, replace it with the proper card symbol
                {
                    switch (_suit)
                    {
                        case "Hearts":
                            Console.Write('♥');
                            break;
                        case "Clubs":
                            Console.Write("♣");
                            break;
                        case "Diamonds":
                            Console.Write("♦");
                            break;
                        case "Spades":
                            Console.Write("♠");
                            break;
                    }
                    continue;
                }
                else if (_printString[i] == 'V') // if we find a V in the _printString, replace it with the cards value. a 10 is 2 characters long and so must be treated separately. face cards are also treated separately.
                {
                    if (_value == 10)
                    {
                        if (hasWrittenFirstNumber == false) // this is where hasWrittenFirstNumber comes into play. since 10 is two characters long, it has to be treated differently depending on where the V is placed in order for the number and the card to print correctly.
                        {
                            Console.Write(10);
                            hasWrittenFirstNumber = true;
                            i++;
                        }
                        else
                        {
                            Console.CursorLeft--;
                            Console.Write(10);
                        }
                        continue;
                    }
                    else if (_value == 11)
                    {
                        Console.Write("J");
                    }
                    else if (_value == 12)
                    {
                        Console.Write("Q");
                    }
                    else if (_value == 13)
                    {
                        Console.Write("K");
                    }
                    else if (_value == 1)
                    {
                        Console.Write("A");
                    }
                    else
                    {
                        Console.Write(_value); // if all else fails, just write the value. this should always be 2, 3, 4, 5, 6, 7, 8, or 9
                    }
                }
                else
                {
                    Console.Write(" "); ; // cycle through the entire string printing the correct amount of whitespace in between each symbol.
                }
            }

            //reset console colors when finished
            Console.BackgroundColor = ConsoleColor.Black; 
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
