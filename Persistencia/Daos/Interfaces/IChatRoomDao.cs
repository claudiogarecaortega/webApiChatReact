using Dominio.ChatRooms;

namespace Persistencia.Daos.Interfaces
{ 
    public interface IChatRoomDao : IDao<ChatRoom>
    {
        bool ValidateChatRoom(int idChatRoom);
        bool ValidateChatRoomOwner(int idChatRoom, int idUser);
        bool ValidateUserChatRoom(int idChatRoom, int idUser);
        bool ValidateChatRoomParticipant(int idChatRoom, int idUser);

    }
}