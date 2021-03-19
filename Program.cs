using ArbolPrimer.clases.ArbolBinario;
using ArbolPrimer.clases.arbolBinarioOrdenado;
using ArbolPrimer.clases.JuegoAnimal;
using System;
using System.Collections;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Xml;

namespace ArbolPrimer
{
    class Program
    {
        public static void preorden(nodo r) {
            if (r != null) {
                r.visitar();
                preorden(r.subarbolIzquierdo());
                preorden(r.subarbolDerecho());  
            } 
        }
        public static void inorden(nodo r) {
            if (r != null)
            {
                preorden(r.subarbolIzquierdo());
                r.visitar();
                preorden(r.subarbolDerecho());
            }
        }
        public static void posorden(nodo r) {
            if (r != null)
            {
                preorden(r.subarbolIzquierdo());
                preorden(r.subarbolDerecho());
                r.visitar();       
            }
        }
        public static void ObtieneNombreHojas(nodo r) {
            if (r != null)
            {
                ObtieneNombreHojas(r.subarbolDerecho());
                ObtieneNombreHojas(r.subarbolIzquierdo());
                string hojasT = r.cuentaHoja();
                if (hojasT != null) { Console.WriteLine(hojasT+ " Es una hoja"); }
            }
        }
        public static int contaNodo(nodo r) {
            int cuenta = 0;
            if (r.valorNodo() == null)
            {
                cuenta = 0;
            }
            else {
                cuenta = 1;
                if (r.subarbolDerecho() != null) {
                    cuenta += contaNodo(r.subarbolDerecho());
                }
                if (r.subarbolIzquierdo() != null) {
                    cuenta += contaNodo(r.subarbolIzquierdo());
                }
            }
            return cuenta;
        }
        public static int contaHoja(nodo r)
        {
            int cuenta = 0;
            if (r.subarbolDerecho() == null && r.subarbolIzquierdo() == null)
            {
                cuenta = 1;
            }
            else
            {
                if (r.subarbolDerecho() != null)
                {
                    cuenta += contaHoja(r.subarbolDerecho());
                }
                if (r.subarbolIzquierdo() != null)
                {
                    cuenta += contaHoja(r.subarbolIzquierdo());
                }
            }
            return cuenta;
        }
        public static void boolBasico() {
            try
            {
                ArbolBinario arbol;
                nodo a1, a2, a;
                Stack pila = new Stack();
                a1 = ArbolBinario.nuevoArbol(null, "Maria", null);
                a2 = ArbolBinario.nuevoArbol(null, "Fabrizio", null);
                a = ArbolBinario.nuevoArbol(a1, "Gaby", a2);
                pila.Push(a);// apilar
                a1 = ArbolBinario.nuevoArbol(null, "Andrea", null);
                a2 = ArbolBinario.nuevoArbol(null, "Abel", null);
                a = ArbolBinario.nuevoArbol(a1, "Monica", a2);
                pila.Push(a); //apilar}

                a1 = (nodo)pila.Pop();
                a2 = (nodo)pila.Pop();

                a = ArbolBinario.nuevoArbol(a1, "hector", a2);
                arbol = new ArbolBinario(a1);

                int pausa;
                pausa = 0;

                Console.WriteLine("preorden:");
                preorden(a);
                Console.WriteLine("posorden:");
                posorden(a);
                Console.WriteLine("Inorden");
                inorden(a);

                int nodos = contaNodo(a);
                Console.WriteLine("El arbol tiene: " + nodos + " nodos");
                int hojas = contaHoja(a);
                Console.WriteLine("El arbol tiene: " + hojas + " hojas");



            }
            catch (Exception ex)
            {
                Console.WriteLine("Hubo un error! " + ex.Message);
            }
        }
        public static void juegoAnimales() {
            Console.WriteLine("Jueguemos adivinar animales");
            Boolean otroJuego = true;
            AdivinaAnimal juego = new AdivinaAnimal();
            ManejoArchivos a = new ManejoArchivos();
            nodo b;
            DibujaArbol c = new DibujaArbol();
            do
            {
                Console.WriteLine("1. Jugar");
                Console.WriteLine("2. Ver grafo");
                string dato = Console.ReadLine();
                switch (dato) {
                    case "1":
                        juego.jugar();
                        Console.WriteLine("Jugamos otra vez");
                        otroJuego = juego.respuesta();
                        break;
                    case "2":
                        b = a.LlenaelArbol();
                        c.generarArbol( ref b);
                        Console.WriteLine("Su imagen está en: ");
                        Console.WriteLine("C:/Users/villa/Desktop/5to Semestre/Programación III/clases/ArbolPrimer/bin/Debug/netcoreapp3.1//ABB.png");
                        break;
                    default:
                        Console.WriteLine("a opcion no está crack");
                        break;
                }
                
                
                
               
            } while (otroJuego);
        }
        public static void pruebaOrden()
        {
            ArbolBinarioBusqueda ArBus = new ArbolBinarioBusqueda();
            int[] datos = { 30, 5, 2, 40, 36, 85, };
            SoloNumeros es = new SoloNumeros();
            foreach(int d in datos)
            {
                es.numero = d;
                es.descripcion = $"insertar No. {d}";
                ArBus.insertar(es);
                es = new SoloNumeros();
            }
            es = new SoloNumeros();
            es.numero = 36;
            es.descripcion = "cualquier cosa";
            ArBus.eliminar(es);
            int pausa;
            pausa = 0;
        }
        public static void PruebaCarne()
        {
            ArbolBinarioBusqueda arBus = new ArbolBinarioBusqueda();
            string[] carne = { "0905-19-12467", "0905-18-1720", "0905-20-1521", 
                               "0905-19-12468", "0905-17-1220", "0905-18-8826"};
            Estudiante es = new Estudiante();
            int num = 0;
            foreach(string d in carne)
            {
                num++;
                es.carnet = d;
                es.nombre = $"Estudiante No. {num}";
                arBus.insertar(es);
                es = new Estudiante();
            }
            int pausa;
            pausa = 0;
        }
        public static void PruebaNombreAlumno()
        {
            ArbolBinarioBusqueda arBus = new ArbolBinarioBusqueda();
            string[] carne = { "Erickson", "David", "Vanessa",
                               "Alex", "Marcos", "Dalila"};
            Estudiante es = new Estudiante();
            int num = 0;
            foreach (string d in carne)
            {
                num++;
                es.carnet = d;
                es.nombre = $"Estudiante No. {num}";
                arBus.insertar(es);
                es = new Estudiante();
            }           
            int pausa;
            pausa = 0;
        }
        static void Main(string[] args)
        {
            //  juegoAnimales();
             //pruebaOrden();
            // PruebaCarne();
            PruebaNombreAlumno();
        }
    }
}
