using System;

class Program
{



    static void Main(string[] args)

    {
        // Calcula la suma de los números del 1 al 100 y muestra el resultado.
        int resultado = 0;
        for (int i = 1; i <= 100; i++)
        {
            resultado = resultado + i;
        }
        Console.WriteLine("El resultado de la suma es: " + resultado);
    }
}

