using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.Contextos
{
    public  interface IApplicationDbContext
    {
        Database Database { get; }
        int SaveChanges();
        DbSet<T> Set<T>() where T : class;
    }
}
