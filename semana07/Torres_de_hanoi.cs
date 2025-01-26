using System;

class Program
{
    static void Main()
    {
        int numberOfDisks = 3; // Puedes cambiar el número de discos
        SolveHanoi(numberOfDisks, 'A', 'C', 'B');
    }

    static void SolveHanoi(int n, char source, char target, char auxiliary)
    {
        if (n == 1)
        {
            Console.WriteLine($"Mover disco 1 de {source} a {target}");
            return;
        }
        
        SolveHanoi(n - 1, source, auxiliary, target);
        Console.WriteLine($"Mover disco {n} de {source} a {target}");
        SolveHanoi(n - 1, auxiliary, target, source);
    }
}
