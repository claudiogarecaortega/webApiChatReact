using Dominio.Usuarios;

namespace Persistencia.Daos.Interfaces
{ 
    public interface IUsuarioAdjuntoDao : IDao<UsuarioAdjunto>
    {
        void LiberarAdjuntoPrincipal(int userAdjuntoid, int userId, int principalId);

    }
}