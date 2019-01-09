using Dominio.Seguridad;
using Modelos.ViewModels;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using Modelos.ViewModelMappers.Interfaces;
using Persistencia.Contextos;



namespace Modelos.ViewModelMappers
{
    public class ModuloUsuarioAccionViewModelMapper : ViewModelMapper<ModuloUsuarioAccion, ModuloUsuarioAccionViewModel, ModuloUsuarioAccionViewModel>, IModuloUsuarioAccionViewModelMapper
    {

        public ModuloUsuarioAccionViewModelMapper()
        {
            Mapper.CreateMap<ModuloUsuarioAccion, ModuloUsuarioAccionViewModel>()
			//.ForMember(model => model.Categorias, opt => opt.Ignore())
			;
            Mapper.CreateMap<ModuloUsuarioAccionViewModel, ModuloUsuarioAccion>()
			//.ForMember(model => model.Categorias, opt => opt.Ignore())
			;
        }
		  public override ModuloUsuarioAccionViewModel Map(ModuloUsuarioAccion model)
        {
            var viewModel = base.Map(model);
			return viewModel;
        }

        public override void Map(ModuloUsuarioAccionViewModel viewModel, ModuloUsuarioAccion model)
        {
            base.Map(viewModel, model);

            //this.Set(hospital => model.UserContact = hospital, viewModel.ContactId, UserExtendedDao);
        }

        public override IEnumerable<ModuloUsuarioAccionViewModel> Map(IEnumerable<ModuloUsuarioAccion> models)
        {
            return models.Select(Map);
        }
    }
}