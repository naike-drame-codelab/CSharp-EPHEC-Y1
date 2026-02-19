//--- Centre de vacances
// main
PreparerExcursion();

// Fonctions
static int NombreSandwiches(int nbAdultes, int nbEnfants)
{
    int adultes = nbAdultes < 0 ? 0 : nbAdultes;
    int enfants = nbEnfants < 0 ? 0 : nbEnfants;
    return  (adultes * 3) + (enfants * 2);
}

static int NombreSandwichesJambon(int total) { 
    return Convert.ToInt32(total/3.0);
}

static int NombreSandwichesFromage(int total) { 
    return Convert.ToInt32(total*2.0/3.0);
}

static string Commande(int nbAdultes, int nbEnfants)
{
    int total = NombreSandwiches(nbAdultes, nbEnfants);
    int jambon = NombreSandwichesJambon(total);
    int fromage = NombreSandwichesFromage(total);
    return $"\nBonjour,\nPour l'excursion d'aujourd'hui, il faut commander : \n" +
        $"- {jambon} sandwiches au jambon ;\n" +
        $"- {fromage} sandwiches au fromage.\nMerci !";
}

static string MessageClients(int nbAdultes, int nbEnfants, string destination)
{
    return $"Ce matin, nous irons visiter {destination}.\n" +
               $"{nbAdultes} adultes et {nbEnfants} enfants participeront à notre sortie.\n" +
               $"Belle journée à tous !";
}

static void PreparerExcursion() {
    Console.Write("Destination du jour: ");
    string destination = Console.ReadLine() ?? "Inconnue";

    int adultes;
    do
    {
        Console.Write("Nombre d'adultes inscrits: ");
        adultes = SaisirEntier();
        if (adultes < 0) Console.WriteLine("Erreur : Le nombre d'adultes ne peut pas être négatif.");
    } while (adultes < 0);

    int enfants;
    do
    {
        Console.Write("Nombre d'enfants inscrits: ");
        enfants = SaisirEntier();
        if (enfants < 0) Console.WriteLine("Erreur : Le nombre d'enfants ne peut pas être négatif.");
    } while (enfants < 0);

    Console.WriteLine("\n------------------------------------------------------------");

    Console.WriteLine(Commande(adultes, enfants));

    Console.WriteLine("\n------------------------------------------------------------\n");
    Console.WriteLine(MessageClients(adultes, enfants, destination));
    Console.WriteLine("\n------------------------------------------------------------");
}

// --- OUTILS GÉNÉRIQUES ---
/// <summary>
/// Lit une entrée clavier et s'assure que c'est un entier valide.
/// </summary>
static int SaisirEntier()
{
    int result;
    while (!int.TryParse(Console.ReadLine(), out result))
    {
        Console.Write("Entrée invalide. Veuillez saisir un nombre entier : ");
    }
    return result;
}