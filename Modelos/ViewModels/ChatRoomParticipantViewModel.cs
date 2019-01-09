using System.ComponentModel.DataAnnotations;
using Dominio.IdentificableObject;
using Libreria.Resource;

namespace Modelos.ViewModels

{ 
    public class ChatRoomParticipantViewModel :IIdentifiableObject
    {
		public int Id { get; set; }
        
        public string UserName { get; set; }
        public bool Aproved { get; set; }

	}
}