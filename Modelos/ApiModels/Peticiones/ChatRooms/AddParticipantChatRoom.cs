using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos.ApiModels.Peticiones.ChatRooms
{
    public class AddParticipantChatRoom
    {
        public int IdChatRoom { get; set; }
        public int IdUser { get; set; }

    }
}
