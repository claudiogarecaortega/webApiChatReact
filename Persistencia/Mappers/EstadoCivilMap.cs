using System.Data.Entity.ModelConfiguration;
using Dominio.Common;

namespace Persistencia.Mappers
{ 
    public class EstadoCivilMap : EntityTypeConfiguration<EstadoCivil>
    {
		public EstadoCivilMap()
        {
            this.ToTable("EstadoCivil");
            this.HasKey(estadocivil => estadocivil.Id);

            this.Property(estadocivil => estadocivil.Id).IsRequired();
        }
	}
}