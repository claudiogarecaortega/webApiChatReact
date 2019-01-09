using System;
using System.Collections.Generic;
using System.Text;
using Dominio.IdentificableObject;

namespace Dominio.Seguridad
{
    public class ModuloAccion : Auditoria, IIdentifiableObjectModel
    {
        public int Id { get; set; }
        public virtual Modulo Modulo { get; set; }
        public virtual IList<Accion> Acciones { get; set; }
        public virtual Rol Rol { get; set; }
        public bool Activo { get; set; }
    }
}
