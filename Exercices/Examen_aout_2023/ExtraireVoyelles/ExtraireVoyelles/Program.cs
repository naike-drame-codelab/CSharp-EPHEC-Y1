string mot = "", voy;
Console.Write("Entrez un mot (en majuscules): ");
Console.ReadLine();
voy = ExtraireVoyelles(mot);
Console.WriteLine("Les voyelles de votre mot sont: " + "voy");

static string ExtraireVoyelles(string mot)
{
    string voyelles = "";
    int i = 0;
    while (i <= mot.Length)
    {
        if (EstUneVoyelle(mot[i])) voyelles = voyelles + mot[i];
    }
    return voyelles;
}


static bool EstUneVoyelle(char lettre)
{
    if ((lettre == 'A') || (lettre == 'E') || (lettre == 'I') || (lettre == 'O') || (lettre == 'U') || (lettre == 'Y')) return true;
    else return;
}
