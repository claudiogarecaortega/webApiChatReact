using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.IdentificableObject;
using Dominio.Seguridad;

namespace Dominio.Errores
{
    public class ErrorLog:Auditoria,IIdentifiableObjectModel
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Mensaje { get; set; }
        public string Modulo { get; set; }
        public string Accion { get; set; }
        public string StackTrace { get; set; }
    }
}
