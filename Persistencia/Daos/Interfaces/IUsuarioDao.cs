using System.Collections.Generic;
using Dominio.Usuarios;

namespace Persistencia.Daos.Interfaces
{
    public interface IUsuarioDao : IDao<Usuario>
    {
        Usuario GetUsuario(string username);
        Usuario GetUsuarioDocumento(string documento, int tipoDocumentoId);
        void ActualizarIngreso(string usuario);
        bool CheckEmailUser(string email);
        bool CheckUserName(string userName);
        bool ValidateUserById(int id);
    }
}