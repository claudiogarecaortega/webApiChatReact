using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos.ApiModels.Peticiones.ChatRooms
{
    public class SendTextMessageViewModel
    {
        public string TextMessage { get; set; }
        public int IdChatRoom { get; set; }
        
    }
}
