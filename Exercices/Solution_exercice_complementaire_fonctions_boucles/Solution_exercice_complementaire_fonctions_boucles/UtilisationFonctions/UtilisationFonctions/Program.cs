using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilisationFonctions
{
    /// <summary>
    /// Exercices sur l'utilisation de fonctions
    /// </summary>
    class Program
    {
        /// <summary>
        /// Dessine une ligne horizontale en répétant un symbole
        /// </summary>
        /// <param name="PosH">Coordonnée horizontale du début de la ligne, comptée à partir de la marge gauche en démarrant à 0</param>
        /// <param name="PosV">Coordonnée verticale du début de la ligne, comptée à partir de la marge supérieure en démarrant à 0</param>
        /// <param name="Longueur">Longueur de la ligne</param>
        /// <param name="Symbole">Symbole à répéter</param>
        static void DessinerLigneHorizontale(int PosH, int PosV, int Longueur, char Symbole)
        {
            Console.SetCursorPosition(PosH, PosV);
            for (int i = 0; i < Longueur; i++)
            {
                Console.Write(Symbole);
            }
        }
        /// <summary>
        /// Dessine une ligne verticale en répétant un symbole
        /// </summary>
        /// <param name="PosH">Coordonnée horizontale du début de la ligne, comptée à partir de la marge gauche en démarrant à 0</param>
        /// <param name="PosV">Coordonnée verticale du début de la ligne, comptée à partir de la marge supérieure en démarrant à 0</param>
        /// <param name="Longueur">Longueur de la ligne</param>
        /// <param name="Symbole">Symbole à répéter</param>
        static void DessinerLigneVerticale(int PosH, int PosV, int Longueur, char Symbole)
        {
            for (int i = 0; i < Longueur; i++)
            {
                Console.SetCursorPosition(PosH, PosV + i);
                Console.Write(Symbole);
            }
        }
        /// <summary>
        /// Renvoie la distance entre deux valeurs
        /// </summary>
        /// <param name="Debut">Plus petite valeur</param>
        /// <param name="Fin">Plus grande valeur</param>
        /// <returns>Distance entre les 2</returns>
        static int Distance(int Debut, int Fin)
        {
            return Fin - Debut + 1;
        }
        /// <summary>
        /// Dessine un cadre en répétant un symbole
        /// </summary>
        /// <param name="BordGauche">Coordonnée horizontale du début du cadre, comptée à partir de la marge gauche en démarrant à 0</param>
        /// <param name="BordHaut">Coordonnée verticale du début du cadre, comptée à partir de la marge supérieure en démarrant à 0</param>
        /// <param name="BordDroit">Coordonnée horizontale de la fin du cadre, comptée à partir de la marge gauche en démarrant à 0</param>
        /// <param name="BordBas">Coordonnée verticale de la fin du cadre, comptée à partir de la marge supérieure en démarrant à 0</param>
        /// <param name="Symbole">Symbole à répéter</param>
        static void DessinerCadre(int BordGauche, int BordHaut, int BordDroit, int BordBas, char Symbole)
        {
            int Hauteur, Largeur;
            Largeur = Distance(BordGauche, BordDroit);
            Hauteur = Distance(BordHaut, BordBas);
            DessinerLigneHorizontale(BordGauche, BordHaut, Largeur, Symbole);
            DessinerLigneHorizontale(BordGauche, BordBas, Largeur, Symbole);
            DessinerLigneVerticale(BordGauche, BordHaut, Hauteur, Symbole);
            DessinerLigneVerticale(BordDroit, BordHaut, Hauteur, Symbole);
        }
        /// <summary>
        /// Renvoie la valeur située à mi-chemin entre les 2, arrondie vers le bas si nécessaire
        /// </summary>
        /// <param name="Debut">Plus petite valeur</param>
        /// <param name="Fin">Plus grande valeur</param>
        /// <returns>Milieu entre les 2</returns>
        static int Milieu (int Debut, int Fin)
        {
            return Debut + (Fin - Debut) / 2;
        }
        /// <summary>
        /// Ecrit un texte centré horizontalement dans un cadre fixé
        /// </summary>
        /// <param name="BordGaucheCadre">Coordonnée horizontale du début du cadre</param>
        /// <param name="BordDroitCadre">Coordonnée horizontale de la fin du cadre</param>
        /// <param name="PosV">Coordonnée verticale où écrire le texte</param>
        /// <param name="Texte">Texte à écrire</param>
        static void EcrireCentre(int BordGaucheCadre, int BordDroitCadre, int PosV, string Texte)
        {
            int PosH = Milieu(BordGaucheCadre, BordDroitCadre) - Texte.Length / 2;
            Console.SetCursorPosition(PosH, PosV);
            Console.Write(Texte);
        }
        static void Main(string[] args)
        {
            DessinerCadre(5, 5, 85, 25, '*');
            DessinerCadre(10, 8, 80, 22, 'o');
            EcrireCentre(10, 80, 13, "avec");
            EcrireCentre(10, 80, 14, "un texte");
            EcrireCentre(10, 80, 15, "aligné");
            EcrireCentre(10, 80, 16, "au centre du cadre");

            Console.SetCursorPosition(1, 26);
        }
    }
}
