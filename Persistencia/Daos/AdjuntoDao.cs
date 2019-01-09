using Dominio.Common;

using System.Linq;
using Persistencia.UnitsOfWork;
using Utilidades.Activadores;
using Persistencia.Daos.Interfaces;

namespace Persistencia.Daos
{ 
    public class AdjuntoDao : Dao<Adjunto>, IAdjuntoDao
    {
		
		  public AdjuntoDao(IUnitOfWorkHelper unitOfWorkHelper, IActivatorWrapper activator)
            : base(unitOfWorkHelper, activator)
        {
        }

        public bool ExisteArchivoPorNombre(string nombreArchivo)
        {
            return GetAll().Any(m => m.NombreArchivo == nombreArchivo);
        }
	}
}