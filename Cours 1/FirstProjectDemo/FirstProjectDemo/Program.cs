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

// type booléen
bool m = true;
bool n = false;
Console.WriteLine("a AND b = " + (m && n)); // false
Console.WriteLine(!m); // false
Console.WriteLine(m && false);  // false

// loi de De Morgan
bool p = true;
bool q = false;
bool rLeft = !(p || q);
bool rRight = (!p && !q);
bool areEqual = (rLeft == rRight);
Console.WriteLine("Loi de de Morgan 1 : " + areEqual);
bool rLeft2 = !(p && q);
bool rRight2 = !p || !q;
bool areEqual2 = (rLeft2 == rRight2);
Console.WriteLine("Loi de de Morgan 2 : " + areEqual2);

// types réels
    // float = sur 32bit, 1.4 * 10^-45 à 3.4 * 10^38, précision ~7 chiffres décimaux
    // double = sur 64bit, 4.9 * 10^-324 à 1.7 * 10^308, précision ~15-16 chiffres décimaux => type PAR DÉFAUT pour les réels
    // decimal = sur 128bit, 1.0 * 10^-28 à 7.9 * 10^28, précision ~28-29 chiffres décimaux (opérations financières, très lent)

double result = 100.0 / 3; // 33.3333333333333 => type double par défaut, très utile dans les calculs de moyennes

double length = 5.5;
double width = 2.3;
Console.WriteLine("Aire du rectangle = " + (length * width));
double radius = 3.0;
double pi = 3.14;
Console.WriteLine("Périmètre du cercle = " + (2 * pi * radius));
Console.WriteLine("Aire du cercle = " + (pi * radius * radius));

// conversion explicite (casting)
double originalDouble = 9.78;
int convertedInt = (int)originalDouble; // 9, la partie décimale est tronquée

// type valeur VS type référence
    // type valeur : int, byte, bool, float, char, double, decimal, struct, enum
    // type référence : string, class, array, interface, delegate
