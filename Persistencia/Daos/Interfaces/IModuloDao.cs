using System.Collections.Generic;
using Dominio.Seguridad;

namespace Persistencia.Daos.Interfaces
{ 
    public interface IModuloDao : IDao<Modulo>
    {
        IEnumerable<Modulo> GetAutoComplete(string text);

    }
}