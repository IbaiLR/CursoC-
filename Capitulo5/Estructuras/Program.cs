using System;

class Program
{
    struct Persona
    {
        public string nombre;
        public int edad;
   }


    static void Main(string[] args)

    {
        string nombre = "Ibai";
        int edad = 19;
        Persona p;

        p.nombre = "Ibai";
        p.edad = 19;

        System.Console.WriteLine($"{p.nombre} - {p.edad}");
    }
}

