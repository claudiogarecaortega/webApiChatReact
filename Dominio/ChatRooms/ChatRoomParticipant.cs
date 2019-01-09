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
    public class ChatRoomParticipant : Auditoria, IIdentifiableObjectModel
    {
        public int Id { get; set; }
        public bool Approved  { get; set; }
        public bool Blocked  { get; set; }

        #region Relaciones

        public virtual Usuario Participant { get; set; }

      
        #endregion
    }
}
