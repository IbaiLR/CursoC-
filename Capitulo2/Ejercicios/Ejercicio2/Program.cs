using System;
using System.Text; // ← La T debe ser mayúscula

class Program
{
    static void Main(string[] args)
    {
        // Pide dos números (inicio y fin) y muestra todos los números primos en ese rango usando bucles
        StringBuilder sb = new StringBuilder();

        Console.WriteLine("Introduce un número de inicio: ");
        int inicio = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Introduce un número de fin: ");
        int fin = Convert.ToInt32(Console.ReadLine());

        for (int i = inicio; i <= fin; i++)
        {
            int contador = 0;

            // Recorremos divisores posibles
            for (int j = 1; j <= i; j++)
            {
                if (i % j == 0)
                {
                    contador++;
                }
            }

            // Un número primo solo tiene dos divisores: 1 y él mismo
            if (contador == 2)
            {
                sb.Append(i + " ");
            }
        }

        Console.WriteLine($"Los números primos entre {inicio} y {fin} son: {sb}");
    }
}
