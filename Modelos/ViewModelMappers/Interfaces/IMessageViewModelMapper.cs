using Dominio.ChatRooms;
using Modelos.ViewModels;

namespace Modelos.ViewModelMappers.Interfaces
{
    public interface IMessageViewModelMapper : IViewModelMapper<Message, MessageViewModel, MessageViewModel>
    {
    }
}