using Dominio.Seguridad;
using Modelos.ViewModels;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using Modelos.ViewModelMappers.Interfaces;
using Persistencia.Daos.Interfaces;


namespace Modelos.ViewModelMappers
{
    public class ModuloViewModelMapper : ViewModelMapper<Modulo, ModuloViewModel, ModuloViewModel>, IModuloViewModelMapper
    {
        private readonly IModuloDao _moduloDao;

        public ModuloViewModelMapper(IModuloDao moduloDao)
        {
            _moduloDao = moduloDao;
            Mapper.CreateMap<Modulo, ModuloViewModel>()
			//.ForMember(model => model.Categorias, opt => opt.Ignore())
			;
            Mapper.CreateMap<ModuloViewModel, Modulo>()
                .ForMember(model => model.ModuloPadre, opt => opt.Ignore());
            //.ForMember(model => model.Categorias, opt => opt.Ignore())
            ;
        }
		  public override ModuloViewModel Map(Modulo model)
        {
            var viewModel = base.Map(model);

            if (model.ModuloPadre != null)
            {
                viewModel.ModuloPadre = model.ModuloPadre.Nombre;
                viewModel.ModuloPadreId = model.ModuloPadre.Id;
            }
            else
            {
                viewModel.ModuloPadre ="Sin Modulo";

            }
            return viewModel;
        }

        public override void Map(ModuloViewModel viewModel, Modulo model)
        {
            base.Map(viewModel, model);
            model.Nombre = model.Id == 0 ? viewModel.Nombre : model.Nombre;

            this.Set(ubication => model.ModuloPadre = ubication, viewModel.ModuloPadreId, _moduloDao);

        }

        public override IEnumerable<ModuloViewModel> Map(IEnumerable<Modulo> models)
        {
            return models.Select(Map);
        }
    }
}