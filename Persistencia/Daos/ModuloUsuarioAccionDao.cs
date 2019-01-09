using Dominio.Seguridad;

using System.Linq;
using Persistencia.UnitsOfWork;
using Utilidades.Activadores;
using Persistencia.Daos.Interfaces;

namespace Persistencia.Daos
{ 
    public class ModuloUsuarioAccionDao : Dao<ModuloUsuarioAccion>, IModuloUsuarioAccionDao
    {
		
		  public ModuloUsuarioAccionDao(IUnitOfWorkHelper unitOfWorkHelper, IActivatorWrapper activator)
            : base(unitOfWorkHelper, activator)
        {
        }

		
	}
}