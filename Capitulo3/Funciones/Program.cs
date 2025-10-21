using System;
using System.Reflection.Metadata;

class Program
{



    static void Main(string[] args)

    {


        welcomeMessage();
        int suma = resultadoSuma(5, 10);//le pasas los parametros
        int resta = resultadoResta(5);// le pasas 1 y el segundo lo omite

        //Para poder cambiar el orden de los parametros
        int n1 = 3;
        int n2 = 1;
        int resta2 = resultadoResta(y: n2, x: n1); //le metes la variable de la funcion ":" y luego tu variable
        Console.WriteLine("El resultado de la resta es " + resta2);

        //Funciones con parametros de salida
        List<string> listaCompra = new List<string>()
        {
            "Patatas",
            "Lechuga"
        };
        System.Console.WriteLine(BuscarLista("Patatas", listaCompra, out int index));
        System.Console.WriteLine(" " + index);

        //Funciones con parametros de referencia
        int num = 10; // n1 de memoria(inventado)
        asignar(ref num);
        System.Console.WriteLine(num);
    }

    //Funciones void
    static void welcomeMessage()
    {
        Console.WriteLine("Welcome to the program!");
    }
    //Funciones con retorno
    static int resultadoSuma(int a, int b)
    {
        return a + b;
    }

    //funciones con parametros opcionales
    static int resultadoResta(int x, int y = 0) //le pones el 0 para que si no le pone nada sea 0
    {
        return x - y;
    }

    // Funciones con parametros de salida

    static bool BuscarLista(string s, List<string> lista, out int index)
    {

        index = -1;

        for (int i = 0; i < lista.Count; i++)
        {
            if (lista[i].ToLower().Equals("patatas"))
            {
                index = 1;
            }
        }
        return index > -1;
    }

    /* Funciones con parametros de referencia, aqui las variables se pasan "reales",
     es decir que no se hace una copia sino que se pasa la misma variable*/
    static void asignar(ref int num) //n1 de memoria tambien 
    {
        num = 20;
    }
}

