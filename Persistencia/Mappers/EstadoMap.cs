using System.Data.Entity.ModelConfiguration;
using Dominio.Common;

namespace Persistencia.Mappers
{
    public class EstadoMap : EntityTypeConfiguration<Estado>
    {
        public EstadoMap()
        {
            this.ToTable("Estado");
            this.HasKey(estado => estado.Id);

            this.Property(estado => estado.Id).IsRequired();
        }
    }
}