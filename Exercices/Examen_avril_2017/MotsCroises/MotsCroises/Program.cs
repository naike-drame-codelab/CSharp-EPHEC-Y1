using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotsCroises
{
    class Program
    {
        static char[,] ConstruireGrilleDeTest()
        // Renvoie une grille de test de mots croisés, de taille 10*10, contenant des cases noircies pré-calculées.
        {
            char[,] Grille = new char[10, 10];

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Grille[i, j] = '.';
                }
            }
            Grille[2, 2] = '*';
            Grille[2, 8] = '*';
            Grille[3, 1] = '*';
            Grille[3, 9] = '*';
            Grille[4, 5] = '*';
            Grille[5, 3] = '*';
            Grille[6, 2] = '*';
            Grille[6, 8] = '*';
            Grille[7, 4] = '*';
            Grille[8, 2] = '*';
            Grille[8, 7] = '*';
            Grille[9, 5] = '*';

            Grille[0, 5] = 'T';
            Grille[1, 5] = 'A';
            Grille[2, 5] = 'I';
            Grille[3, 5] = 'T';
            return Grille;
        }

        // Q4. Ecrivez une fonction AfficherGrille() qui reçoit un tableau de 10x10 char correspondant à une grille(dont certaines cases peuvent être déjà remplies) et
        // affiche cette grille à la console.Vous pouvez supposer(ici et pour toutes les questions qui suivent)
        // que le tableau reçu est bien formé(pas besoin de vérifier si la Taille et le contenu sont corrects).
        //Vous pouvez afficher les cases noircies avec le caractère ‘*’.
        static void AfficherGrille(char[,] Grille)
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Console.Write(Grille[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        /*
        Question 5. Écrivez une fonction CoordonneesValides() qui reçoit 3 paramètres (un numéro de ligne, un numéro de colonne, une lettre indiquant le sens horizontal ou vertical) 
        et renvoie une information indiquant si ces coordonnées sont valides.
        Des coordonnées sont valides si les numéros de ligne et de colonne, ainsi que le sens, sont des valeurs autorisées 
        (il n'est pas demandé de vérifier ce qui se trouve à cet endroit de la grille).
        Rappel : La grille fait 10x10 et le sens est soit 'h' soit 'v'.
         */
        static bool CoordonneesValides(int ligne, int colonne, char sens)
        {
            //if (ligne < 0 || ligne >= 10)
            //{
            //    return false;
            //}
            //if (colonne < 0 || colonne >= 10)
            //{
            //    return false;
            //}
            //if (sens != 'h' && sens != 'v')
            //{
            //    return false;
            //}
            //return true;

            return (ligne >= 0 && ligne < 10) &&
                      (colonne >= 0 && colonne < 10) &&
                      (sens == 'h' || sens == 'v');

        }

        /*
        Question 6. Écrivez une fonction LireCoordonnees() qui demande à l'utilisateur d'entrer au clavier 3 coordonnées :
        * Un numéro de ligne,
        * Un numéro de colonne,
        * Une lettre 'h' ou 'v' indiquant le sens horizontal ou vertical.  Si les éléments entrés sont valides, la fonction renvoie ces éléments sous la forme de deux entiers et un char, transmis en paramètres out. Sinon, la fonction demande à nouveau à l'utilisateur d'entrer 3 coordonnées, et ainsi de suite jusqu'à obtenir des valeurs valides.  Pour simplifier :
        * Il n'est pas nécessaire d'indiquer à l'utilisateur quels éléments sont invalides : si un élément est incorrect, il doit tout réentrer.
        * Vous pouvez supposer que l'utilisateur entrera des données du bon type (il entrera bien un entier avec int.Parse(Console.ReadLine()), pas besoin de gérer le cas où il tape du texte à la place d'un chiffre).  
        */

        static void LireCoordonnees(out int ligne, out int colonne, out char sens)
        {
            do
            {
                Console.Write("Veuillez entrer un n° de ligne : ");
                ligne = int.Parse(Console.ReadLine());
                Console.Write("Veuillez entrer un n° de colonne : ");
                colonne = int.Parse(Console.ReadLine());
                Console.Write("Veuillez entrer un sens ('h' ou 'v') : ");
                sens = char.Parse(Console.ReadLine());

            } while (!CoordonneesValides(ligne, colonne, sens));
        }


        /*
         Question 7. Écrivez une fonction LettrePossible() qui :
        * Reçoit 4 paramètres : une grille, un numéro de ligne, un numéro de colonne et un char contenant une lettre majuscule.
        * Renvoie une information indiquant si la lettre reçue est autorisée à cet endroit.  La lettre est autorisée si la position est bien à l'intérieur de la grille ET qu'une de ces conditions est vérifiée:
        1. La position correspondante dans la grille n'est pas encore remplie (Rappel de la page 4 : une case vide contient un point '.').
        2. La position contient déjà une lettre, mais identique à celle passée en paramètre.  Remarques :
        * La fonction teste si l'opération est possible, mais ne modifie pas la grille.
        * Pour simplifier, vous pouvez supposer que la lettre reçue est bien une majuscule entre A et Z.
        */

        static bool LettrePossible(char[,] grille, int ligne, int colonne, char lettre)
        {
            if (ligne < 0 || ligne >= 10 || colonne < 0 || colonne >= 10)
            {
                return false;
            }
            char caseGrille = grille[ligne, colonne];
            return caseGrille == '.' || caseGrille == lettre;
        }

        /*
         Question 8. Écrivez une fonction EcrireLettre() qui :
        * Reçoit 4 paramètres : une grille, un numéro de ligne, un numéro de colonne et un char contenant une lettre majuscule.
        * Si l'opération est autorisée, écrit la lettre reçue à cet endroit dans la grille. Sinon, rien n'est modifié.
        * Renvoie une information indiquant si la lettre a bien été écrite (true ou false).  
        * Remarque : Tu peux évidemment réutiliser la fonction LettrePossible que tu viens d'écrire pour savoir si l'opération est autorisée.  
         */

        static bool EcrireLettre(char[,] grille, int ligne, int colonne, char lettre)
        {
            if (LettrePossible(grille, ligne, colonne, lettre))
            {
                grille[ligne, colonne] = lettre;
                return true;
            }
            return false;
        }

        /*
         Question 9. Écrivez une fonction MotPossible() qui :
        * Reçoit 5 paramètres : une grille, des coordonnées (un numéro de ligne, un numéro de colonne et un char indiquant une direction 'h' ou 'v') 
        * et une chaîne de caractères (string) correspondant à un mot à écrire dans la grille.
        * Renvoie une information indiquant si le mot reçu peut être écrit à cet endroit. 
        * C'est-à-dire si chacune des lettres du mot peut être écrite à l'emplacement où elle devrait être placée (position encore libre '.', ou contenant déjà la même lettre).  
        * Remarques importantes :
        * La fonction teste si l'opération est possible, mais ne doit pas modifier la grille.  
        * Tu peux utiliser la fonction LettrePossible pour tester chaque lettre une par une.
        * Pour savoir combien de fois ta boucle doit tourner, pense à utiliser la propriété .Length sur ta chaîne de caractères (le mot).
        * Axe de déplacement : Si le sens vaut 'h', tu avances de case en case horizontalement (la colonne augmente : colonne + i). 
        * Si le sens vaut 'v', tu avances verticalement (la ligne augmente : ligne + i).
         */

        static bool MotPossible(char[,] grille, int ligne, int colonne, char sens, string mot)
        {
            int deplacementLigne = 0;
            int deplacementColonne = 0;

            if (sens == 'v')
            {
                deplacementLigne = 1;
            }
            else
            {
                deplacementColonne = 1;
            }

            for (int i = 0; i < mot.Length; i++)
            {
                int l = ligne + (i * deplacementLigne);
                int c = colonne + (i * deplacementColonne);

                if (!LettrePossible(grille, l, c, mot[i]))
                {
                    return false;
                }
            }
            return true;
        }


        /*
         Question 10. Écrivez une fonction EcrireMot() qui  :
        * Reçoit 5 paramètres : une grille, des coordonnées (un numéro de ligne, un numéro de colonne et un char indiquant une direction) et une chaîne de caractères correspondant à un mot à écrire dans la grille.  Si l'opération est autorisée, écrit le mot reçu à cet endroit dans la grille. Sinon, rien n'est modifié.
        * Renvoie une information indiquant si le mot a été écrit (true ou false).  Remarques :
        * Vous pouvez supposer que le mot reçu a le bon format (lettres majuscules).
         */

        static bool EcrireMot(char[,] grille, int ligne, int colonne, char sens, string mot)
        {
            if (MotPossible(grille, ligne, colonne, sens, mot))
            {
                int deplacementLigne = 0;
                int deplacementColonne = 0;
                if (sens == 'v')
                {
                    deplacementLigne = 1;
                }
                else
                {
                    deplacementColonne = 1;
                }
                for (int i = 0; i < mot.Length; i++)
                {
                    int l = ligne + (i * deplacementLigne);
                    int c = colonne + (i * deplacementColonne);
                    grille[l, c] = mot[i];
                }
                return true;
            }
            return false;
        }

        /*
         Question 11. Écrivez une fonction ListeMotsPossibles() qui : 
        * Reçoit 5 paramètres : une grille, des coordonnées (un numéro de ligne, un numéro de colonne et un char indiquant une direction) et une liste de chaînes de caractères (List<string>) correspondant à des mots à tester.
        * Renvoie, sans modifier la liste initiale, la sous-liste (List<string>) des mots qui pourraient être écrits à cet endroit.  
        * Exemple : Avec la grille d'examen, si la fonction reçoit les coordonnées (3, 2, 'h') 
        * et la liste contenant "CHEVAL", "NUIT", "TRAVAILLEUR", "NUITEE", elle doit renvoyer une nouvelle liste contenant uniquement "NUIT", "NUITEE". 
         */

        static List<string> ListeMotsPossibles(char[,] grille, int ligne, int colonne, char sens, List<string> mots) { 
            List<string> resultat = new List<string>();

            foreach (string mot in mots)
            {
                if (MotPossible(grille, ligne, colonne, sens, mot))
                {
                    resultat.Add(mot);
                }
            }

            return resultat;
        }

        /*=====================================================================================
         MAIN
        =====================================================================================*/

        static void Main(string[] args)
        {
            // 1. Charger la grille de test
            char[,] grille = ConstruireGrilleDeTest();

            // 2. Vérifier si l'on peut écrire un 'A' en position (1, 5) et afficher le résultat
            Console.WriteLine("'A' en (1, 5) possible ? " + LettrePossible(grille, 1, 5, 'A'));

            // 3. Vérifier si l'on peut écrire un 'E' en position (0, 5) et afficher le résultat
            Console.WriteLine("'E' en (0, 5) possible ? " + LettrePossible(grille, 0, 5, 'E'));

            // 4. Vérifier si l'on peut écrire un 'E' en position (11, 35) et afficher le résultat
            Console.WriteLine("'E' en (11, 35) possible ? " + LettrePossible(grille, 11, 35, 'E'));

            // 5. Écrire un 'A' en position (0, 0)
            EcrireLettre(grille, 0, 0, 'A');

            // 6. Demander à l'utilisateur d'entrer 3 coordonnées valides
            int l, c;
            char s;
            LireCoordonnees(out l, out c, out s); // (Entrez 0, 3, et v au clavier pour tester)

            // 7. Vérifier si l'on peut écrire le mot "EGOUT" aux coordonnées entrées
            bool egoutPossible = MotPossible(grille, l, c, s, "EGOUT");
            Console.WriteLine("Mot 'EGOUT' possible à ces coordonnées ? " + egoutPossible);

            // 8. Écrire effectivement ce mot à cet endroit si c'est possible
            if (egoutPossible)
            {
                EcrireMot(grille, l, c, s, "EGOUT");
            }

            // 9. Tenter d'écrire le mot "DISTRIBUTEUR" en (0, 5, 'v')
            EcrireMot(grille, 0, 5, 'v', "DISTRIBUTEUR");

            // 10. Tester quels mots de la liste peuvent être écrits en (3, 2, 'h') et afficher la liste
            List<string> listeMots = new List<string> { "CHEVAL", "NUIT", "TRAVAILLEUR", "NUITEE" };
            List<string> motsValides = ListeMotsPossibles(grille, 3, 2, 'h', listeMots);

            Console.WriteLine("Mots de la liste possibles en (3, 2, 'h') :");
            foreach (string mot in motsValides)
            {
                Console.WriteLine("- " + mot);
            }

            // 11. Afficher la grille finale
            Console.WriteLine("\n --- AFFICHAGE DE LA GRILLE FINALE ---");
            AfficherGrille(grille);
        }
    }
}