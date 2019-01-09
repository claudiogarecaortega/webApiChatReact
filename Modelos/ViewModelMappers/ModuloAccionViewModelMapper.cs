using Dominio.Seguridad;
using Modelos.ViewModels;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using Modelos.ViewModelMappers.Interfaces;
using Persistencia.Contextos;



namespace Modelos.ViewModelMappers
{
    public class ModuloAccionViewModelMapper : ViewModelMapper<ModuloAccion, ModuloAccionViewModel, ModuloAccionViewModel>, IModuloAccionViewModelMapper
    {

        public ModuloAccionViewModelMapper()
        {
            Mapper.CreateMap<ModuloAccion, ModuloAccionViewModel>()
			//.ForMember(model => model.Categorias, opt => opt.Ignore())
			;
            Mapper.CreateMap<ModuloAccionViewModel, ModuloAccion>()
			//.ForMember(model => model.Categorias, opt => opt.Ignore())
			;
        }
		  public override ModuloAccionViewModel Map(ModuloAccion model)
        {
            var viewModel = base.Map(model);
			return viewModel;
        }

        public override void Map(ModuloAccionViewModel viewModel, ModuloAccion model)
        {
            base.Map(viewModel, model);

            //this.Set(hospital => model.UserContact = hospital, viewModel.ContactId, UserExtendedDao);
        }

        public override IEnumerable<ModuloAccionViewModel> Map(IEnumerable<ModuloAccion> models)
        {
            return models.Select(Map);
        }
    }
}