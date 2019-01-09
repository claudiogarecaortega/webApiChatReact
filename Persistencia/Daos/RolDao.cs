using Dominio.Seguridad;

using System.Linq;
using Persistencia.UnitsOfWork;
using Utilidades.Activadores;
using Persistencia.Daos.Interfaces;

namespace Persistencia.Daos
{ 
    public class RolDao : Dao<Rol>, IRolDao
    {
		
		  public RolDao(IUnitOfWorkHelper unitOfWorkHelper, IActivatorWrapper activator)
            : base(unitOfWorkHelper, activator)
        {
        }

        public void AgregarAccionesRol()
        {

        }

        public Rol GetRollByName(string name)
        {
            return GetAll().FirstOrDefault(rol => rol.Nombre == name);
        }
        protected override IQueryable<Rol> SetFiltro(IQueryable<Rol> modelos, string filtro)
        {
            return modelos.Where(modelo => modelo.Descripcion.ToLower().Contains(filtro.ToLower()));
        }
    }
}