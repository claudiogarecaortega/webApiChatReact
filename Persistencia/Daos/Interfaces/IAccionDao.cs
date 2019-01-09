using System.Collections.Generic;
using Dominio.Seguridad;

namespace Persistencia.Daos.Interfaces
{ 
    public interface IAccionDao : IDao<Accion>
    {
        IEnumerable<Accion> GetActions(string[] keysStrings);

    }
}