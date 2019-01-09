using Dominio.ChatRooms;
using Modelos.ViewModels;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using Modelos.ViewModelMappers.Interfaces;
using Persistencia.Contextos;



namespace Modelos.ViewModelMappers
{
    public class MessageViewModelMapper : ViewModelMapper<Message, MessageViewModel, MessageViewModel>, IMessageViewModelMapper
    {

        public MessageViewModelMapper()
        {
            Mapper.CreateMap<Message, MessageViewModel>()
			//.ForMember(model => model.Categorias, opt => opt.Ignore())
			;
            Mapper.CreateMap<MessageViewModel, Message>()
			//.ForMember(model => model.Categorias, opt => opt.Ignore())
			;
        }
		  public override MessageViewModel Map(Message model)
        {
            var viewModel = base.Map(model);
            if (model.Owner != null)
            {
                viewModel.UserOwner = model.Owner.UserName;
                viewModel.Id = model.Owner.Id;
            }
            viewModel.DateSend = model.FechaAlta.ToString("f");

			return viewModel;
        }

        public override void Map(MessageViewModel viewModel, Message model)
        {
            base.Map(viewModel, model);

            //this.Set(hospital => model.UserContact = hospital, viewModel.ContactId, UserExtendedDao);
        }

        public override IEnumerable<MessageViewModel> Map(IEnumerable<Message> models)
        {
            return models.Select(Map);
        }
    }
}