using System; // Necesario para Console y Math

class Program
{
    static void Main(string[] args)
    {
        double resultado = 1000 / 12.34;
        Console.WriteLine(resultado);                // Muestra el número completo
        Console.WriteLine(Math.Round(resultado));    // Redondea al entero más cercano

        // Formatos de cadena
        Console.WriteLine(string.Format("{0:0}", resultado));    // Sin decimales
        Console.WriteLine(string.Format("{0:0.0}", resultado));  // Un decimal
        Console.WriteLine(string.Format("{0:0.00}", resultado)); // Dos decimales

        double dinero = 10D / 3D;//si no le pones la D lo toma como int y te da 3
        Console.WriteLine(string.Format("{0:0.00}€", dinero)); // Dos decimales
    }
}
