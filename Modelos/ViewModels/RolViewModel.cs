using System.ComponentModel.DataAnnotations;
using Dominio.IdentificableObject;
using Libreria.Resource;

namespace Modelos.ViewModels

{ 
    public class RolViewModel :IIdentifiableObject
    {
		public int Id { get; set; }
        [Display(ResourceType = typeof(Resources), Name = "Description")]
        public string Descripcion { get; set; }
        public string Nombre { get; set; }
	}
    public class RolModuloViewModel
    {
        public int RolNameId { get; set; }
        public int ModuleNameId { get; set; }
        public string RolName { get; set; }
        public string ModuleName { get; set; }
        public string[] Actions { get; set; }
    }
    public class RolNotificacionesAlertasViewModel
    {
        public int RolNameId { get; set; }
        public string RolName { get; set; }
        public string[] Notificaciones { get; set; }
        public string[] Alertas { get; set; }
    }
}