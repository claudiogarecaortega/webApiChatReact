using Dominio.Errores;
using Modelos.ViewModels;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using Modelos.ViewModelMappers.Interfaces;
namespace Modelos.ViewModelMappers
{
    public class ErrorLogViewModelMapper : ViewModelMapper<ErrorLog, ErrorLogViewModel, ErrorLogViewModel>, IErrorLogViewModelMapper
    {

        public ErrorLogViewModelMapper()
        {
            Mapper.CreateMap<ErrorLog, ErrorLogViewModel>()
			//.ForMember(model => model.Categorias, opt => opt.Ignore())
			;
            Mapper.CreateMap<ErrorLogViewModel, ErrorLog>()
			//.ForMember(model => model.Categorias, opt => opt.Ignore())
			;
        }
		  public override ErrorLogViewModel Map(ErrorLog model)
        {
            var viewModel = base.Map(model);
			return viewModel;
        }

        public override void Map(ErrorLogViewModel viewModel, ErrorLog model)
        {
            base.Map(viewModel, model);

            //this.Set(hospital => model.UserContact = hospital, viewModel.ContactId, UserExtendedDao);
        }

        public override IEnumerable<ErrorLogViewModel> Map(IEnumerable<ErrorLog> models)
        {
            return models.Select(Map);
        }
    }
}