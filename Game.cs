using statki;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace ships
{
    public class DuelGameManager
    {
        public DuelGameManager(GameBoard gameBoard, Ships ships, Player player)
        {
            this.gameBoard = gameBoard;
            this.ships = ships;
            this.player = player;
        }
        public GameBoard gameBoard;
        public Ships ships;
        public Player player;


        public bool MakeMove(string move)
        {
            if (GameBoard.currentPlayerMove == 1)
            {
                if (gameBoard.playerTwoBoard[move] == "o")
                {
                    gameBoard.playerTwoBoard[move] = "*";
                    gameBoard.playerOneShots[move] = "*";
                    player.player2_hp--;
                    Console.WriteLine("Trafiles w statek!");
                    Console.ReadKey();

                }
                else if (gameBoard.playerTwoBoard[move] == "x" || gameBoard.playerTwoShots[move] == "*")
                {
                    Console.WriteLine("Strzelałeś już w to miejsce");
                }
                else if (gameBoard.playerTwoBoard[move] == " ")
                {
                    Console.WriteLine("Pudło!");
                    gameBoard.playerTwoBoard[move] = "x";
                    gameBoard.playerOneShots[move] = "x";
                    GameBoard.currentPlayerMove = 2;
                    Console.ReadKey();
                }
            }
            else if (GameBoard.currentPlayerMove == 2)
            {
                if (gameBoard.playerOneBoard[move] == "o")
                {
                    gameBoard.playerOneBoard[move] = "*";
                    gameBoard.playerTwoShots[move] = "*";
                    player.player1_hp--;
                    Console.WriteLine("Trafiles w statek!");
                    Console.ReadKey();
                }
                else if (gameBoard.playerOneBoard[move] == "x" || gameBoard.playerTwoShots[move] == "*")
                {
                    Console.WriteLine("Strzelałeś już w to miejsce");
                    Console.ReadKey();
                }
                else if (gameBoard.playerOneBoard[move] == " ")
                {
                    Console.WriteLine("Pudło!");
                    gameBoard.playerOneBoard[move] = "x";
                    gameBoard.playerTwoShots[move] = "x";
                    GameBoard.currentPlayerMove = 1;
                }
            }
            gameBoard.ShowBoard();

            return true;
        }
        public void TestPlaceShip()
        {
            gameBoard.playerOneBoard["A1"] = "o";
            gameBoard.playerOneBoard["A3"] = "o";
            gameBoard.playerOneBoard["A5"] = "o";
            gameBoard.playerOneBoard["A7"] = "o";

            gameBoard.playerOneBoard["B1"] = "o";
            gameBoard.playerOneBoard["C1"] = "o";

            gameBoard.playerOneBoard["D5"] = "o";
            gameBoard.playerOneBoard["E5"] = "o";
            gameBoard.playerOneBoard["F5"] = "o";

            gameBoard.playerOneBoard["C6"] = "o";
            gameBoard.playerOneBoard["C7"] = "o";
            gameBoard.playerOneBoard["C8"] = "o";
            gameBoard.playerOneBoard["C9"] = "o";

            // player 2
            gameBoard.playerTwoBoard["A1"] = "o";
            gameBoard.playerTwoBoard["A3"] = "o";
            gameBoard.playerTwoBoard["A5"] = "o";
            gameBoard.playerTwoBoard["A7"] = "o";

            gameBoard.playerTwoBoard["B1"] = "o";
            gameBoard.playerTwoBoard["C1"] = "o";

            gameBoard.playerTwoBoard["D5"] = "o";
            gameBoard.playerTwoBoard["E5"] = "o";
            gameBoard.playerTwoBoard["F5"] = "o";

            gameBoard.playerTwoBoard["C6"] = "o";
            gameBoard.playerTwoBoard["C7"] = "o";
            gameBoard.playerTwoBoard["C8"] = "o";
            gameBoard.playerTwoBoard["C9"] = "o";

        }
        public void PlaceShip()
        {
            string ALPHABET = "ABCDEFGHIJ";

            for (int i = 1; i <= 4;) // 1 masztowiec
            {
                Console.WriteLine($"GRACZ [{GameBoard.currentPlayerMove}] ({i}/4)Wybierz miejsce w którym chcesz postawic 1 masztowca: ");
                string placeShip = Console.ReadLine().ToUpper();
                if (GameBoard.currentPlayerMove == 1)
                {
                    if (gameBoard.playerOneBoard.ContainsKey(placeShip) && gameBoard.playerOneBoard[placeShip] != "o" && ships.IsPositionValid(gameBoard.playerOneBoard, placeShip))
                    {
                        gameBoard.playerOneBoard[placeShip] = "o";

                        i++;
                        Console.Clear();
                        gameBoard.ShowBoard();
                    }
                    else
                    {
                        Console.WriteLine("Podales zle miejsce!");
                    }
                }
                else
                {
                    if (gameBoard.playerTwoBoard.ContainsKey(placeShip) && gameBoard.playerTwoBoard[placeShip] != "o" && ships.IsPositionValid(gameBoard.playerTwoBoard, placeShip))
                    {
                        gameBoard.playerTwoBoard[placeShip] = "o";

                        i++;
                        Console.Clear();
                        gameBoard.ShowBoard();
                    }
                    else
                    {
                        Console.WriteLine("Podales zle miejsce!");
                    }
                }
            }
            for (int i = 1; i <= 3;) // 2 masztowiec ==== poziomo
            {
                Console.WriteLine($"GRACZ [{GameBoard.currentPlayerMove}] ({i}/3) Wybierz kierunek w którym chcesz postawic 2 masztowca: ");
                Console.WriteLine("[1] poziomo [2] pionowo");
                int shipDirection = Convert.ToInt32(Console.ReadLine());

                if (GameBoard.currentPlayerMove == 1)
                {
                    if (shipDirection == 1)
                    {
                        Console.WriteLine($"({i}/3)Wybierz miejsce w którym chcesz postawic 2 masztowca: ");
                        string placeShip = Console.ReadLine().ToUpper();
                        if (gameBoard.playerOneBoard.ContainsKey(placeShip) && gameBoard.playerOneBoard[placeShip] != "o" && ships.IsPositionValid(gameBoard.playerOneBoard, placeShip))
                        {
                            if (ALPHABET.IndexOf(placeShip[0]) == 9)
                            {
                                Console.WriteLine("Statek wykracza poza plansze [poziomo A-I]");
                            }
                            else
                            {
                                int columnIndex = ALPHABET.IndexOf(placeShip[0]);
                                char nextColumn = ALPHABET[columnIndex + 1];
                                string key = nextColumn + "" + placeShip[1];
                                key = placeShip.Length < 3 ? key : key + placeShip[2];

                                if (ships.IsPositionValid(gameBoard.playerOneBoard, placeShip) && ships.IsPositionValid(gameBoard.playerOneBoard, ALPHABET[ALPHABET.IndexOf(placeShip[0]) + 1] + "" + placeShip[1]))
                                {
                                    gameBoard.playerOneBoard[placeShip] = "o";
                                    gameBoard.playerOneBoard[key] = "o";
                                    i++;
                                    Console.Clear();
                                    gameBoard.ShowBoard();
                                }
                                else
                                    Console.WriteLine("W poblizu znajduje sie inny statek!");

                            }
                        }
                        else
                            Console.WriteLine("Podales zle miejsce!");
                    }
                    if (shipDirection == 2) // 2 masztowiec ==== pioniowo
                    {
                        Console.WriteLine($"({i}/3)Wybierz miejsce w którym chcesz postawic 2 masztowca: ");
                        string placeShip = Console.ReadLine().ToUpper(); ;

                        if (gameBoard.playerOneBoard.ContainsKey(placeShip) && gameBoard.playerOneBoard[placeShip] != "o" && ships.IsPositionValid(gameBoard.playerOneBoard, placeShip))
                        {
                            if (Convert.ToInt32(placeShip[1].ToString()) > 9)
                            {
                                Console.WriteLine("Statek wykracza poza plansze [poziomo 1-9]");
                            }
                            else
                            {
                                int columnIndex = Convert.ToInt32(placeShip[1]) - 48;
                                string nextColumn = Convert.ToString(columnIndex + 1);
                                string key = placeShip[0] + "" + nextColumn;

                                if (ships.IsPositionValid(gameBoard.playerOneBoard, placeShip) && ships.IsPositionValid(gameBoard.playerOneBoard, ALPHABET[ALPHABET.IndexOf(placeShip[0]) + 1] + "" + placeShip[1]))
                                {
                                    gameBoard.playerOneBoard[placeShip] = "o";
                                    gameBoard.playerOneBoard[key] = "o";
                                    i++;
                                    Console.Clear();
                                    gameBoard.ShowBoard();
                                }

                            }
                        }
                        else
                        {
                            Console.WriteLine("Podales zle miejsce!");
                        }
                    }
                }
                else
                {
                    Console.WriteLine($"({i}/3)Wybierz miejsce w którym chcesz postawic 2 masztowca: ");
                    string placeShip = Console.ReadLine().ToUpper();
                    if (gameBoard.playerTwoBoard.ContainsKey(placeShip) && gameBoard.playerTwoBoard[placeShip] != "o" && ships.IsPositionValid(gameBoard.playerTwoBoard, placeShip))
                    {
                        if (ALPHABET.IndexOf(placeShip[0]) == 9)
                        {
                            Console.WriteLine("Statek wykracza poza plansze [poziomo A-I]");
                        }
                        else
                        {
                            int columnIndex = ALPHABET.IndexOf(placeShip[0]);
                            char nextColumn = ALPHABET[columnIndex + 1];
                            string key = nextColumn + "" + placeShip[1];
                            key = placeShip.Length < 3 ? key : key + placeShip[2];

                            if (ships.IsPositionValid(gameBoard.playerTwoBoard, placeShip) && ships.IsPositionValid(gameBoard.playerTwoBoard, ALPHABET[ALPHABET.IndexOf(placeShip[0]) + 1] + "" + placeShip[1]))
                            {
                                gameBoard.playerTwoBoard[placeShip] = "o";
                                gameBoard.playerTwoBoard[key] = "o";
                                i++;
                                Console.Clear();
                                gameBoard.ShowBoard();
                            }
                            else
                                Console.WriteLine("W poblizu znajduje sie inny statek!");
                        }
                    }
                    else
                        Console.WriteLine("Podales zle miejsce!");
                }
                if (shipDirection == 2) // 2 masztowiec ==== pioniowo
                {
                    Console.WriteLine($"({i}/3)Wybierz miejsce w którym chcesz postawic 2 masztowca: ");
                    string placeShip = Console.ReadLine().ToUpper(); ;

                    if (ships.IsPositionValid(gameBoard.playerTwoBoard, placeShip) && ships.IsPositionValid(gameBoard.playerTwoBoard, placeShip[0] + "" + (int.Parse(placeShip.Substring(1)) + 1)))
                    {
                        if (Convert.ToInt32(placeShip[1].ToString()) > 9)
                        {
                            Console.WriteLine("Statek wykracza poza plansze [poziomo 1-9]");
                        }
                        else
                        {
                            int columnIndex = Convert.ToInt32(placeShip[1]) - 48;
                            string nextColumn = Convert.ToString(columnIndex + 1);
                            string key = placeShip[0] + "" + nextColumn;

                            if (ships.IsPositionValid(gameBoard.playerTwoBoard, placeShip) && ships.IsPositionValid(gameBoard.playerTwoBoard, placeShip[0] + "" + (int.Parse(placeShip.Substring(1)) + 1)))
                            {
                                gameBoard.playerTwoBoard[placeShip] = "o";
                                gameBoard.playerTwoBoard[key] = "o";
                                i++;
                                Console.Clear();
                                gameBoard.ShowBoard();
                            }

                        }
                    }
                    else
                    {
                        Console.WriteLine("Podales zle miejsce!");
                    }
                }
            }
            for (int i = 1; i <= 2;) // 3 masztowiec ==== poziomo
            {
                Console.WriteLine($"GRACZ [{GameBoard.currentPlayerMove}] ({i}/2) Wybierz kierunek w którym chcesz postawic 3 masztowca: ");
                Console.WriteLine("[1] poziomo [2] pionowo");
                int shipDirection = Convert.ToInt32(Console.ReadLine());
                if (GameBoard.currentPlayerMove == 1)
                {
                    if (shipDirection == 1)
                    {

                        Console.WriteLine($"({i}/2)Wybierz miejsce w którym chcesz postawic 3 masztowca: ");
                        string placeShip = Console.ReadLine().ToUpper(); ;
                        if (gameBoard.playerOneBoard[placeShip] != "o")
                        {
                            if (ALPHABET.IndexOf(placeShip[0]) > 8)
                            {
                                Console.WriteLine("Statek wykracza poza plansze [poziomo A-H]");
                            }
                            else
                            {
                                int columnIndex = ALPHABET.IndexOf(placeShip[0]);

                                char nextColumn = ALPHABET[columnIndex + 1];
                                string key = nextColumn + "" + placeShip[1];
                                key = placeShip.Length < 3 ? key : key + placeShip[2];

                                char nextColumn2 = ALPHABET[columnIndex + 2];
                                string key2 = nextColumn2 + "" + placeShip[1];
                                key2 = placeShip.Length < 3 ? key2 : key2 + placeShip[2];

                                if (ships.IsPositionValid(gameBoard.playerOneBoard, placeShip) && ships.IsPositionValid(gameBoard.playerOneBoard, ALPHABET[ALPHABET.IndexOf(placeShip[0]) + 1] + "" + placeShip[1]) && ships.IsPositionValid(gameBoard.playerOneBoard, ALPHABET[ALPHABET.IndexOf(placeShip[0]) + 2] + "" + placeShip[1]))
                                {
                                    gameBoard.playerOneBoard[placeShip] = "o";
                                    gameBoard.playerOneBoard[key] = "o";
                                    gameBoard.playerOneBoard[key2] = "o";
                                    i++;
                                    Console.Clear();
                                    gameBoard.ShowBoard();
                                }

                            }
                        }
                        else
                        {
                            Console.WriteLine("Podales zle miejsce!");
                        }
                    }
                    if (shipDirection == 2) // 3 masztowiec ==== pinowo
                    {
                        Console.WriteLine($"({i}/2)Wybierz miejsce w którym chcesz postawic 3 masztowca: ");
                        string placeShip = Console.ReadLine().ToUpper(); ;

                        if (gameBoard.playerOneBoard[placeShip] != "o")
                        {
                            if (Convert.ToInt32(placeShip[1].ToString()) > 8)
                            {
                                Console.WriteLine("Statek wykracza poza plansze [poziomo 1-8]");
                            }
                            else
                            {
                                int columnIndex = Convert.ToInt32(placeShip[1]) - 48;
                                string nextColumn = Convert.ToString(columnIndex + 1);
                                string key = placeShip[0] + "" + nextColumn;

                                string nextColumn2 = Convert.ToString(columnIndex + 2);
                                string key2 = placeShip[0] + "" + nextColumn2;

                                if (ships.IsPositionValid(gameBoard.playerOneBoard, placeShip) && ships.IsPositionValid(gameBoard.playerOneBoard, placeShip[0] + "" + (int.Parse(placeShip.Substring(1)) + 1)) && ships.IsPositionValid(gameBoard.playerOneBoard, placeShip[0] + "" + (int.Parse(placeShip.Substring(1)) + 2)))
                                {
                                    gameBoard.playerOneBoard[placeShip] = "o";
                                    gameBoard.playerOneBoard[key] = "o";
                                    gameBoard.playerOneBoard[key2] = "o";
                                    i++;
                                    Console.Clear();
                                    gameBoard.ShowBoard();
                                }

                            }
                        }
                        else
                        {
                            Console.WriteLine("Podales zle miejsce!");
                        }
                    }
                }
                else
                {
                    Console.WriteLine($"({i}/2)Wybierz miejsce w którym chcesz postawic 3 masztowca: ");
                    string placeShip = Console.ReadLine().ToUpper(); ;
                    if (gameBoard.playerTwoBoard[placeShip] != "o")
                    {
                        if (ALPHABET.IndexOf(placeShip[0]) > 8)
                        {
                            Console.WriteLine("Statek wykracza poza plansze [poziomo A-H]");
                        }
                        else
                        {
                            int columnIndex = ALPHABET.IndexOf(placeShip[0]);

                            char nextColumn = ALPHABET[columnIndex + 1];
                            string key = nextColumn + "" + placeShip[1];
                            key = placeShip.Length < 3 ? key : key + placeShip[2];

                            char nextColumn2 = ALPHABET[columnIndex + 2];
                            string key2 = nextColumn2 + "" + placeShip[1];
                            key2 = placeShip.Length < 3 ? key2 : key2 + placeShip[2];

                            if (ships.IsPositionValid(gameBoard.playerTwoBoard, placeShip) && ships.IsPositionValid(gameBoard.playerTwoBoard, ALPHABET[ALPHABET.IndexOf(placeShip[0]) + 1] + "" + placeShip[1]) && ships.IsPositionValid(gameBoard.playerOneBoard, ALPHABET[ALPHABET.IndexOf(placeShip[0]) + 2] + "" + placeShip[1]))
                            {
                                gameBoard.playerTwoBoard[placeShip] = "o";
                                gameBoard.playerTwoBoard[key] = "o";
                                gameBoard.playerTwoBoard[key2] = "o";
                                i++;
                                Console.Clear();
                                gameBoard.ShowBoard();
                            }

                        }
                    }
                    else
                    {
                        Console.WriteLine("Podales zle miejsce!");
                    }
                }
                if (shipDirection == 2) // 3 masztowiec ==== pinowo
                {
                    Console.WriteLine($"({i}/2)Wybierz miejsce w którym chcesz postawic 3 masztowca: ");
                    string placeShip = Console.ReadLine().ToUpper(); ;

                    if (gameBoard.playerTwoBoard[placeShip] != "o")
                    {
                        if (Convert.ToInt32(placeShip[1].ToString()) > 8)
                        {
                            Console.WriteLine("Statek wykracza poza plansze [poziomo 1-8]");
                        }
                        else
                        {
                            int columnIndex = Convert.ToInt32(placeShip[1]) - 48;
                            string nextColumn = Convert.ToString(columnIndex + 1);
                            string key = placeShip[0] + "" + nextColumn;

                            string nextColumn2 = Convert.ToString(columnIndex + 2);
                            string key2 = placeShip[0] + "" + nextColumn2;

                            if (ships.IsPositionValid(gameBoard.playerTwoBoard, placeShip) && ships.IsPositionValid(gameBoard.playerTwoBoard, placeShip[0] + "" + (int.Parse(placeShip.Substring(1)) + 1)) && ships.IsPositionValid(gameBoard.playerOneBoard, placeShip[0] + "" + (int.Parse(placeShip.Substring(1)) + 2)))
                            {
                                gameBoard.playerTwoBoard[placeShip] = "o";
                                gameBoard.playerTwoBoard[key] = "o";
                                gameBoard.playerTwoBoard[key2] = "o";
                                i++;
                                Console.Clear();
                                gameBoard.ShowBoard();
                            }

                        }
                    }
                    else
                    {
                        Console.WriteLine("Podales zle miejsce!");
                    }
                }
            }
            for (int i = 1; i <= 1;) // 4 masztowiec ==== poziomo
            {
                Console.WriteLine($"GRACZ [{GameBoard.currentPlayerMove}] ({i}/1) Wybierz kierunek w którym chcesz postawic 4 masztowca: ");
                Console.WriteLine("[1] poziomo [2] pionowo");
                int shipDirection = Convert.ToInt32(Console.ReadLine());

                if (GameBoard.currentPlayerMove == 1)
                {
                    if (shipDirection == 1)
                    {
                        Console.WriteLine($"({i}/1)Wybierz miejsce w którym chcesz postawic 4 masztowca: ");
                        string placeShip = Console.ReadLine().ToUpper(); ;

                        if (ALPHABET.IndexOf(placeShip[0]) > 7)
                        {
                            Console.WriteLine("Statek wykracza poza plansze [poziomo A-G]");
                        }
                        else
                        {
                            int columnIndex = ALPHABET.IndexOf(placeShip[0]);

                            char nextColumn = ALPHABET[columnIndex + 1];
                            string key = nextColumn + "" + placeShip[1];
                            key = placeShip.Length < 3 ? key : key + placeShip[2];

                            char nextColumn2 = ALPHABET[columnIndex + 2];
                            string key2 = nextColumn2 + "" + placeShip[1];
                            key2 = placeShip.Length < 3 ? key2 : key2 + placeShip[2];

                            char nextColumn3 = ALPHABET[columnIndex + 3];
                            string key3 = nextColumn3 + "" + placeShip[1];
                            key3 = placeShip.Length < 3 ? key3 : key3 + placeShip[2];

                            if (ships.IsPositionValid(gameBoard.playerOneBoard, placeShip) && ships.IsPositionValid(gameBoard.playerOneBoard, ALPHABET[ALPHABET.IndexOf(placeShip[0]) + 1] + "" + placeShip[1]) && ships.IsPositionValid(gameBoard.playerOneBoard, ALPHABET[ALPHABET.IndexOf(placeShip[0]) + 2] + "" + placeShip[1]) && ships.IsPositionValid(gameBoard.playerOneBoard, ALPHABET[ALPHABET.IndexOf(placeShip[0]) + 3] + "" + placeShip[1]))
                            {
                                gameBoard.playerOneBoard[placeShip] = "o";
                                gameBoard.playerOneBoard[key] = "o";
                                gameBoard.playerOneBoard[key2] = "o";
                                gameBoard.playerOneBoard[key3] = "o";
                                i++;
                                Console.Clear();
                                gameBoard.ShowBoard();
                                GameBoard.currentPlayerMove = 2;
                            }

                        }
                    }
                    if (shipDirection == 2) // 4 masztowiec ===== pionowo
                    {
                        Console.WriteLine($"({i}/1)Wybierz miejsce w którym chcesz postawic 4 masztowca: ");
                        string placeShip = Console.ReadLine();

                        if (gameBoard.playerOneBoard[placeShip] != "o")
                        {
                            if (Convert.ToInt32(placeShip[1].ToString()) > 7)
                            {
                                Console.WriteLine("Statek wykracza poza plansze [poziomo 1-7]");
                            }
                            else
                            {

                                int columnIndex = Convert.ToInt32(placeShip[1]) - 48;
                                string nextColumn = Convert.ToString(columnIndex + 1);
                                string key = placeShip[0] + "" + nextColumn;

                                string nextColumn2 = Convert.ToString(columnIndex + 2);
                                string key2 = placeShip[0] + "" + nextColumn2;

                                string nextColumn3 = Convert.ToString(columnIndex + 3);
                                string key3 = placeShip[0] + "" + nextColumn3;

                                if (ships.IsPositionValid(gameBoard.playerOneBoard, placeShip) && ships.IsPositionValid(gameBoard.playerOneBoard, placeShip[0] + "" + (int.Parse(placeShip.Substring(1)) + 1)) && ships.IsPositionValid(gameBoard.playerOneBoard, placeShip[0] + "" + (int.Parse(placeShip.Substring(1)) + 2)) && ships.IsPositionValid(gameBoard.playerOneBoard, placeShip[0] + "" + (int.Parse(placeShip.Substring(1)) + 3)))
                                {
                                    gameBoard.playerOneBoard[placeShip] = "o";
                                    gameBoard.playerOneBoard[key] = "o";
                                    gameBoard.playerOneBoard[key2] = "o";
                                    gameBoard.playerOneBoard[key3] = "o";
                                    i++;
                                    Console.Clear();
                                    gameBoard.ShowBoard();
                                    GameBoard.currentPlayerMove = 2;
                                }
                            }
                        }
                        else
                            Console.WriteLine("Podales zle miejsce!");
                    }
                }
                else
                {
                    if (shipDirection == 1)
                    {
                        Console.WriteLine($"({i}/1)Wybierz miejsce w którym chcesz postawic 4 masztowca: ");
                        string placeShip = Console.ReadLine().ToUpper(); ;

                        if (ALPHABET.IndexOf(placeShip[0]) > 7)
                        {
                            Console.WriteLine("Statek wykracza poza plansze [poziomo A-G]");
                        }
                        else
                        {
                            int columnIndex = ALPHABET.IndexOf(placeShip[0]);

                            char nextColumn = ALPHABET[columnIndex + 1];
                            string key = nextColumn + "" + placeShip[1];
                            key = placeShip.Length < 3 ? key : key + placeShip[2];

                            char nextColumn2 = ALPHABET[columnIndex + 2];
                            string key2 = nextColumn2 + "" + placeShip[1];
                            key2 = placeShip.Length < 3 ? key2 : key2 + placeShip[2];

                            char nextColumn3 = ALPHABET[columnIndex + 3];
                            string key3 = nextColumn3 + "" + placeShip[1];
                            key3 = placeShip.Length < 3 ? key3 : key3 + placeShip[2];

                            if (ships.IsPositionValid(gameBoard.playerTwoBoard, placeShip) && ships.IsPositionValid(gameBoard.playerTwoBoard, ALPHABET[ALPHABET.IndexOf(placeShip[0]) + 1] + "" + placeShip[1]) && ships.IsPositionValid(gameBoard.playerTwoBoard, ALPHABET[ALPHABET.IndexOf(placeShip[0]) + 2] + "" + placeShip[1]) && ships.IsPositionValid(gameBoard.playerTwoBoard, ALPHABET[ALPHABET.IndexOf(placeShip[0]) + 3] + "" + placeShip[1]))
                            {
                                gameBoard.playerTwoBoard[placeShip] = "o";
                                gameBoard.playerTwoBoard[key] = "o";
                                gameBoard.playerTwoBoard[key2] = "o";
                                gameBoard.playerTwoBoard[key3] = "o";
                                i++;
                                Console.Clear();
                                gameBoard.ShowBoard();
                                GameBoard.currentPlayerMove = 1;
                            }

                        }
                    }
                    if (shipDirection == 2) // 4 masztowiec ===== pionowo
                    {
                        Console.WriteLine($"({i}/1)Wybierz miejsce w którym chcesz postawic 4 masztowca: ");
                        string placeShip = Console.ReadLine();

                        if (gameBoard.playerOneBoard[placeShip] != "o")
                        {
                            if (Convert.ToInt32(placeShip[1].ToString()) > 7)
                            {
                                Console.WriteLine("Statek wykracza poza plansze [poziomo 1-7]");
                            }
                            else
                            {

                                int columnIndex = Convert.ToInt32(placeShip[1]) - 48;
                                string nextColumn = Convert.ToString(columnIndex + 1);
                                string key = placeShip[0] + "" + nextColumn;

                                string nextColumn2 = Convert.ToString(columnIndex + 2);
                                string key2 = placeShip[0] + "" + nextColumn2;

                                string nextColumn3 = Convert.ToString(columnIndex + 3);
                                string key3 = placeShip[0] + "" + nextColumn3;

                                if (ships.IsPositionValid(gameBoard.playerOneBoard, placeShip) && ships.IsPositionValid(gameBoard.playerOneBoard, placeShip[0] + "" + (int.Parse(placeShip.Substring(1)) + 1)) && ships.IsPositionValid(gameBoard.playerOneBoard, placeShip[0] + "" + (int.Parse(placeShip.Substring(1)) + 2)) && ships.IsPositionValid(gameBoard.playerOneBoard, placeShip[0] + "" + (int.Parse(placeShip.Substring(1)) + 3)))
                                {
                                    gameBoard.playerOneBoard[placeShip] = "o";
                                    gameBoard.playerOneBoard[key] = "o";
                                    gameBoard.playerOneBoard[key2] = "o";
                                    gameBoard.playerOneBoard[key3] = "o";
                                    i++;
                                    Console.Clear();
                                    gameBoard.ShowBoard();
                                    GameBoard.currentPlayerMove = 1;
                                }
                            }
                        }
                        else
                            Console.WriteLine("Podales zle miejsce!");
                    }
                }
            }
            Console.ReadKey();
            Console.Clear();
            gameBoard.ShowBoard();
        }
    }
}

