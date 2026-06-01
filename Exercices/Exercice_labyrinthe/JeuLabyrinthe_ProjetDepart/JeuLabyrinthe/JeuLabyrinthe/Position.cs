using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuLabyrinthe
{
    class Position
    {
        public int PosH { get; set; }
        public int PosV { get; set; }
        public Position(int PosH,int PosV)
        {
            this.PosH = PosH;
            this.PosV = PosV;
        }
        public Position(Position P)
        {
            PosH = P.PosH;
            PosV = P.PosV;
        }
        public Position Haut()
        {
            Position P = new Position(this);
            P.PosV--;
            return P;
        }
        public Position Bas()
        {
            Position P = new Position(this);
            P.PosV++;
            return P;
        }
        public Position Gauche()
        {
            Position P = new Position(this);
            P.PosH--;
            return P;
        }
        public Position Droite()
        {
            Position P = new Position(this);
            P.PosH++;
            return P;
        }
        public override bool Equals(object obj)
        {
            Position Posi = obj as Position;
            if (Posi == null) return false;
            else return ((this.PosH == Posi.PosH) && (this.PosV == Posi.PosV));
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public static bool operator ==(Position P1, Position P2)
        {
            return ((P1.PosH == P2.PosH) && (P1.PosV == P2.PosV));
        }
        public static bool operator !=(Position P1, Position P2)
        {
            return !((P1.PosH == P2.PosH) && (P1.PosV == P2.PosV));
        }
    }
}
