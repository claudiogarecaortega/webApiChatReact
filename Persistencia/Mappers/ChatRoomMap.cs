using System.Data.Entity.ModelConfiguration;
using Dominio.ChatRooms;

namespace Persistencia.Mappers
{ 
    public class ChatRoomMap : EntityTypeConfiguration<ChatRoom>
    {
		public ChatRoomMap()
        {
            this.ToTable("ChatRoom");
            this.HasKey(chatroom => chatroom.Id);

            this.Property(chatroom => chatroom.Id).IsRequired();
        }
	}
}