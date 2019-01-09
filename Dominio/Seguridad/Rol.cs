using System.Collections.Generic;
using Dominio.IdentificableObject;
using Dominio.Usuarios;

namespace Dominio.Seguridad
{
    public class Rol:Auditoria, IIdentifiableObjectModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        #region Relaciones

        public virtual IList<ModuloAccion> ListaModuloAcciones { get; set; }
        public virtual IList<Usuario> ListaUsuarios { get; set; }
        #endregion

    }
}
