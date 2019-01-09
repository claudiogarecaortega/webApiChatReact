using Dominio.Common;
using Modelos.ViewModels;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using Modelos.ViewModelMappers.Interfaces;
using Persistencia.Contextos;



namespace Modelos.ViewModelMappers
{
    public class SexoViewModelMapper : ViewModelMapper<Sexo, SexoViewModel, SexoViewModel>, ISexoViewModelMapper
    {

        public SexoViewModelMapper()
        {
            Mapper.CreateMap<Sexo, SexoViewModel>()
			//.ForMember(model => model.Categorias, opt => opt.Ignore())
			;
            Mapper.CreateMap<SexoViewModel, Sexo>()
			//.ForMember(model => model.Categorias, opt => opt.Ignore())
			;
        }
		  public override SexoViewModel Map(Sexo model)
        {
            var viewModel = base.Map(model);
			return viewModel;
        }

        public override void Map(SexoViewModel viewModel, Sexo model)
        {
            base.Map(viewModel, model);

            //this.Set(hospital => model.UserContact = hospital, viewModel.ContactId, UserExtendedDao);
        }

        public override IEnumerable<SexoViewModel> Map(IEnumerable<Sexo> models)
        {
            return models.Select(Map);
        }
    }
}