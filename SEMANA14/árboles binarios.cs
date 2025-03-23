// Definición de un nodo del árbol binario
class Nodo
{
    public int Valor;
    public Nodo Izquierdo, Derecho;
    
    public Nodo(int valor)
    {
        Valor = valor;
        Izquierdo = Derecho = null;
    }
}

// Definición de la clase del árbol binario
class ArbolBinario
{
    private Nodo raiz;

    public ArbolBinario()
    {
        raiz = null;
    }

    // Método para insertar un nodo en el árbol
    public void Insertar(int valor)
    {
        raiz = InsertarRec(raiz, valor);
    }

    private Nodo InsertarRec(Nodo raiz, int valor)
    {
        if (raiz == null)
        {
            return new Nodo(valor);
        }
        if (valor < raiz.Valor)
        {
            raiz.Izquierdo = InsertarRec(raiz.Izquierdo, valor);
        }
        else if (valor > raiz.Valor)
        {
            raiz.Derecho = InsertarRec(raiz.Derecho, valor);
        }
        return raiz;
    }

    // Método para buscar un valor en el árbol
    public bool Buscar(int valor)
    {
        return BuscarRec(raiz, valor);
    }

    private bool BuscarRec(Nodo raiz, int valor)
    {
        if (raiz == null)
        {
            return false;
        }
        if (raiz.Valor == valor)
        {
            return true;
        }
        return valor < raiz.Valor ? BuscarRec(raiz.Izquierdo, valor) : BuscarRec(raiz.Derecho, valor);
    }

    // Método para recorrer el árbol en orden
    public void InOrden()
    {
        InOrdenRec(raiz);
        Console.WriteLine();
    }

    private void InOrdenRec(Nodo raiz)
    {
        if (raiz != null)
        {
            InOrdenRec(raiz.Izquierdo);
            Console.Write(raiz.Valor + " ");
            InOrdenRec(raiz.Derecho);
        }
    }
}

class Program
{
    static void Main()
    {
        ArbolBinario arbol = new ArbolBinario();
        int opcion, valor;

        do
        {
            Console.WriteLine("\nMenú de Operaciones del Árbol Binario");
            Console.WriteLine("1. Insertar");
            Console.WriteLine("2. Buscar");
            Console.WriteLine("3. Recorrer en orden");
            Console.WriteLine("4. Salir");
            Console.Write("Seleccione una opción: ");
            opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    Console.Write("Ingrese un valor a insertar: ");
                    valor = int.Parse(Console.ReadLine());
                    arbol.Insertar(valor);
                    break;
                case 2:
                    Console.Write("Ingrese un valor a buscar: ");
                    valor = int.Parse(Console.ReadLine());
                    Console.WriteLine(arbol.Buscar(valor) ? "Valor encontrado" : "Valor no encontrado");
                    break;
                case 3:
                    Console.WriteLine("Recorrido en orden:");
                    arbol.InOrden();
                    break;
                case 4:
                    Console.WriteLine("Saliendo del programa...");
                    break;
                default:
                    Console.WriteLine("Opción no válida");
                    break;
            }
        } while (opcion != 4);
    }
}
