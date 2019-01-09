using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilidades.Activadores
{
    public interface IActivatorWrapper
    {
        event EventHandler<ObjectCreatedEventArgs> ObjectCreated;
        T CreateInstance<T>();
        object CreateInstance(string assemblyName, string typeName);
    }
}
