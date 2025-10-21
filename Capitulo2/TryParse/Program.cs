using System;

class Program
{



    static void Main(string[] args)

    {
        /*Console.WriteLine("Ingrese un número:");
        string numInput = Console.ReadLine();
        int numero = 0;
        //vamos a poner una letra a ver que pasa (excepcion)

        int.TryParse(numInput, out numero);
        //intenta parsearlo, si no puedo pone el numero en 0
        Console.WriteLine("El número es: " + numero);*/
        bool correcto = false;
        while (!correcto)
        {
            Console.WriteLine("Ingrese un número:");
            string numInput = Console.ReadLine();
            int numero = 0;
            correcto = int.TryParse(numInput, out numero);
            if (correcto)
            {
                Console.WriteLine("El número es: " + numero);
            }
            else
            {
                Console.WriteLine("El valor ingresado no es un número válido. Intente de nuevo.");
            }
        }
        
    }
    
}

