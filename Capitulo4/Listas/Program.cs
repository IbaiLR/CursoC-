using System;

class Program
{



    static void Main(string[] args)

    {
        List<int> listaNumeros = new List<int>(); //son como arrays pero sin capacidaad determinada

        listaNumeros.Add(1); //le añades un numero, 
        listaNumeros.Add(4);
        listaNumeros.Add(6);

        for (int i = 0; i < listaNumeros.Count; i++) // en vez de length se pone count como en php
        {
            System.Console.WriteLine(listaNumeros[i]);
        }

        //Para borrar 
        listaNumeros.Remove(1); //Borra el valor 1
        listaNumeros.RemoveAt(2); //Borra la posicion 2 de la lista

    }
}

