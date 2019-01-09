using System.Collections.Generic;
using Dominio.Seguridad;

using System.Linq;
using Persistencia.UnitsOfWork;
using Utilidades.Activadores;
using Persistencia.Daos.Interfaces;

namespace Persistencia.Daos
{ 
    public class AccionDao : Dao<Accion>, IAccionDao
    {
		
		  public AccionDao(IUnitOfWorkHelper unitOfWorkHelper, IActivatorWrapper activator)
            : base(unitOfWorkHelper, activator)
        {
        }
        public IEnumerable<Accion> GetActions(string[] keysStrings)
        {
            var actions = GetAll().ToList();
            return keysStrings.Select(item => actions.FirstOrDefault(c => c.Descripcion == item)).Where(result => result != null).ToList();

        }
        protected override IQueryable<Accion> SetFiltro(IQueryable<Accion> modelos, string filtro)
        {
            return modelos.Where(modelo => modelo.Descripcion.ToLower().Contains(filtro.ToLower()));
        }
    }
}