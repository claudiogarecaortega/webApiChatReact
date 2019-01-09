using System;
using System.Collections.Generic;
using System.Text;
using Dominio.IdentificableObject;
using Dominio.Usuarios;

namespace Dominio.Seguridad
{
    public class ModuloUsuarioAccion : Auditoria, IIdentifiableObjectModel
    {
        public int Id { get; set; }
        public virtual Modulo Modulo { get; set; }
        public virtual IList<Accion> Acciones { get; set; }
        public virtual Usuario Usuario { get; set; }
        public bool Activo { get; set; }
    }
}
