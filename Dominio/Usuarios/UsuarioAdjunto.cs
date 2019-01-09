using Dominio.Common;
using Dominio.IdentificableObject;
using Dominio.Seguridad;

namespace Dominio.Usuarios
{
    public class UsuarioAdjunto:Auditoria,IIdentifiableObjectModel
    {
        public int Id { get; set; }
        public string Descripccion { get; set; }
        public string Titulo { get; set; }
        public bool EsImagen { get; set; }
        public bool Principal { get; set; }

        #region Relaciones
        public virtual Adjunto Adjunto { get; set; }
        public virtual Usuario Usuario { get; set; }
        #endregion
    }
}
