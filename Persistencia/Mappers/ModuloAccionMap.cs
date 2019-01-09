using System.Data.Entity.ModelConfiguration;
using Dominio.Seguridad;

namespace Persistencia.Mappers
{ 
    public class ModuloAccionMap : EntityTypeConfiguration<ModuloAccion>
    {
		public ModuloAccionMap()
        {
            this.ToTable("ModuloAccion");
            this.HasKey(moduloaccion => moduloaccion.Id);

            this.Property(moduloaccion => moduloaccion.Id).IsRequired();
            this.HasMany(m => m.Acciones)
                .WithMany(v => v.ModuloAcciones)
                .Map(x => x.ToTable("ModuleAccionMuchas").MapLeftKey("ModuloAccionId").MapRightKey("AccionId"));
        }
	}
}