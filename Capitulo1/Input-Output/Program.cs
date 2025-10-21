using System;

class Program
{



    static void Main(string[] args)

    {
        Console.WriteLine("Introduce tu nombre:");
        string nombre = Console.ReadLine();

        Console.WriteLine("Introduce tu edad:");
        string edadTexto = Console.ReadLine();
        int edad = Convert.ToInt32(edadTexto);

        Console.WriteLine("Introduce tu altura:");
        int altura = Convert.ToInt32(Console.ReadLine());//otra forma de convertir a int en un paso

        Console.WriteLine("Hola " + nombre + " tienes " + edad + " años"+ " y mides " + altura + " cm.");
       
    }
}

