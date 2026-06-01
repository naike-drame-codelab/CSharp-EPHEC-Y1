/*************************************************************************************************
 * Ajoutez ci-dessous les instructions (top-level statements) répondant à la question 10.        *
 *************************************************************************************************/
// Charge le tableau de mines de test
bool[,] mines = ChargerTableau();

// Lance la boucle principale du démineur
JeuDemineur(mines);

/*************************************************************************************************
 * Ajoutez ci-dessous vos fonctions répondant aux questions 1 à 9.                               *
 *************************************************************************************************/

static bool CoordonneeValide(int coord)
{
    return coord >= 0 && coord <= 9;
}

static bool AccederTableau(bool[,] tableau, int ligne, int colonne)
{
    if (CoordonneeValide(ligne) && CoordonneeValide(colonne))
    {
        return tableau[ligne, colonne];
    }
    return false; // Renvoie faux sans planter si hors limites
}

static int CompterMines(bool[,] mines, int ligne, int colonne)
{
    int nbMines = 0;

    // Boucle imbriquée pour analyser le carré de 3x3 autour de la case
    for (int l = ligne - 1; l <= ligne + 1; l++)
    {
        for (int c = colonne - 1; c <= colonne + 1; c++)
        {
            // On ne compte pas la case centrale elle-même
            if (l == ligne && c == colonne)
            {
                continue;
            }

            // Si une mine est détectée (sécurisé par AccederTableau)
            if (AccederTableau(mines, l, c))
            {
                nbMines++;
            }
        }
    }
    return nbMines;
}

static void Afficher(bool[,] jeu, bool[,] mines)
{
    for (int l = 0; l < 10; l++)
    {
        for (int c = 0; c < 10; c++)
        {
            if (jeu[l, c])
            {
                int nb = CompterMines(mines, l, c);
                Console.Write(nb);
            }
            else
            {
                Console.Write(' '); // Espace pour les cases non jouées
            }
        }
        Console.WriteLine(); // Retour à la ligne à la fin de chaque rangée
    }
}

static int LireNombre(string question)
{
    int nombre;
    
    do
    {
        // 1. On pose la question et on récupère la saisie
        Console.Write(question);
        nombre = int.Parse(Console.ReadLine());

        // 2. Si la valeur est incorrecte, on affiche un message d'erreur
        if (nombre < 0 || nombre > 9)
        {
            Console.WriteLine("Erreur : la valeur doit être comprise entre 0 et 9.");
        }

    } while (nombre < 0 || nombre > 9);
    return nombre;
}

static void LireCoup(out int ligne, out int colonne)
{
    ligne = LireNombre("Entrez le numéro de ligne (0-9) : ");
    colonne = LireNombre("Entrez le numéro de colonne (0-9) : ");
}

static bool JouerCoup(bool[,] jeu, bool[,] mines, int ligne, int colonne)
{
    if (mines[ligne, colonne])
    {
        Console.WriteLine("Vous avez perdu !");
        return false;
    }
    else
    {
        jeu[ligne, colonne] = true;
        Afficher(jeu, mines); // Affiche la grille mise à jour
        return true;
    }
}

static bool[,] InitialiserTableau()
{
    bool[,] tableau = new bool[10, 10];
    for (int l = 0; l < 10; l++)
    {
        for (int c = 0; c < 10; c++)
        {
            tableau[l, c] = false;
        }
    }
    return tableau;
}

static void JeuDemineur(bool[,] mines)
{
    bool[,] jeu = InitialiserTableau();
    int coupsJoues = 0;
    bool enVie = true;

    // La partie s'arrête après 5 coups ou dès que le joueur perd
    while (coupsJoues < 5 && enVie)
    {
        Console.WriteLine("\n--- TOUR " + (coupsJoues + 1) + " ---");
        int ligne, colonne;

        LireCoup(out ligne, out colonne);
        enVie = JouerCoup(jeu, mines, ligne, colonne);

        if (enVie)
        {
            coupsJoues++;
        }
    }

    if (enVie)
    {
        Console.WriteLine("\nBravo ! Vous avez survécu aux 5 coups !");
    }
}

/*************************************************************************************************
 * Fonctions à utiliser pour l'examen: ne rien modifier après ce point.                          *
 *************************************************************************************************/

static bool[,] ChargerTableau()
// Charge un grille de test et la renvoie sous la forme d'un tableau d'entiers
{
    string fileName = @"..\..\..\..\TestTabs\GrilleTest";
    bool[,] tab = new bool[10, 10];
    char c;

    try
    {
        using (StreamReader sr = new StreamReader(fileName))
        {
            for (int i = 0; i < 10; i++)
            {
                string line = sr.ReadLine();
                for (int j = 0; j < 10; j++)
                {
                    c = line[j];
                    tab[i, j] = (c == '1');
                }
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