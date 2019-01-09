using Dominio.ChatRooms;

using System.Linq;
using Persistencia.UnitsOfWork;
using Utilidades.Activadores;
using Persistencia.Daos.Interfaces;

namespace Persistencia.Daos
{ 
    public class ChatRoomParticipantDao : Dao<ChatRoomParticipant>, IChatRoomParticipantDao
    {
		
		  public ChatRoomParticipantDao(IUnitOfWorkHelper unitOfWorkHelper, IActivatorWrapper activator)
            : base(unitOfWorkHelper, activator)
        {
        }

		
	}
}