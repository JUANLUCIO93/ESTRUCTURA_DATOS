using System;
using System.Collections.Generic;

namespace AuditorioCongreso
{
    // Clase que representa a un asistente
    public class Asistente
    {
        public string Nombre { get; set; }

        public Asistente(string nombre)
        {
            Nombre = nombre;
        }
    }

    // Clase que representa el sistema de registro
    public class SistemaRegistro
    {
        private Queue<Asistente> colaAsistentes; // Cola para gestionar la llegada de asistentes
        private int totalAsientos; // Total de asientos disponibles
        private int asientosOcupados; // Contador de asientos ocupados

        public SistemaRegistro(int totalAsientos)
        {
            this.totalAsientos = totalAsientos;
            this.asientosOcupados = 0;
            this.colaAsistentes = new Queue<Asistente>();
        }

        // Método para registrar un nuevo asistente
        public void RegistrarAsistente(string nombre)
        {
            if (asientosOcupados < totalAsientos)
            {
                Asistente nuevoAsistente = new Asistente(nombre);
                colaAsistentes.Enqueue(nuevoAsistente);
                Console.WriteLine($"Asistente {nombre} registrado en la cola.");
            }
            else
            {
                Console.WriteLine("No hay asientos disponibles.");
            }
        }

        // Método para asignar asientos a los asistentes en orden
        public void AsignarAsientos()
        {
            while (colaAsistentes.Count > 0 && asientosOcupados < totalAsientos)
            {
                Asistente asistente = colaAsistentes.Dequeue();
                asientosOcupados++;
                Console.WriteLine($"Asiento asignado a {asistente.Nombre}. Asientos ocupados: {asientosOcupados}/{totalAsientos}");
            }
        }

        // Método para mostrar la cantidad de asistentes en la cola
        public void MostrarCola()
        {
            Console.WriteLine($"Total de asistentes en la cola: {colaAsistentes.Count}");
            foreach (var asistente in colaAsistentes)
            {
                Console.WriteLine($"- {asistente.Nombre}");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            SistemaRegistro sistema = new SistemaRegistro(100); // Crear sistema con 100 asientos

            // Simulación de registro de asistentes
            for (int i = 1; i <= 30; i++)
            {
                sistema.RegistrarAsistente($"Asistente {i}");
            }

            // Mostrar la cola de asistentes
            sistema.MostrarCola();

            // Asignar asientos
            sistema.AsignarAsientos();

            // Mostrar la cola después de asignar asientos
            sistema.MostrarCola();
        }
    }
}
