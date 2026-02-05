// fonctions
    // servent à structurer le programme
    // permettent de réutiliser du code
    // permettent d'éviter les répétitions
Console.WriteLine();

/* ---- 1) définition d'une fonction ---
    // static : mot-clé indiquant que la fonction appartient à la classe et non à une instance de celle-ci
    // returnType : type de valeur renvoyée par la fonction (void signifie que la fonction ne renvoie rien)
    // NomDeLaFonction : nom de la fonction (Doit commencer par une majuscule par convention)
    // (paramètres) : liste des paramètres d'entrée de la fonction
*/
static void Hello()
{
    Console.WriteLine("Bonjour !");
}

static void Bye()
{
    Console.WriteLine("Au revoir !");
}

// --- 2) appeler une fonction à l'endroit où l'on veut qu'elle soit exécutée ---
Hello();
Bye();
Hello();
Bye();
Hello();
Bye();

Greet("Alice");

CircleArea(2.5);

BusinessCard("Albus", "Dumbledore", "Directeur", "Poudlard");

Average(4.0, 5.5, 6.0);

Console.WriteLine(CreateString('C', 'S', 'h', 'a'));

// --- 3) fonction avec paramètres ---
// paramètres peuvent des valeurs directes, des variables ou des expressions
static void Greet(string name)
{
    Console.WriteLine($"Bonjour, {name} !");
}

static void CircleArea(double radius)
{
    double pi = 3.14159;
    double area = pi * radius * radius;
    Console.WriteLine($"L'aire du cercle de rayon {radius} est {area}.\n");
}

static void BusinessCard(string firstName, string lastName, string position, string location)
{
    Console.WriteLine("----- Carte de Visite -----");
    Console.WriteLine($"Nom: {firstName}");
    Console.WriteLine($"Prénom: {lastName}");
    Console.WriteLine($"Poste : {position}");
    Console.WriteLine($"Lieu : {location}");
    Console.WriteLine("---------------------------\n");
}

// --- 4) fonction avec valeur de retour ---
static double Average(double a, double b, double c)
{
    return (a + b + c) / 3;
}

static string CreateString(char a, char b, char c, char d)
{
    return $"{a}{b}{c}{d}\n";
}