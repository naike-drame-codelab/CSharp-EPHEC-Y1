using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuLabyrinthe
{
    class Voyageur
    {
        private Labyrinthe Laby;
        public Position Pos { get; }
        private Direction TourneVers;
        private Trajet Montrajet;

        public Voyageur(Labyrinthe Laby)
        {
            this.Laby = Laby;
            this.Pos = new Position(Laby.PosDepart);
            this.TourneVers = Direction.Haut;
            this.Montrajet = new Trajet();
        }
        public Direction GetTourneVers()
        {
            return TourneVers;
        }
        public Trajet GetTrajet()
        {
            return Montrajet;
        }
        public bool PeutBouger(Direction Dir)
        {
            Cell Localisation = Laby.GetCell(Pos);
            if (Dir == Direction.Haut)
                return !Localisation.MurHaut;
            else if (Dir == Direction.Bas)
                return !Localisation.MurBas;
            else if (Dir == Direction.Gauche)
                return !Localisation.MurGauche;
            else if (Dir == Direction.Droite)
                return !Localisation.MurDroit;
            else return false;
        }
        /// <summary>
        /// Déplace le voyageur selon la direction reçue, sans vérifier si c'est possible 
        /// (afin de faciliter le debugging)
        /// </summary>
        /// <param name="Dir">Direction que doit prendre le voyageur ('H','B','G' ou 'D')</param>
        /// <remarks>Si Dir n'a pas l'une des valeurs 'H', 'B', 'G' ou 'D', le déplacement se fait par défaut vers le haut.</remarks>
        public void DeplacerImprudemment(char Dir)
        {
            Direction D = Direction.Create(Dir);
            if (D == null) D = Direction.Haut;
            DeplacerImprudemment(D);
        }
        public void DeplacerImprudemment(Direction Dir)
        {
            if (Dir == Direction.Haut) this.Pos.PosV--;
            else if (Dir == Direction.Bas) this.Pos.PosV++;
            else if (Dir == Direction.Gauche) this.Pos.PosH--;
            else this.Pos.PosH++;
            this.TourneVers = Dir;
            this.Montrajet.AjouterEtape(Dir);
        }

        /// <summary>
        /// Si c'est possible, déplace le voyageur selon la direction reçue, sinon, ne fait rien
        /// </summary>
        /// <param name="Dir">Direction que doit prendre le voyageur ('H','B','G' ou 'D')</param>
        /// <remarks>Si Dir n'a pas l'une des valeurs 'H', 'B', 'G' ou 'D', le déplacement se fait par défaut vers le haut.</remarks>
        /// <returns>true si le déplacement a pu être effectué, false sinon</returns>
        public bool DeplacerPrudemment(char Dir)
        {
            Direction D = Direction.Create(Dir);
            if (D == null) D = Direction.Haut;
            return DeplacerPrudemment(D);
        }
        public bool DeplacerPrudemment(Direction Dir)
        {
            if (!PeutBouger(Dir)) return false;
            else
            {
                DeplacerImprudemment(Dir);
                return true;
            }
        }
        public bool EstArrive()
        {
            return (this.Pos == Laby.PosArrivee);
        }
    }
}
