using System.ComponentModel.DataAnnotations;
using Dominio.IdentificableObject;
using Libreria.Resource;

namespace Modelos.ViewModels

{ 
    public class ModuloViewModel :IIdentifiableObject
    {
		public int Id { get; set; }
		[Display(ResourceType = typeof(Resources), Name = "Description")]
        public string Descripcion { get; set; }
        [Display(ResourceType = typeof(Resources), Name = "Nombre")]
        public string Nombre { get; set; }
        [Display(ResourceType = typeof(Resources), Name = "ModuloPadre")]
        public string ModuloPadre { get; set; }
        [Display(ResourceType = typeof(Resources), Name = "ModuloPadre")]
        public int? ModuloPadreId { get; set; }
    }
}