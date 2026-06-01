using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuLabyrinthe
{
    class Labyrinthe
    {
        private Cell[,] Cells;
        public int Largeur { get; set; }
        public int Hauteur { get; set; }
        private Random Rng;
        public Position PosDepart;
        public Position PosArrivee;

        public Labyrinthe(int Largeur, int Hauteur, int Seed)
        {
            Rng = new Random(Seed);
            this.Create(Largeur, Hauteur);
        }
        public Labyrinthe(int Largeur, int Hauteur)
        {
            Rng = new Random();
            this.Create(Largeur, Hauteur);
        }
        private void Create(int Largeur,int Hauteur)
        {
            this.Largeur = Largeur;
            this.Hauteur = Hauteur;
            Cells = new Cell[Largeur, Hauteur];
            for (int PosV = 0; PosV < Hauteur; PosV++)
            {
                for (int PosH = 0; PosH < Largeur; PosH++)
                {
                    Cells[PosH, PosV] = new Cell(PosH, PosV);
                }
            }
            CreerParcours();
        }

        public Cell GetCell(int PosH, int PosV)
        {
            if ((PosH < 0) || (PosH >= Largeur) || (PosV < 0) || (PosV >= Hauteur))
                return Cell.DummyCell();
            else return Cells[PosH , PosV];
        }

        public void PositionSortie(out int PosH, out int PosV)
        {
            PosH = PosArrivee.PosH;
            PosV = PosArrivee.PosV;
        }
        public void PositionEntree(out int PosH, out int PosV)
        {
            PosH = PosDepart.PosH;
            PosV = PosDepart.PosV;
        }
        public Cell GetCell(Position Pos)
        {
            return GetCell(Pos.PosH, Pos.PosV);
        }
        public void CreerParcours()
        {
            this.PosDepart = new Position(Rng.Next(this.Largeur), this.Hauteur - 1);
            this.PosArrivee = new Position(Rng.Next(this.Largeur), 0);
            GetCell(this.PosDepart).MurBas = false;
            GetCell(this.PosArrivee).MurHaut = false;
            Creuser(this.PosDepart);

        }
        public void Creuser(Position P)
        {
            GetCell(P).Visite = true;

            List<Position> V = Voisins(P);

            while(V.Count>0)
            {
                int UnVoisin = Rng.Next(V.Count);
                GetCell(P).PercerPassage(GetCell(V[UnVoisin]));
                Creuser(V[UnVoisin]);
                V = Voisins(P);
            }
        }
        public List<Position> Voisins(Position P)
        {
            List<Position> V = new List<Position>();
            Cell c;
            c = GetCell(P.Haut());
            if (!c.Visite) V.Add(P.Haut());
            c = GetCell(P.Bas());
            if (!c.Visite) V.Add(P.Bas());
            c = GetCell(P.Gauche());
            if (!c.Visite) V.Add(P.Gauche());
            c = GetCell(P.Droite());
            if (!c.Visite) V.Add(P.Droite());

            return V;
        }


    }
}