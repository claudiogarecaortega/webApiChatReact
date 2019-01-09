using System.Text;
using Dominio.IdentificableObject;
using Dominio.Seguridad;

namespace Dominio.Common
{
    public class Ubicacion : Auditoria, IIdentifiableObjectModel
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public virtual Ubicacion UbicacionPadre { get; set; }
        public string DescripcionCompleta()
        {
            var stringBuilder = new StringBuilder();

            stringBuilder.Append(Descripcion);

            var ubicacionPadre = UbicacionPadre;

            while (ubicacionPadre != null)
            {
                stringBuilder.AppendFormat(" - {0}", ubicacionPadre.Descripcion);

                ubicacionPadre = ubicacionPadre.UbicacionPadre;
            }

            return stringBuilder.ToString();
        }
    }
}
