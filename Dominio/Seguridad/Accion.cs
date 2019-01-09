using System;
using System.Collections.Generic;
using System.Text;
using Dominio.IdentificableObject;

namespace Dominio.Seguridad
{
    public class Accion : Auditoria, IIdentifiableObjectModel
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }

        #region Relaciones
        public virtual IList<ModuloAccion> ModuloAcciones { get; set; }
        public virtual IList<ModuloUsuarioAccion> ModuloUdUsuarioAcciones { get; set; }
        
        #endregion

    }
}
