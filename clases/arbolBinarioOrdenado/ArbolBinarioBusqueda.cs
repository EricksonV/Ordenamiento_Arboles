using System;
using System.Collections.Generic;
using System.Text;
using ArbolPrimer.clases.ArbolBinario;
using Newtonsoft.Json.Serialization;

namespace ArbolPrimer.clases.arbolBinarioOrdenado
{
    class ArbolBinarioBusqueda : ArbolBinario.ArbolBinario
    {
        public ArbolBinarioBusqueda() : base() {
            
        }
        public nodo buscar(object buscado) {
            Comparador dato;
            dato = (Comparador)buscado;
            if (raiz == null) {
                return null;
            }
            else
            {
                return localizar(raizArbol(), dato);
            }
        }//end buscar
        protected nodo localizar(nodo raizSub,Comparador buscado)
        {
            if (raizSub == null)
            {
                return null;
            }
            else if (buscado.igualQue(raizSub.valorNodo()))
            {
                return raiz;
            }
            else if (buscado.menorQue(raizSub.valorNodo()))
            {
                return localizar(raizSub.subarbolIzquierdo(), buscado);
            }
            else {
                return localizar(raizSub.subarbolDerecho(), buscado);
            }
        }//end localizar
        public void insertar(Object valor)
        {
            Comparador dato;
            dato = (Comparador)valor;
            raiz = insertar(raiz, dato);
        }
        protected nodo insertar(nodo raizSub, Comparador dato) {
            if (raizSub == null) {
                raizSub = new nodo(dato);
            }else if (dato.menorIgualQue(raizSub.valorNodo()))
            {
                nodo iz;
                iz = insertar(raizSub.subarbolIzquierdo(), dato);
                raizSub.ramaIzquierda(iz);
            }else if (dato.mayorQue(raizSub.valorNodo()))
            {
                nodo dr;
                dr = insertar(raizSub.subarbolDerecho(), dato);
                raizSub.ramaDerecha(dr);
            }
            return raizSub;
        }//end insertar
        public void eliminar(object valor)
        {
            Comparador dato;
            dato = (Comparador)valor;
            raiz = eliminar(raiz, dato);
        }
        protected nodo eliminar(nodo raizSub, Comparador dato)
        {
            if(raizSub == null)
            {
                throw new Exception("No hay nodo para eliminar");
            }
            else if (dato.menorQue(raizSub.valorNodo())) 
            {
                nodo iz;
                iz = eliminar(raizSub.subarbolIzquierdo(), dato);
                raizSub.ramaIzquierda(iz);
                
            }else if (dato.mayorQue(raizSub.valorNodo()))
            {
                nodo dr;
                dr = eliminar(raizSub.subarbolDerecho(), dato);
                raizSub.ramaDerecha(dr);
            }
            else
            {
                nodo q;
                q = raizSub; //este es el nodo que se quita del árbol
                if (q.subarbolIzquierdo() == null) {
                    raizSub = q.subarbolDerecho();
                }else if(q.subarbolDerecho()== null)
                {
                    raizSub = q.subarbolIzquierdo();
                }
                else// tiene rama izquierda y derecha
                {
                    q = reemplazar(q);
                }
                q = null;
            }
            return raizSub;
        }//end eliminar
        protected nodo reemplazar(nodo act)
        {
            nodo a, p;
            p = act;
            a = act.subarbolIzquierdo(); //rama de nodos menores
            
            while(a.subarbolDerecho()!= null)
            {
                p = a;
                p.subarbolDerecho();
            }
            act.nuevoValor(a.valorNodo());
            if(p == act)
            {
                p.ramaIzquierda(a.subarbolIzquierdo());
            }
            else
            {
                p.ramaDerecha(a.subarbolDerecho());
            }
            return a;
        }//end nodo reemplazar 

    }//end class
}
