using System.Data.Entity.ModelConfiguration;
using Dominio.Usuarios;

namespace Persistencia.Mappers
{ 
    public class UsuarioAdjuntoMap : EntityTypeConfiguration<UsuarioAdjunto>
    {
		public UsuarioAdjuntoMap()
        {
            this.ToTable("UsuarioAdjunto");
            this.HasKey(usuarioadjunto => usuarioadjunto.Id);

            this.Property(usuarioadjunto => usuarioadjunto.Id).IsRequired();
        }
	}
}