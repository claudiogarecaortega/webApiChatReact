using System.Data.Entity.ModelConfiguration;
using Dominio.Personas;

namespace Persistencia.Mappers
{ 
    public class TipoDocumentoMap : EntityTypeConfiguration<TipoDocumento>
    {
		public TipoDocumentoMap()
        {
            this.ToTable("TipoDocumento");
            this.HasKey(tipodocumento => tipodocumento.Id);

            this.Property(tipodocumento => tipodocumento.Id).IsRequired();
        }
	}
}