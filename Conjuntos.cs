using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        // Generamos un conjunto o listado ficticio de 500 ciudadanos.
        HashSet<string> ciudadanos = new HashSet<string>();
        for (int i = 1; i <= 500; i++)
        {
            ciudadanos.Add("Ciudadano" + i);
        }

        // Generamos el listado de ciudadanos vacunados con Pfizer
        HashSet<string> vacunadosPfizer = new HashSet<string>();
        for (int i = 1; i <= 75; i++)
        {
            vacunadosPfizer.Add("Ciudadano" + i);
        }

        // Generación de listado de ciudadanos vacunados con AstraZeneca
        HashSet<string> vacunadosAstraZeneca = new HashSet<string>();
        for (int i = 76; i <= 150; i++)
        {
            vacunadosAstraZeneca.Add("Ciudadano" + i);
        }

        // listado de Ciudadanos que recibieron ambas dosis
        HashSet<string> vacunadosAmbasDosis = new HashSet<string>(vacunadosPfizer.Intersect(vacunadosAstraZeneca));

        // listado de Ciudadanos vacunados con solo Pfizer
        HashSet<string> soloPfizer = new HashSet<string>(vacunadosPfizer.Except(vacunadosAstraZeneca));

        // generamos el listado de Ciudadanos vacunados con solo AstraZeneca
        HashSet<string> soloAstraZeneca = new HashSet<string>(vacunadosAstraZeneca.Except(vacunadosPfizer));

        // generamos el listado de Ciudadanos no vacunados
        HashSet<string> noVacunados = new HashSet<string>(ciudadanos.Except(vacunadosPfizer.Union(vacunadosAstraZeneca)));

        // Metodo para obtener resultdos de ciudanos vacunados, no vacunados, solo pfizer, solo Astrazeneca y de ambas dosis,tambien mostarmos resultados aleatoris de conjuntos ficticios que hemos creado.
        Console.WriteLine("Ciudadanos no vacunados: " + noVacunados.Count);
        Console.WriteLine("Ciudadanos con ambas dosis: " + vacunadosAmbasDosis.Count);
        Console.WriteLine("Ciudadanos vacunados solo con Pfizer: " + soloPfizer.Count);
        Console.WriteLine("Ciudadanos vacunados solo con AstraZeneca: " + soloAstraZeneca.Count);
    }
}
