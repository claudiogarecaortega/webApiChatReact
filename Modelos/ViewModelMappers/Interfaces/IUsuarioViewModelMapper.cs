using Dominio.Usuarios;
using Modelos.ViewModels;

namespace Modelos.ViewModelMappers.Interfaces
{
    public interface IUsuarioViewModelMapper : IViewModelMapper<Usuario, UsuarioViewModel, UsuarioViewModel>
    {
    }
}