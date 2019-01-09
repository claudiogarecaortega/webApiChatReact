using System.ComponentModel.DataAnnotations;
using Dominio.IdentificableObject;
using Libreria.Resource;

namespace Modelos.ViewModels

{ 
    public class MessageViewModel :IIdentifiableObject
    {
		public int Id { get; set; }
        public string TextMessage { get; set; }
        public string UserOwner { get; set; }
        public int UserOwnerId { get; set; }
        public string DateSend { get; set; }
    }
}