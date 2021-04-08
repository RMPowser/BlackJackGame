using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary;

namespace BlackJackGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8; // UTF8 encoding is required for the console to display the suit symbols. ♥ ♦ ♣ ♠

            // useful variables
            string choice;
            string mainMenu = "1. Play BlackJack\n2. Shuffle and Show Deck\n3. Exit\nChoice: ";
            string inputError = "That's not an option...";
            string pressEnter = "Enter to continue... ";
            string playMenu = "1. Hit\n2. Stand\nChoice: ";
            string playAgain = "Play again?\n1. Yes\n2. No\nChoice: ";

            Deck deck = new Deck(); //initialize player, dealer, and deck. very important...
            Actor dealer = new Actor();
            Actor player = new Actor();

           
            do //game loop start
            {

                //main menu
                Console.Clear();
                Console.Write(mainMenu);
                choice = Console.ReadLine();
                if (choice != "1" && choice != "2" && choice != "3") //check for input error
                {
                    
                    do //print error and get choice again until choice is valid
                    {
                        Console.WriteLine(inputError);//this is the error
                        Console.CursorTop++;
                        Console.Write(pressEnter);
                        Console.ReadLine();

                        Console.Clear();//redo the menu
                        Console.Write(mainMenu);
                        choice = Console.ReadLine();
                    } while (choice != "1" && choice != "2" && choice != "3");
                }

                if (choice == "1") //option 1, main game
                {
                    InitGameScene(); //this displays the default game screen and sets its layout including the facedown dealer card
                    
                    do//play menu loop
                    {
                        if (player._hand.GetScore() == 21) //check for player blackjack
                        {
                            Decide();
                        }

                        if (dealer._hand.GetScore() == 21) //check for dealer blackjack
                        {
                            CursorSetPositionDealerCards();
                            dealer._hand.PrintHand();
                            CursorSetPositionDealerScore();
                            Console.Write(dealer._hand.GetScore());
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write(" BLACKJACK");
                            Console.ForegroundColor = ConsoleColor.White;
                            Decide();
                        }
                        ClearPlayMenu(); //this just clears a bunch of lines below the player score line to keep things clean
                        Console.Write(playMenu);
                        choice = Console.ReadLine();
                        if (choice != "1" && choice != "2") //check for input  error
                        {
                            do //print error and get choice again until choice is valid
                            {
                                Console.WriteLine(inputError); //this is the error
                                Console.CursorTop++;
                                Console.Write(pressEnter);
                                Console.ReadLine();
                                ClearPlayMenu(); //redo the menu
                                Console.Write(playMenu);
                                choice = Console.ReadLine();
                            } while (choice != "1" && choice != "2");
                        }

                        if (choice == "1")// player wants us to hit them
                        {
                            player.Hit(deck); //draw a card from the deck and add it to the players hand
                            CursorSetPositionPlayerCards(); //this sets the position of the cursor to prepare for printing the hand
                            player._hand.PrintHand(); //print the cards in the hand to the screen
                            CursorSetPositionPlayerScore(); //this sets the posotion of the cursor to prepare for printing a new player score
                            Console.Write(player._hand.GetScore()); //get the score and write it to the console
                            if (player._hand.GetScore() > 21)// if player busts from hitting
                            {
                                Decide(); // this decides the outcome of the match, win/lose etc. and asks if they want to play again
                            }
                            if (player._hand.GetScore() == 21) //if player gets a blackjack from hitting
                            {
                                Decide(); //this also handles text display for player blackjack
                            }
                        }

                        if (choice == "2")// player wants to stay put. dealers turn
                        {
                            if (dealer._hand.GetScore() < 17) //dealer will always hit if score is less than 17
                            {
                                do
                                {
                                    dealer.Hit(deck);//draw a card and add it to the dealers hand
                                } while (dealer._hand.GetScore() < 17);
                            }
                            if ((dealer._hand.GetScore() >= 17 && dealer._hand.GetScore() <= 20) || dealer._hand.GetScore() > 21) //if dealer score is between 17 and 20 inclusive or if dealer busts
                            {
                                CursorSetPositionDealerCards(); //set the cursor to prepare for printing the dealers hand
                                dealer._hand.PrintHand();
                                CursorSetPositionDealerScore(); //set the cursor to prepare for ptinting the dealers score
                                Console.Write(dealer._hand.GetScore());
                                Decide(); //determine outcome
                            }
                            if (dealer._hand.GetScore() == 21)
                            {
                                CursorSetPositionDealerCards();
                                dealer._hand.PrintHand();
                                CursorSetPositionDealerScore();
                                Console.Write(dealer._hand.GetScore());
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.Write(" BLACKJACK");
                                Console.ForegroundColor = ConsoleColor.White;
                                Decide(); //determine outcome. dealer usually wins in this case.
                            }
                        }
                    } while (true); //do play loop forever until process is terminated
                }

                if (choice == "2") //option 2, shuffle and print complete deck
                {
                    deck.Shuffle(); //shuffle the deck
                    deck.PrintDeck(); //print the whole deck to the screen, one card at a time
                    Console.CursorLeft = 0;
                    Console.CursorTop += 10;
                    Console.Write(pressEnter);
                    Console.ReadLine();
                }

                if (choice == "3") //option 3, exit game
                {
                    Environment.Exit(0);
                }
                
            } while (true); //do main game loop forever until process is terminated



            //end game loop. everything after this is methods/functions that pertain to or depend on elements in the core game loop.



            void Decide() // this decides the outcome of the match, win/lose etc.
            {
                if (player._hand.GetScore() >= dealer._hand.GetScore() && player._hand.GetScore() < 21)
                {
                    CursorSetPositionPlayerScore();
                    Console.CursorLeft +=3;
                    Console.Write("YOU WIN!");
                    Console.CursorTop = 18; 
                    Console.CursorLeft = 0;
                    getPlayAgain();
                }
                else if (dealer._hand.GetScore() > 21)
                {
                    CursorSetPositionPlayerScore();
                    Console.CursorLeft += 3;
                    Console.Write("YOU WIN!");
                    CursorSetPositionDealerScore();
                    Console.CursorLeft += 3;
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write("BUST");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.CursorTop = 18;
                    Console.CursorLeft = 0;
                    getPlayAgain();
                }
                else if (player._hand.GetScore() > 21)
                {
                    CursorSetPositionPlayerScore();
                    Console.CursorLeft += 3;
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write("BUST");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.CursorTop = 18;
                    Console.CursorLeft = 0;
                    getPlayAgain();
                }
                else if (player._hand.GetScore() < dealer._hand.GetScore())
                {
                    CursorSetPositionPlayerScore();
                    Console.CursorLeft += 3;
                    Console.Write("YOU LOSE...");
                    Console.CursorTop = 18;
                    Console.CursorLeft = 0;
                    getPlayAgain();
                }
                else if (player._hand.GetScore() >= dealer._hand.GetScore() && player._hand.GetScore() == 21)
                {
                    CursorSetPositionPlayerScore();
                    Console.CursorLeft += 3;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("BLACKJACK!! YOU WIN!!");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.CursorTop = 18;
                    Console.CursorLeft = 0;
                    getPlayAgain();
                }
            }

            void getPlayAgain()
            {
                ClearPlayMenu();
                Console.Write(playAgain);
                choice = Console.ReadLine();
                if (choice != "1" && choice != "2") //check for input  error
                {
                    do //print error and get choice again until choice is valid
                    {
                        Console.WriteLine(inputError);
                        Console.CursorTop++;
                        Console.Write(pressEnter);
                        Console.ReadLine();
                        ClearPlayMenu();
                        Console.Write(playAgain);
                        choice = Console.ReadLine();
                    } while (choice != "1" && choice != "2");
                }
                if (choice == "1")
                {
                    InitGameScene();
                }
                if (choice == "2")
                {
                    Environment.Exit(0);
                }
            }

            void InitGameScene()
            {
                deck.drawnCards = -1;
                dealer._hand.Reset();
                player._hand.Reset();
                Console.Clear();
                deck.Shuffle();
                dealer.Hit(deck);
                player.Hit(deck);
                dealer.Hit(deck);
                player.Hit(deck);
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.Write($"Dealer: ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("??");
                CursorSetPositionDealerCards();
                dealer._hand._cards[0].PrintCardBack();
                Console.CursorLeft += 2;
                Console.CursorTop -= 6;
                dealer._hand._cards[1].PrintCard();
                CursorSetPositionPlayerCards();
                player._hand.PrintHand();
                Console.CursorLeft = 0;
                Console.CursorTop = 17;
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Write("Player: ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(player._hand.GetScore());
            }

            void ClearPlayMenu()
            {
                Console.CursorLeft = 0;
                Console.CursorTop = 18;
                for (int i = 0; i < 20; i++)
                {
                    ClearCurrentConsoleLine();
                    Console.CursorTop++;
                }
                Console.CursorLeft = 0;
                Console.CursorTop = 0;
                Console.CursorTop = 18;
            }

            void CursorSetPositionPlayerCards()
            {
                Console.CursorTop = 10;
                Console.CursorLeft = 1;
            }

            void CursorSetPositionDealerCards()
            {
                Console.CursorTop = 1;
                Console.CursorLeft = 1;
            }

            void CursorSetPositionPlayerScore()
            {
                Console.CursorTop = 17;
                Console.CursorLeft = 8;
            }

            void CursorSetPositionDealerScore()
            {
                Console.CursorTop = 0;
                Console.CursorLeft = 8;
            }

            void ClearCurrentConsoleLine()
            {
                int currentLineCursor = Console.CursorTop;
                Console.SetCursorPosition(0, Console.CursorTop);
                Console.Write(new string(' ', Console.WindowWidth));
                Console.SetCursorPosition(0, currentLineCursor);
            }
        }
    }
}
