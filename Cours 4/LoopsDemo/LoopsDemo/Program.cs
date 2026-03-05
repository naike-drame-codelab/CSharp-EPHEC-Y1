// while - compteur par 2
CompteurPar2();
Console.WriteLine();

// while - compteur par 7
CompteurParDeuxBis();
Console.WriteLine();

// while - nombres impairs
NombresImpairs();
Console.WriteLine();

// while - carré des entiers
Console.Write("Entrez le nombre d'entiers à calculer : ");
int x = int.Parse(Console.ReadLine());
CarreEntier(x);

static void CompteurPar2()
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