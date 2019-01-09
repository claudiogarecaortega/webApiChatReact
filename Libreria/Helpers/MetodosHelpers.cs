using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.Helpers
{
    public static class MetodosHelpers
    {
        public static string ObtenerStiloAleatorio()
        {
            var colores=new List<string>(){"primary"
                ,"info"
                ,"success"
                ,"alert"
                ,"system"
                ,"info"
                ,"success"
                ,"primary"
            };
            Random aleatorio=new Random();
            var indice=aleatorio.Next(0, 7);
            return colores[indice];
        }
    }
}
