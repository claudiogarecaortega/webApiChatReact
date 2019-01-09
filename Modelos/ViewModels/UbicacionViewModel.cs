using System.ComponentModel.DataAnnotations;
using Dominio.IdentificableObject;
using Libreria.Resource;

namespace Modelos.ViewModels

{ 
    public class UbicacionViewModel :IIdentifiableObject
    {
		public int Id { get; set; }
		[Display(ResourceType = typeof(Resources), Name = "Description")]
        public string Descripcion { get; set; }
        public string DescripcionCompleta { get; set; }
        [Display(ResourceType = typeof(ViewModelsResources), Name = "Ubicacion")]
        public string UbicacionPadre { get; set; }
        [Display(ResourceType = typeof(ViewModelsResources), Name = "Ubicacion")]
        public int? UbicacionPdreId { get; set; }
	}
}