using System.Data.Entity.ModelConfiguration;
using Dominio.Seguridad;

namespace Persistencia.Mappers
{ 
    public class RolMap : EntityTypeConfiguration<Rol>
    {
		public RolMap()
        {
            this.ToTable("Rol");
            this.HasKey(rol => rol.Id);

            this.Property(rol => rol.Id).IsRequired();
            this.HasMany(roles => roles.ListaUsuarios)
                .WithOptional(roles => roles.UsuarioRol)
                .Map(x => x.MapKey("RolId"));
            this.HasMany(x => x.ListaModuloAcciones)
                .WithRequired(x => x.Rol)
                .Map(x => x.MapKey("RolId"));
           
        }
	}
}