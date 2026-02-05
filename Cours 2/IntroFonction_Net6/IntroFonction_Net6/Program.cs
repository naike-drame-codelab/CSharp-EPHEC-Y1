// Série 1: fonctions sans paramètres
// ==================================

Console.WriteLine("Voici un triangle");
DessinerTriangle();

Console.WriteLine();
Console.WriteLine("Voici un sapin");
DessinerTriangle();
DessinerTriangle();
DessinerTriangle();
DessinerTriangle();

Console.WriteLine();

// Série 2: fonctions avec paramètres
// ==================================

AfficherBonDAchat("Potter", "Harry", "Ron", 50);
AfficherBonDAchat("Granger", "Hermione", "Dimitri", 100);

string nomDuDirecteur = "Dumbledore";
string prenomDuDirecteur = "Albus";
string auteurCadeau = "Severus Rogue";
int montantCadeauDuDirecteur = 1000;
AfficherBonDAchat(nomDuDirecteur, prenomDuDirecteur, auteurCadeau, montantCadeauDuDirecteur);

// Série 3: fonctions avec renvoi de valeur
// =================================
int montantCadeauRon;
montantCadeauRon = CalculerMoyenne(50, 100);
AfficherBonDAchat("Weasley", "Ron", "Harry", montantCadeauRon);

Console.WriteLine("Appuyez sur <enter> pour terminer...");
Console.ReadLine();

// Définitions des fonctions
// =========================
static void DessinerTriangle()
{
    Console.WriteLine("  *");
    Console.WriteLine(" ***");
    Console.WriteLine("*****");
}

static void AfficherBonDAchat(string nom, string prenom, string auteur, int valeur)
// Affiche un bon d'achat établi aux nom et prénom de la personne, pour la valeur donnée
{
    Console.WriteLine("==========================================");
    Console.WriteLine("Bon d'achat d'une valeur de " + valeur + " euros");
    Console.WriteLine("Etabli au nom de " + prenom + " " + nom);
    Console.WriteLine("De la part de " + auteur);
    Console.WriteLine("==========================================");
}
static int CalculerMoyenne(int nombre1, int nombre2)
// Renvoie la moyenne des deux nombres, arrondie à l'entier inférieur
{
    int resultat;
    resultat = (nombre1 + nombre2) / 2;
    return resultat;
}
