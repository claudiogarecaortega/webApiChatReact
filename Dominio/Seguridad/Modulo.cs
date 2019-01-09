using System;
using System.Collections.Generic;
using System.Text;
using Dominio.IdentificableObject;

namespace Dominio.Seguridad
{
    public class Modulo : Auditoria, IIdentifiableObjectModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public virtual Modulo ModuloPadre { get; set; }
        //public virtual  IList<Action> Actions { get; set; }
        public virtual IList<ModuloAccion> ListaModuloAcciones { get; set; }
        public virtual IList<ModuloUsuarioAccion> ListaModuloUsuarioAcciones { get; set; }
        // public virtual  IList<User> ListUsers { get; set; }
    }
}
