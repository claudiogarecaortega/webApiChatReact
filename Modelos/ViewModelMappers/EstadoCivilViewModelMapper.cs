using Dominio.Common;
using Modelos.ViewModels;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using Modelos.ViewModelMappers.Interfaces;
using Persistencia.Contextos;



namespace Modelos.ViewModelMappers
{
    public class EstadoCivilViewModelMapper : ViewModelMapper<EstadoCivil, EstadoCivilViewModel, EstadoCivilViewModel>, IEstadoCivilViewModelMapper
    {

        public EstadoCivilViewModelMapper()
        {
            Mapper.CreateMap<EstadoCivil, EstadoCivilViewModel>()
			//.ForMember(model => model.Categorias, opt => opt.Ignore())
			;
            Mapper.CreateMap<EstadoCivilViewModel, EstadoCivil>()
			//.ForMember(model => model.Categorias, opt => opt.Ignore())
			;
        }
		  public override EstadoCivilViewModel Map(EstadoCivil model)
        {
            var viewModel = base.Map(model);
			return viewModel;
        }

        public override void Map(EstadoCivilViewModel viewModel, EstadoCivil model)
        {
            base.Map(viewModel, model);

            //this.Set(hospital => model.UserContact = hospital, viewModel.ContactId, UserExtendedDao);
        }

        public override IEnumerable<EstadoCivilViewModel> Map(IEnumerable<EstadoCivil> models)
        {
            return models.Select(Map);
        }
    }
}