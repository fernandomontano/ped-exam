using System;

namespace Ejercicio_2
{
    class Program
    {
        public static AVL raiz = null;
        static void Main(string[] args)
        {
            AVL arbolito = new AVL();
            Console.Title = "Árbol AVL";
            Console.BackgroundColor = ConsoleColor.White;
            Console.Clear();
           int[] valoresarbol = new int[] { 50,17,9,14,23,54,76,12,19,72,67 };
            for (int i = 0; i < valoresarbol.Length; i++)
            {
                arbolito.Insertar1(valoresarbol[i]);
            }
            Console.ForegroundColor = ConsoleColor.Black;
            arbolito.dibujararbol();
            Console.WriteLine("\n");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            arbolito.preordenrecursivo();
            Console.WriteLine("\n");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            arbolito.inordenrecursivo();
            Console.WriteLine("\n");
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            arbolito.postordenrecursivo();
            Console.ReadKey();
        }
    }
}
