/*************************************************************************************************
 * Ajoutez ci-dessous les instructions (top-level statements) répondant à la question 10.        *
 *************************************************************************************************/


/*************************************************************************************************
 * Ajoutez ci-dessous vos fonctions répondant aux questions 1 à 9.                               *
 *************************************************************************************************/




/*************************************************************************************************
 * Fonctions à utiliser pour l'examen: ne rien modifier après ce point.                          *
 *************************************************************************************************/

static bool[,] ChargerTableau()
// Charge un grille de test et la renvoie sous la forme d'un tableau d'entiers
{
    string fileName = @"..\..\..\..\TestTabs\GrilleTest";
    bool[,] tab = new bool[10, 10];
    char c;

    try
    {
        using (StreamReader sr = new StreamReader(fileName))
        {
            for (int i = 0; i < 10; i++)
            {
                string line = sr.ReadLine();
                for (int j = 0; j < 10; j++)
                {
                    c = line[j];
                    tab[i, j] = (c == '1');
                }
            }
            return tab;
        }
    }
    catch (Exception e)
    {
        Console.WriteLine("The file could not be read:");
        Console.WriteLine(e.Message);
        return null;
    }
}