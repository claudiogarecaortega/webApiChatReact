using Dominio.ChatRooms;
using Modelos.ApiModels.Peticiones;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using Modelos.ViewModelMappers.Interfaces;
using Persistencia.Contextos;
using Persistencia.Daos.Interfaces;


namespace Modelos.ViewModelMappers
{
    public class ChatRoomViewModelMapper : ViewModelMapper<ChatRoom, ChatRoomViewModel, ChatRoomViewModel>, IChatRoomViewModelMapper
    {
        private readonly IUsuarioDao _userDao;

        public ChatRoomViewModelMapper(IUsuarioDao userDao)
        {
            _userDao = userDao;
            Mapper.CreateMap<ChatRoom, ChatRoomViewModel>()
			//.ForMember(model => model.Categorias, opt => opt.Ignore())
			;
            Mapper.CreateMap<ChatRoomViewModel, ChatRoom>()
			//.ForMember(model => model.Categorias, opt => opt.Ignore())
			;
        }
		  public override ChatRoomViewModel Map(ChatRoom model)
        {
            var viewModel = base.Map(model);
            if (model.Creator != null)
            {
                viewModel.UserCreatorId = model.Creator.Id;}
			return viewModel;
        }

        public override void Map(ChatRoomViewModel viewModel, ChatRoom model)
        {
            base.Map(viewModel, model);

            this.Set(owner => model.Creator = owner, viewModel.UserCreatorId, _userDao);
        }

        public override IEnumerable<ChatRoomViewModel> Map(IEnumerable<ChatRoom> models)
        {
            return models.Select(Map);
        }
    }
}