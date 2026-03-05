//// while - compteur par 2
//CompteurParDeux();
//Console.WriteLine();

//// while - compteur par 2 bis
//CompteurParDeuxBis();
//Console.WriteLine();

//// while - nombres impairs
//NombresImpairs();
//Console.WriteLine();

//// while - carré des entiers
//Console.Write("Entrez le nombre d'entiers à calculer : ");
//int x = int.Parse(Console.ReadLine());
//CarreEntier(x);

// do...while - validation de saisie
//DoWhile();

// for
//TheoremeDeGauss();

// for imbriqué - dessiner des étoiles
// DessinerEtoiles();

// for imbriqué bis - dessiner des étoiles
DessinerEtoilesBis();
Console.WriteLine();

// for imbriqué bis - lancer de dés
Console.WriteLine(DeSix());

static void CompteurParDeux()
{
    int i = 0;
    while (i <= 10)
    {
        Console.WriteLine(i*2);
        i++;
    }
}

static void CompteurParDeuxBis()
{
    int i = 0;
    while (i <= 20)
    {
        Console.WriteLine(i);
        i += 2;
    }
}

static void NombresImpairs()
{
    int i = 0;
    while (i <= 20)
    {
        if(i % 2 != 0)
        {
            Console.WriteLine(i);
        }
        i++;
    }
}

static void CarreEntier(int x)
{
    int i = 1;
    while (i <= x) { 
        Console.WriteLine(i * i);
        i++;
    }
}

static int DoWhile()
{
    int nb;
    do
    {
        Console.WriteLine("Entrez un nombre entre 1 et 10 : ");
        nb = int.Parse(Console.ReadLine());
    } while (!(nb < 1 && nb > 10));

    return nb;
}

static void TheoremeDeGauss()
{
    int n;
    do { 
        Console.Write("Entrez un nombre entier positif : ");
        n = int.Parse(Console.ReadLine());
    } while (n <= 0);

    int formula = n * (n + 1) / 2;

    int sum = 0;
    for (int i = 1; i <= n; i++)
    {
        sum += i;
    }

    if (sum == formula) Console.WriteLine("Le théorème est vrai : la somme totale - " + sum + " - est égale à la formule n * (n+1)/2 : " + formula + ".");
    else Console.WriteLine("Le théorème est faux.");
}

static void DessinerEtoiles() 
{
    for (int i = 1; i <= 20; i++) {
        for (int j = 1; j <= 40; j++)
        {
            Console.Write("*");
        }        Console.WriteLine();
    }
}

static void DessinerEtoilesBis()
{
    Console.WriteLine("*");

    for (int i = 1; i <= 6; i++)
    {
        Console.Write("*");
        for (int j = 1; j <= i; j++)
        {
            Console.Write(" ");
        }
        Console.WriteLine("*");
    }
}

// Simule le lancer de 3 dés à 6 faces et compte le nombre de lancers nécessaires pour obtenir 3 six - 216 max
static int DeSix() 
{
    Random rng = new Random();
    int counter;
    
    int de1 = rng.Next(1, 7);
    int de2 = rng.Next(1, 7);
    int de3 = rng.Next(1, 7);

    for (counter = 0; counter < 216; counter++) { 
        while (de1 != 6 || de2 != 6 || de3 != 6) // Loi de De Morgan : !(A && B && C) == !A || !B || !C
        {
            de1 = rng.Next(1, 7);
            de2 = rng.Next(1, 7);
            de3 = rng.Next(1, 7);
        }
    }
    return counter;
}