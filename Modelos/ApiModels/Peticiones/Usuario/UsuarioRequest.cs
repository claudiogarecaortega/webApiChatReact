using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos.ApiModels.Peticiones.Usuario
{
    public class UsuarioRequest
    {
        public int Id { get; set; }
        public string NombreCompleto { get; set; }
        public string NombreCorto { get; set; }
        public int Notificaiones { get; set; }
        public int Mensajes { get; set; }
        public int Rol { get; set; }

    }
}
