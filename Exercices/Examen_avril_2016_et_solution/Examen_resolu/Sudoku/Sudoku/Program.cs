using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    class Program
    {
        static int[,] ChargerGrille(int Nb)
        // Charge la grille précalculée n° Nb (où Nb est un nombre entre 1 et 20) et renvoie cette grille sous la forme d'un tableau de 9*9 entiers
        {
            string FileName = @"..\..\..\Grilles\Grille";
            if (Nb < 10) FileName += "0";
            FileName += Nb;
            int[,] Tab = new int[9, 9];

            try
            {
                using (StreamReader sr = new StreamReader(FileName))
                {
                    string line = sr.ReadLine();
                    string[] TabString = line.Split(' ');

                    for (int i = 0; i < 9; i++)
                        for (int j = 0; j < 9; j++)
                            Tab[i, j] = int.Parse(TabString[i * 9 + j]);
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

        // Q5 - Ecrivez une fonction ChiffreValide() qui reçoit un entier et renvoie une information indiquant si cet entier est compris entre 1 et 9. 
        static bool ChiffreValide(int i)
        {
            if ((i >= 1) && (i <= 9)) return true;
            else return false;
        }
        
        // Q6 - Ecrivez une fonction Afficher() qui reçoit un tableau de 9x9 entiers correspondant à une grille de sudoku et l’affiche à l’écran.
        // Il n’est pas nécessaire d’afficher les traits Verticaux et horizontaux, ni de traiter des cas particuliers tels qu’une grille incomplète ou de taille incorrecte.
        static void Afficher(int[,] Tab)
        {
            for (int i=0;i<9;i++)
            {
                for (int j = 0; j < 9; j++)
                    Console.Write(Tab[i, j] + " ");
                Console.WriteLine();
            }
        }
        
        // Q7 - Ecrivez une fonction TraduireCoordonnees() qui reçoit un numéro de bloc et renvoie, en paramètres out, le numéro de ligne et de colonne du coin supérieur gauche de ce bloc.
        // Par exemple, si la fonction reçoit le numéro de bloc 5, elle doit donner en réponse les coordonnées 3, 6 ; pour le bloc numéro 6, elle doit donner 6, 0. 
        static void TraduireCoordonnees(int Bloc, out int i, out int j)
        {
            i = Bloc / 3;
            i = i * 3;
            j = Bloc % 3;
            j = j * 3;
        }

        // Q8 - Ecrivez une fonction LigneVersListe() qui reçoit un tableau de 9x9 entiers et un numéro de ligne et renvoie tous les éléments de cette ligne sous la forme d’une liste.
        static List<int> LigneVersListe(int[,] G, int ligne)
        {
            List<int> L = new List<int>();

            for (int j = 0; j < 9; j++)
                L.Add(G[ligne, j]);
            return L;
        }

        // Q9 - Ecrivez une fonction ColonneVersListe() qui reçoit un tableau de 9x9 entiers et un numéro de colonne et renvoie tous les éléments de cette colonne sous la forme d’une liste.
        static List<int> ColonneVersListe(int[,] G, int colonne)
        {
            List<int> L = new List<int>();

            for (int i = 0; i < 9; i++)
                L.Add(G[i, colonne]);
            return L;
        }

        // Q10 - Ecrivez une fonction BlocVersListe() qui reçoit un tableau de 9x9 entiers et un numéro de bloc et renvoie tous les éléments de ce bloc sous la forme d’une liste.
        // Vous pouvez bien évidemment réutiliser l’une des fonctions que vous venez d’écrire pour effectuer ce traitement.
        static List<int> BlocVersListe(int [,] G, int bloc)
        {
            List<int> L = new List<int>();
            int x, y;
            TraduireCoordonnees(bloc, out x, out y);
            for (int i = x; i < x + 3; i++)
                for (int j = y; j < y + 3; j++)
                    L.Add(G[i, j]);
            return L;
        }

        //   Q 11 - Ecrivez une fonction BlocVersListe() qui reçoit un tableau de 9x9 entiers et un
        //numéro de bloc et renvoie tous les éléments de ce bloc sous la forme d’une liste.
        //Vous pouvez bien évidemment réutiliser l’une des fonctions que vous venez d’écrire
        //pour effectuer ce traitement.
        static bool EstDansListe(List<int> L, int v)
        {
            for (int i = 0; i < 9; i++)
                if (L[i] == v) return true;
            return false;
        }

        // Q12 - Ecrivez une fonction ListeCorrecte() qui reçoit une liste de 9 entiers et renvoie une
        // valeur indiquant si cette liste contient bien tous les entiers de 1 à 9, chacun
        // apparaissant exactement une fois.Il n’est pas nécessaire de traiter les cas
        // particuliers tels qu’une liste trop longue ou trop courte.En revanche, la liste pourrait
        // contenir des chiffres non valides(0, par exemple). 
        // Astuce : si la liste contient 9 éléments et que chaque chiffre apparaît au moins une
        // fois, est-il nécessaire de vérifier que certains chiffres n’apparaissent pas en double?
        static bool ListeCorrecte(List<int> L)
        {
            for (int i = 1; i <= 9; i++)
            {
                if (!ChiffreValide(L[i - 1])) return false;
                if (!EstDansListe(L, i)) return false;
            }
            return true;
        }

        // Q13 - Ecrivez une fonction VerifierGrille() qui reçoit un tableau d’entiers correspondant à
        // une grille de sudoku et renvoie une information indiquant si la grille est correctement
        // remplie.Cette fonction peut bien évidemment utiliser les fonctions ci-dessus.
        static bool VerifierGrille(int[,] G)
        {
            List<int> L;
            for (int i=0;i<9;i++)
            {
                L = LigneVersListe(G, i);
                if (!ListeCorrecte(L)) return false;
                L = ColonneVersListe(G, i);
                if (!ListeCorrecte(L)) return false;
                L = BlocVersListe(G, i);
                if (!ListeCorrecte(L)) return false;
            }
            return true;
        }
        static void Main(string[] args)
        {
            // Exemple
            int[,] Grille = ChargerGrille(3);

            Afficher(Grille);

/*            int x, y;
            int b;
            b = 0;
            TraduireCoordonnees(b, out x, out y);
            Console.WriteLine(b + "--> " + x + " " + y);
            b = 2;
            TraduireCoordonnees(b, out x, out y);
            Console.WriteLine(b + "--> " + x + " " + y);
            b = 5;
            TraduireCoordonnees(b, out x, out y);
            Console.WriteLine(b + "--> " + x + " " + y);
            b = 7;
            TraduireCoordonnees(b, out x, out y);
            Console.WriteLine(b + "--> " + x + " " + y);
            b = 8;
            TraduireCoordonnees(b, out x, out y);
            Console.WriteLine(b + "--> " + x + " " + y); */

            List<int> L = BlocVersListe(Grille, 8);
            for (int i = 0; i < L.Count(); i++) Console.Write(L[i] + ",");
            Console.WriteLine();


            for (int i=1;i<=20;i++)
            {
                Grille =ChargerGrille(i);
                Console.WriteLine("Grille " + i + ": " + VerifierGrille(Grille));
            }
        }
    }
}
