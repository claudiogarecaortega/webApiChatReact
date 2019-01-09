using System.Collections.Generic;
using Dominio.Common;

using System.Linq;
using Persistencia.UnitsOfWork;
using Utilidades.Activadores;
using Persistencia.Daos.Interfaces;

namespace Persistencia.Daos
{ 
    public class UbicacionDao : Dao<Ubicacion>, IUbicacionDao
    {
		
		  public UbicacionDao(IUnitOfWorkHelper unitOfWorkHelper, IActivatorWrapper activator)
            : base(unitOfWorkHelper, activator)
        {
        }

        public  IEnumerable<Ubicacion> GetAutoComplete(string text)
        {
            return
                GetAll().Where(d=>d.Descripcion.ToLower().Contains(text.ToLower()))

                    .AsEnumerable().Take(10);
        }
    }
}