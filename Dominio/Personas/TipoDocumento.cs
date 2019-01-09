
using Dominio.IdentificableObject;
using Dominio.Seguridad;

namespace Dominio.Personas
{
    public class TipoDocumento:Auditoria,IIdentifiableObjectModel
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
    }
}
