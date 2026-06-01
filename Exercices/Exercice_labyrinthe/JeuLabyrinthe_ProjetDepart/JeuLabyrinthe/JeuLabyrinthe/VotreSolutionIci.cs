using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuLabyrinthe
{
    static class VotreSolutionIci
    {
        public static List<char> Resoudre(Labyrinthe Laby)
        {
            // Les lignes ci-dessous sont là pour vous aider à prendre l'interface en main:
            // elles ne correspondent pas forcément à la bonne solution
            List<char> Parcours = new List<char>();
            int PosH, PosV;
            // Récupération de la position de départ
            Laby.PositionEntree(out PosH, out PosV);
            // Déclaration d'une variable de "type" Cell, pouvant contenir des cases de labyrinthe
            Cell CaseCourante;
            // Initialisation de cette case au point de départ du labyrinthe
            CaseCourante = Laby.GetCell(PosH, PosV);
            // Test de la présence d'un mur à gauche: s'il n'y en a pas, faisons un pas à gauche
            if (!CaseCourante.MurGauche) Parcours.Add('G');

            // Ajout de 2 pas à gauche (sans aucun test --> risque de se cogner à un mur)
            Parcours.Add('G');
            Parcours.Add('G');

            return Parcours;
        }
        public static List<char> Simplifier(List<char> Trajet)
        {
            return Trajet;
        }
    }
}