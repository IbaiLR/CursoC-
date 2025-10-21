using System;

class Program
{
    /* 
    Cosas a tener en cuenta antes de empezar:
   - para ejecutar el codigo: dotnet run (estando ya dentro de la carpeta del proyecto)
   - cd parwa cambiar de carpeta
    - cd.. para subir una carpeta
    - mkdir para crear una carpeta
    - para crear un proyecto: dotnet new console -o NombreDeLaCarpeta
    
    
    */
    static void Main(string[] args)  //si no le pones el string[] args el usuario no puede meter datos

    {
        /*todas las variables se pueden sustituir por var y el compilador detecta el tipo de dato
        pero es mejor poner el tipo de dato para que sea mas facil de entender */
        int edad = 23;
        Console.WriteLine(edad);

        long bigNumber = 999999;
        Console.WriteLine(bigNumber);
        Console.WriteLine(long.MaxValue);
        Console.WriteLine(long.MinValue);

        double numeroDecimal = 3.14;
        Console.WriteLine(numeroDecimal);
        Console.WriteLine(double.MaxValue);
        Console.WriteLine(double.MinValue);

        float numeroF = 1201201f;
        Console.WriteLine(numeroF);
        Console.WriteLine(float.MaxValue);
        Console.WriteLine(float.MinValue);

        decimal numeroDecimal2 = 1.5m;
        Console.WriteLine(numeroDecimal2);
        Console.WriteLine(decimal.MaxValue);
        Console.WriteLine(decimal.MinValue);

        char letra = 'a';
        Console.WriteLine(letra);
        Console.WriteLine(char.MaxValue);
        Console.WriteLine(char.MinValue);

        string texto = "Hola";
        string texto2 = "buenos dias";
        Console.WriteLine(texto + " " + texto2);

        string textoNumero = "-9009098";
        int numero2 = Convert.ToInt32(textoNumero);
        int numero3 = Convert.toDouble(textoNumero);
        Console.WriteLine(numero2);

        bool verdadero = true;
        bool falso = false;
        Console.WriteLine(verdadero);
        Console.WriteLine(falso);
    }
}

