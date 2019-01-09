using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelos.ViewModels;
using Modelos.ApiModels.Peticiones;
using ChatRoomViewModel = Modelos.ApiModels.Peticiones.ChatRoomViewModel;

namespace Modelos.ApiModels.Respuestas
{
    public class ChatRoomResponse:BaseResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IList<MessageViewModel> ChatRoomMessages { get; set; }
        public IList<ChatRoomViewModel> ChatRooms { get; set; }
        public IList<ChatRoomParticipantViewModel> Participant { get; set; }

    }
}
