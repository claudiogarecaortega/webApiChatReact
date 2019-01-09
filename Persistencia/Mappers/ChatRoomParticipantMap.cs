using System.Data.Entity.ModelConfiguration;
using Dominio.ChatRooms;

namespace Persistencia.Mappers
{ 
    public class ChatRoomParticipantMap : EntityTypeConfiguration<ChatRoomParticipant>
    {
		public ChatRoomParticipantMap()
        {
            this.ToTable("ChatRoomParticipant");
            this.HasKey(chatroomparticipant => chatroomparticipant.Id);

            this.Property(chatroomparticipant => chatroomparticipant.Id).IsRequired();
        }
	}
}