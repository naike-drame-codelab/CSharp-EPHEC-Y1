using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Labyrinthe
{
    class Program
    {


        static char LireTouche()
        {
            ConsoleKeyInfo Touche = Console.ReadKey(true);
            return Touche.KeyChar;
        }
        static int[,] ChargerLabyrinthe(int Nb)
        // Charge le labyrinthe précalculé n° Nb (où Nb est un nombre entre 1 et 5) et renvoie ce labyrinthe sous la forme d'un tableau de 9*9 entiers
        {
            string FileName = @"..\..\..\Grilles\Grille";
            if (Nb < 10) FileName += "0";
            FileName += Nb;
            int[,] Tab = new int[10,10];

            Console.CursorVisible = false;
            try
            {
                using (StreamReader sr = new StreamReader(FileName))
                {
                    for (int PosV = 0; PosV < 10; PosV++)
                    {
                        string line = sr.ReadLine();
                        for (int PosH = 0; PosH < 10; PosH++)
                        {
                            if (line[PosH] == '*')
                                Tab[PosV, PosH] = 1;
                            else Tab[PosV, PosH] = 0;
                        }
                    }
                    return Tab;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
                return null;
            }
        }


        static void Main(string[] args)
        {
        }
    }
}
