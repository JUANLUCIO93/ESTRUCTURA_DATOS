using System;
using System.Collections.Generic;

//EJEMPLO DE GRAFO DIRIGIDO CON PESO 

class Arista
{
    public string Destino;
    public int Peso;

    public Arista(string destino, int peso)
    {
        Destino = destino;
        Peso = peso;
    }
}

class Program
{
    static void Main()
    {
        // Crear el grafo como un diccionario de listas de aristas
        Dictionary<string, List<Arista>> grafo = new Dictionary<string, List<Arista>>();

        // Agregar nodos y aristas con pesos
        grafo["A"] = new List<Arista> { new Arista("B", 3), new Arista("C", 1) };
        grafo["B"] = new List<Arista> { new Arista("C", 7), new Arista("D", 5) };
        grafo["C"] = new List<Arista> { new Arista("D", 2) };
        grafo["D"] = new List<Arista> { new Arista("A", 8) };

        // Mostrar el grafo
        Console.WriteLine("Grafo Dirigido con Pesos:");
        foreach (var nodo in grafo)
        {
            Console.Write($"{nodo.Key} -> ");
            foreach (var arista in nodo.Value)
            {
                Console.Write($"[{arista.Destino}, peso: {arista.Peso}] ");
            }
            Console.WriteLine();
        }
    }
}