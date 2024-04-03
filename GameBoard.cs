using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ships
{
    using System;
    using System.Collections.Generic;

    public class GameBoard
    {
        Player player = new Player();

        static public int currentPlayerMove = 1;
        public Dictionary<string, string> playerOneBoard = new Dictionary<string, string>();
        public Dictionary<string, string> playerTwoBoard = new Dictionary<string, string>();
        public Dictionary<string, string> playerTwoShots = new Dictionary<string, string>();
        public Dictionary<string, string> playerOneShots = new Dictionary<string, string>();

        public GameBoard()
        {
            const string ALPHABET = "ABCDEFGHIJ";
            for (int i = 0; i < ALPHABET.Length; i++)
            {
                for (int j = 1; j <= 10; j++)
                {
                    playerOneBoard.Add($"{ALPHABET[i]}{j}", " ");
                    playerTwoBoard.Add($"{ALPHABET[i]}{j}", " ");
                    playerOneShots.Add($"{ALPHABET[i]}{j}", " ");
                    playerTwoShots.Add($"{ALPHABET[i]}{j}", " ");
                }
            }
        }
        public void ShowBoard()
        {
            Dictionary<string, string> board = currentPlayerMove == 1 ? playerOneBoard : playerTwoBoard;
            Dictionary<string, string> board2 = currentPlayerMove == 1 ? playerOneShots : playerTwoShots;
            Console.WriteLine($"                 Gracz1: {Player.player_1}      \t\t\t\t\t\t   Gracz2: {Player.player_2}");
            Console.WriteLine($"               TWOJE STATKI         o - statek / * - trafiony / x - pudlo \t TWOJE STRZALY");
            Console.WriteLine();
            Console.WriteLine("    A | B | C | D | E | F | G | H | I | J  \t\t\t     A | B | C | D | E | F | G | H | I | J  ");
            Console.WriteLine("  -----------------------------------------\t\t\t   -----------------------------------------");
            Console.WriteLine($" 1| {board["A1"]} | {board["B1"]} | {board["C1"]} | {board["D1"]} | {board["E1"]} | {board["F1"]} | {board["G1"]} | {board["H1"]} | {board["I1"]} | {board["J1"]}\t\t\t  1| {board2["A1"]} | {board2["B1"]} | {board2["C1"]} | {board2["D1"]} | {board2["E1"]} | {board2["F1"]} | {board2["G1"]} | {board2["H1"]} | {board2["I1"]} | {board2["J1"]}");
            Console.WriteLine("  -----------------------------------------\t\t\t   -----------------------------------------");
            Console.WriteLine($" 2| {board["A2"]} | {board["B2"]} | {board["C2"]} | {board["D2"]} | {board["E2"]} | {board["F2"]} | {board["G2"]} | {board["H2"]} | {board["I2"]} | {board["J2"]}\t\t\t  2| {board2["A2"]} | {board2["B2"]} | {board2["C2"]} | {board2["D2"]} | {board2["E2"]} | {board2["F2"]} | {board2["G2"]} | {board2["H2"]} | {board2["I2"]} | {board2["J2"]}");
            Console.WriteLine("  -----------------------------------------\t\t\t   -----------------------------------------");
            Console.WriteLine($" 3| {board["A3"]} | {board["B3"]} | {board["C3"]} | {board["D3"]} | {board["E3"]} | {board["F3"]} | {board["G3"]} | {board["H3"]} | {board["I3"]} | {board["J3"]}\t\t\t  3| {board2["A3"]} | {board2["B3"]} | {board2["C3"]} | {board2["D3"]} | {board2["E3"]} | {board2["F3"]} | {board2["G3"]} | {board2["H3"]} | {board2["I3"]} | {board2["J3"]}");
            Console.WriteLine("  -----------------------------------------\t\t\t   -----------------------------------------");
            Console.WriteLine($" 4| {board["A4"]} | {board["B4"]} | {board["C4"]} | {board["D4"]} | {board["E4"]} | {board["F4"]} | {board["G4"]} | {board["H4"]} | {board["I4"]} | {board["J4"]}\t\t\t  4| {board2["A4"]} | {board2["B4"]} | {board2["C4"]} | {board2["D4"]} | {board2["E4"]} | {board2["F4"]} | {board2["G4"]} | {board2["H4"]} | {board2["I4"]} | {board2["J4"]}");
            Console.WriteLine("  -----------------------------------------\t\t\t   -----------------------------------------");
            Console.WriteLine($" 5| {board["A5"]} | {board["B5"]} | {board["C5"]} | {board["D5"]} | {board["E5"]} | {board["F5"]} | {board["G5"]} | {board["H5"]} | {board["I5"]} | {board["J5"]}\t\t\t  5| {board2["A5"]} | {board2["B5"]} | {board2["C5"]} | {board2["D5"]} | {board2["E5"]} | {board2["F5"]} | {board2["G5"]} | {board2["H5"]} | {board2["I5"]} | {board2["J5"]}");
            Console.WriteLine("  -----------------------------------------\t\t\t   -----------------------------------------");
            Console.WriteLine($" 6| {board["A6"]} | {board["B6"]} | {board["C6"]} | {board["D6"]} | {board["E6"]} | {board["F6"]} | {board["G6"]} | {board["H6"]} | {board["I6"]} | {board["J6"]}\t\t\t  6| {board2["A6"]} | {board2["B6"]} | {board2["C6"]} | {board2["D6"]} | {board2["E6"]} | {board2["F6"]} | {board2["G6"]} | {board2["H6"]} | {board2["I6"]} | {board2["J6"]}");
            Console.WriteLine("  -----------------------------------------\t\t\t   -----------------------------------------");
            Console.WriteLine($" 7| {board["A7"]} | {board["B7"]} | {board["C7"]} | {board["D7"]} | {board["E7"]} | {board["F7"]} | {board["G7"]} | {board["H7"]} | {board["I7"]} | {board["J7"]}\t\t\t  7| {board2["A7"]} | {board2["B7"]} | {board2["C7"]} | {board2["D7"]} | {board2["E7"]} | {board2["F7"]} | {board2["G7"]} | {board2["H7"]} | {board2["I7"]} | {board2["J7"]}");
            Console.WriteLine("  -----------------------------------------\t\t\t   -----------------------------------------");
            Console.WriteLine($" 8| {board["A8"]} | {board["B8"]} | {board["C8"]} | {board["D8"]} | {board["E8"]} | {board["F8"]} | {board["G8"]} | {board["H8"]} | {board["I8"]} | {board["J8"]}\t\t\t  8| {board2["A8"]} | {board2["B8"]} | {board2["C8"]} | {board2["D8"]} | {board2["E8"]} | {board2["F8"]} | {board2["G8"]} | {board2["H8"]} | {board2["I8"]} | {board2["J8"]}");
            Console.WriteLine("  -----------------------------------------\t\t\t   -----------------------------------------");
            Console.WriteLine($" 9| {board["A9"]} | {board["B9"]} | {board["C9"]} | {board["D9"]} | {board["E9"]} | {board["F9"]} | {board["G9"]} | {board["H9"]} | {board["I9"]} | {board["J9"]}\t\t\t  9| {board2["A9"]} | {board2["B9"]} | {board2["C9"]} | {board2["D9"]} | {board2["E9"]} | {board2["F9"]} | {board2["G9"]} | {board2["H9"]} | {board2["I9"]} | {board2["J9"]}");
            Console.WriteLine("  -----------------------------------------\t\t\t   -----------------------------------------");
            Console.WriteLine($"10| {board["A10"]} | {board["B10"]} | {board["C10"]} | {board["D10"]} | {board["E10"]} | {board["F10"]} | {board["G10"]} | {board["H10"]} | {board["I10"]} | {board["J10"]}\t\t\t 10| {board2["A10"]} | {board2["B10"]} | {board2["C10"]} | {board2["D10"]} | {board2["E10"]} | {board2["F10"]} | {board2["G10"]} | {board2["H10"]} | {board2["I10"]} | {board2["J10"]}");
            Console.WriteLine("  -----------------------------------------\t\t\t   -----------------------------------------");
            Console.WriteLine($"Ruch gracza: {currentPlayerMove} ");
        }
    }
}
