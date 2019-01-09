using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persistencia.Contextos;
using Utilidades.Activadores;

namespace Persistencia.UnitsOfWork
{
    public interface IUnitOfWorkHelper : IDisposable
    {
        event EventHandler<ObjectCreatedEventArgs> ObjectCreated;
        IApplicationDbContext DBContext { get; }
        void SaveChanges();
        void RollBack();
    }
}
