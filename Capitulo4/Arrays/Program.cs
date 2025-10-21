using System;

class Program
{



    static void Main(string[] args)

    {
        //prueba1();
        // RecorrerArray();
        //ordenarNumeros();
        //ArrayReverse();
        //borrarArrays();
        buscarArrays();
    }

    static void prueba1()
    {
        int n1 = 5;
        int n2 = 10;
        int n3 = 15;

        int[] numbers = new int[3];  //Tiene 3 huecos

        System.Console.WriteLine("Introduce un número");
        numbers[0] = Convert.ToInt32(Console.ReadLine());

        System.Console.WriteLine("Introduce un número");
        numbers[1] = Convert.ToInt32(Console.ReadLine());

        System.Console.WriteLine("Introduce un número");
        numbers[2] = Convert.ToInt32(Console.ReadLine());

        System.Console.WriteLine($"Manera 1: {n1} {n2} {n3}");
        System.Console.WriteLine($"Manera 2: {numbers[0]} {numbers[1]} {numbers[2]}");
    }

    static void RecorrerArray()
    {

        string[] nombres = new string[10] //el numero dentro de los corchetes no es necesario
{
            "Ana",
            "Luis",
            "María",
            "Carlos",
            "Sofía",
            "Pedro",
            "Lucía",
            "Miguel",
            "Elena",
            "Javier"
};

        for (int i = 0; i < nombres.Length; i++)
        {
            System.Console.WriteLine(nombres[i]);
        }

    }

    static void ordenarNumeros()
    {
        int[] numeros = new int[] {
            8,4,5,1,4,3,2,15,12,11
        };
        Array.Sort(numeros);
        foreach (int numero in numeros)
        {
            System.Console.WriteLine($"{numero} ");
        }
    }

    static void ArrayReverse()
    {
        int[] numeros = new int[] {
            8,4,5,1,4,3,2,15,12,11
        };

        Array.Reverse(numeros);

        foreach (int numero in numeros)
        {
            System.Console.WriteLine($" {numero} ");
            System.Console.WriteLine();
        }

        for (int i = 0; i < numeros.Length; i++)
        {
            System.Console.WriteLine($" {numeros[i]}");
        }
    }

    static void borrarArrays()
    {
        int[] numeros = new int[] {
            0,1,2,3,4,5,6,7,8,9,10
        };

        Array.Clear(numeros, 3, 2); /*el primer numero indica en que posicion quieres empezar
                                     y el segundo cuantos quieres borrar en total(3 y 4) */
        System.Console.WriteLine($"3 y 4 borrados");
        for (int i = 0; i < numeros.Length; i++)
        {
            System.Console.Write(numeros[i]);
        }
    }

    static void buscarArrays()
    {
        int[] numeros = new int[] {
            12, 14, 56, 34, 10, 23, 54
        };

        System.Console.WriteLine("Escribe el numero que quieres buscar");
        int buscar = Convert.ToInt32(Console.ReadLine());

        int posicion = Array.IndexOf(numeros, buscar);
        //si no lo encuentra posicion=-1, si lo encuentra posicion=0

        if (posicion == -1) //
        {
            System.Console.WriteLine($"No se ha encontrado el número {buscar}");
        }
        else
        {
            System.Console.WriteLine($"Se ha encontrado el número {buscar} en la posición {posicion+1}");
        }

        
    }
    
}

