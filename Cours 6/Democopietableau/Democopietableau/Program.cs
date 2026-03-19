using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Democopietableau
{
    class Program
    {
        static void DemoCopieTableau()
        {
            int[] t1, t2;
            int i;
            t1 = new int[10];
            for (i = 0; i < 10; i++)
                t1[i] = i;

            t2 = t1;

            Console.Write("Tableau 1: ");
            for (i = 0; i < 10; i++)
                Console.Write(t1[i] + ", ");
            Console.WriteLine();
            Console.Write("Tableau 2: ");
            for (i = 0; i < 10; i++)
                Console.Write(t2[i] + ", ");
            Console.WriteLine();

            t2[4] = 1492;

            Console.Write("Tableau 1: ");
            for (i = 0; i < 10; i++)
                Console.Write(t1[i] + ", ");
            Console.WriteLine();
            Console.Write("Tableau 2: ");
            for (i = 0; i < 10; i++)
                Console.Write(t2[i] + ", ");
        }
        static void Main()
        {
            DemoCopieTableau();
            Console.ReadLine();
        }
    }
}