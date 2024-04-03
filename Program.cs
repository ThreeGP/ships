using statki;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ships
{
    public class Program
    {
        static void Main(string[] args)
        {

            bool IsON = true;
            bool IsONGlobal = true;
            Menu menu = new Menu();
            DuelGameManager gm;
            GameBoard gameBoard;
            Ships ships;
            Player player;
        
            while(IsONGlobal)
            {
                menu.ShowMenu();
                int choice = Convert.ToInt32(Console.ReadLine());
                Console.Clear();

                if (choice == 1)
                {
                    Console.Clear();
                    bool IsON2 = true;

                    while (IsON2)
                    {
                        player = new Player();
                        ships = new Ships();
                        gameBoard = new GameBoard();
                        gm = new DuelGameManager(gameBoard, ships, player);
                        gameBoard.ShowBoard();
                        gm.PlaceShip();
                        GameBoard.currentPlayerMove = 2;
                        gm.PlaceShip();
                        Console.Clear();
                        gameBoard.ShowBoard();

                        while (IsON)
                        {
                            Console.WriteLine("Podaj pole do strzalu: ");
                            string move = Console.ReadLine().ToUpper();

                            gm.MakeMove(move);
                            if (player.player2_hp == 0)
                            {
                                Console.WriteLine("Wygrał gracz 1");
                                Player.player_1++;
                                Console.ReadKey();
                                IsON = false;
                            }
                            if (player.player1_hp == 0)
                            {
                                Console.WriteLine("Wygrał gracz 2");
                                Player.player_2++;
                                Console.ReadKey();
                                IsON = false;
                            }
                            Console.Clear();
                            gameBoard.ShowBoard();
                        }

                        Console.WriteLine("Chcesz kontynuowac gre? y/n");
                        string playAgain = Console.ReadLine().ToUpper();

                        if (playAgain == "N")
                            IsON2 = false;
                        if (playAgain == "Y")
                            IsON = true;
                        Console.ReadKey();
                        Console.Clear();
                    }
                }
                else if (choice == 2)
                {

                }
                else if (choice == 3)
                {
                    player = new Player();
                    ships = new Ships();
                    gameBoard = new GameBoard();
                    gm = new DuelGameManager(gameBoard, ships, player);
                    Player.player_2 = 0;
                    Player.player_1 = 0;
                    Console.Clear();
                    Console.WriteLine("Zresetowano punkty!");
                    Console.ReadKey();
                }
                else if (choice == 4)
                {
                    IsONGlobal = false;
                    Console.WriteLine("Do zobaczenia!");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("Podales zla opcje!");
                }
            }
            
        }
    }
}
