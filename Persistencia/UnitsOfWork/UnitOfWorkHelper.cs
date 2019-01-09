using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using Persistencia.Contextos;
using Utilidades.Activadores;

namespace Persistencia.UnitsOfWork
{
    public class UnitOfWorkHelper : IUnitOfWorkHelper
    {
        public ApplicationDbContext SessionContext;
        public event EventHandler<ObjectCreatedEventArgs> ObjectCreated;

        public IApplicationDbContext DBContext
        {
            get
            {
                if (SessionContext != null)
                    return SessionContext;
                SessionContext = new ApplicationDbContext();
                ((IObjectContextAdapter)SessionContext).ObjectContext.ObjectMaterialized += (sender, e) => OnObjectCreated(e.Entity);

                return SessionContext;
            }
        }

        private void OnObjectCreated(object entity)
        {
            ObjectCreated?.Invoke(this, new ObjectCreatedEventArgs(entity));
        }

        public void SaveChanges()
        {
            DBContext.SaveChanges();
        }

        public void RollBack()
        {
            SessionContext?.ChangeTracker.Entries()
                .ToList()
                .ForEach(entry => entry.State = EntityState.Unchanged);
        }

        public void Dispose()
        {
            SessionContext?.Dispose();
        }
    }
}
