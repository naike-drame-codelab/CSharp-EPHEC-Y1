// Récursion : technique de programmation dans laquelle une fonction s'appelle elle-même pour résoudre un problème.
// Pile d'appels ou call stack : structure de données utilisée pour stocker les informations sur les fonctions en cours d'exécution, y compris les variables locales et les adresses de retour.
// La récursivité met en pause une fonction jusqu'à ce que la fonction appelée se termine, puis reprend l'exécution de la fonction initiale avec les résultats de la fonction appelée.
// Conditions de terminaison : pour éviter les appels récursifs infinis, il est crucial d'avoir une condition de terminaison qui arrête la récursion lorsque le problème est résolu ou atteint une base de cas.
// Autre condition de terminaison : la récursion doit converger vers une solution, c'est-à-dire que chaque appel récursif doit rapprocher le problème d'une condition de terminaison.



// EXEMPLES D'UTILISATION DE LA RÉCURSION

// calculer la somme des nombres de 1 à n avec une fonction récursive
Console.WriteLine("La somme des nombres vaut " + RecursiveSum(10));

// trier tableau, trouver position du plus grand nb dans un tableau avec fonction récursive
int[] arr = GenerateArray(10);
Console.WriteLine("--- Tableau non trié ---");
PrintArray(arr);
Console.WriteLine(FindMaxPosition(arr, arr.Length));
RecursiveSort(arr, arr.Length);
Console.WriteLine("--- Tableau trié ---");
PrintArray(arr);



// --------------- FONCTIONS RÉCURSIVES ---------------
static int RecursiveSum(int n) {
    if (n == 0) return 0;

    return (n + RecursiveSum(n - 1));
}

static int[] RecursiveSort(int[] arr, int length) {
    // condition de base : si le tableau n'a qu'un élément, il est déjà trié
    if (length <= 1) return arr;

    // trouver la position du plus grand nombre dans la portion non triée
    int maxPos = FindMaxPosition(arr, length);

    // échanger le plus grand élément avec la fin de la portion non triée
    int temp = arr[maxPos];
    arr[maxPos] = arr[length - 1];
    arr[length - 1] = temp;

    // trier récursivement le reste du tableau
    return RecursiveSort(arr, length - 1);
}


// ------------- FONCTIONS UTILITAIRES -------------

// Trouver la position du plus grand nombre dans un tableau d'entiers
static int FindMaxPosition(int[] arr, int length)
{
    int maxPos = 0;
    for (int i = 1; i < length; i++)
    {
        if (arr[i] > arr[maxPos])
        {
            maxPos = i;
        }
    }
    return maxPos;
}

// Générer un tableau d'entiers aléatoires de la taille spécifiée
static int[] GenerateArray(int size)
{
    int[] arr = new int[size];
    Random rng = new Random();
    for (int i = 0; i < size; i++)
    {
        arr[i] = rng.Next(1, 101);
    }
    return arr;
}

// Afficher les éléments d'un tableau d'entiers
static void PrintArray(int[] arr)
{
    for (int i = 0; i < arr.Length; i++)
    {
        Console.Write(arr[i] + " ");
    }
    Console.WriteLine();
}