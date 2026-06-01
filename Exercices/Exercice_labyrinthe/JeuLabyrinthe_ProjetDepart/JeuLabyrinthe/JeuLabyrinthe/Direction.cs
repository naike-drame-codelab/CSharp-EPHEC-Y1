using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuLabyrinthe
{
    class Direction
    {
        public static Direction Haut = new Direction('H');
        public static Direction Bas = new Direction('B');
        public static Direction Gauche = new Direction('G');
        public static Direction Droite = new Direction('D');
        public static List<Direction> Autorisees = new List<Direction>() { Direction.Haut, Direction.Bas, Direction.Gauche, Direction.Droite };

        public char Dir;

        private Direction(char Dir)
        {
            this.Dir = Dir;
        }
        public static Direction Create(char Dir)
        {
            if (new[] { 'H', 'B', 'G', 'D' }.Contains(Dir))
                return new Direction(Dir);
            else return null;
        }
        public static Direction Create(Direction Dir)
        {
            return new Direction(Dir.Dir);
        }
        public override bool Equals(object obj)
        {
            Direction dir = obj as Direction;
            if (dir == null) return false;
            else return Compare(this, dir);
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public static bool operator ==(Direction D1, Direction D2)
        {
            return Compare(D1, D2);
        }
        public static bool operator !=(Direction D1, Direction D2)
        {
            return !Compare(D1, D2);
        }
        public static bool Compare(Direction D1,Direction D2)
        {
            if (Object.ReferenceEquals(D1, null) && Object.ReferenceEquals(D2,null)) return true;
            else if (Object.ReferenceEquals(D1, null) || Object.ReferenceEquals(D2, null)) return false;
            else return (D1.Dir == D2.Dir);
        }
        public Direction Oppose()
        {
            if (this == Direction.Haut) return Direction.Bas;
            else if (this == Direction.Bas) return Direction.Haut;
            else if (this == Direction.Gauche) return Direction.Droite;
            else if (this == Direction.Droite) return Direction.Gauche;
            else return null;
        }
    }
}
