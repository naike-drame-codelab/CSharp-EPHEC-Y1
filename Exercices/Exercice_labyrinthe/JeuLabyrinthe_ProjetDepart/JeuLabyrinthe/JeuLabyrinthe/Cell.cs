using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuLabyrinthe
{
    class Cell
    {
        public bool MurHaut { get; set; }
        public bool MurBas { get; set; }
        public bool MurGauche { get; set; }
        public bool MurDroit { get; set; }
        private int PosH { get; set; }
        private int PosV { get; set; }
        public bool Visite { get; set; }  // true si déjà visité (lors du parcours de construction du labyrinthe)
                                          // et également true si "dummy cell" (celles de la zone tampon) 
        
        public Cell(int PosH, int PosV)
        {
            MurHaut = MurBas = MurDroit = MurGauche = true;
            Visite = false;
            this.PosH = PosH;
            this.PosV = PosV;
        }
        public static Cell DummyCell()
        {
            Cell D = new Cell(-10, -10);
            D.Visite = true;
            return D;
        }
        public void PercerPassage(Cell Autre)
        {
            if ((Autre.PosH == this.PosH - 1) && (Autre.PosV == this.PosV))
            {
                this.MurGauche = false;
                Autre.MurDroit = false;
            }
            else if ((Autre.PosH == this.PosH + 1) && (Autre.PosV == this.PosV))
            {
                this.MurDroit = false;
                Autre.MurGauche = false;
            }
            else if ((Autre.PosH == this.PosH) && (Autre.PosV == this.PosV - 1))
            {
                this.MurHaut = false;
                Autre.MurBas = false;
            }
            else if ((Autre.PosH == this.PosH) && (Autre.PosV == this.PosV + 1))
            {
                this.MurBas = false;
                Autre.MurHaut = false;
            }
            else throw new Exception("On ne joue pas à Portal, là !");
        }
    }
}
