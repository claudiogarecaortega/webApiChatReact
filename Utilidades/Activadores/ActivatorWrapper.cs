using System;

namespace Utilidades.Activadores
{
    public class ActivatorWrapper : IActivatorWrapper
    {
        public event EventHandler<ObjectCreatedEventArgs> ObjectCreated;

        public virtual T CreateInstance<T>()
        {
            var instance = Activator.CreateInstance<T>();
            OnObjectCreated(instance);
            return instance;
        }

        public virtual object CreateInstance(string assemblyName, string typeName)
        {
            var instance = Activator.CreateInstance(assemblyName, typeName).Unwrap();
            OnObjectCreated(instance);
            return instance;
        }

        protected void OnObjectCreated(object entity)
        {
            ObjectCreated?.Invoke(this, new ObjectCreatedEventArgs(entity));
        }
    }
}
