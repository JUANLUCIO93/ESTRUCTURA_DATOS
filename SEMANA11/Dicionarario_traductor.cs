using System;
using System.Collections.Generic;

class Traductor
{
    // Diccionario para almacenar palabras en inglés y su traducción al español
    static Dictionary<string, string> diccionario = new Dictionary<string, string>
    {
        { "time", "tiempo" }, { "person", "persona" }, { "year", "año" },
        { "way", "camino/forma" }, { "day", "día" }, { "thing", "cosa" },
        { "man", "hombre" }, { "world", "mundo" }, { "life", "vida" },
        { "hand", "mano" }, { "part", "parte" }, { "child", "niño/a" },
        { "eye", "ojo" }, { "woman", "mujer" }, { "place", "lugar" },
        { "work", "trabajo" }, { "week", "semana" }, { "case", "caso" },
        { "point", "punto/tema" }, { "government", "gobierno" }, { "company", "empresa/compañía" }
    };

    static void Main()
    {
        int opcion;
        do
        {
            // Mostrar menú de opciones
            Console.WriteLine("\nMENU");
            Console.WriteLine("=================================================================");
            Console.WriteLine("1. Traducir una frase");
            Console.WriteLine("2. Ingresar más palabras al diccionario");
            Console.WriteLine("0. Salir");
            Console.Write("Seleccione una opción: ");
            
            if (!int.TryParse(Console.ReadLine(), out opcion))
            {
                Console.WriteLine("Opción no válida. Intente de nuevo.");
                continue;
            }

            switch (opcion)
            {
                case 1:
                    TraducirFrase(); // Llamar al método para traducir la frase
                    break;
                case 2:
                    AgregarPalabra(); // Llamar al método para agregar palabras al diccionario
                    break;
                case 0:
                    Console.WriteLine("Saliendo del programa...");
                    break;
                default:
                    Console.WriteLine("Opción no válida. Intente de nuevo.");
                    break;
            }
        } while (opcion != 0);
    }

    static void TraducirFrase()
    {
        Console.Write("Ingrese la frase: ");
        string frase = Console.ReadLine();
        string[] palabras = frase.Split(' ');
        
        // Recorrer cada palabra de la frase
        for (int i = 0; i < palabras.Length; i++)
        {
            string palabra = palabras[i].ToLower(); // Convertir a minúsculas para comparación
            if (diccionario.ContainsKey(palabra))
            {
                palabras[i] = diccionario[palabra]; // Reemplazar con la traducción si existe en el diccionario
            }
        }

        // Mostrar la frase traducida
        Console.WriteLine("Su frase traducida es: " + string.Join(" ", palabras));
    }

    static void AgregarPalabra()
    {
        Console.Write("Ingrese la palabra en inglés: ");
        string palabraIngles = Console.ReadLine().ToLower();
        
        if (diccionario.ContainsKey(palabraIngles))
        {
            Console.WriteLine("Esta palabra ya existe en el diccionario.");
            return;
        }

        Console.Write("Ingrese la traducción en español: ");
        string palabraEspanol = Console.ReadLine().ToLower();
        
        // Agregar la nueva palabra al diccionario
        diccionario.Add(palabraIngles, palabraEspanol);
        Console.WriteLine("Palabra agregada exitosamente!");
    }
}