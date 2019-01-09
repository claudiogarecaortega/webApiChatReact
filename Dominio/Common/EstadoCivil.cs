using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.IdentificableObject;
using Dominio.Seguridad;

namespace Dominio.Common
{
    public class EstadoCivil : Auditoria, IIdentifiableObjectModel
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }

    }
}
