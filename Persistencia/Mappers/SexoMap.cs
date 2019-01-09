using System.Data.Entity.ModelConfiguration;
using Dominio.Common;

namespace Persistencia.Mappers
{ 
    public class SexoMap : EntityTypeConfiguration<Sexo>
    {
		public SexoMap()
        {
            this.ToTable("Sexo");
            this.HasKey(sexo => sexo.Id);

            this.Property(sexo => sexo.Id).IsRequired();
        }
	}
}