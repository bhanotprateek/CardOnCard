using System;
using System.Collections.Generic;

namespace CardOnCard
{
    /// <summary>
    /// User interactivity class
    /// </summary>
    class GamePlay
    {
        static void Main(string[] args)
        {
            /*
             * 2 Players
             * first User and second computer
            */
            bool invalidEntry = true;
            bool gameStarted = false;
            while (invalidEntry)
            {
                Console.WriteLine();
                Console.WriteLine("Welcome to Card on Card Game");
                Console.WriteLine("Press 'S' to start");
                Console.WriteLine("Press 'Q' to quit");
                char ch = Console.ReadKey().KeyChar;
                switch (ch)
                {
                    case 's':
                    case 'S':
                        gameStarted = true; invalidEntry = false; break;
                    case 'q':
                    case 'Q':
                        Environment.Exit(0); break;
                    default:
                        {
                            Console.WriteLine("\nEnter valid entry\n"); invalidEntry = true;
                        }
                        break;
                }
            }
            if (gameStarted)
            {
                CardOnCardGame game = new CardOnCardGame();
                game.Start();
                bool isGameOver = false;
                while (true)
                {
                    CardOnCardPlayer user = game.GetPlayerUser();
                    Console.WriteLine();
                    Console.WriteLine("************Game Menu*********");
                    if (isGameOver == false)
                    {
                        Console.WriteLine("Press 'P' to play a card                 | Press 'S' to shuffle your deck in hand");
                    }
                    Console.WriteLine("Press 'D' to display cards played so far | Press 'R' to restart the game");
                    Console.WriteLine("Press 'Q' to quit");
                    Console.WriteLine("*****************************");

                    char ch = Console.ReadKey().KeyChar;
                    
                    switch (ch)
                    {
                        case 's':
                        case 'S':
                            {
                                if (isGameOver)
                                {
                                    Console.WriteLine("\nGame Over | Cannot Shuffle");
                                    Console.WriteLine("Let's Play agian");
                                    Console.WriteLine("*****************************");
                                    continue;
                                }
                                user.ShuffleMyDeck();
                                game.ShuffleCompDeck();
                                Console.WriteLine("\nDeck Shuffled");
                            }
                            break;
                        case 'p':
                        case 'P':
                            {
                                if (isGameOver)
                                {
                                    Console.WriteLine("\nGame Over | Cannot Play");
                                    Console.WriteLine("Let's Play agian");
                                    Console.WriteLine("*****************************");
                                    continue;
                                }
                                Card userCard = user.PlayACard();
                                
                                if (game.ComputeWinner(userCard))
                                {
                                    Console.WriteLine();
                                    Console.WriteLine("************Game Play*********");
                                    Console.WriteLine("\nYou are the Winner");
                                    isGameOver = true;
                                    game.AddCardToGameStack(userCard, PlayerType.user);
                                }
                                else
                                {
                                    game.AddCardToGameStack(userCard, PlayerType.user);
                                    Card compCard=game.PlayCompCard();
                                    if (game.ComputeWinner(compCard))
                                    {
                                        Console.WriteLine();
                                        Console.WriteLine("************Game Play*********");
                                        Console.WriteLine("\nComputer is the Winner");
                                        isGameOver = true;
                                        
                                    }
                                    game.AddCardToGameStack(compCard, PlayerType.comp);
                                }
                                DisplayLastPlayedCard(game);
                                
                            }
                            break;
                        case 'd':
                        case 'D':
                            {
                                DisplayCardsPlayedSoFar(game);
                            }
                            break;
                        case 'r':
                        case 'R':
                            {
                                game.Restart();
                                isGameOver = false;
                                Console.WriteLine();
                                Console.WriteLine("************Game Play*********");
                                Console.WriteLine("Game Restarted");
                                DisplayCardsInHandCount(game);
                                Console.WriteLine("******************************");
                            }
                            break;
                        case 'q':
                        case 'Q':
                            Environment.Exit(0); break;
                        default:
                            {
                                Console.WriteLine("Enter valid entry");
                                invalidEntry = false;
                            }
                            break;
                    }
                }
            }
        }

        private static void DisplayCardsInHandCount(CardOnCardGame game)
        {
            int userCardsInHandCount = game.GetPlayerUser().GetCardsInHandCount();
            int compCardsInHandCount = game.GetCompCardsInHandCount();
            Console.WriteLine("Cards In Hand Count of user:{0}", userCardsInHandCount);
            Console.WriteLine("Cards In Hand Count of computer:{0}", compCardsInHandCount);          
        }

        private static void DisplayLastPlayedCard(CardOnCardGame game)
        {
            Card userLastCard = game.GetPlayerUser().GetLastCardPlayed();
            Card compLastCard = game.GetCompLastCard();
            Card lastCardOnGameStack = game.GetGameLastCard();
            Console.WriteLine();
            Console.WriteLine("************Game Play*********");
            Console.WriteLine("Last card played by user:{0} of {1}",userLastCard.Value,userLastCard.Suite);
            Console.WriteLine("Last card played by computer:{0} of {1}", compLastCard.Value, compLastCard.Suite);
            if(lastCardOnGameStack!=null)
                Console.WriteLine("Last card on game stack:{0} of {1}", lastCardOnGameStack.Value, lastCardOnGameStack.Suite);
            DisplayCardsInHandCount(game);
            Console.WriteLine("******************************");
        }
        
        private static void DisplayCardsPlayedSoFar(CardOnCardGame game)
        {
            List<GameStackDetail> gameDetailsSoFar = game.GetCardsPlayedSoFar();
            Console.WriteLine();
            Console.WriteLine("************Game Play*********");
            if (gameDetailsSoFar.Count == 0)
                Console.WriteLine("No card played yet");
            else
            {
                Console.WriteLine("Cards Played so far");

                foreach (var gameDetail in gameDetailsSoFar)
                {
                    Console.WriteLine("{0} of {1} played by {2}", gameDetail.Card.Value, gameDetail.Card.Suite, gameDetail.Player.ToString());
                }

                Card lastCardOnGameStack = game.GetGameLastCard();
                Console.WriteLine("Last card on game stack:{0} of {1}", lastCardOnGameStack.Value, lastCardOnGameStack.Suite);

                DisplayCardsInHandCount(game);
            }
            Console.WriteLine("******************************");
            Console.WriteLine();
        }
    }
}
