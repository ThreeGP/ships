using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace statki
{
    public class Ships
    {
        public bool IsPositionValid(Dictionary<string, string> board, string position)
        {
            const string ALPHABET = "ABCDEFGHIJ";

            if (board[position] == "o")
                return false;

            int row = ALPHABET.IndexOf(position[0]);
            int col = int.Parse(position.Substring(1)) - 1;

            for (int r = row - 1; r <= row + 1; r++)
            {
                for (int c = col - 1; c <= col + 1; c++)
                {
                    if (r >= 0 && r < 10 && c >= 0 && c < 10)
                    {
                        if (r == row && c == col)
                            continue;

                        if (board[ALPHABET[r] + "" + (c + 1)] == "o")
                            return false;
                    }
                }
            }
            return true;
        }
    }
}
