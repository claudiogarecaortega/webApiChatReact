using System.Data.Entity.ModelConfiguration;
using Dominio.Seguridad;

namespace Persistencia.Mappers
{ 
    public class AccionMap : EntityTypeConfiguration<Accion>
    {
		public AccionMap()
        {
            this.ToTable("Accion");
            this.HasKey(accion => accion.Id);

            this.Property(accion => accion.Id).IsRequired();

            #region Relaciones

           
            #endregion
        }
    }
}