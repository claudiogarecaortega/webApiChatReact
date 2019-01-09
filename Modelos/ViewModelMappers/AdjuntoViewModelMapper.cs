using Dominio.Common;
using Modelos.ViewModels;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using Modelos.ViewModelMappers.Interfaces;
using Persistencia.Contextos;



namespace Modelos.ViewModelMappers
{
    public class AdjuntoViewModelMapper : ViewModelMapper<Adjunto, AdjuntoViewModel, AdjuntoViewModel>, IAdjuntoViewModelMapper
    {

        public AdjuntoViewModelMapper()
        {
            Mapper.CreateMap<Adjunto, AdjuntoViewModel>()
			//.ForMember(model => model.Categorias, opt => opt.Ignore())
			;
            Mapper.CreateMap<AdjuntoViewModel, Adjunto>()
			//.ForMember(model => model.Categorias, opt => opt.Ignore())
			;
        }
		  public override AdjuntoViewModel Map(Adjunto model)
        {
            var viewModel = base.Map(model);
			return viewModel;
        }

        public override void Map(AdjuntoViewModel viewModel, Adjunto model)
        {
            base.Map(viewModel, model);

            //this.Set(hospital => model.UserContact = hospital, viewModel.ContactId, UserExtendedDao);
        }

        public override IEnumerable<AdjuntoViewModel> Map(IEnumerable<Adjunto> models)
        {
            return models.Select(Map);
        }
    }
}