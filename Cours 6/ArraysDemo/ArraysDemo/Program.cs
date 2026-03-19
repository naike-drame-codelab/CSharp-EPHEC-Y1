// Déclarer et afficher les valeurs d'un tableau d'entiers contenant les éléments 1, 2, 3, 4 et 5.
//using System.Drawing;

//int[] arr = new int[] { 1, 2, 3, 4, 5 };

//for (int i = 0; i < arr.Length; i++)
//{
//    Console.Write(arr[i] + " ");
//}
//Console.WriteLine();

//// Choisir un élément aléatoire dans un tableau
//string[] arr3 = new string[] { "Riri", "Fifi", "Loulou" };
//Random rng = new Random();
//int rngIndex = rng.Next(arr3.Length);
//Console.WriteLine(arr3[rngIndex]);

//// Créer un tableau d'entiers de taille n.
//Console.Write($"Entrez la taille du tableau : ");
//int size = int.Parse(Console.ReadLine());
//int[] arr4 = CreateArray(size);
//DisplayArray(arr4);

//// Trouver la plus grande valeur d'un tableau d'entiers.
//int[] arr5 = GenerateArray(10);
//DisplayArray(arr5);
//GreatestValue(arr5);

//// Renvoyer un tableau aux valeurs inversées
//int[] arr6 = GenerateArray(10);
//DisplayArray(arr6);
//DisplayArray(ReverseArray(arr6));
//DisplayArray(arr6); // Vérification que le tableau original n'est pas modifié

// Trouver l'index d'une valeur dans un tableau d'entiers
int[] arr7 = GenerateArray(10);
DisplayArray(arr7);
Console.Write($"Entrez une valeur à rechercher : ");
int valueToFind = int.Parse(Console.ReadLine());
int? index = FindValueIndex(arr7, valueToFind);
if (index.HasValue)
{
    Console.WriteLine($"La valeur {valueToFind} se trouve à l'index {index}.");
}


//--- FONCTIONS ---
static int[] CreateArray(int size)
    {
        int[] arr = new int[size];
        for (int i = 0; i < size; i++)
        {
            arr[i] = size - i;
        }
        return arr;
    }

static void DisplayArray(int[] arr)
{
    for (int i = 0; i < arr.Length; i++)
    {
        Console.Write(arr[i] + " ");
    }
    Console.WriteLine();
}

static void GreatestValue(int[] arr)
{
    int greatest = arr[0];
    for (int i = 1; i < arr.Length; i++)
    {
        if (arr[i] > greatest)
        {
            greatest = arr[i];
        }
    }
    Console.WriteLine($"La plus grande valeur du tableau est : {greatest}");
}

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

static int[] ReverseArray(int[] arr)
{
    int[] reversed = new int[arr.Length];
    for (int i = 0; i < arr.Length; i++)
    {
        reversed[i] = arr[arr.Length - 1 - i];
    }
    return reversed;
}

static int FindValueIndex(int[] arr, int value) {
    for(int i = 0; i < arr.Length; i++)
    {
        if (arr[i] == value) 
        { 
            return i; 
        }
    }
    
    return -1;
}