using Dominio.Seguridad;
using Modelos.ViewModels;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using Modelos.ViewModelMappers.Interfaces;
using Persistencia.Contextos;



namespace Modelos.ViewModelMappers
{
    public class AccionViewModelMapper : ViewModelMapper<Accion, AccionViewModel, AccionViewModel>, IAccionViewModelMapper
    {

        public AccionViewModelMapper()
        {
            Mapper.CreateMap<Accion, AccionViewModel>()
			//.ForMember(model => model.Categorias, opt => opt.Ignore())
			;
            Mapper.CreateMap<AccionViewModel, Accion>()
			//.ForMember(model => model.Categorias, opt => opt.Ignore())
			;
        }
		  public override AccionViewModel Map(Accion model)
        {
            var viewModel = base.Map(model);
			return viewModel;
        }

        public override void Map(AccionViewModel viewModel, Accion model)
        {
            base.Map(viewModel, model);

            //this.Set(hospital => model.UserContact = hospital, viewModel.ContactId, UserExtendedDao);
        }

        public override IEnumerable<AccionViewModel> Map(IEnumerable<Accion> models)
        {
            return models.Select(Map);
        }
    }
}