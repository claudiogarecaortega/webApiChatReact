using System;
using Dominio.Usuarios;

using System.Linq;
using Persistencia.UnitsOfWork;
using Utilidades.Activadores;
using Persistencia.Daos.Interfaces;

namespace Persistencia.Daos
{ 
    public class UsuarioAdjuntoDao : Dao<UsuarioAdjunto>, IUsuarioAdjuntoDao
    {
		
		  public UsuarioAdjuntoDao(IUnitOfWorkHelper unitOfWorkHelper, IActivatorWrapper activator)
            : base(unitOfWorkHelper, activator)
        {
        }

        public void LiberarAdjuntoPrincipal(int userAdjuntoid,int userId, int principalId)
        {
            var adjuntos = GetAll().Where(f => f.Usuario.Id == userAdjuntoid);
            foreach (var usuarioAdjunto in adjuntos)
            {
                if (usuarioAdjunto.Id != principalId)
                {
                    usuarioAdjunto.Principal = false;
                    usuarioAdjunto.UsuarioModificacion = userId;
                    usuarioAdjunto.FechaModificacion=DateTime.Now;
                }
                    
            }

            Save();
        }
		
	}
}