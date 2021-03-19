using System;
using System.Collections.Generic;
using System.Text;

namespace ArbolPrimer.clases.ArbolBinario
{
    class nodo
    {
        public object dato;
        public nodo izquierda;
        public nodo derecha;
        //public nodo() { 
        //}

        public nodo(object valor) {
            dato = valor;
            izquierda = null;
            derecha = null;
        }
        public nodo(nodo ramaIzquierda, object valor, nodo ramaDerecha) {
            dato = valor;
            izquierda = ramaIzquierda;
            derecha = ramaDerecha;
        }

        public object valorNodo() {
            return dato;
        }
        public nodo subarbolDerecho() {
            return derecha;
        }
        public nodo subarbolIzquierdo() {
            return izquierda;
        }
        public void nuevoValor(object d) {
            dato = d;
        }
        public void ramaIzquierda(nodo i) {
            izquierda = i;
        }
        public void ramaDerecha(nodo de) {
            derecha = de;
        }
        public void visitar() {
            Console.WriteLine(dato + "<->");
        }
        public string cuentaHoja() {
            return this.izquierda == null && this.derecha == null ?  dato.ToString() : null;
        }
        public object devuelve() {
            return dato;
        }
    }
}
