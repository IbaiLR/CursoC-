using System;
using System.Runtime.CompilerServices;

class Program
{



    static void Main(string[] args)

    {
        //Son como los Map en java, van por clave-valor, la clave es única

        /*Dictionary<int, String> nombres = new Dictionary<int, string>();
        nombres.Add(1, "Ibai");*/

        /*
        Dictionary<int, string> nombres = new Dictionary<int, string>
        {
            {1, "Ibai"},
            {8, "Paco"},
            {3, "Antonio"},
           //{3, "Iker"} //si lo ponemos da error porque la clave estaría duplicada
        };

        for (int i = 0; i < nombres.Count; i++)
        {
            KeyValuePair<int, string> copiaNombres = nombres.ElementAt(i); //aqui estás haciendo una copia temporal
            System.Console.WriteLine($"{copiaNombres.Key}- {copiaNombres.Value}");
        }
        System.Console.WriteLine("");
        foreach (KeyValuePair<int, string> copiaNombres in nombres)
        {
            System.Console.WriteLine($"{copiaNombres.Key}- {copiaNombres.Value}");
        }
        {
            
        } */


        Dictionary<string, string> profesores = new Dictionary<string, string>
        {
            {"Matematicas","Ibai" },
            {"Lengua", "Paco"}
        };
        // System.Console.WriteLine(profesores["Matematicas"]);

        if (profesores.TryGetValue("Matematicas", out string profesor))
        {
            System.Console.WriteLine(profesor);
        }
        else
        {
            System.Console.WriteLine("No se ha encontrado ningun profesor");
        }

        //Si por ejemplo matemticas cambia de profesor
        profesores["Matematicas"] = "Ibai";

        if (profesores.ContainsKey("Matematicas"))
        {
            profesores.Remove("Matematicas");
            System.Console.WriteLine("Matematicas borrada");
        }
        else
        {
            System.Console.WriteLine("No se ha encontrado matematicas");
        }
    }
}

