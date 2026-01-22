// Shortcut for Console.Writeline() : cw + TAB
// Console.WriteLine("Hello World!");
// Console.ReadLine();

// somme de 3 entiers
int a = 5;
int b = 15;
int c = 79;

Console.WriteLine("a + b + c = " + (a + b + c));

// carré d'un nombre
int x = 12;
Console.WriteLine("x² = " + (x * x));

// division de deux nombres entiers avec gestion de la division par zéro
    // solution d'une division entière = un entier sans décimales
int d = 7;
int e = 3;

if(e == 0) { 
    Console.WriteLine("La division par zéro n'est pas autorisée.");
}
else {
    Console.WriteLine("d / e = " + (d / e));
}

// addition de bytes
int f = 205;
int g = 143;
byte sum = (byte)(f + g); // 92 car calcul modulo : vraie répose est 256 + 92
Console.WriteLine("f + g = " + sum);

// concaténation de chaînes de caractères 1
string s1 = "Hello";
string s2 = "World";
Console.WriteLine(s1 + " " + s2 + "!");

// concaténation de chaînes de caractères 2
int i = 3, j = 5;
string s = "test", resultat;
resultat = i+j+s;
Console.WriteLine(resultat); // 8test car addition des entiers avant concaténation
resultat = s+i+j;
Console.WriteLine(resultat); // test35 car concaténation de chaînes de caractères