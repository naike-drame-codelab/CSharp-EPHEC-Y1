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


        static void AfficherLabyrinthe(int[,] labyrinthe)
        {
            for (int v = 0; v < 10; v++)
            {
                for (int h = 0; h < 10; h++)
                {
                    if (labyrinthe[v, h] == 1)
                    {
                        Console.Write('*');
                    }
                    else
                    {
                        Console.Write(' ');
                    }
                }
                Console.WriteLine(); // Retour à la ligne après chaque ligne du labyrinthe
            }
        }


        static bool Gagne(int posV, int posH)
        {
            return posV == 0;
        }


        static bool PositionAutorisee(int posV, int posH, int[,] labyrinthe)
        {
            // On vérifie d'abord si la position est bien dans la grille de 10x10
            if (posV >= 0 && posV < 10 && posH >= 0 && posH < 10)
            {
                // On vérifie que ce n'est pas un mur
                if (labyrinthe[posV, posH] != 1)
                {
                    return true;
                }
            }
            return false; // Position hors limites ou sur un mur
        }

        static void Deplacer(ref int posV, ref int posH, char direction, int[,] labyrinthe)
        {
            int nouvellePosV = posV;
            int nouvellePosH = posH;

            // On calcule la position visée selon la touche enfoncée
            if (direction == 'Z') // Haut
            {
                nouvellePosV = posV - 1;
            }
            else if (direction == 'S') // Bas
            {
                nouvellePosV = posV + 1;
            }
            else if (direction == 'Q') // Gauche
            {
                nouvellePosH = posH - 1;
            }
            else if (direction == 'D') // Droite
            {
                nouvellePosH = posH + 1;
            }

            // Si le déplacement est légal, on applique les nouvelles coordonnées
            if (PositionAutorisee(nouvellePosV, nouvellePosH, labyrinthe))
            {
                posV = nouvellePosV;
                posH = nouvellePosH;
            }
        }

        static void AfficherPerso(int posV, int posH)
        {
            Console.SetCursorPosition(posH, posV);
            Console.Write('O');
        }

        static void EffacerPerso(int posV, int posH)
        {
            Console.SetCursorPosition(posH, posV);
            Console.Write(' ');
        }

        static void Jeu(int numLabyrinthe)
        {
            // 1. Chargement et affichage du labyrinthe choisi
            int[,] labyrinthe = ChargerLabyrinthe(numLabyrinthe);
            Console.Clear();
            AfficherLabyrinthe(labyrinthe);

            // 2. Initialisation de la position de départ (9, 4)
            int posV = 9;
            int posH = 4;
            AfficherPerso(posV, posH);

            // 3. Boucle principale du jeu
            while (!Gagne(posV, posH))
            {
                // On attend que l'utilisateur appuie sur une touche (Z, Q, S, D)
                char touche = LireTouche();

                // Étape A : Effacer le personnage de sa position actuelle
                EffacerPerso(posV, posH);

                // Étape B : Tenter le déplacement
                Deplacer(ref posV, ref posH, touche, labyrinthe);

                // Étape C : Redessiner le personnage à sa (nouvelle) position
                AfficherPerso(posV, posH);
            }

            // 4. Fin de la partie
            Console.SetCursorPosition(0, 11); // On se place sous le labyrinthe pour écrire
            Console.WriteLine("Gagné !");
        }

        static void Main(string[] args)
        {
            Jeu(0);
        }
    }
}
