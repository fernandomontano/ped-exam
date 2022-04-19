using System;

namespace Ejercicio_2
{
    class Program
    {
        static void Main(string[] args)
        {
            AVL arbolito = new AVL();
            Console.Title = "Árbol AVL";
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("Ejercicio 1\n");
            //array que contiene los valores a ingresar al árbol, con la ayuda de un bucle for
           int[] valoresarbol = new int[] { 50,17,9,14,23,54,76,12,19,72,67 };
            for (int i = 0; i < valoresarbol.Length; i++)
            {
                arbolito.Insertar1(valoresarbol[i]);
            }
            //impresión de resultados
            Console.ForegroundColor = ConsoleColor.Black;
            arbolito.dibujararbol();
            Console.WriteLine("\n");
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("Recorridos:\n");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            arbolito.inordenrecursivo();
            Console.WriteLine("\n");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            arbolito.preordenrecursivo();
            Console.WriteLine("\n");
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            arbolito.postordenrecursivo();
            Console.ReadKey();
            
        }
    }
}
