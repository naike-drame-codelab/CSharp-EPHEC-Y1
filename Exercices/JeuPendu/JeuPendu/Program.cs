JeuDuPendu();


/*
 FONCTIONS
 */

static bool EstUneLettre(char caractere)
{
    // On vérifie s'il est compris entre 'A' et 'Z' OU entre 'a' et 'z'
    if ((caractere >= 'A' && caractere <= 'Z') || (caractere >= 'a' && caractere <= 'z'))
    {
        return true;
    }
    return false;
}

static char LettreEnMajuscules(char caractere)
{
    // Si c'est une minuscule, on applique le décalage de la table Unicode
    if (caractere >= 'a' && caractere <= 'z')
    {
        int ordre = caractere - 'a';
        return (char)('A' + ordre);
    }
    return caractere; // Sinon, on renvoie le caractère inchangé
}

static char SaisirLettre()
{
    string saisie;
    char lettre = ' ';
    bool valide = false;

    do
    {
        Console.Write("Entrez une lettre non accentuée suivie de <ENTER> : ");
        saisie = Console.ReadLine();

        // On vérifie que l'utilisateur a entré exactement 1 caractère et que c'est une lettre
        if (saisie.Length == 1 && EstUneLettre(saisie[0]))
        {
            lettre = LettreEnMajuscules(saisie[0]);
            valide = true;
        }
        else
        {
            Console.WriteLine("Erreur : Saisie invalide.");
        }

    } while (!valide);

    return lettre;
}

static bool EstComposeDeLettres(string mot)
{
    if (mot.Length == 0) return false;

    for (int i = 0; i < mot.Length; i++)
    {
        if (!EstUneLettre(mot[i]))
        {
            return false; // Dès qu'un caractère n'est pas une lettre
        }
    }
    return true;
}

static string MotEnMajuscules(string mot)
{
    string resultat = "";
    for (int i = 0; i < mot.Length; i++)
    {
        resultat += LettreEnMajuscules(mot[i]); // Réutilisation de Q2
    }
    return resultat;
}

static string SaisirMot()
{
    string saisie;
    do
    {
        Console.Write("Entrez le mot à faire deviner (uniquement des lettres) : ");
        saisie = Console.ReadLine();
    } while (!EstComposeDeLettres(saisie)); // Réutilisation de Q4

    return MotEnMajuscules(saisie); // Réutilisation de Q5
}

static string InitialiserMotVide(string motReference)
{
    string masque = "";
    for (int i = 0; i < motReference.Length; i++)
    {
        masque += ".";
    }
    return masque;
}

static bool EstDansMot(char caractere, string mot)
{
    for (int i = 0; i < mot.Length; i++)
    {
        if (mot[i] == caractere) return true;
    }
    return false;
}

static string CompleterMot(string motACompleter, string motReference, char lettreProposee)
{
    string nouveauMot = "";
    for (int i = 0; i < motReference.Length; i++)
    {
        if (motReference[i] == lettreProposee)
        {
            nouveauMot += lettreProposee; // On révèle la lettre
        }
        else
        {
            nouveauMot += motACompleter[i]; // On garde ce qu'il y avait (. ou autre lettre trouvée)
        }
    }
    return nouveauMot;
}

//static void AfficherPendu(int nbErreurs)
//{
//    Console.WriteLine("Vous avez fait " + nbErreurs + " erreur(s).");
//}

//static void AfficherSituation(string motPartiel, string lettresIncorrectes, int nbErreurs)
//{
//    Console.WriteLine("\n======================================");
//    Console.WriteLine("Votre proposition : " + motPartiel);
//    Console.WriteLine("Lettres incorrectes : " + lettresIncorrectes);
//    AfficherPendu(nbErreurs);
//    Console.WriteLine("======================================\n");
//}

