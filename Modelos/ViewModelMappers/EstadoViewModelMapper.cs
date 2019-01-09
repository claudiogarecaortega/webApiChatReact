using Dominio.Common;
using Modelos.ViewModels;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using Modelos.ViewModelMappers.Interfaces;
using Persistencia.Contextos;



namespace Modelos.ViewModelMappers
{
    public class EstadoViewModelMapper : ViewModelMapper<Estado, EstadoViewModel, EstadoViewModel>, IEstadoViewModelMapper
    {

        public EstadoViewModelMapper()
        {
            Mapper.CreateMap<Estado, EstadoViewModel>()
			//.ForMember(model => model.Categorias, opt => opt.Ignore())
			;
            Mapper.CreateMap<EstadoViewModel, Estado>()
			//.ForMember(model => model.Categorias, opt => opt.Ignore())
			;
        }
		  public override EstadoViewModel Map(Estado model)
        {
            var viewModel = base.Map(model);
			return viewModel;
        }

        public override void Map(EstadoViewModel viewModel, Estado model)
        {
            base.Map(viewModel, model);

            //this.Set(hospital => model.UserContact = hospital, viewModel.ContactId, UserExtendedDao);
        }

        public override IEnumerable<EstadoViewModel> Map(IEnumerable<Estado> models)
        {
            return models.Select(Map);
        }
    }
}