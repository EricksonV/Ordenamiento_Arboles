using System;
using System.Collections.Generic;
using System.Text;

namespace ArbolPrimer.clases.arbolBinarioOrdenado
{
    class Estudiante : Comparador
    { 
        public string carnet;
        public string nombre;       
        public bool igualQue(object q)
        {
            Estudiante p2 = (Estudiante)q;
            return (carnet.CompareTo(p2.carnet) == 0);
        }

        public bool mayorIgualQue(object q)
        {
            Estudiante p2 = (Estudiante)q;
            return (carnet.CompareTo(p2.carnet)==1);
        }

        public bool mayorQue(object q)
        {
            Estudiante p2 = (Estudiante)q;
            return (carnet.CompareTo(p2.carnet) == 1);
        }

        public bool menorIgualQue(object q)
        {
            Estudiante p2 = (Estudiante)q;
            return (carnet.CompareTo(p2.carnet) == -1);
        }

        public bool menorQue(object q)
        {
            Estudiante p2 = (Estudiante)q;
            return (carnet.CompareTo(p2.carnet) == -1);
        }
    }
}
