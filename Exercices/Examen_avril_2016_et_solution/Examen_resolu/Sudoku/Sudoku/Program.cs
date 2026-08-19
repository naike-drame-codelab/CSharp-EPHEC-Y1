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
            // On vérifie directement si la valeur reçue est dans les bornes du Sudoku (entre 1 et 9 inclus).
            // Si c'est le cas, on renvoie vrai,
            if ((i >= 1) && (i <= 9)) return true;
            // sinon on renvoie faux.
            else return false;
        }

        // Q6 - Ecrivez une fonction Afficher() qui reçoit un tableau de 9x9 entiers correspondant à une grille de sudoku et l’affiche à l’écran.
        // Il n’est pas nécessaire d’afficher les traits Verticaux et horizontaux, ni de traiter des cas particuliers tels qu’une grille incomplète ou de taille incorrecte.
        static void Afficher(int[,] Tab)
        {
            // La première boucle gère les lignes (de haut en bas)
            for (int i = 0; i < 9; i++)
            {
                // La deuxième boucle gère les colonnes d'une même ligne (de gauche à droite)

                for (int j = 0; j < 9; j++)
                    // Console.Write affiche la case ET un espace à côté, sans passer à la ligne
                    Console.Write(Tab[i, j] + " ");
                // Une fois la ligne de 9 chiffres terminée, on force un saut de ligne 
                // avant de passer à la ligne (i) suivante.
                Console.WriteLine();
            }
        }

        // Q7 - Ecrivez une fonction TraduireCoordonnees() qui reçoit un numéro de bloc et renvoie, en paramètres out, le numéro de ligne et de colonne du coin supérieur gauche de ce bloc.
        // Par exemple, si la fonction reçoit le numéro de bloc 5, elle doit donner en réponse les coordonnées 3, 6 ; pour le bloc numéro 6, elle doit donner 6, 0. 
        static void TraduireCoordonnees(int Bloc, out int i, out int j)
        {
            // i = la ligne de départ. 
            // La division entière par 3 regroupe les blocs par tranche horizontale.
            // Ex: Blocs 0, 1, 2 donnent 0. Blocs 3, 4, 5 donnent 1. Blocs 6, 7, 8 donnent 2.
            i = Bloc / 3;
            // On multiplie par 3 pour obtenir le VRAI index de départ dans le tableau (0, 3 ou 6).
            i = i * 3;

            // j = la colonne de départ.
            // Le modulo 3 (reste de la division) regroupe les blocs par tranche verticale.
            // Ex: Blocs 0, 3, 6 donnent 0. Blocs 1, 4, 7 donnent 1. Blocs 2, 5, 8 donnent 2.
            j = Bloc % 3;
            // On multiplie par 3 pour obtenir le VRAI index de départ (0, 3 ou 6).
            j = j * 3;
        }

        // Q8 - Ecrivez une fonction LigneVersListe() qui reçoit un tableau de 9x9 entiers et un numéro de ligne et renvoie tous les éléments de cette ligne sous la forme d’une liste.
        static List<int> LigneVersListe(int[,] G, int ligne)
        {
            // On prépare une liste vide qui va stocker nos 9 chiffres.
            List<int> L = new List<int>();

            for (int j = 0; j < 9; j++)
            {
                // La 'ligne' reste fixe (ex: G[2, 0], G[2, 1], G[2, 2]...).
                // On ajoute chaque élément lu à la fin de notre liste.
                L.Add(G[ligne, j]);
            }

            // On renvoie la liste remplie.
            return L;
        }

        // Q9 - Ecrivez une fonction ColonneVersListe() qui reçoit un tableau de 9x9 entiers et un numéro de colonne et renvoie tous les éléments de cette colonne sous la forme d’une liste.
        static List<int> ColonneVersListe(int[,] G, int colonne)
        {
            List<int> L = new List<int>();

            // On boucle uniquement sur les lignes (de 0 à 8)
            for (int i = 0; i < 9; i++)
            {
                // La 'colonne' reste fixe (ex: G[0, 4], G[1, 4], G[2, 4]...).
                // On ajoute chaque élément lu à la liste.
                L.Add(G[i, colonne]);
            }
            return L;
        }

        // Q10 - Ecrivez une fonction BlocVersListe() qui reçoit un tableau de 9x9 entiers et un numéro de bloc et renvoie tous les éléments de ce bloc sous la forme d’une liste.
        // Vous pouvez bien évidemment réutiliser l’une des fonctions que vous venez d’écrire pour effectuer ce traitement.
        static List<int> BlocVersListe(int[,] G, int bloc)
        {
            List<int> L = new List<int>();

            // x et y vont recevoir les coordonnées du coin en haut à gauche du bloc.
            int x, y;

            // On appelle la fonction pour calculer x et y en fonction du numéro du bloc.
            // Les mots-clés 'out' permettent à la fonction de modifier x et y directement.
            TraduireCoordonnees(bloc, out x, out y);

            // On fait une boucle qui commence à la ligne x, et qui fait 3 tours (x, x+1, x+2)
            for (int i = x; i < x + 3; i++)
            {
                // À chaque ligne, on fait une boucle sur les colonnes de y à y+2
                for (int j = y; j < y + 3; j++)
                {
                    // On copie la case dans la liste. On obtient 9 éléments au total.
                    L.Add(G[i, j]);
                }

            }
            return L;
        }

        //   Q 11 - Ecrivez une fonction BlocVersListe() qui reçoit un tableau de 9x9 entiers et un numéro de bloc et renvoie tous les éléments de ce bloc sous la forme d’une liste.
        // Vous pouvez bien évidemment réutiliser l’une des fonctions que vous venez d’écrire pour effectuer ce traitement.
        static bool EstDansListe(List<int> L, int v)
        {
            // On parcourt chaque case de la liste (de 0 à 8)
            for (int i = 0; i < 9; i++)
            {
                // Dès qu'on trouve la valeur 'v' qu'on cherche, on arrête tout 
                // et on renvoie 'true' (vrai, elle y est).
                if (L[i] == v) return true;
            }
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
            // On va faire un test pour chaque chiffre qui DOIT être dans un Sudoku (de 1 à 9)
            // Attention : 'i' ici représente le CHIFFRE cherché (1, 2, 3...), pas un index de tableau
            for (int i = 1; i <= 9; i++)
            {
                // Test de sécurité 1 : On vérifie que la case qu'on est en train de lire
                // contient bien un chiffre valide (pas de 0 ou de -1). 
                // On utilise [i - 1] car quand i vaut 1, on veut lire l'index 0 de la liste.
                if (!ChiffreValide(L[i - 1])) return false;
                
                // Test de validité 2 : On cherche si le chiffre 'i' (qui vaut 1, puis 2, etc.) 
                // est bien présent au moins une fois dans la liste L.
                // Si 'EstDansListe' répond faux (le ! inverse le résultat), la ligne est invalide.
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

            // On utilise une seule boucle 'i' allant de 0 à 8 pour tester les 9 lignes,
            // les 9 colonnes et les 9 blocs en un seul passage.
            for (int i = 0; i < 9; i++)
            {
                // 1. On extrait la ligne n°i et on la teste
                L = LigneVersListe(G, i);
                // Si la ligne est fausse, la grille entière est fausse. On arrête tout.
                if (!ListeCorrecte(L)) return false;

                // 2. On extrait la colonne n°i et on la teste
                L = ColonneVersListe(G, i);
                // Si la colonne est fausse, on arrête tout.
                if (!ListeCorrecte(L)) return false;

                // 3. On extrait le bloc n°i et on le teste
                L = BlocVersListe(G, i);
                // Si le bloc est faux, on arrête tout.
                if (!ListeCorrecte(L)) return false;
            }
            return true;
        }
        static void Main(string[] args)
        {
            // Exemple
            int[,] Grille = ChargerGrille(3);

            Afficher(Grille);

            /* ------ Test de la fonction TraduireCoordonnees() ----            
            int x, y;
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
            Console.WriteLine(b + "--> " + x + " " + y); 
            */

            List<int> L = BlocVersListe(Grille, 8);
            for (int i = 0; i < L.Count(); i++) Console.Write(L[i] + ",");
            Console.WriteLine();


            for (int i = 1; i <= 20; i++)
            {
                Grille = ChargerGrille(i);
                Console.WriteLine("Grille " + i + ": " + VerifierGrille(Grille));
            }
        }
    }
}
