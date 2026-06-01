// =================  Main  =================

char[,] grille = InitialiserGrille();
char joueurActuel = 'N'; // Les Noirs commencent toujours à l'Othello
bool partieEnCours = true;

while (partieEnCours)
{
    Console.Clear();
    AfficherGrille(grille);

    // Cas 1 : Le joueur actuel peut jouer
    if (PeutJouer(grille, joueurActuel))
    {
        int l, c;
        bool coupApplique = false;

        do
        {
            SaisirCoup(joueurActuel, out l, out c);

            if (CoupValide(grille, l, c, joueurActuel))
            {
                JouerCoup(grille, l, c, joueurActuel);
                coupApplique = true;
            }
            else
            {
                Console.WriteLine("Coup illégal ! Vous devez capturer au moins un pion adverse.");
            }

        } while (!coupApplique);

        joueurActuel = ChangerJoueur(joueurActuel);
    }
    // Cas 2 : Le joueur actuel doit passer son tour car bloqué
    else if (PeutJouer(grille, ChangerJoueur(joueurActuel)))
    {
        Console.WriteLine("\nJoueur " + joueurActuel + " est bloqué et doit passer son tour !");
        Console.WriteLine("Appuyez sur <ENTER> pour continuer...");
        Console.ReadLine();
        joueurActuel = ChangerJoueur(joueurActuel);
    }
    // Cas 3 : Plus personne ne peut jouer, fin de la partie
    else
    {
        partieEnCours = false;
    }
}

// --- FIN DE LA PARTIE : COMPTAGE ET COMPTE RENDU DES SCORES ---
Console.Clear();
AfficherGrille(grille);
Console.WriteLine("\n=== FIN DE LA PARTIE ===");

int scoreNoir = 0;
int scoreBlanc = 0;

for (int l = 0; l < 8; l++)
{
    for (int c = 0; c < 8; c++)
    {
        if (grille[l, c] == 'N') scoreNoir++;
        if (grille[l, c] == 'B') scoreBlanc++;
    }
}

Console.WriteLine("Score final -> Noir (N) : " + scoreNoir + " | Blanc (B) : " + scoreBlanc);

if (scoreNoir > scoreBlanc)
{
    Console.WriteLine("Victoire du joueur NOIR (N) !");
}
else if (scoreBlanc > scoreNoir)
{
    Console.WriteLine("Victoire du joueur BLANC (B) !");
}
else
{
    Console.WriteLine("Match nul parfait !");
}



// ================ Fonctions ================
/// <summary>
/// Fonction pré-codée par le professeur pour charger une configuration de test.
/// Permet de tester les captures horizontales, verticales et diagonales.
/// </summary>
static char[,] ChargerGrille()
{
    char[,] grille = new char[8, 8];

    // 1. On commence par vider entièrement la grille
    for (int l = 0; l < 8; l++)
    {
        for (int c = 0; c < 8; c++)
        {
            grille[l, c] = ' ';
        }
    }

    // 2. Alignement pour tester une capture HORIZONTALE
    // Si le joueur 'N' joue en (2, 2), il doit capturer les deux 'B' en (2, 3) et (2, 4) car bloqués par le 'N' en (2, 5)
    grille[2, 3] = 'B';
    grille[2, 4] = 'B';
    grille[2, 5] = 'N';

    // 3. Alignement pour tester une capture VERTICALE
    // Si le joueur 'N' joue en (2, 2), il doit capturer les 'B' en (3, 2) et (4, 2) grâce au 'N' en (5, 2)
    grille[3, 2] = 'B';
    grille[4, 2] = 'B';
    grille[5, 2] = 'N';

    // 4. Alignement pour tester une capture DIAGONALE (descendante droite)
    // Si le joueur 'N' joue en (2, 2), il doit capturer le 'B' en (3, 3) grâce au 'N' en (4, 4)
    grille[3, 3] = 'B';
    grille[4, 4] = 'N';

    // 5. Cas piège (bord de grille ou encadrement incomplet)
    // Un joueur ne doit PAS pouvoir capturer ici car la suite est vide ou sort de la grille
    grille[0, 5] = 'B';
    grille[0, 6] = 'B';

    grille[6, 7] = 'B';
    grille[7, 7] = 'N';

    return grille;
}

// Cette fonction utilitaire sécurise les accès au tableau en vérifiant qu'une coordonnée ne déborde pas des indices d'une grille 8x8.
static bool EstValide(int coord)
{
    return coord >= 0 && coord <= 7;
}

// On crée une matrice de caractères, on applique un espace vide par défaut, puis on configure la croix centrale réglementaire du jeu.
static char[,] InitialiserGrille()
{
    char[,] grille = new char[8, 8];

    // Remplissage initial avec des espaces vides
    for (int l = 0; l < 8; l++)
    {
        for (int c = 0; c < 8; c++)
        {
            grille[l, c] = ' ';
        }
    }

    // Configuration centrale initiale obligatoire
    grille[3, 3] = 'N';
    grille[4, 4] = 'N';
    grille[3, 4] = 'B';
    grille[4, 4] = 'B'; // Correction de la saisie : (4,3) est 'B'
    grille[4, 3] = 'B';

    return grille;
}

