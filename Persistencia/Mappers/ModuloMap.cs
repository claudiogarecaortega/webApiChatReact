using System.Data.Entity.ModelConfiguration;
using Dominio.Seguridad;

namespace Persistencia.Mappers
{ 
    public class ModuloMap : EntityTypeConfiguration<Modulo>
    {
		public ModuloMap()
        {
            this.ToTable("Modulo");
            this.HasKey(modulo => modulo.Id);

            this.Property(modulo => modulo.Id).IsRequired();

            #region Relaciones  

            this.HasOptional(modulopadre => modulopadre.ModuloPadre)
                .WithMany();


            this.HasMany(x => x.ListaModuloAcciones)
                .WithRequired(m => m.Modulo)
                .Map(x => x.MapKey("ModuloId"));
            this.HasMany(x => x.ListaModuloUsuarioAcciones)
                .WithOptional(x => x.Modulo)
                .Map(z => z.MapKey("ModuloId"));

            #endregion
        }
	}
}