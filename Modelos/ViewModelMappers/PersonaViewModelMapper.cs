using Dominio.Personas;
using Modelos.ViewModels;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using Modelos.ViewModelMappers.Interfaces;
using Persistencia.Contextos;



namespace Modelos.ViewModelMappers
{
    public class PersonaViewModelMapper : ViewModelMapper<Persona, PersonaViewModel, PersonaViewModel>, IPersonaViewModelMapper
    {

        public PersonaViewModelMapper()
        {
            Mapper.CreateMap<Persona, PersonaViewModel>()
			//.ForMember(model => model.Categorias, opt => opt.Ignore())
			;
            Mapper.CreateMap<PersonaViewModel, Persona>()
			//.ForMember(model => model.Categorias, opt => opt.Ignore())
			;
        }
		  public override PersonaViewModel Map(Persona model)
        {
            var viewModel = base.Map(model);
			return viewModel;
        }

        public override void Map(PersonaViewModel viewModel, Persona model)
        {
            base.Map(viewModel, model);

            //this.Set(hospital => model.UserContact = hospital, viewModel.ContactId, UserExtendedDao);
        }

        public override IEnumerable<PersonaViewModel> Map(IEnumerable<Persona> models)
        {
            return models.Select(Map);
        }
    }
}