// Main
// Valeur absolue d'un nombre entier
Console.Write("Entrez un nombre : ");
int nb = SaisirEntier();
Console.WriteLine($"La valeur absolue de {nb} est {Abs(nb)}.");

Console.WriteLine(EstPair(Abs(nb)));

TenueRecommandee();

TestCalcul();

// Fonctions
static int Abs(int x)
{
    if (x < 0) x = -x;
    return x;
}

static bool EstPair(int x) {
    if(x % 2 == 0) return true;
    return false;
}

static double Temperature()
{
    Console.Write("Entrez la température du jour : ");
    return double.Parse(Console.ReadLine());
}

static void TenueRecommandee()
{
    double temp = Temperature();
    if(temp < 0) Console.WriteLine("Prenez un manteau et des gants !");
    else if (temp >= 0 && temp < 15) Console.WriteLine("Prenez un manteau.");
    else if (temp >= 15 && temp < 20) Console.WriteLine("Prenez une veste.");
    else if (temp >= 20 && temp < 30) Console.WriteLine("Prenez un T-Shirt.");
    else Console.WriteLine("Prenez un maillot !");

}

static void TestCalcul() {
    Console.WriteLine("\n----------------------------------");
    Console.WriteLine("Test de calcul !");
    Random rng = new Random();
    int a = rng.Next(1, 10);
    int b = rng.Next(1, 10);
    int result = a + b;

    Console.Write($"Que vaut {a}+{b} ? : ");
    int x = SaisirEntier();

    if(result == x) Console.WriteLine("Correct !");
    else Console.WriteLine($"Faux, la bonne réponse était {result}.");
    Console.WriteLine("----------------------------------\n");
}

static int SaisirEntier()
{
    int result;
    while (!int.TryParse(Console.ReadLine(), out result))
    {
        Console.Write("Entrée invalide. Veuillez saisir un nombre entier : ");
    }
    return result;
}