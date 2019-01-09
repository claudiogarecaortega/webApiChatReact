using System.ComponentModel.DataAnnotations;
using Dominio.IdentificableObject;
using Libreria.Resource;

namespace Modelos.ViewModels

{ 
    public class AccionViewModel :IIdentifiableObject
    {
		public int Id { get; set; }
        [Display(ResourceType = typeof(Resources), Name = "Description")]
        public string Descripcion { get; set; }
	}
}