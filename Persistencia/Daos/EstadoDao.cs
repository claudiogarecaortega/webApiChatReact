using Dominio.Common;

using System.Linq;
using Persistencia.UnitsOfWork;
using Utilidades.Activadores;
using Persistencia.Daos.Interfaces;

namespace Persistencia.Daos
{
    public class EstadoDao : Dao<Estado>, IEstadoDao
    {

        public EstadoDao(IUnitOfWorkHelper unitOfWorkHelper, IActivatorWrapper activator)
          : base(unitOfWorkHelper, activator)
        {
        }


    }
}