using System;
using System.Reflection;
using System.Reflection.Metadata;

class Program
{



    static void Main(string[] args)

    {
        List<int> pares = new List<int>();
        List<int> impares = new List<int>();

        for (int i = 0; i <= 20; i++)
        {
            if (i % 2 == 0)
            {
                pares.Add(i);
            }
            else
            {
                impares.Add(i);
            }
        }
        System.Console.WriteLine("Numeros pares: ");
        for (int i = 0; i < pares.Count; i++)
        {
            System.Console.WriteLine($"{pares.ElementAt(i)}");
        }
        System.Console.WriteLine("");
        System.Console.WriteLine("Numeros impares");

        foreach (int impar in impares)
        {
            System.Console.WriteLine(impar);
        }

    }
}

