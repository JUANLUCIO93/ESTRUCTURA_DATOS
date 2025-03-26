using System;

// Definición de un nodo del árbol binario
class Nodo
{
    public string Titulo;
    public Nodo Izquierda, Derecha;
    
    public Nodo(string titulo)
    {
        Titulo = titulo;
        Izquierda = Derecha = null;
    }
}

// Clase para manejar el árbol binario de búsqueda
class ArbolBinario
{
    public Nodo Raiz;
    
    public ArbolBinario()
    {
        Raiz = null;
    }
    
    // Método para insertar un nuevo título en el árbol
    public void Insertar(string titulo)
    {
        Raiz = InsertarRecursivo(Raiz, titulo);
    }

    private Nodo InsertarRecursivo(Nodo raiz, string titulo)
    {
        if (raiz == null)
        {
            return new Nodo(titulo);
        }
        if (string.Compare(titulo, raiz.Titulo, StringComparison.OrdinalIgnoreCase) < 0)
        {
            raiz.Izquierda = InsertarRecursivo(raiz.Izquierda, titulo);
        }
        else
        {
            raiz.Derecha = InsertarRecursivo(raiz.Derecha, titulo);
        }
        return raiz;
    }

    // Método para buscar un título en el árbol de manera recursiva
    public bool Buscar(string titulo)
    {
        return BuscarRecursivo(Raiz, titulo);
    }

    private bool BuscarRecursivo(Nodo raiz, string titulo)
    {
        if (raiz == null)
        {
            return false;
        }
        if (raiz.Titulo.Equals(titulo, StringComparison.OrdinalIgnoreCase))
        {
            return true;
        }
        if (string.Compare(titulo, raiz.Titulo, StringComparison.OrdinalIgnoreCase) < 0)
        {
            return BuscarRecursivo(raiz.Izquierda, titulo);
        }
        return BuscarRecursivo(raiz.Derecha, titulo);
    }
}

class Program
{
    static void Main()
    {
        ArbolBinario catalogo = new ArbolBinario();
        
        // Insertar 10 títulos en el árbol binario
        string[] titulos = {
            "salud",
            "Moda",
            "Maquillaje",
            "Bebe mejores vinos",
            "Viajes",
            "Mundo lenseria",
            "cotteleria",
            "Negocios tecnologicas",
            "tecnologias nueva generacion",
            "motocicletas de aventuras"
        };
        
        foreach (var titulo in titulos)
        {
            catalogo.Insertar(titulo);
        }

        while (true)
        {
            Console.WriteLine("\nMenú:");
            Console.WriteLine("1. Buscar un título");
            Console.WriteLine("2. Salir");
            Console.Write("Seleccione una opción: ");
            string opcion = Console.ReadLine();

            if (opcion == "2")
                break;
            else if (opcion == "1")
            {
                Console.Write("Ingrese el título a buscar: ");
                string titulo = Console.ReadLine();
                bool encontrado = catalogo.Buscar(titulo);
                Console.WriteLine(encontrado ? "Título encontrado" : "Título no encontrado");
            }
            else
            {
                Console.WriteLine("Opción no válida, intente nuevamente.");
            }
        }
    }
}
