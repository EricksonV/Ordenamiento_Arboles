using ArbolPrimer.clases.ArbolBinario;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;


namespace ArbolPrimer.clases.JuegoAnimal
{
    class AdivinaAnimal
    {
        private static nodo raiz;
        private ManejoArchivos a = new ManejoArchivos();
        //public AdivinaAnimal()
        //{
        //    raiz = new nodo("Elefante");
        //}
        public void Llena()
        {

            raiz = a.LlenaelArbol();
        }
        public void jugar()
        {
            Llena();
            nodo Nodo = raiz;
            while (Nodo != null)
            {//iteración del arbol
                a.guardaDatos2(Nodo);
                if (Nodo.izquierda != null)
                { //existe una pregunta                       
                    Console.WriteLine(Nodo.valorNodo());
                    Nodo = (respuesta()) ? Nodo.izquierda : Nodo.derecha;
                    
                }
                else
                {
                   
                    Console.WriteLine($"Ya se, ¿es un {Nodo.valorNodo()}?");
                    if (respuesta())
                    {
                        Console.WriteLine("Gané :)");
                    }
                    else
                    {
                        
                        animalNuevo(Nodo);
                        
                    }
                    
                    Nodo = null;
                    
                    return;
                }//fin if  
                
            }//fin while
        }//fin jugar

        public bool respuesta() {
            while (true) {
                String resp = Console.ReadLine().ToLower().Trim();
                if (resp.Equals("si")) return true;
                if (resp.Equals("no")) return false;
                Console.WriteLine("La respuesta debe ser si o no");
            }
            
        }//fin de respuesta

        private void animalNuevo(nodo r) {
            
            String animalnodo = (String)r.valorNodo();
            Console.WriteLine("¿Cuál es tu animal pues?");
            String nuevoA = Console.ReadLine();
            Console.WriteLine($"Qué pregunta con respuesta si/no puedo hacer para poder decir que es un {nuevoA}");
            string pregunta = Console.ReadLine();
            nodo nodo1 = new nodo(animalnodo);
            nodo nodo2 = new nodo(nuevoA);
            Console.WriteLine($"para un(a) {nuevoA} la respuesta es si/no?");
            r.nuevoValor(pregunta);

            if (respuesta()){
                r.izquierda = nodo2;
                r.derecha = nodo1;               
            }
            else
            {
                r.izquierda = nodo1;
                r.derecha = nodo2;
            }
            
        }

    }
}
