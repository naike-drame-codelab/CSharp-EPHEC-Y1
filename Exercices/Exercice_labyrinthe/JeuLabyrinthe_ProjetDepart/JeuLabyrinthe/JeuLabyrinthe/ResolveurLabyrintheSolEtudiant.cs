using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuLabyrinthe
{
    class ResolveurLabyrintheSolEtudiant : ResolveurLabyrinthe
    {
        public override Trajet Resoudre(Labyrinthe Laby)
        {
            List<char> Parcours = VotreSolutionIci.Resoudre(Laby);
            Voyageur Voy = new Voyageur(Laby);

            foreach (char D in Parcours)
            {
                Voy.DeplacerImprudemment(D);
            }            
            return Voy.GetTrajet();
        }
    }
}
