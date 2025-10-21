using System;
using System.Collections.Concurrent;

class Program
{



    static void Main(string[] args)

    {
    bool correcto = false;
        do
        {

            try
            {
                System.Console.WriteLine("Introduce un número");
                int numero = Convert.ToInt32(Console.ReadLine());
                System.Console.WriteLine("Numero dentro de rango");
                correcto = true;
            }
            catch (FormatException)
            {
                System.Console.WriteLine("El numero es demasaido grande");
            }
            catch (Exception e)
            {
                System.Console.WriteLine($"Error: {e.Message}");
            }
        } while (correcto == false);
    }
    
        
    
}

