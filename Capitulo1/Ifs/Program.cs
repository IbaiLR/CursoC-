using System;

class Program
{



    static void Main(string[] args)

    {
        int n1 = 5;
        int n2 = 10;

        if (n1 < n2)
        {
            Console.WriteLine("n1 es menor que n2");
        }
        else if (n1 >= n2)
        {
            Console.WriteLine("n1 es mayor que n2");
        }
        else if (n1 == n2)
        {
            Console.WriteLine("n1 es igual que n2");
        }

        Console.WriteLine("Introduce tu edad: ");
        int edad = Convert.ToInt32(Console.ReadLine());
        if (edad < 18)
        {
            Console.WriteLine("Eres menor de edad");
        }
        else if (edad >= 18 && edad < 30)
        {
            Console.WriteLine("Tienes el verano joven");
        }
        else
        { 
            Console.WriteLine("No entras en el rango de edad");
        }
    }
}

