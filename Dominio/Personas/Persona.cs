using System;
using Dominio.Common;
using Dominio.IdentificableObject;
using Dominio.Seguridad;
using Dominio.Usuarios;

namespace Dominio.Personas
{
    public class Persona : Auditoria, IIdentifiableObjectModel
    {
        public int Id { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Documento { get; set; }
        public string Telefono { get; set; }
        public string TelefonAlternativo { get; set; }
        public DateTime? FechaNacimento { get; set; }

        #region Relaciones

        public virtual Sexo Sexo { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual TipoDocumento TipoDocumento { get; set; }

        #endregion

        #region MEtodos

        public string ObtenerNombreComplete()
        {
            return $"{Nombres}, {Apellidos}";
        }
        public string ObtenerNombreCompletoDocumento()
        {
            return $"{Nombres}, {Apellidos} -Documento: {Documento}";
        }
       
        public int ObtenerEdad()
        {
            if (FechaNacimento == null)
                return 0;

            int age = DateTime.Now.Year - FechaNacimento.Value.Year;
            if (DateTime.Now < FechaNacimento.Value.AddYears(age)) age--;

            return age;
            
        }

        #endregion
    }
}
