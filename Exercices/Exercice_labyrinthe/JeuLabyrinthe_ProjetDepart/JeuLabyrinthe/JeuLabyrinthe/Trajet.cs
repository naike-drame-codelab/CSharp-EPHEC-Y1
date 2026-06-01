using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuLabyrinthe
{
    class Trajet
    {
        private List<Direction> MonTrajet;
        private int Etape;

        public Trajet()
        {
            MonTrajet = new List<Direction>();
            Etape = 0;
        }
        public List<Direction> GetTrajet()
        {
            return MonTrajet;
        }
        public void AjouterEtape(Direction Dir)
        {
            MonTrajet.Add(Dir);
        }
        public void RelireAuDebut()
        {
            Etape = 0;
        }
        public Direction LireProchainMouvement()
        {
            if (Etape < MonTrajet.Count)
            {
                return MonTrajet[Etape++];
            }
            else return null;
        }
        public void Simplifier()
        {
                ImportFromListChar(VotreSolutionIci.Simplifier(ExportAsListChar()));
        }
        public override string ToString()
        {
            string Res = "";
            for (int i = 0; i < MonTrajet.Count; i++)
            {
                Res += MonTrajet[i].Dir;
            }
            return Res;
        }
        public List<char> ExportAsListChar()
        {
            List<char> Export = new List<char>();
            for (int i = 0; i < MonTrajet.Count; i++)
                Export.Add(MonTrajet[i].Dir);
            return Export;
        }
        public void ImportFromListChar(List<char> Import)
        {
            Direction NextStep;
            MonTrajet = new List<Direction>();
            for (int i = 0; i < Import.Count; i++)
            {
                NextStep = Direction.Create(Import[i]);
                if (NextStep != null)
                    MonTrajet.Add(NextStep);
            }
        }

    }
}
