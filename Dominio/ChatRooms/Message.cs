using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.IdentificableObject;
using Dominio.Seguridad;
using Dominio.Usuarios;

namespace Dominio.ChatRooms
{
    public class Message : Auditoria, IIdentifiableObjectModel
    {
        public int Id { get; set; }
        public string TextMessage { get; set; }

        #region Relaciones

        public virtual Usuario Owner { get; set; }

        #endregion

    }
}
