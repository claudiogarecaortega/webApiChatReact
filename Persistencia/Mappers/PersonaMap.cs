using System.Data.Entity.ModelConfiguration;
using Dominio.Personas;

namespace Persistencia.Mappers
{ 
    public class PersonaMap : EntityTypeConfiguration<Persona>
    {
		public PersonaMap()
        {
            this.ToTable("Persona");
            this.HasKey(persona => persona.Id);

            this.Property(persona => persona.Id).IsRequired();
           
            this.HasRequired(cliente => cliente.Usuario)
                .WithOptional(persona => persona.Persona);
        }
	}
}