using System.Data.Entity.ModelConfiguration;
using Dominio.Common;

namespace Persistencia.Mappers
{ 
    public class AdjuntoMap : EntityTypeConfiguration<Adjunto>
    {
		public AdjuntoMap()
        {
            this.ToTable("Adjunto");
            this.HasKey(adjunto => adjunto.Id);

            this.Property(adjunto => adjunto.Id).IsRequired();
        }
	}
}