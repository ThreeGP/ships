using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ships
{
    public class Menu
    {
        public void ShowMenu()
        {
            Console.WriteLine("====================");
            Console.WriteLine("       Statki       ");
            Console.WriteLine("====================");
            Console.WriteLine(" [1] Gra z graczem  ");
            Console.WriteLine(" [2] Gra z botem  ");
            Console.WriteLine(" [3] Resetuj punkty  ");
            Console.WriteLine(" [4] wyjdz  ");
            Console.WriteLine("====================");
            Console.Write("Podaj opcje: ");
        }
    }
}
