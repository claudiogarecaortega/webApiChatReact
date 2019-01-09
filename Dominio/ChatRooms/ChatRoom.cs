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
    public class ChatRoom : Auditoria, IIdentifiableObjectModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }


        #region Relaciones

        public virtual Usuario Creator { get; set; }

        public virtual IList<ChatRoomParticipant> Participants{ get; set; }
        public virtual IList<Message> Messages{ get; set; }

        #endregion
    }
}
