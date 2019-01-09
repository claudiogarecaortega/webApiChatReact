using Dominio.Seguridad;
using Modelos.ViewModels;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using Modelos.ViewModelMappers.Interfaces;
using Persistencia.Contextos;



namespace Modelos.ViewModelMappers
{
    public class RolViewModelMapper : ViewModelMapper<Rol, RolViewModel, RolViewModel>, IRolViewModelMapper
    {

        public RolViewModelMapper()
        {
            Mapper.CreateMap<Rol, RolViewModel>()
			//.ForMember(model => model.Categorias, opt => opt.Ignore())
			;
            Mapper.CreateMap<RolViewModel, Rol>()
			//.ForMember(model => model.Categorias, opt => opt.Ignore())
			;
        }
		  public override RolViewModel Map(Rol model)
        {
            var viewModel = base.Map(model);
			return viewModel;
        }

        public override void Map(RolViewModel viewModel, Rol model)
        {
            base.Map(viewModel, model);

            //this.Set(hospital => model.UserContact = hospital, viewModel.ContactId, UserExtendedDao);
        }

        public override IEnumerable<RolViewModel> Map(IEnumerable<Rol> models)
        {
            return models.Select(Map);
        }
    }
}