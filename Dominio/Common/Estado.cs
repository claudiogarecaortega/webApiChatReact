using System;
using System.Collections.Generic;
using System.Text;
using Dominio.IdentificableObject;
using Dominio.Seguridad;

namespace Dominio.Common
{

    public class Estado:Auditoria,IIdentifiableObjectModel
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
    }
}
