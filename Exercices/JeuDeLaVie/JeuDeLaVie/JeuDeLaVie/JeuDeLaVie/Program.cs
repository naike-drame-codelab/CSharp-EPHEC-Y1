// Encodez vos réponses à partir de ce point
// =========================================================================================

// --- Main ---
int numero = DemanderNumGrille();
bool[,] grilleTest = ChargerGrille(numero);
AfficherListe(ExtraireColonneInverse(grilleTest, 0));
JeuDeLaVie(3, 5);


// --- Fonctions ---
static void AfficherGrille(bool[,] grille)
{
    for (int i = 0; i < grille.GetLength(0); i++)
    {
        for (int j = 0; j < grille.GetLength(1); j++)
        {
            if (grille[i, j] == true) Console.Write('*');
            else Console.Write('.');
        }
        Console.WriteLine();
    }
}

static bool LireCellule(bool[,] grille, int l, int c)
{
    return (l >= 0 && l <= grille.GetLength(0)) &&
        (c >= 0 && c <= grille.GetLength(1));
}

static int CompteVoisine(bool[,] grille, int l, int c)
{
    int nbCellulesVivantes = 0;
    for (int i = 0; i < grille.GetLength(0); i++)
    {
        for (int j = 0; j < grille.GetLength(1); j++)
        {
            if (LireCellule(grille, l, c))
            {
                if (i == l && j == c) continue;

                if (grille[i, j] == true) nbCellulesVivantes++;
            }
        }
    }

    return nbCellulesVivantes;
}

static bool ProchainEtat(bool[,] grille, int l, int c)
{
    for (int i = 0; i < grille.GetLength(0); i++)
    {
        for (int j = 0; j < grille.GetLength(1); j++)
        {
            if (l == 0 && c == 0) continue;

            if (CompteVoisine(grille, l, c) == 3) return true;
            if (CompteVoisine(grille, l, c) == 2) return grille[l, c];
        }
    }

    return false;
}

static bool[,] ProchaineGrille(bool[,] grille)
{
    bool[,] prochaineGrille = new bool[grille.GetLength(0), grille.GetLength(1)];

    for (int i = 0; i < prochaineGrille.GetLength(0); i++)
    {
        for (int j = 0; j < prochaineGrille.GetLength(1); j++)
        {
            grille[i, j] = ProchainEtat(grille, i, j);
            prochaineGrille[i, j] = grille[i, j];
        }
    }

    return prochaineGrille;
}

static void JeuDeLaVie(int numGrille, int iteration)
{
    bool[,] grille = ChargerGrille(numGrille);

    for (int i = 0; i <= iteration; i++)
    {
        AfficherGrille(ProchaineGrille(grille));
    }
}

static List<bool> ExtraireColonneInverse(bool[,] grille, int c)
{
    List<bool> liste = new List<bool>();

    for (int i = 0; i < grille.GetLength(0); i++)
    {
        liste.Add(grille[grille.GetLength(0) - 1 - i, c]);
    }

    return liste;
}

static void AfficherListe(List<bool> liste)
{
    foreach (bool e in liste)
    {
        Console.Write(e + " ");
    }
}

static int DemanderNumGrille()
{
    int nb;
    bool valide = false;
    
    do
    {
        Console.Write("Entrez le numéro de la grille à tester (entre 1 et 6) : ");
        nb = int.Parse(Console.ReadLine());

        if (nb >= 1 && nb <= 6) valide = true;
        else Console.WriteLine("Erreur, veuillez entrer un nombre.");
    }
    while (!valide);

    return nb;
}



// Fonctions à utiliser pour résoudre l'examen: ne rien écrire ou modifier après cette ligne
// =========================================================================================


static bool[,] ChargerGrille(int nb)
// Charge la grille de test numéro nb et la renvoie sous la forme d'un tableau 2D
{
    string fileName = @"..\..\..\..\grilles\grille" + nb.ToString() + ".txt";

    bool[,] tab;
    string[] tabString;
    int nbLignes, nbColonnes;
    try
    {
        using (StreamReader sr = new StreamReader(fileName))
        {
            string ligne = sr.ReadLine();
            nbLignes = int.Parse(ligne);
            nbColonnes = int.Parse(ligne);
            tab = new bool[nbLignes, nbColonnes];

            for (int i = 0; i < nbLignes; i++)
            {
                ligne = sr.ReadLine();
                for (int j = 0; j < nbColonnes; j++)
                    tab[i, j] = ligne[j] == '1' ? true : false;
            }
            return tab;
        }
    }
    catch (Exception e)
    {
        Console.WriteLine("The file could not be read:");
        Console.WriteLine(e.Message);
        return null;
    }
}
