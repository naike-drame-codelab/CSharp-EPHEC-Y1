// Générer une liste et ajouter un élément à la liste, puis afficher les éléments de la liste.
List<int> l = new List<int> { 5, 10, 15, 20 };
l.Add(25);

// Insérer un élément à une position spécifique dans la liste
l.Insert(2, 99);

// Trier la liste en ordre croissant. Rmq : une liste de caractères sont triés selon l'ordre ASCII, les majuscules sont triés avant les minuscules.
List<char> c = new List<char> { 'z', 'a', 'c', 'Z', 'w', 'b', 'A'};
c.Sort();

// !!! Pour retirer un élément de la liste, on peut utiliser la méthode Remove() ou RemoveAt().Rmq : mieux vaut parcourir la liste à l'envers pour retirer des éléments, sinon on risque de sauter des éléments.
List<int> sequence = CreateSequence(100);
List<int> temp = NotMultiple(sequence, 3);
List<int> result = NotMultiple(temp, 5);
PrintList(result);


static List<int> CreateSequence(int max)
{
    List<int> l = new List<int>();

    for (int i = 1; i <= max; i++)
    {
        l.Add(i);
    }

    return l;
}

static List<int> NotMultiple(List<int> l, int n)
{
    List<int> result = new List<int>();
    for (int i = 0; i < l.Count; i++)
    {
        if (l[i] % n != 0)
        {
            result.Add(l[i]);
        }
    }
    return result;
}


static void PrintList(List<int> l)
{
    for (int i = 0; i < l.Count; i++)
    {
        Console.Write(l[i] + " ");
    }
}




