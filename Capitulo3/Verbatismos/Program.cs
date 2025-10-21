using System;

class Program
{



    static void Main(string[] args)

    {
        //Para poner una sola \ se usa \\
        string path = "C:\\Users\\Usuario\\Documents\\file.txt";
        string mensaje = "Me dijo: \"Hola, ¿cómo estás?\"";
        Console.WriteLine(path);
        Console.WriteLine(mensaje);

        // Si pones una @ antes de la cadena, no necesitas escapar los caracteres especiales
        string pathVerbatim = @"C:\Users\Usuario\Documents\file.txt";
        Console.WriteLine(pathVerbatim);

        string name = @"Hello ""someone"" ";
        //Hello "someone", se ponen dobles porque son comillas
        Console.WriteLine(name);




        //Otras maneras de concatenar cadenas
        string nombre = "Ibai";
        string edad = "19";

        Console.WriteLine("(Manera 1) Hola, me llamo " + nombre + "\n y tengo " + edad + " años.");
        Console.WriteLine("(Manera 2) Hola, me llamo {0} \n y tengo {1} años.", nombre, edad);
        Console.WriteLine($"(Manera 3) Hola me llamo {nombre} \n y tengo {edad} años");
        Console.WriteLine(string.Concat("(Manera 4) Hola, me llamo ", nombre, "\n y tengo ", edad, " años."));
    }
}

