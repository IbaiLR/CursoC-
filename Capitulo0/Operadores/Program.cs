using System;

class Program
{
    static void Main(string[] args)
    {
        int age = 23;
        age = age + 10;
        Console.WriteLine(age);
        age += 10; //esto es igual a age = age + 10
        Console.WriteLine(age);
        age -= 5; //esto es igual a age = age - 5
        Console.WriteLine(age);
        age *= 2; //esto es igual a age = age * 2
        Console.WriteLine(age);
        age /= 4; //esto es igual a age = age / 4
        Console.WriteLine(age);
        age++; //esto es igual a age = age + 1
        Console.WriteLine(age);
        age--; //esto es igual a age = age - 1
        Console.WriteLine(age);

        int n1 = 10;
        int n2 = 3;
        Console.WriteLine(n1%n2); //esto es el resto de la division
        
    }
}

