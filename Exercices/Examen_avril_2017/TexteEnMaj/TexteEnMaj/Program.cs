using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TexteEnMaj
{
    class Program
    {
        static int EstUneLettreMinuscule(char l)
            // Renvoie vrai si le caractère reçu est une lettre minuscule non accentuée,
            // renvoie faux sinon.
        {
            if (l >= 'a' && l <= 'z') return true;
        }

        static char LettreEnMajuscule(char LettreMin)
            // Reçoit une lettre minuscule non accentuée,
            // renvoie la majuscule correspondante.
        {
            char LettreMaj;

            LettreMaj = (char)(LettreMin - 'a' + 'A');
            return LettreMaj;
        }

        static string TexteEnMajuscules(string Texte)
            // Reçoit un texte.
            // Renvoie le même texte, dont les lettres minuscules non accentuées ont été converties en majuscules.
            // Les autres caractères sont inchangés.
        {
            int i = 1;
            string MotMaj = "";
            while (i <= Texte.Length)
            {
                if (EstUneLettreMinuscule(Texte[i]))
                    MotMaj += LettreEnMajuscule(Texte[i]);
            }
            return MotMaj;
        }

        static void Main(string[] args)
        {
            string Texte="", TexteMaj="";

            Console.Write("Entrez votre texte: ");
            Console.ReadLine();

            TexteMaj = TexteEnMajuscules(Texte);
            Console.WriteLine("Votre texte en majuscules: " + TexteMaj);
        }
    }
}