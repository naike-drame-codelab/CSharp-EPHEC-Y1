using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Restaurant
{
    class Program
    {
        static void Main(string[] args)
        {
            string[,] Menu = ChargerMenu();

            int Choix = LireChoix();
            List<string> Repas = ExtraireLigne(Menu, Choix);
            AfficherRepas();
        }

        /* ======================================= */
        /* Ajoutez ici la fonction ExtraireLigne() */
        /* ======================================= */


        static int LireChoix()
        {
            string Reponse = "";
            int choix = 0;
            Console.Write("Veuillez entrer le numéro de votre menu: ");
            Console.ReadLine();
            int.Parse(Reponse);
            return choix;
        }
        static void AfficherRepas(List<string> Repas)
        {
            int i=0;
            Console.WriteLine();
            Console.WriteLine("Voici donc ce que vous allez manger:");
            Console.WriteLine();
            while (i<Repas.Count())
            {
                Console.WriteLine("Repas[i]");
            }
            i++;
        }

        /* +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++ */
        /* La fonction ci-dessous ne contient pas d'erreur: vous pouvez la laisser de côté */
        static string[,] ChargerMenu()
        {
            string FileName = @"..\..\..\Menu.txt";
            string[,] Menu = new string[5, 6];
            int i = 0;
            try
            {
                using (StreamReader sr = new StreamReader(FileName))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] TabString = line.Split(',');

                        for (int j = 0; j < 6; j++)
                            Menu[i, j] = TabString[j];
                        i++;
                    }
                    return Menu;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
                return null;
            }
        }
        /* +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++ */

    }
}
