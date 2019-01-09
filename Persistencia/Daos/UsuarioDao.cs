using System;
using System.Collections.Generic;
using Dominio.Usuarios;

using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Dominio.Seguridad;
using Microsoft.AspNet.Identity;
using Persistencia.UnitsOfWork;
using Utilidades.Activadores;
using Persistencia.Daos.Interfaces;

namespace Persistencia.Daos
{
    public class UsuarioDao : Dao<Usuario>, IUsuarioDao
    {

        public UsuarioDao(IUnitOfWorkHelper unitOfWorkHelper, IActivatorWrapper activator)
          : base(unitOfWorkHelper, activator)
        {
        }
        public Usuario GetUsuario(string username)
        {
            var usuarios = GetAll();
            return usuarios.FirstOrDefault(usuario => usuario.UserName.ToLower() == username.ToLower());
        }
        public bool CheckEmailUser(string email)
        {
            var users = GetAll();
            return users.FirstOrDefault(user => string.Equals(user.Email, email, StringComparison.CurrentCultureIgnoreCase)) != null;
        }
        public bool CheckUserName(string userName)
        {
            var users = GetAll();
            return users.FirstOrDefault(user => string.Equals(user.UserName, userName, StringComparison.CurrentCultureIgnoreCase)) != null;
        }
        public Usuario GetUsuarioDocumento(string documento, int tipoDocumentoId)
        {
            var usuarios = GetAll();
            return usuarios.FirstOrDefault(usuario => usuario.Persona != null && usuario.Persona.TipoDocumento != null && usuario.Persona.TipoDocumento.Id == tipoDocumentoId && usuario.Persona.Documento == documento);
        }

        public void ActualizarIngreso(string usuario)
        {
            var model = GetUsuario(usuario);
            model.UltimoAccesso = DateTime.Now;
            Save();
        }

        protected override IQueryable<Usuario> SetFiltro(IQueryable<Usuario> modelos, string filtro)
        {
            return modelos.Where(modelo => modelo.NombreCompleto().ToLower().Contains(filtro.ToLower()));
        }

        #region Validaciones

        public bool ValidateUserById(int id)
        {
            return Get(id) != null;
        }

        #endregion
    }
}