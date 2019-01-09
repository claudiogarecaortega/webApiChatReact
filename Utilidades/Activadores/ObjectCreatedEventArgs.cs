using System;

namespace Utilidades.Activadores
{
    public class ObjectCreatedEventArgs : EventArgs
    {
        /// <summary>
        ///     The object that was materialized.
        /// </summary>
        private readonly object _entity;

        /// <summary>
        ///     Constructs new arguments for the ObjectMaterialized event.
        /// </summary>
        /// <param name="entity">The object that has been materialized. </param>
        public ObjectCreatedEventArgs(object entity)
        {
            _entity = entity;
        }

        /// <summary>
        ///     Gets the entity object that was created.
        /// </summary>
        /// <returns>
        ///     The entity object that was created.
        /// </returns>
        public object Entity
        {
            get { return _entity; }
        }
    }
}
