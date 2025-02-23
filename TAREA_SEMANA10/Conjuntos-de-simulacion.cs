using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        // Generación de datos ficticios
        HashSet<string> ciudadanos = GenerarCiudadanos(500);
        HashSet<string> vacunadosPfizer = GenerarCiudadanos(75);
        HashSet<string> vacunadosAstrazeneca = GenerarCiudadanos(75);
        HashSet<string> vacunadosAmbos = GenerarCiudadanos(100);
        
        // Ciudadanos vacunados con ambas dosis (asumimos que ambos conjuntos contienen ciudadanos únicos)
        HashSet<string> vacunadosDosDosis = new HashSet<string>(vacunadosAmbos);
        
        // Ciudadanos vacunados con solo Pfizer
        HashSet<string> soloPfizer = new HashSet<string>(vacunadosPfizer);
        soloPfizer.ExceptWith(vacunadosAstrazeneca);
        soloPfizer.ExceptWith(vacunadosDosDosis);
        
        // Ciudadanos vacunados con solo Astrazeneca
        HashSet<string> soloAstrazeneca = new HashSet<string>(vacunadosAstrazeneca);
        soloAstrazeneca.ExceptWith(vacunadosPfizer);
        soloAstrazeneca.ExceptWith(vacunadosDosDosis);
        
        // Ciudadanos no vacunados
        HashSet<string> noVacunados = new HashSet<string>(ciudadanos);
        noVacunados.ExceptWith(vacunadosPfizer);
        noVacunados.ExceptWith(vacunadosAstrazeneca);
        noVacunados.ExceptWith(vacunadosDosDosis);
        
        // Impresión de resultados
        Console.WriteLine("Listado de ciudadanos no vacunados: " + noVacunados.Count);
        Console.WriteLine("Listado de ciudadanos con dos dosis: " + vacunadosDosDosis.Count);
        Console.WriteLine("Listado de ciudadanos vacunados solo con Pfizer: " + soloPfizer.Count);
        Console.WriteLine("Listado de ciudadanos vacunados solo con Astrazeneca: " + soloAstrazeneca.Count);
    }

    static HashSet<string> GenerarCiudadanos(int cantidad)
    {
        HashSet<string> ciudadanos = new HashSet<string>();
        Random rnd = new Random();
        while (ciudadanos.Count < cantidad)
        {
            ciudadanos.Add("Ciudadano_" + rnd.Next(1, 10000));
        }
        return ciudadanos;
    }
}
