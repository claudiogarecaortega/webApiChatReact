using System.Collections.Generic;
using Dominio.Seguridad;

using System.Linq;
using System.Reflection;
using Persistencia.UnitsOfWork;
using Utilidades.Activadores;
using Persistencia.Daos.Interfaces;

namespace Persistencia.Daos
{
    public class ModuloDao : Dao<Modulo>, IModuloDao
    {

        public ModuloDao(IUnitOfWorkHelper unitOfWorkHelper, IActivatorWrapper activator)
          : base(unitOfWorkHelper, activator)
        {
        }
        public virtual IEnumerable<Modulo> GetAutoComplete(string text)
        {
            return
                GetAll()
                    .Where(diagnostico => diagnostico.Nombre.ToLower().Contains(text.ToLower()) )
                    .AsEnumerable().Take(10);
        }

        protected override IQueryable<Modulo> SetFiltro(IQueryable<Modulo> modelos, string filtro)
        {
            return modelos.Where(modelo => modelo.Descripcion.ToLower().Contains(filtro.ToLower()));
        }
    }
}