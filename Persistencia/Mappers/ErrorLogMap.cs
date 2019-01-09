using System.Data.Entity.ModelConfiguration;
using Dominio.Errores;

namespace Persistencia.Mappers
{ 
    public class ErrorLogMap : EntityTypeConfiguration<ErrorLog>
    {
		public ErrorLogMap()
        {
            this.ToTable("ErrorLog");
            this.HasKey(errorlog => errorlog.Id);

            this.Property(errorlog => errorlog.Id).IsRequired();
        }
	}
}