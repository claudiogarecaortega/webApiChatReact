using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Dominio.Common;
using Dominio.IdentificableObject;
using Dominio.Personas;
using Dominio.Seguridad;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
namespace Dominio.Usuarios
{
    public class UserRole : IdentityUserRole<int>
    {
    }

    public class UserClaim : IdentityUserClaim<int>
    {
    }

    public class UserLogin : IdentityUserLogin<int>
    {
    }

    public class Role : IdentityRole<int, UserRole>
    {
        public Role() { }
        public Role(string name) { Name = name; }
    }

    public class Usuario : IdentityUser<int, UserLogin, UserRole, UserClaim>, IIdentifiableObjectModel
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<Usuario, int> manager)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            return userIdentity;
        }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<Usuario, int> manager, string authenticationType)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            return userIdentity;
        }

     
        #region CamposExtendidos

        public int UsuarioAlta { get; set; }
        public int? UsuarioBaja { get; set; }
        public int? UsuarioModificacion { get; set; }
        public DateTime FechaAlta { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public DateTime? FechaBaja { get; set; }
        public DateTime? UltimoAccesso { get; set; }

        public bool Activo { get; set; }
        #endregion
        #region Relaciones
        public virtual Rol UsuarioRol { get; set; }
        public virtual Persona Persona { get; set; }
        public virtual IList<ModuloUsuarioAccion> Modulos { get; set; }
      //  public virtual IList<UsuarioAdjunto> UsuarioAdjuntos { get; set; }

        #endregion
        #region Metodos

        
       
        public string NombreCompleto()
        {
            return Persona == null ? "Sin Nobre" : $"{Persona.Nombres}, {Persona.Apellidos}";
        }
        public string NombreAbreviado()
        {
            return Persona == null ? "Sin Nobre" : $"{Persona.Nombres}, {Persona.Apellidos.Substring(0, 1)}";
        }
        public List<int> ObtenerModulosMenu()
        {
            var listaIdModulosPermitidos = UsuarioRol.ListaModuloAcciones.Select(modulo => modulo.Modulo.Id).ToList();
            listaIdModulosPermitidos.Add(0);
            return listaIdModulosPermitidos;

        }

        public List<Accion> ObtenerAccionesPorModulo(string modulo)
        {
            var moduloAcciones = UsuarioRol.ListaModuloAcciones.FirstOrDefault(mo => mo.Modulo.Nombre == modulo);
            return moduloAcciones?.Acciones.ToList();
        }

        public bool VerificarOperacion(int idAccion, string modulo)
        {
            var listaPermitida = ObtenerAccionesPorModulo(modulo);
            return listaPermitida.Any(x => x.Id == idAccion);
        }

        #endregion
    }
}
