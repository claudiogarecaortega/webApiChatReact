using Dominio.Common;

namespace Persistencia.Daos.Interfaces
{ 
    public interface IAdjuntoDao : IDao<Adjunto>
    {
        bool ExisteArchivoPorNombre(string nombreArchivo);

    }
}