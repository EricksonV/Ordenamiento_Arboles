using ArbolPrimer.clases.ArbolBinario;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace ArbolPrimer.clases.JuegoAnimal
{
    class DibujaArbol
    {
        public void generarArbol(ref nodo r) {
            string acum = "digraph G{\n";
            if (r != null) {
                acum += r.dato + ";\n";
                recorrerABB(r, ref acum);
            }
            acum += "\n}\n";
            const string f = "ABB.dot";
            StreamWriter w = new StreamWriter(f);
            w.WriteLine(acum);
            w.Close();
            generarImagen("ABB.dot", "ABB.png");
        }
        public void recorrerABB(nodo r, ref string acum) {
            if (r != null) {
                if (r.izquierda != null) {
                    acum += r.dato + "->" + r.izquierda.dato + ";\n";
                }
                if (r.derecha != null) {
                    acum += r.dato + "->" + r.derecha.dato + ";\n";
                }
                recorrerABB(r.izquierda, ref acum);
                recorrerABB(r.derecha, ref acum);
            }
        }
        public void generarImagen(string nombArchivo, string nombImagen) {
            Process a = new Process();
            a.StartInfo.FileName = @"C:\Program Files\Graphviz\bin\\dot.exe";
            a.StartInfo.Arguments = "dot -Tpng " + nombArchivo + " -o " + nombImagen;
            a.StartInfo.UseShellExecute = false;
            a.Start();
            a.WaitForExit();
        }
    }
}
