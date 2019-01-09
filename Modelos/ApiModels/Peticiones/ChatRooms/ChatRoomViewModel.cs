using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos.ApiModels.Peticiones
{
    public class ChatRoomViewModel
    {
        public int  Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int UserCreatorId { get; set; }
    }
}
