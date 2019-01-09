using System;
using System.Collections.Generic;
using System.Linq;
using Dominio.IdentificableObject;
using Persistencia.UnitsOfWork;
using Utilidades.Activadores;

namespace Persistencia.Daos
{
    public abstract class Dao<TModelo> where TModelo : class, new()
    {

        protected IUnitOfWorkHelper UnitOfWorkHelper;
        protected readonly IActivatorWrapper Activator;

        protected Dao(IUnitOfWorkHelper unitOfWorkHelper, IActivatorWrapper activator)
        {
            UnitOfWorkHelper = unitOfWorkHelper;
            Activator = activator;
        }

        public virtual bool ExistenEntidades()
        {
            return UnitOfWorkHelper.DBContext.Set<TModelo>().Any();
        }
        public virtual TModelo Get(object id)
        {
            return UnitOfWorkHelper.DBContext.Set<TModelo>().Find(id);
        }

        public virtual TModelo Get(object[] id)
        {
            var modelo= UnitOfWorkHelper.DBContext.Set<TModelo>().Find(id);
            if(modelo!=null)
                 modelo = SetAuditFields(modelo, true, false);
            return modelo;
        }

        public virtual TModelo GetForEdit(object id)
        {
            return Get(id);
        }

        public virtual TModelo GetForEdit(object[] id)
        {
            return Get(id);
        }

        public virtual TModelo GetForDelete(object id)
        {
            return Get(id);
        }

        public virtual TModelo GetForDelete(object[] id)
        {
            return Get(id);
        }

        public virtual IEnumerable<TModelo> GetAll()
        {
            return GetAllInternal().ToList();
        }

        protected virtual IQueryable<TModelo> GetAllInternal()
        {
            return UnitOfWorkHelper.DBContext.Set<TModelo>();
        }

        public virtual IQueryable<TModelo> GetAllQ(string filtro)
        {
             
            var modelos = UnitOfWorkHelper.DBContext.Set<TModelo>().AsQueryable();

            if (!string.IsNullOrEmpty(filtro))
                modelos = SetFiltro(modelos, filtro);

            return modelos.AsQueryable();
        }

        public virtual TModelo Create()
        {
            var modelo= Activator.CreateInstance<TModelo>();
            modelo = SetAuditFields(modelo, false, false);
            return modelo;
        }

        public virtual void Add(TModelo modelo)
        {
            modelo = SetAuditFields(modelo, false, false);
            UnitOfWorkHelper.DBContext.Set<TModelo>().Add(modelo);
        }

        public virtual void Delete(TModelo modelo)
        {
            modelo = SetAuditFields(modelo, false, true);
            UnitOfWorkHelper.DBContext.Set<TModelo>().Remove(modelo);
        }

        public virtual bool SePuedeBorrar(TModelo modelo)
        {
            return true;
        }

        public virtual bool Existe(object id)
        {
            return Get(id) != null;
        }
        public virtual void Save()
        {
            UnitOfWorkHelper.SaveChanges();
        }

        public virtual void BeforeSave()
        {
            
        }
        public virtual TModel SetAuditFields<TModel>(TModel modelo, bool isNew, bool delete)
        {

            var modeloIdentificable = modelo as IIdentifiableObjectModel;
            if (modeloIdentificable != null && modeloIdentificable.Id == 0)
                isNew = true;
            if (modeloIdentificable != null && (modeloIdentificable.UsuarioAlta != 0 && isNew))
                return (TModel)modeloIdentificable;

            if (modeloIdentificable != null && modeloIdentificable.UsuarioModificacion != 0 && !isNew && !delete)
                return (TModel)modeloIdentificable;

            if (modeloIdentificable != null && modeloIdentificable.UsuarioBaja != 0 && delete)
                return (TModel)modeloIdentificable;

            if (delete)
            {
                if (modeloIdentificable != null)
                {
                    modeloIdentificable.FechaBaja = DateTime.Now;
                    modeloIdentificable.UsuarioBaja = 1;
                    modeloIdentificable.Activo = false;
                }
            }
            else
            {
                if (isNew)
                {
                    if (modeloIdentificable != null)
                    {
                        modeloIdentificable.FechaAlta = DateTime.Now;
                        modeloIdentificable.UsuarioAlta = 1;
                    }
                }
                else
                {
                    if (modeloIdentificable != null)
                    {
                        modeloIdentificable.FechaModificacion = DateTime.Now;
                        modeloIdentificable.UsuarioModificacion = 1;
                    }
                }
                if (modeloIdentificable != null)
                    modeloIdentificable.Activo = true;
            }
            modelo = (TModel)modeloIdentificable;
            return modelo;

        }
        public virtual bool Existe(object[] id)
        {
            return Get(id) != null;
        }

        protected virtual IQueryable<TModelo> SetFiltro(IQueryable<TModelo> modelos, string filtro)
        {
            return modelos;
        }
        public virtual IEnumerable<TModelo> GetAutoComplete(string text)
        {
            return
                GetAll()
                    
                    .AsEnumerable();
        }
       
    }
}
