using System.Data.Entity.ModelConfiguration;
using Dominio.Usuarios;

namespace Persistencia.Mappers
{ 
    public class UsuarioMap : EntityTypeConfiguration<Usuario>
    {
		public UsuarioMap()
        {
            this.ToTable("Usuario");
            this.HasKey(usuario => usuario.Id);

            this.Property(usuario => usuario.Id).IsRequired();
        }
	}
}