static void AfficherGrille(char[,] grille)
{
    // Affichage des numéros de colonnes
    Console.WriteLine("  0 1 2 3 4 5 6 7");

    for (int l = 0; l < 8; l++)
    {
        // Affichage du numéro de ligne au début de chaque rangée
        Console.Write(l + " ");

        for (int c = 0; c < 8; c++)
        {
            Console.Write(grille[l, c] + " ");
        }
        Console.WriteLine(); // Retour à la ligne
    }
}

static char ChangerJoueur(char joueurActuel)
{
    if (joueurActuel == 'N')
    {
        return 'B';
    }
    return 'N';
}

static void SaisirCoup(char joueur, out int ligne, out int colonne)
{
    bool coupSaisiValide = false;
    ligne = -1;
    colonne = -1;

    do
    {
        Console.WriteLine("\nJoueur " + joueur + ", à vous de jouer.");

        Console.Write("Entrez le numéro de ligne (0-7) : ");
        ligne = int.Parse(Console.ReadLine());

        Console.Write("Entrez le numéro de colonne (0-7) : ");
        colonne = int.Parse(Console.ReadLine());

        // On valide les coordonnées grâce à la Question 1
        if (EstValide(ligne) && EstValide(colonne))
        {
            coupSaisiValide = true;
        }
        else
        {
            Console.WriteLine("Erreur : Les coordonnées doivent être comprises entre 0 et 7 ! Recommencez.");
        }

    } while (!coupSaisiValide);
}

static bool DirectionValide(char[,] grille, int ligne, int colonne, int dirL, int dirC, char joueur)
{
    // Le coup de départ doit impérativement se faire sur une case vide
    if (grille[ligne, colonne] != ' ')
    {
        return false;
    }

    char adversaire = ChangerJoueur(joueur); // Réutilisation Q4
    int l = ligne + dirL;
    int c = colonne + dirC;
    int nbPionsAdverses = 0;

    // On avance tant qu'on est dans la grille et qu'on rencontre l'adversaire
    while (EstValide(l) && EstValide(c) && grille[l, c] == adversaire)
    {
        l += dirL;
        c += dirC;
        nbPionsAdverses++;
    }

    // Le coup est valide si on a croisé au moins un adversaire ET qu'on s'arrête sur notre propre pion
    if (nbPionsAdverses > 0 && EstValide(l) && EstValide(c) && grille[l, c] == joueur)
    {
        return true;
    }

    return false;
}

static bool CoupValide(char[,] grille, int ligne, int colonne, char joueur)
{
    // Parcours des 8 directions possibles autour de la case
    for (int dirL = -1; dirL <= 1; dirL++)
    {
        for (int dirC = -1; dirC <= 1; dirC++)
        {
            // On ignore le cas (0,0) qui ne correspond à aucun déplacement
            if (dirL == 0 && dirC == 0)
            {
                continue;
            }

            // Si au moins une direction permet une capture, le coup global est valide
            if (DirectionValide(grille, ligne, colonne, dirL, dirC, joueur))
            {
                return true;
            }
        }
    }
    return false;
}

static void RetournerPions(char[,] grille, int ligne, int colonne, int dirL, int dirC, char joueur)
{
    char adversaire = ChangerJoueur(joueur);
    int l = ligne + dirL;
    int c = colonne + dirC;

    // On avance et on retourne les pions tant qu'on croise l'adversaire
    while (grille[l, c] == adversaire)
    {
        grille[l, c] = joueur;
        l += dirL;
        c += dirC;
    }
}

static void JouerCoup(char[,] grille, int ligne, int colonne, char joueur)
{
    grille[ligne, colonne] = joueur; // Placement du nouveau pion

    // On inspecte à nouveau les 8 directions pour appliquer les captures
    for (int dirL = -1; dirL <= 1; dirL++)
    {
        for (int dirC = -1; dirC <= 1; dirC++)
        {
            if (dirL == 0 && dirC == 0)
            {
                continue;
            }

            // Si la direction est fructueuse, on retourne les pions associés
            if (DirectionValide(grille, ligne, colonne, dirL, dirC, joueur))
            {
                RetournerPions(grille, ligne, colonne, dirL, dirC, joueur);
            }
        }
    }
}

// Fonction d'aide pour vérifier si un joueur a au moins un coup possible sur toute la grille
static bool PeutJouer(char[,] grille, char joueur)
{
    for (int l = 0; l < 8; l++)
    {
        for (int c = 0; c < 8; c++)
        {
            if (CoupValide(grille, l, c, joueur))
            {
                return true;
            }
        }
    }
    return false;
}
