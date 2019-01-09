using Dominio.Seguridad;

namespace Persistencia.Daos.Interfaces
{ 
    public interface IRolDao : IDao<Rol>
    {
        Rol GetRollByName(string name);

    }
}