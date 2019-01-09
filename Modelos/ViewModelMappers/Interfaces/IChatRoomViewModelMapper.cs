using Dominio.ChatRooms;
using Modelos.ApiModels.Peticiones;

namespace Modelos.ViewModelMappers.Interfaces
{
    public interface IChatRoomViewModelMapper : IViewModelMapper<ChatRoom, ChatRoomViewModel, ChatRoomViewModel>
    {
    }
}