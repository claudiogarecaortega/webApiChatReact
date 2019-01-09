using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Seguridad
{
    public class Auditoria
    {
        public int UsuarioAlta { get; set; }
        public int? UsuarioBaja { get; set; }
        public int? UsuarioModificacion { get; set; }
        public DateTime FechaAlta { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public DateTime? FechaBaja { get; set; }
        public bool Activo { get; set; }
    }
}
