using System;
using System.Collections.Generic;

//EJEMPLO DE GRAFO NO DIRIGIDO 
class Program
{
    static void Main()
    {
        // Crear el grafo como un diccionario de listas de adyacencia
        Dictionary<string, List<string>> grafo = new Dictionary<string, List<string>>();

        // Agregar vértices y aristas
        grafo["A"] = new List<string> { "B", "C" };
        grafo["B"] = new List<string> { "A", "D", "E" };
        grafo["C"] = new List<string> { "A", "F" };
        grafo["D"] = new List<string> { "B" };
        grafo["E"] = new List<string> { "B", "F" };
        grafo["F"] = new List<string> { "C", "E" };

        // Mostrar el grafo
        Console.WriteLine("Grafo No Dirigido:");
        foreach (var nodo in grafo)
        {
            Console.Write($"{nodo.Key} -> ");
            Console.WriteLine(string.Join(", ", nodo.Value));
        }
    }
}