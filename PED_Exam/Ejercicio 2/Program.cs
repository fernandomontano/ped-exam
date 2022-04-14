using System;

namespace Ejercicio_2
{
    class Program
    {
        public static AVL raiz = null;
        static void Main(string[] args)
        {
            AVL arbolito = new AVL();

           int[] valoresarbol = new int[] { 50,17,9,14,23,54,76,12,19,72,67 };
            for (int i = 0; i < valoresarbol.Length; i++)
            {
                arbolito.Insertar1(valoresarbol[i]);
            }
            arbolito.dibujararbol();
            arbolito.preordenrecursivo();
            Console.WriteLine();
            arbolito.inordenrecursivo();
            Console.WriteLine();
            arbolito.postordenrecursivo();
            Console.ReadKey();
        }
        public static void dibujaravl()
        {

        }
    }
}
