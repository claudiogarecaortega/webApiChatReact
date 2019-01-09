using Dominio.ChatRooms;
using Modelos.ViewModels;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using Modelos.ViewModelMappers.Interfaces;
using Persistencia.Contextos;



namespace Modelos.ViewModelMappers
{
    public class ChatRoomParticipantViewModelMapper : ViewModelMapper<ChatRoomParticipant, ChatRoomParticipantViewModel, ChatRoomParticipantViewModel>, IChatRoomParticipantViewModelMapper
    {

        public ChatRoomParticipantViewModelMapper()
        {
            Mapper.CreateMap<ChatRoomParticipant, ChatRoomParticipantViewModel>()
			//.ForMember(model => model.Categorias, opt => opt.Ignore())
			;
            Mapper.CreateMap<ChatRoomParticipantViewModel, ChatRoomParticipant>()
			//.ForMember(model => model.Categorias, opt => opt.Ignore())
			;
        }
		  public override ChatRoomParticipantViewModel Map(ChatRoomParticipant model)
        {
            var viewModel = base.Map(model);
            if (model.Participant != null)
            {
                viewModel.UserName = model.Participant.UserName;
                viewModel.Aproved = model.Approved;
            }
			return viewModel;
        }

        public override void Map(ChatRoomParticipantViewModel viewModel, ChatRoomParticipant model)
        {
            base.Map(viewModel, model);

            //this.Set(hospital => model.UserContact = hospital, viewModel.ContactId, UserExtendedDao);
        }

        public override IEnumerable<ChatRoomParticipantViewModel> Map(IEnumerable<ChatRoomParticipant> models)
        {
            return models.Select(Map);
        }
    }
}