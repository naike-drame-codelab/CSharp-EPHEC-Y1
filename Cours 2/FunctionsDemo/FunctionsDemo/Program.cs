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

// --- 3) fonction avec paramètres ---
string userName = "Alice";
Greet(userName);
static void Greet(string name)
{
    Console.WriteLine($"Bonjour, {name} !");
}