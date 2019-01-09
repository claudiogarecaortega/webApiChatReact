using System;
using System.ComponentModel.DataAnnotations;
using Dominio.IdentificableObject;
using Libreria.Resource;

namespace Modelos.ViewModels

{ 
    public class PersonaViewModel :IIdentifiableObject
    {
		public int Id { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Documento { get; set; }
        public string Telefono { get; set; }
        public string TelefonAlternativo { get; set; }
        public DateTime? FechaNacimento { get; set; }

      
        public virtual SexoViewModel Sexo { get; set; }
        public virtual TipoDocumentoViewModel TipoDocumento { get; set; }
    }
}