static void JeuDuPendu()
{
    string motADeviner = SaisirMot();
    string motPartiel = InitialiserMotVide(motADeviner);
    string lettresIncorrectes = "";
    int nbErreurs = 0;

    Console.Clear();
    AfficherSituation(motPartiel, lettresIncorrectes, nbErreurs);

    // Boucle de jeu : tourne tant qu'on n'a ni gagné ni perdu
    while (motPartiel != motADeviner && nbErreurs < 6)
    {
        char proposition = SaisirLettre();

        // 1. On vérifie si la lettre a déjà été proposée dans les erreurs
        if (EstDansMot(proposition, lettresIncorrectes))
        {
            Console.WriteLine("Vous avez déjà proposé cette lettre incorrecte !");
            continue;
        }

        // 2. On vérifie si elle est dans le mot
        if (EstDansMot(proposition, motADeviner))
        {
            motPartiel = CompleterMot(motPartiel, motADeviner, proposition);
        }
        else
        {
            lettresIncorrectes += proposition + " ";
            nbErreurs++;
        }

        Console.Clear();
        AfficherSituation(motPartiel, lettresIncorrectes, nbErreurs);
    }

    // Conclusion de la partie
    if (motPartiel == motADeviner)
    {
        Console.WriteLine("Bravo ! Vous avez gagné ! Le mot était bien : " + motADeviner);
    }
    else
    {
        Console.WriteLine("Pendu ! Vous avez perdu. Le mot était : " + motADeviner);
    }
}

static void LigneHorizontale(int posH, int posV, int longueur)
{
    Console.SetCursorPosition(posH, posV);
    for (int i = 0; i < longueur; i++) Console.Write('*');
}

static void LigneVerticale(int posH, int posV, int longueur) // Pratique pour le poteau
{
    for (int i = 0; i < longueur; i++)
    {
        Console.SetCursorPosition(posH, posV + i);
        Console.Write('*');
    }
}

static void LigneDiagonaleGauche(int posH, int posV, int longueur)
{
    for (int i = 0; i < longueur; i++)
    {
        Console.SetCursorPosition(posH - i, posV + i);
        Console.Write('*');
    }
}

static void LigneDiagonaleDroite(int posH, int posV, int longueur)
{
    for (int i = 0; i < longueur; i++)
    {
        Console.SetCursorPosition(posH + i, posV + i);
        Console.Write('*');
    }
}

static void DessinerTete(int posH, int posV)
{
    Console.SetCursorPosition(posH, posV); Console.Write("***");
    Console.SetCursorPosition(posH - 1, posV + 1); Console.Write("* *");
    Console.SetCursorPosition(posH, posV + 2); Console.Write("***");
}

static void AfficherPendu(int nbErreurs)
{
    // Étape de base : La potence et la corde sont toujours dessinées
    LigneVerticale(25, 3, 12);       // Poteau vertical principal
    LigneHorizontale(15, 3, 11);     // Poutre horizontale haute
    LigneDiagonaleDroite(21, 4, 3);  // Support diagonale de renfort
    LigneVerticale(15, 4, 2);        // La Corde

    // Erreur 1 : La tête
    if (nbErreurs >= 1)
    {
        DessinerTete(14, 6);
    }
    // Erreur 2 : Le tronc (corps)
    if (nbErreurs >= 2)
    {
        LigneVerticale(15, 9, 4);
    }
    // Erreur 3 : Bras gauche
    if (nbErreurs >= 3)
    {
        LigneDiagonaleGauche(14, 10, 2);
    }
    // Erreur 4 : Bras droit
    if (nbErreurs >= 4)
    {
        LigneDiagonaleDroite(16, 10, 2);
    }
    // Erreur 5 : Jambe gauche
    if (nbErreurs >= 5)
    {
        LigneDiagonaleGauche(14, 13, 3);
    }
    // Erreur 6 : Jambe droite
    if (nbErreurs >= 6)
    {
        LigneDiagonaleDroite(16, 13, 3);
    }
}

static void AfficherSituation(string motPartiel, string lettresIncorrectes, int nbErreurs)
{
    // Écritures textuelles fixées en haut à gauche et à droite
    Console.SetCursorPosition(0, 0);
    Console.Write("Votre proposition : " + motPartiel);

    Console.SetCursorPosition(40, 0);
    Console.Write("Lettres incorrectes : " + lettresIncorrectes);

    // Dessin du pendu en dessous
    AfficherPendu(nbErreurs);

    // On repositionne le curseur tout en bas pour ne pas casser la saisie de texte
    Console.SetCursorPosition(0, 18);
}