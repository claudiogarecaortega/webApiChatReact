using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Libreria.Resource;
using Libreria.Utils;
using Modelos.ViewModelMappers.Interfaces;
using Persistencia.Daos.Interfaces;

namespace Modelos.ViewModelMappers
{
    public abstract class ViewModelMapper<TModelo, TViewModel, TCommonViewModel> :
        IViewModelMapper<TModelo, TViewModel, TCommonViewModel>
    {
        public virtual void Map(TViewModel viewModel, TModelo model)
        {
            try
            {
                Mapper.Map(viewModel, model);
            }
            catch (Exception e)
            {
               
                throw e;
            }
        }

        public virtual TViewModel Map(TModelo model)
        {
            try
            {
                return Mapper.Map<TViewModel>(model);
            }
            catch (Exception e)
            {
               
                throw e;
            }
        }

        public virtual IEnumerable<TViewModel> Map(IEnumerable<TModelo> tipoProcesamientoAPItems)
        {
            try
            {
                return tipoProcesamientoAPItems.Select(Map);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public virtual void MapCommon(TCommonViewModel viewModel, TModelo model)
        {
            try
            {
                Mapper.Map(viewModel, model);
            }
            catch (Exception e)
            {
                
                throw e;
            }
        }

        public virtual TCommonViewModel MapCommon(TModelo model)
        {
            return Mapper.Map<TCommonViewModel>(model);
        }

        public virtual IEnumerable<TCommonViewModel> MapCommon(IEnumerable<TModelo> models)
        {
            return models.Select(MapCommon);
        }

        protected string MapFecha(DateTime? fecha)
        {
            return MapFecha(fecha, "dd/MM/yyyy");
        }

        protected string MapFechaMonthYear(DateTime? fecha)
        {
            return MapFecha(fecha, "MM/yyyy");
        }

        protected string MapFecha(DateTime? fecha, string format)
        {
            if (fecha == null)
                return "";

            return fecha.GetValueOrDefault().ToString(format);
        }

        protected void Set<TProp>(Action<TProp> asignement, object id, IDao<TProp> dao)
        {
            if (id == null)
            {
                asignement(default(TProp));
                return;
            }

            var valProp = dao.Get(id);
            asignement(valProp);
        }

        protected void Set<TProp>(Action<TProp> asignement, object[] id, IDao<TProp> dao)
        {
            if (id == null)
            {
                asignement(default(TProp));
                return;
            }

            var valProp = dao.Get(id);
            asignement(valProp);
        }

        protected void SetFecha(Action<DateTime?> asignement, string fecha)
        {
            if (string.IsNullOrEmpty(fecha))
            {
                asignement(null);
                return;
            }

            asignement(DateTime.Parse(fecha));
        }

        protected void SetViewModel<TProp>(TViewModel viewModel, TProp obj, Action<TViewModel, TProp> action)
            where TProp : class
        {
            if (obj != null)
            {
                action.Invoke(viewModel, obj);
            }
        }

        protected void SetViewModel<TModel>(TViewModel viewModel, TModel model, Expression<Func<TModel, object>> action)
        {
            var propertyName = ReflectionUtils.Instance.GetPropertyName(action);
            var propertyIdName = propertyName + "Id";

            var viewModelType = viewModel.GetType();
            var modelType = model.GetType();

            var subModel = modelType.GetProperty(propertyName).GetValue(model);

            if (subModel == null)
            {
                return;
            }

            var subModelId = subModel.GetType().GetProperty("Id").GetValue(subModel);
            var subModelDescripcion = subModel.GetType().GetProperty("Descripcion").GetValue(subModel);

            var viewModelPropertyIdInfo = viewModelType.GetProperty(propertyIdName);
            viewModelPropertyIdInfo.SetValue(viewModel, subModelId);

            var viewModelPropertyInfo = viewModelType.GetProperty(propertyName);
            viewModelPropertyInfo.SetValue(viewModel, subModelDescripcion);
        }

        protected string BoolToString(bool value)
        {
            return value ? Resources.Yes : Resources.No;
        }

        protected void SetCollectionFromMultiSelect<TModel>(int[] multiSelect, IDao<TModel> dao,
            IList<TModel> collection)
        {
            var listaParaActualizar = new List<TModel>();

            if (multiSelect != null)
            {
                listaParaActualizar = multiSelect.Select(item => dao.Get(item)).ToList();
            }

            var listaParaAgregar = listaParaActualizar.Where(item => !collection.Contains(item)).ToList();
            var listaParaBorrar = collection.Where(item => !listaParaActualizar.Contains(item)).ToList();

            foreach (var item in listaParaAgregar)
            {
                collection.Add(item);
            }

            foreach (var item in listaParaBorrar)
            {
                collection.Remove(item);
            }
        }
        protected void SetCollectionUSers<TModel>(int? id, IDao<TModel> dao,
            IList<TModel> collection)
        {
            var listaParaActualizar = new List<TModel>();

            if (id != 0)
            {
                listaParaActualizar.Add(dao.Get(id))
                    ;
            }
            if (collection == null)
                collection = new List<TModel>();

            var listaParaAgregar = listaParaActualizar.Where(item => !collection.Contains(item)).ToList();
            var listaParaBorrar = collection.Where(item => !listaParaActualizar.Contains(item)).ToList();

            foreach (var item in listaParaAgregar)
            {
                collection.Add(item);
            }

            foreach (var item in listaParaBorrar)
            {
                collection.Remove(item);
            }
        }
        public decimal CustomParse(string incomingValue)
        {
            if (incomingValue.Contains('.'))
                incomingValue = incomingValue.Replace('.', ',');

            var u = Convert.ToDecimal(incomingValue);
            return Math.Round(u, 3);
        }
        public double CustomParseDouble(string incomingValue)
        {
            if (incomingValue.Contains('.'))
                incomingValue = incomingValue.Replace('.', ',');

            var u = Convert.ToDouble(incomingValue);
            return Math.Round(u, 3);
        }
        public static string TruncateLongString(string str, int maxLength)
        {
            return str.Substring(0, Math.Min(str.Length, maxLength));
        }
        public static string AddCharacterString(string str, int maxLength,string character)
        {
            if (str.Length >= maxLength)
                return str;
            for (int i = 0; i < maxLength-str.Length; i++)
            {
                str = $"{character}{str}";
            }
            return str;
        }
        //instancias
    }
}
