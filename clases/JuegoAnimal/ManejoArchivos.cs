using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using ArbolPrimer.clases.ArbolBinario;
using System.Runtime.CompilerServices;
using System.Collections;
using Newtonsoft.Json;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace ArbolPrimer.clases.JuegoAnimal
{
    class ManejoArchivos
    {
        private string direcc = @"C:\Users\villa\Desktop\5to Semestre\Programación III\Tareas\1er Parcial\\arbol.txt";
        private nodo n;
        public void guardaDatos2(nodo r)
        {

            StreamWriter leer = new StreamWriter(direcc);
            try
            {
                string dato = JsonConvert.SerializeObject(r);
                leer.WriteLine(dato);

            }
            catch (Exception ex)
            {
                Console.WriteLine("Fallo en guardarDatos " + ex.Message);
            }
            finally
            {
                leer.Close();
            }

        }
        public nodo LlenaelArbol() {
            StreamReader leer = new StreamReader(direcc);
            try
            {
                string dato = leer.ReadToEnd();
                n = JsonConvert.DeserializeObject<nodo>(dato);
            }
            catch (Exception ex)
            {
                Console.WriteLine("El error es: " + ex.Message);
            }
            finally {
                leer.Close();
            }
            return n;
        }


       
      
    }
}
