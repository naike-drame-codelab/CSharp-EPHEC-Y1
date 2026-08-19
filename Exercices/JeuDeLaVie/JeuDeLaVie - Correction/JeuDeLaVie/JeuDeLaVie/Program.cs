// Encodez vos réponses à partir de ce point
// =========================================================================================

// --- Main ---
int numero = DemanderNumGrille();
bool[,] grilleTest = ChargerGrille(numero);

// On affiche la colonne demandée à l'envers
AfficherListe(ExtraireColonneInverse(grilleTest, 0));
Console.WriteLine("\n"); // Double saut de ligne pour la propreté visuelle

// On lance le jeu avec le numéro choisi par l'utilisateur, pas une valeur fixe
JeuDeLaVie(numero, 5);


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
    // On utilise '<' et non '<=' car les indices vont de 0 à Taille - 1
    if (l >= 0 && l < grille.GetLength(0) && c >= 0 && c < grille.GetLength(1))
    {
        return grille[l, c]; // La cellule existe, on renvoie son état (true ou false)
    }

    // Si les coordonnées sont hors du tableau, la règle dit que c'est une zone "morte"
    return false;
}

static int CompteVoisine(bool[,] grille, int l, int c)
{
    int nbCellulesVivantes = 0;

    // On boucle uniquement de la ligne du dessus à la ligne du dessous
    for (int i = l - 1; i <= l + 1; i++)
    {
        // On boucle uniquement de la colonne de gauche à la colonne de droite
        for (int j = c - 1; j <= c + 1; j++)
        {
            // On ne doit pas compter la cellule centrale elle-même
            if (i == l && j == c) continue;

            // LireCellule gère les débordements : si (i, j) est hors grille, ça renvoie false
            if (LireCellule(grille, i, j) == true)
            {
                nbCellulesVivantes++;
            }
        }
    }

    return nbCellulesVivantes;
}

static bool ProchainEtat(bool[,] grille, int l, int c)
{
    // On récupère le nombre de voisines une seule fois
    int voisines = CompteVoisine(grille, l, c);

    // Application stricte des 3 règles du Jeu de la Vie
    if (voisines == 3)
    {
        return true; // Naissance ou maintien en vie
    }
    else if (voisines == 2)
    {
        return grille[l, c]; // Survie : reste dans son état actuel
    }
    else
    {
        return false; // Isolement (< 2) ou Surpopulation (> 3) : la cellule meurt
    }
}

static bool[,] ProchaineGrille(bool[,] grille)
{
    int nbLignes = grille.GetLength(0);
    int nbColonnes = grille.GetLength(1);

    // On crée une NOUVELLE grille vierge
    bool[,] prochaineGrille = new bool[nbLignes, nbColonnes];

    for (int i = 0; i < nbLignes; i++)
    {
        for (int j = 0; j < nbColonnes; j++)
        {
            // On lit l'état de l'ancienne grille, mais on écrit dans la nouvelle !
            prochaineGrille[i, j] = ProchainEtat(grille, i, j);
        }
    }

    // On retourne le nouveau calque, l'ancien est resté intact
    return prochaineGrille;
}

static void JeuDeLaVie(int numGrille, int iteration)
{
    bool[,] grille = ChargerGrille(numGrille);

    // Affichage de l'état initial (itération 0)
    AfficherGrille(grille);
    Console.WriteLine();

    for (int i = 0; i < iteration; i++)
    {
        // La grille est écrasée par sa nouvelle version
        grille = ProchaineGrille(grille);
        AfficherGrille(grille);
        Console.WriteLine();
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
        string saisie = Console.ReadLine();

        // int.TryParse tente de convertir la chaîne 'saisie' en entier.
        // - Si la conversion réussit, la méthode place la valeur dans la variable 'nb' (grâce au mot-clé 'out') et renvoie 'true'.
        // - Si l'utilisateur tape des lettres ou valide à vide, la méthode renvoie 'false' sans faire planter le programme.
        if (int.TryParse(saisie, out nb))
        {
            // La saisie est bien un nombre, on vérifie maintenant s'il est dans la bonne fourchette
            if (nb >= 1 && nb <= 6)
            {
                valide = true;
            }
            else
            {
                Console.WriteLine("Erreur, veuillez entrer un nombre valide entre 1 et 6.");
            }
        }
        else
        {
            // La saisie n'était pas un nombre du tout
            Console.WriteLine("Erreur de saisie. Ce n'est pas un nombre.");
        }
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
