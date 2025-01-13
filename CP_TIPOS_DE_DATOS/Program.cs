using System;
using System.Collections.Generic;

// Clase que representa un contacto en la agenda
class Contacto
{
    public string Nombre { get; set; }  // Propiedad para el nombre del contacto
    public string Telefono { get; set; } // Propiedad para el número de teléfono

    // Constructor de la clase Contacto
    public Contacto(string nombre, string telefono)
    {
        Nombre = nombre;
        Telefono = telefono;
    }

    // Método para mostrar la información del contacto
    public void MostrarInformacion()
    {
        Console.WriteLine($"Nombre: {Nombre}, Teléfono: {Telefono}");
    }
}

// Clase que representa la agenda telefónica
class Agenda
{
    private List<Contacto> contactos; // Lista para almacenar los contactos

    // Constructor de la clase Agenda
    public Agenda()
    {
        contactos = new List<Contacto>(); // Inicializa la lista de contactos
    }

    // Método para agregar un nuevo contacto a la agenda
    public void AgregarContacto(string nombre, string telefono)
    {
        Contacto nuevoContacto = new Contacto(nombre, telefono);
        contactos.Add(nuevoContacto); // Añade el contacto a la lista
        Console.WriteLine("Contacto agregado.");
    }

    // Método para mostrar todos los contactos en la agenda
    public void MostrarContactos()
    {
        Console.WriteLine("Lista de Contactos:");
        foreach (var contacto in contactos)
        {
            contacto.MostrarInformacion(); // Muestra la información de cada contacto
        }
    }

    // Método para buscar un contacto por nombre
    public void BuscarContacto(string nombre)
    {
        var encontrado = false; // Bandera para verificar si se encontró el contacto

        foreach (var contacto in contactos)
        {
            if (contacto.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase))
            {
                contacto.MostrarInformacion(); // Muestra el contacto encontrado
                encontrado = true;
                break;
            }
        }

        if (!encontrado)
        {
            Console.WriteLine("Contacto no encontrado.");
        }
    }
}

// Clase principal que ejecuta el programa
class Program
{
    static void Main(string[] args)
    {
        Agenda agenda = new Agenda(); // Crea una nueva instancia de Agenda

        while (true) // Bucle infinito para interactuar con el usuario
        {
            Console.WriteLine("\n--- Agenda Telefónica ---");
            Console.WriteLine("1. Agregar Contacto");
            Console.WriteLine("2. Mostrar Contactos");
            Console.WriteLine("3. Buscar Contacto");
            Console.WriteLine("4. Salir");
            Console.Write("Seleccione una opción: ");
            
            string opcion = Console.ReadLine(); // Lee la opción seleccionada

            switch (opcion)
            {
                case "1":
                    Console.Write("Ingrese el nombre del contacto: ");
                    string nombre = Console.ReadLine();
                    Console.Write("Ingrese el teléfono del contacto: ");
                    string telefono = Console.ReadLine();
                    agenda.AgregarContacto(nombre, telefono); // Agrega el nuevo contacto
                    break;

                case "2":
                    agenda.MostrarContactos(); // Muestra todos los contactos
                    break;

                case "3":
                    Console.Write("Ingrese el nombre del contacto a buscar: ");
                    string nombreBuscar = Console.ReadLine();
                    agenda.BuscarContacto(nombreBuscar); // Busca el contacto por nombre
                    break;

                case "4":
                    return; // Sale del programa

                default:
                    Console.WriteLine("Opción no válida. Intente nuevamente.");
                    break;
            }
        }
    }
}
