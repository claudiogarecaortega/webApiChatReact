using System.Data.Entity.ModelConfiguration;
using Dominio.ChatRooms;

namespace Persistencia.Mappers
{ 
    public class MessageMap : EntityTypeConfiguration<Message>
    {
		public MessageMap()
        {
            this.ToTable("Message");
            this.HasKey(message => message.Id);

            this.Property(message => message.Id).IsRequired();
        }
	}
}