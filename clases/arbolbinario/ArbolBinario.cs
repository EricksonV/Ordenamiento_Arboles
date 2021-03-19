using System;
using System.Collections.Generic;
using System.Text;

namespace ArbolPrimer.clases.ArbolBinario
{
    class ArbolBinario
    {
        public nodo raiz;

        public ArbolBinario() {
            raiz = null;
        }
        public ArbolBinario(nodo ValorRaiz) {
            this.raiz = ValorRaiz;
        }
        public nodo raizArbol() {
            return raiz;
        }
        bool esVacio() {
            return raiz == null;
        }
        public static nodo nuevoArbol(nodo ramaIzqda, object dato, nodo ramaDrcha) {
            return new nodo(ramaIzqda, dato, ramaDrcha);
        }
    }
}
