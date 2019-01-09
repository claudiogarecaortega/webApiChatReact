using Dominio.Usuarios;
using Modelos.ViewModels;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using Modelos.ViewModelMappers.Interfaces;
using Persistencia.Contextos;



namespace Modelos.ViewModelMappers
{
    public class UsuarioAdjuntoViewModelMapper : ViewModelMapper<UsuarioAdjunto, UsuarioAdjuntoViewModel, UsuarioAdjuntoViewModel>, IUsuarioAdjuntoViewModelMapper
    {

        public UsuarioAdjuntoViewModelMapper()
        {
            Mapper.CreateMap<UsuarioAdjunto, UsuarioAdjuntoViewModel>()
			//.ForMember(model => model.Categorias, opt => opt.Ignore())
			;
            Mapper.CreateMap<UsuarioAdjuntoViewModel, UsuarioAdjunto>()
			//.ForMember(model => model.Categorias, opt => opt.Ignore())
			;
        }
		  public override UsuarioAdjuntoViewModel Map(UsuarioAdjunto model)
        {
            var viewModel = base.Map(model);
			return viewModel;
        }

        public override void Map(UsuarioAdjuntoViewModel viewModel, UsuarioAdjunto model)
        {
            base.Map(viewModel, model);

            //this.Set(hospital => model.UserContact = hospital, viewModel.ContactId, UserExtendedDao);
        }

        public override IEnumerable<UsuarioAdjuntoViewModel> Map(IEnumerable<UsuarioAdjunto> models)
        {
            return models.Select(Map);
        }
    }
}