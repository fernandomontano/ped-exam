using System;
using System.Collections.Generic;
using System.Text;

namespace Ejercicio_2
{
    class AVL
    {
        public int valor;
        public AVL nodoizquierdo;
        public AVL nododerecho;
        public AVL nodopadre;
        public int altura;
        public AVL()
        {

        }
        AVL raiz = null;
        public void Insertar1(int dato)
        {

            if (raiz == null)
            {
                raiz = new AVL(dato, null, null, null);
            }
            else
            {
                raiz = raiz.Insertar(dato, raiz);
            }
        }
        public void preordenrecursivo()
        {
            Console.WriteLine("\tPre-orden");
            Console.Write("  ");
            preorden(raiz);
        }
        public void preorden(AVL raiz)
        {
            if (raiz != null)
            {
                Console.Write(raiz.valor.ToString() +" - ");
                preorden(raiz.nodoizquierdo);
                preorden(raiz.nododerecho);
            }
        }
        public void inordenrecursivo()
        {
            Console.WriteLine("\tIn-orden");
            Console.Write("  ");
            inorden(raiz);
        }
        public void inorden(AVL raiz)
        {
            if (raiz != null)
            {
                inorden(raiz.nodoizquierdo);
                Console.Write(raiz.valor.ToString() + " - ");
                inorden(raiz.nododerecho);
            }
        }
        public void postordenrecursivo()
        {
            Console.WriteLine("\tPost-orden");
            Console.Write("  ");
            postorden(raiz);
        }
        public void postorden(AVL raiz)
        {
            if (raiz != null)
            {
                postorden(raiz.nodoizquierdo);
                postorden(raiz.nododerecho);
                Console.Write(raiz.valor.ToString() + " - ");
            }
        }
        public void dibujararbol()
        {
            Console.WriteLine("Dibujo de árbol (horizontalmente)");
            dibujar(raiz, 0);
        }
        public void dibujar(AVL arbol, int cont)
        {
            if (arbol == null)
            {
                return;
            }
            else
            {
                dibujar(arbol.nododerecho, cont + 1);
                for (int i = 0; i < cont; i++)
                {
                    Console.Write("\t");
                }
                Console.WriteLine(arbol.valor);
                dibujar(arbol.nodoizquierdo, cont + 1);
            }

        }
        public AVL (int valornuevo, AVL izquierdo, AVL derecho, AVL padre)
        {
            valor = valornuevo;
            nodoizquierdo = izquierdo;
            nododerecho = derecho;
            nodopadre = padre;
            altura = 0;
        }
        public AVL Insertar(int pvalornuevo, AVL praiz)
        {
            if (praiz == null)
            {
                praiz = new AVL(pvalornuevo, null, null, null);
            }
            else if (pvalornuevo < praiz.valor)
            {
                praiz.nodoizquierdo = Insertar(pvalornuevo, praiz.nodoizquierdo);
            }
            else if (pvalornuevo > praiz.valor)
            {
                praiz.nododerecho = Insertar(pvalornuevo, praiz.nododerecho);
            }
            else
            {
                Console.WriteLine("Ya existe el valor");
            }
            if (alturas(praiz.nodoizquierdo) - alturas(praiz.nododerecho) == 2)
            {
                if (pvalornuevo < praiz.nodoizquierdo.valor) praiz = rotacionizquierdasimple(praiz);
                else praiz = rotacionizquierdadoble(praiz);
            }
            if (alturas(praiz.nododerecho) - alturas(praiz.nodoizquierdo) == 2)
            {
                if (pvalornuevo > praiz.nododerecho.valor) praiz = rotacionderechasimple(praiz);
                else praiz = rotacionderechadoble(praiz);
            }
            praiz.altura = max(alturas(praiz.nodoizquierdo), alturas(praiz.nododerecho)) + 1;
            return praiz;
        }

        private static int max(int lhs, int rhs)
        {
            return lhs > rhs ? lhs : rhs;
        }
        private static int alturas (AVL raiz)
        {
            return raiz == null ? -1 : raiz.altura;
        }
 
        private static AVL rotacionizquierdasimple(AVL k2)
        {
            AVL k1 = k2.nodoizquierdo;
            k2.nodoizquierdo = k1.nododerecho;
            k1.nododerecho = k2;
            k2.altura = max(alturas(k2.nodoizquierdo), alturas(k2.nododerecho)) + 1;
            k1.altura = max(alturas(k1.nodoizquierdo), k2.altura) + 1;
            return k1;
        }
        private static AVL rotacionderechasimple(AVL k1)
        {
            AVL k2 = k1.nododerecho;
            k1.nododerecho = k2.nodoizquierdo;
            k2.nodoizquierdo = k1;
            k1.altura = max(alturas(k1.nodoizquierdo), alturas(k1.nododerecho)) + 1;
            k2.altura = max(alturas(k2.nododerecho), k1.altura) + 1;
            return k2;
        }
        private static AVL rotacionizquierdadoble(AVL k3)
        {
            k3.nodoizquierdo = rotacionderechasimple(k3.nodoizquierdo);
            return rotacionizquierdasimple(k3);
        }
        private static AVL rotacionderechadoble(AVL k4)
        {
            k4.nododerecho = rotacionizquierdasimple(k4.nododerecho);
            return rotacionderechasimple(k4);
        }
        public int getaltura(AVL nodoactual)
        {
            if (nodoactual == null)
            {
                return 0;
            }
            else
            {
                return 1 + Math.Max(getaltura(nodoactual.nodoizquierdo), getaltura(nodoactual.nododerecho));
            }
        }
        public void buscar(int valorbuscar, AVL raiz)
        {
            if (raiz != null)
            {
                if (valorbuscar < raiz.valor)
                {
                    buscar(valorbuscar, raiz.nodoizquierdo);
                }
                else
                {
                    if (valorbuscar > raiz.valor)
                    {
                        buscar(valorbuscar, raiz.nododerecho);
                    }
                }
            }
            else
            {
                Console.WriteLine("Valor no encontrado");
            }  
        }
    }
}
