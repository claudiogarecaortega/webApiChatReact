using Dominio.Personas;
using Modelos.ViewModels;

namespace Modelos.ViewModelMappers.Interfaces
{
    public interface IPersonaViewModelMapper : IViewModelMapper<Persona, PersonaViewModel, PersonaViewModel>
    {
    }
}