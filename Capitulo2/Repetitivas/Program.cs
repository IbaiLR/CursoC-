using System;

class Program
{



    static void Main(string[] args)

    {
        //For
        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine("Vamos por el numero: " + i);
        }
        //While
        int contador = 0;
        while (contador < 5)
        {
            Console.WriteLine("Vamos por el numero: " + contador);
            contador++;
        }
        //Do While
        int contador2 = 0;
        do
        {
            Console.WriteLine("Vamos por el numero: " + contador2);
            contador2++;
        } while (contador2 < 5);

        
    }
}

