using Dominio.ChatRooms;

using System.Linq;
using Persistencia.UnitsOfWork;
using Utilidades.Activadores;
using Persistencia.Daos.Interfaces;

namespace Persistencia.Daos
{ 
    public class ChatRoomDao : Dao<ChatRoom>, IChatRoomDao
    {
		
		  public ChatRoomDao(IUnitOfWorkHelper unitOfWorkHelper, IActivatorWrapper activator)
            : base(unitOfWorkHelper, activator)
        {
        }

          public bool ValidateChatRoom(int idChatRoom)
          {
              return Get(idChatRoom) != null;
          }
          public bool ValidateChatRoomOwner(int idChatRoom,int idUser)
          {
              var chatRoom = Get(idChatRoom);
              return  chatRoom.Creator.Id==idUser;
          }
          public bool ValidateChatRoomParticipant(int idChatRoom, int idUser)
          {
              var chatRoom = Get(idChatRoom);
              if (chatRoom.Creator.Id == idUser)
                  return true;
              return chatRoom.Participants.Any(user=>(user.Participant.Id==idUser && user.Approved));
          }
        public bool ValidateUserChatRoom(int idChatRoom, int idUser)
          {
              var chatRoom = Get(idChatRoom);
              return chatRoom.Participants.Any(user=>user.Participant.Id==idUser);
          }


    }
}