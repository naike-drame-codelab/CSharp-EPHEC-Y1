using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuLabyrinthe
{
    abstract class ResolveurLabyrinthe
    {
        public abstract Trajet Resoudre(Labyrinthe Laby);

        protected static List<Direction> OrdrePreference(Direction T)
        // Renvoie la liste des directions à tenter pour aller le plus à droite possible, pour un voyageur orienté vers T
        {
            List<Direction> OrdreBase = new List<Direction>() { Direction.Droite, Direction.Haut, Direction.Gauche, Direction.Bas };
            List<Direction> Pref = new List<Direction>();
            int Index = OrdreBase.IndexOf(T);
            Index = (Index + 3) % OrdreBase.Count;

            int i = 0;
            while (i < OrdreBase.Count)
            {
                Pref.Add(OrdreBase[Index]);
                Index = (Index + 1) % OrdreBase.Count;
                i++;
            }
            return Pref;
        }
    }
}
