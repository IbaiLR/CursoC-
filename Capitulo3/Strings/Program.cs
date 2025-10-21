using System;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
class Program
{



    static void Main(string[] args)

    {
        //stringVacios();
        // compararStrings();
        //CaracteresString();
        // StringTiempo();
        //StringContains1();
        //StringContains2();
        //StringNullEmpty();
        //escribirAlReves();
        PassWordChecker();
    }
    static void stringVacios()
    {
        //String vacios

        Console.WriteLine("Ingresa tu nombre:");
        string nombre = Console.ReadLine();
        if (nombre != "")
        {
            Console.WriteLine("Hola " + nombre);
        }
        else
        {
            Console.WriteLine("No ingresaste tu nombre");
        }
        //Tambien se puede poner
        if (nombre == string.Empty)
        {
            Console.WriteLine("No ingresaste tu nombre");
        }
        else
        {
            Console.WriteLine("Hola " + nombre);
        }
    }
    //ver si dos o mas strings son iguales
    static void compararStrings()
    {
        string nombre1 = "Juan";
        string nombre2 = "juan";

        if (nombre1.Equals(nombre2))
        {
            Console.WriteLine("Los nombres son iguales");
        }
        else
        {
            Console.WriteLine("Los nombres son diferentes");
        }
    }

    //Caracteres de un string

    static void CaracteresString()
    {
        //Para escribir los caracteres de cada posicion de una cadena
        string mensaje = "Hola";
        System.Console.WriteLine(mensaje[0]);
        System.Console.WriteLine(mensaje[1]);
        System.Console.WriteLine(mensaje[2]);
        System.Console.WriteLine(mensaje[3]);

    }

    static void StringTiempo()
    {
        string mensaje = "Hola Buenos Días";

        for (int i = 0; i < mensaje.Length; i++)
        {
            Console.Write(mensaje[i]);
            Thread.Sleep(200); //son los milisegundos que va a tardar en escribir cada letra
        }
    }

    static void StringContains1()
    {
        string cadena = "Hola me llamo Ibai";
        bool encontrado = false;
        for (int i = 0; i < cadena.Length && encontrado == false; i++)
        {
            if (cadena[i].Equals("I"))
            {
                encontrado = true;
                Console.WriteLine($"Se ha encontrado la letra I en la posicion: {i}");
            }
        }
    }

    static void StringContains2()
    {
        String cadena = "Hola me llamo Ibai";
        if
            (cadena.Contains("I"))
        {

            Console.WriteLine("Se ha encontrado");
        }
        else
        {
            System.Console.WriteLine("No se ha encontrado");
        }
    }

    static void StringNullEmpty()
    {
        bool rellenado = false;

        do
        {


            System.Console.WriteLine("Escribe tu nombre");
            String nombre = Console.ReadLine();
            if (string.IsNullOrEmpty(nombre))
            {
                System.Console.WriteLine("No has escrito nada");
            }
            else
            {
                System.Console.WriteLine($"Bienvenido, {nombre}");
                rellenado = true;

            }
        } while (rellenado == false);

    }
//Ejercicio 1
    static void escribirAlReves()
    {
        System.Console.WriteLine("Introduce una frase ");
        string frase = Console.ReadLine();
        for (int i = frase.Length - 1; i >= 0; i--)
        {
            System.Console.Write(frase[i]);
        }
    }

    //Ejercicio 2
    static void PassWordChecker()
    {
        bool correcto = false;
        
        do
        {
            System.Console.WriteLine("Introduzca su contraseña");
            string psw1 = Console.ReadLine();
            System.Console.WriteLine("Repita la contraseña ");
            string psw2 = Console.ReadLine();


            if (string.IsNullOrEmpty(psw1) || string.IsNullOrEmpty(psw2))
            {
                System.Console.WriteLine("Por favor introduzca la contraseña");
            }
            else
            {
                if (!psw1.Equals(psw2))
                {
                    System.Console.WriteLine("Las contraseñas no coinciden");
                }
                else
                {
                    correcto = true;
                    System.Console.WriteLine("Bienvenido!");
                }
            }
        } while (correcto == false);
        
    }
    
    }

 