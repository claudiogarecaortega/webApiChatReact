using Dominio.Personas;
using Modelos.ViewModels;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using Modelos.ViewModelMappers.Interfaces;
using Persistencia.Contextos;



namespace Modelos.ViewModelMappers
{
    public class TipoDocumentoViewModelMapper : ViewModelMapper<TipoDocumento, TipoDocumentoViewModel, TipoDocumentoViewModel>, ITipoDocumentoViewModelMapper
    {

        public TipoDocumentoViewModelMapper()
        {
            Mapper.CreateMap<TipoDocumento, TipoDocumentoViewModel>()
			//.ForMember(model => model.Categorias, opt => opt.Ignore())
			;
            Mapper.CreateMap<TipoDocumentoViewModel, TipoDocumento>()
			//.ForMember(model => model.Categorias, opt => opt.Ignore())
			;
        }
		  public override TipoDocumentoViewModel Map(TipoDocumento model)
        {
            var viewModel = base.Map(model);
			return viewModel;
        }

        public override void Map(TipoDocumentoViewModel viewModel, TipoDocumento model)
        {
            base.Map(viewModel, model);

            //this.Set(hospital => model.UserContact = hospital, viewModel.ContactId, UserExtendedDao);
        }

        public override IEnumerable<TipoDocumentoViewModel> Map(IEnumerable<TipoDocumento> models)
        {
            return models.Select(Map);
        }
    }
}