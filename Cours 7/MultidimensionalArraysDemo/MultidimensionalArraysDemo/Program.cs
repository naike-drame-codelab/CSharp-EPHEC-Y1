// Parcourir un tableau 2D

int[,] m = GenerateTwoDArray(3, 4);
DisplayTwoDArray(m);
Console.WriteLine();

char[,] m2 = GenerateTwoDCharArray(5, 5);
DisplayTwoDCharArray(m2);
Console.WriteLine();

GenerateFirstPattern(m2);
DisplayTwoDCharArray(m2);
Console.WriteLine();

char[,] m3 = GenerateTwoDCharArray(5, 5);
GenerateSecondPattern(m3);
DisplayTwoDCharArray(m3);
Console.WriteLine();

char[,] m4 = GenerateTwoDCharArray(5, 5);
GenerateThirdPattern(m4);
DisplayTwoDCharArray(m4);
Console.WriteLine();

char[,] m5 = GenerateTwoDCharArray(5, 5);
GenerateFourthPattern(m5);
DisplayTwoDCharArray(m5);
Console.WriteLine();

char[,] m6 = GenerateTwoDCharArray(5, 5);
GenerateFifthPattern(m6);
DisplayTwoDCharArray(m6);
Console.WriteLine();

//----------FUNCTIONS-----------------
// !!! Pas nécessaire de faire des boucles imbriquées quand on ne veut pas parcourir tout le tableau, mais juste une ligne ou une colonne.

static int[,] GenerateTwoDArray(int r, int c) { 
    int[,] m = new int[r, c];
    return m;
}


static char[,] GenerateTwoDCharArray(int r, int c)
{
    char[,] m = new char[r, c];
    for (int i = 0; i < m.GetLength(0); i++)
    {
        for (int j = 0; j < m.GetLength(1); j++)
        {
            m[i, j] = '.';
        }
    }
    return m;
}

static char[,] GenerateFirstPattern(char[,] m)
{
    for (int i = 0; i < m.GetLength(0); i++)
    {
       m[i, 2] = '*';
    }
    return m;
}

static char[,] GenerateSecondPattern(char[,] m)
{
    for (int j = 0; j < m.GetLength(1); j++)
    {
        m[2, j] = '*';
    }
    return m;
}

static char[,] GenerateThirdPattern(char[,] m)
{
    for (int i = 0; i < m.GetLength(0); i++)
    {
         m[i, i] = '*';
    }
    return m;
}

static char[,] GenerateFourthPattern(char[,] m)
{
    for (int i = 0; i < m.GetLength(0); i++)
    {
         m[i, m.GetLength(0) - 1 - i] = '*';       
    }
    return m;
}

static char[,] GenerateFifthPattern(char[,] m)
{
    GenerateThirdPattern(m);
    GenerateFourthPattern(m);
    return m;
}

static void DisplayTwoDArray(int[,] m)
    {
        for (int i = 0; i < m.GetLength(0); i++)
        {
            for (int j = 0; j < m.GetLength(1); j++)
            {
                Console.Write(m[i, j] + " ");
            }
            Console.WriteLine();
        }
}

static void DisplayTwoDCharArray(char[,] m)
{
    for (int i = 0; i < m.GetLength(0); i++)
    {
        for (int j = 0; j < m.GetLength(1); j++)
        {
            Console.Write(m[i, j] + " ");
        }
        Console.WriteLine();
    }
}