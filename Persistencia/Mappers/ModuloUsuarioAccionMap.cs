using System.Data.Entity.ModelConfiguration;
using Dominio.Seguridad;

namespace Persistencia.Mappers
{ 
    public class ModuloUsuarioAccionMap : EntityTypeConfiguration<ModuloUsuarioAccion>
    {
		public ModuloUsuarioAccionMap()
        {
            this.ToTable("ModuloUsuarioAccion");
            this.HasKey(modulousuarioaccion => modulousuarioaccion.Id);

            this.Property(modulousuarioaccion => modulousuarioaccion.Id).IsRequired();
            this.HasMany(m => m.Acciones)
                .WithMany(v => v.ModuloUdUsuarioAcciones)
                .Map(x => x.ToTable("ModuloUsuarioAccionesMuchas").MapLeftKey("ModuloAccionesUsuarioId").MapRightKey("AccionId"));
        }
	}
}