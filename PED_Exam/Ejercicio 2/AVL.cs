using System;
using System.Collections.Generic;
using System.Text;

namespace Ejercicio_2
{
    class AVL
    {
        //declarando nodos y variables 
        public int valor;
        public AVL nodoizquierdo;
        public AVL nododerecho;
        public AVL nodopadre;
        public int altura;
        AVL raiz = null;

        //constructor
        public AVL()
        {

        }

        //método auxiliar para insertar dato
        public void Insertar1(int dato)
        {

            if (raiz == null)
            {
                raiz = new AVL(dato, null, null, null);
            }
            else
            {
                raiz = raiz.Insertar(dato, raiz); //recursividad para insertar los nodos
            }
        }
        
        //constructor que recibe parámetros para la inserción
        public AVL (int valornuevo, AVL izquierdo, AVL derecho, AVL padre)
        {
            valor = valornuevo;
            nodoizquierdo = izquierdo;
            nododerecho = derecho;
            nodopadre = padre;
            altura = 0;
        }

        //Inserta y equilibra los nodos en el árbol
        public AVL Insertar(int pvalornuevo, AVL praiz)
        {
            if (praiz == null)
            {
                praiz = new AVL(pvalornuevo, null, null, null); //si el árbol está vació
            }
            else if (pvalornuevo < praiz.valor)
            {
                //condición para subárbol izquierdo
                praiz.nodoizquierdo = Insertar(pvalornuevo, praiz.nodoizquierdo); 
            }
            else if (pvalornuevo > praiz.valor)
            {
                //condición para subárbol derecho
                praiz.nododerecho = Insertar(pvalornuevo, praiz.nododerecho);
            }
            else
            {
                Console.WriteLine("Ya existe el valor");
            }
            //los ifs se aseguran que las alturas no tengan una diferencia mayor a dos
            if (alturas(praiz.nodoizquierdo) - alturas(praiz.nododerecho) == 2)
            {
                //realiza las rotaciones si el árbol se desequilibra con la nueva inserción
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

        //devuelve la altura máxima de las ramas
        private static int max(int lhs, int rhs)
        {
            return lhs > rhs ? lhs : rhs;
        }
        //devuelve la altura actual de la rama
        private static int alturas (AVL raiz)
        {
            return raiz == null ? -1 : raiz.altura;
        }
 
        //Rotaciones para equilibrar el árbol
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
                //recorrido pre orden: raíz, subárbol izquierdo, subárbol derecho
                Console.Write(raiz.valor.ToString() + " - ");
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
                //recorrido in orden: subárbol izquierdo, raiz, subárbol derecho
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
                //recorrido in orden: subárbol izquierdo, subárbol derecho, raíz
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
        //método recursivo para dibujar el árbol: primero el subárbol derecho, luego la raíz, luego el izquierdo
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
    }
}
