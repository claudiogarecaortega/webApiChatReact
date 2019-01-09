using System.Data.Entity.ModelConfiguration;
using Dominio.Common;

namespace Persistencia.Mappers
{ 
    public class UbicacionMap : EntityTypeConfiguration<Ubicacion>
    {
		public UbicacionMap()
        {
            this.ToTable("Ubicacion");
            this.HasKey(ubicacion => ubicacion.Id);

            this.Property(ubicacion => ubicacion.Id).IsRequired();
            this.HasOptional(ubicacion => ubicacion.UbicacionPadre)
                .WithMany();
        }
	}
}