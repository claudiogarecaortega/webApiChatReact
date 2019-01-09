using Dominio.Errores;

using System.Linq;
using Persistencia.UnitsOfWork;
using Utilidades.Activadores;
using Persistencia.Daos.Interfaces;

namespace Persistencia.Daos
{ 
    public class ErrorLogDao : Dao<ErrorLog>, IErrorLogDao
    {
		
		  public ErrorLogDao(IUnitOfWorkHelper unitOfWorkHelper, IActivatorWrapper activator)
            : base(unitOfWorkHelper, activator)
        {
        }

		
	}
}