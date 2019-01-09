using System;
using System.Linq;
using System.Text;
using System.Web.Http;
using Libreria.Execptiones;
using Microsoft.AspNet.Identity;
using Modelos.ApiModels.Peticiones.ChatRooms;
using Modelos.ApiModels.Respuestas;
using Modelos.ViewModelMappers.Interfaces;
using Persistencia.Daos.Interfaces;
using RabbitMQ.Client;
using ChatRoomViewModel = Modelos.ApiModels.Peticiones.ChatRoomViewModel;

namespace WebChatApi.Controllers
{
    [RoutePrefix("api/chatroom")]
   public class ChatRoomController :BaseController
    {
        private readonly IChatRoomDao _chatRoomDao;
        private readonly IChatRoomViewModelMapper _chatRoomViewModelMapper;
        private readonly IChatRoomParticipantDao _chatRoomParticipantDao;
        private readonly IMessageDao _messageDao;
        private readonly IMessageViewModelMapper _messageViewModelMapper;
        private readonly IChatRoomParticipantViewModelMapper _chatParticipantViewModelMapper;

        public ChatRoomController(IUsuarioDao userDao, IChatRoomDao chatRoomDao, IChatRoomViewModelMapper chatRoomViewModelMapper, IChatRoomParticipantDao chatRoomParticipantDao, IMessageDao messageDao, IMessageViewModelMapper messageViewModelMapper, IChatRoomParticipantViewModelMapper chatParticipantViewModelMapper) : base(userDao)
        {
            _chatRoomDao = chatRoomDao;
            _chatRoomViewModelMapper = chatRoomViewModelMapper;
            _chatRoomParticipantDao = chatRoomParticipantDao;
            _messageDao = messageDao;
            _messageViewModelMapper = messageViewModelMapper;
            _chatParticipantViewModelMapper = chatParticipantViewModelMapper;
        }
        [Route("CreateChatRoom")]
        [HttpPost]
        public IHttpActionResult CreateChatRoom(ChatRoomViewModel viewModel)
        {
            var jsonResult = new ChatRoomResponse();
            try
            {
                var userId =Convert.ToInt32(User.Identity.GetUserId());
                if (string.IsNullOrEmpty(viewModel.Name))
                    throw new CustomExeption("The name is invalid");

                if (string.IsNullOrEmpty(viewModel.Description))
                    throw new CustomExeption("The description is invalid");

                viewModel.UserCreatorId = userId;
                var model = _chatRoomDao.Create();
                _chatRoomViewModelMapper.Map(viewModel,model);
                _chatRoomDao.Add(model);
                _chatRoomDao.Save();

                jsonResult.Id = model.Id;
                jsonResult.Name = model.Name;
                jsonResult.Description = model.Description;
               jsonResult.JsonResult=new JsonResult()
               {
                   HasError = false,
                   EntityResult = "Create Chat Room"
               };
                 return Ok( jsonResult );
            }
            catch (CustomExeption e)
            {
                jsonResult.JsonResult = new JsonResult()
                {
                    HasError = true,
                    ErrorMessage = e.Message,
                    EntityResult = "Create"
                };
                 return Ok( jsonResult );
            }
            catch (Exception e)
            {
                jsonResult.JsonResult = new JsonResult()
                {
                    HasError = true,
                    ErrorMessage = e.Message,
                    EntityResult = "Create"
                };
                 return Ok( jsonResult );
            }
        }
        [Route("AddParticipantToChatRoom")]
        [HttpPost]
        public IHttpActionResult AddParticipantToChatRoom(AddParticipantChatRoom viewModel)
        {
            var jsonResult = new ChatRoomResponse();
            try
            {
                var userId = Convert.ToInt32(User.Identity.GetUserId());
                if(!_chatRoomDao.ValidateChatRoomOwner(viewModel.IdChatRoom,userId))
                    throw new CustomExeption("The user is not the owner chat room");

                if (!_chatRoomDao.ValidateChatRoom(viewModel.IdChatRoom))
                    throw new CustomExeption("The Chat Room is not invalid");

                if (!_userDao.ValidateUserById(viewModel.IdUser))
                    throw new CustomExeption("The user does not exist invalid");

                var model = _chatRoomDao.Get(viewModel.IdChatRoom);
                var user = _userDao.Get(viewModel.IdUser);
                var participant = _chatRoomParticipantDao.Create();
                participant.Approved = true;
                participant.Participant = user;
                model.Participants.Add(participant);
                _chatRoomDao.Save();

                jsonResult.Id = model.Id;
                jsonResult.Name = model.Name;
                jsonResult.Description = model.Description;
                jsonResult.JsonResult = new JsonResult()
                {
                    HasError = false,
                    EntityResult = "Add Participant to Chat Room"
                };
                 return Ok( jsonResult );
            }
            catch (CustomExeption e)
            {
                jsonResult.JsonResult = new JsonResult()
                {
                    HasError = true,
                    ErrorMessage = e.Message,
                    EntityResult = "Add Participant to Chat Room"
                };
                 return Ok( jsonResult );
            }
            catch (Exception e)
            {
                jsonResult.JsonResult = new JsonResult()
                {
                    HasError = true,
                    ErrorMessage = e.Message,
                    EntityResult = "Add Participant to Chat Room"
                };
                 return Ok( jsonResult );
            }
        }
        [Route("AskJoinParticipantToChatRoom")]
        [HttpPost]
        public IHttpActionResult AskJoinParticipantToChatRoom(AskJoinChatRoomViewModel viewModel)
        {
            var jsonResult = new ChatRoomResponse();
            try
            {
                var userId = Convert.ToInt32(User.Identity.GetUserId());
                if (_chatRoomDao.ValidateChatRoomOwner(viewModel.IdChatRoom, userId))
                    throw new CustomExeption("your are the owner, you can not be add as a participant");

                if (_chatRoomDao.ValidateUserChatRoom(viewModel.IdChatRoom, userId))
                    throw new CustomExeption("you have a pending request for this chat room");


                if (!_chatRoomDao.ValidateChatRoom(viewModel.IdChatRoom))
                    throw new CustomExeption("The Chat Room is not invalid");

                if (!_userDao.ValidateUserById(userId))
                    throw new CustomExeption("The user does not exist invalid");

                var model = _chatRoomDao.Get(viewModel.IdChatRoom);
                var user = _userDao.Get(userId);
                var participant = _chatRoomParticipantDao.Create();
                participant.Approved = true;
                participant.Participant = user;
                model.Participants.Add(participant);
                _chatRoomDao.Save();

                jsonResult.Id = model.Id;
                jsonResult.Name = model.Name;
                jsonResult.Description = model.Description;
                jsonResult.JsonResult = new JsonResult()
                {
                    HasError = false,
                    EntityResult = "Ask Join Participant to Chat Room"
                };
                 return Ok( jsonResult );
            }
            catch (CustomExeption e)
            {
                jsonResult.JsonResult = new JsonResult()
                {
                    HasError = true,
                    ErrorMessage = e.Message,
                    EntityResult = "Ask Join Participant to Chat Room"
                };
                 return Ok( jsonResult );
            }
            catch (Exception e)
            {
                jsonResult.JsonResult = new JsonResult()
                {
                    HasError = true,
                    ErrorMessage = e.Message,
                    EntityResult = "Ask Join Participant to Chat Room"
                };
                 return Ok( jsonResult );
            }
        }
        [Route("SendTextMessageToChatRoom")]
        [HttpPost]
        public IHttpActionResult SendTextMessageToChatRoom(SendTextMessageViewModel viewModel)
        {
            var jsonResult = new ChatRoomResponse();
            try
            {
                var userId = Convert.ToInt32(User.Identity.GetUserId());
                if (!_chatRoomDao.ValidateChatRoomParticipant(viewModel.IdChatRoom, userId))
                    throw new CustomExeption("You are not a valid member of this chat Room");

                if (!_chatRoomDao.ValidateChatRoom(viewModel.IdChatRoom))
                    throw new CustomExeption("The Chat Room is not invalid");

                if (!_userDao.ValidateUserById(userId))
                    throw new CustomExeption("The user does not exist invalid");
                if (viewModel.TextMessage.Contains("/stock="))
                {
                    RabbitQueue(viewModel.IdChatRoom.ToString());
                }
                else
                {
                    var model = _chatRoomDao.Get(viewModel.IdChatRoom);
                    var user = _userDao.Get(userId);
                    var textMessage = _messageDao.Create();
                    textMessage.TextMessage = viewModel.TextMessage;
                    textMessage.Owner = user;
                    model.Messages.Add(textMessage);
                    _chatRoomDao.Save();
                    jsonResult.Id = model.Id;
                    jsonResult.Name = model.Name;
                    jsonResult.Description = model.Description;
                   
                }
                jsonResult.JsonResult = new JsonResult()
                {
                    HasError = false,
                    EntityResult = "Send Message to Chat Room"
                };
                return Ok(jsonResult);

            }
            catch (CustomExeption e)
            {
                jsonResult.JsonResult = new JsonResult()
                {
                    HasError = true,
                    ErrorMessage = e.Message,
                    EntityResult = "Send Message to Chat Room"
                };
                 return Ok( jsonResult );
            }
            catch (Exception e)
            {
                jsonResult.JsonResult = new JsonResult()
                {
                    HasError = true,
                    ErrorMessage = e.Message,
                    EntityResult = "Send Message to Chat Room"
                };
                 return Ok( jsonResult );
            }
        }
        [Route("GetSendTextMessageChatRoom")]
        [HttpPost]
        public IHttpActionResult GetSendTextMessageChatRoom(SendTextMessageViewModel viewModel)
        {
            var jsonResult = new ChatRoomResponse();
            try
            {
                var userId = Convert.ToInt32(User.Identity.GetUserId());
                if (!_chatRoomDao.ValidateChatRoomParticipant(viewModel.IdChatRoom, userId))
                    throw new CustomExeption("You are not a valid member of this chat Room");

                if (!_chatRoomDao.ValidateChatRoom(viewModel.IdChatRoom))
                    throw new CustomExeption("The Chat Room is not invalid");

                if (!_userDao.ValidateUserById(userId))
                    throw new CustomExeption("The user does not exist invalid");

                var model = _chatRoomDao.Get(viewModel.IdChatRoom);
                jsonResult.Id = userId;
                jsonResult.Name = model.Name;
                jsonResult.Description = model.Description;
                jsonResult.ChatRoomMessages = _messageViewModelMapper.Map(model.Messages).ToList();
                jsonResult.Participant = _chatParticipantViewModelMapper.Map(model.Participants).ToList();
                jsonResult.JsonResult = new JsonResult()
                {
                    HasError = false,
                    EntityResult = "Get Messages to Chat Room"
                };
                 return Ok( jsonResult );
            }
            catch (CustomExeption e)
            {
                jsonResult.JsonResult = new JsonResult()
                {
                    HasError = true,
                    ErrorMessage = e.Message,
                    EntityResult = "Get Messages to Chat Room"
                };
                 return Ok( jsonResult );
            }
            catch (Exception e)
            {
                jsonResult.JsonResult = new JsonResult()
                {
                    HasError = true,
                    ErrorMessage = e.Message,
                    EntityResult = "Get Messages to Chat Room"
                };
                 return Ok( jsonResult );
            }
        }
        [Route("GetChatRooms")]
        [HttpPost]
        public IHttpActionResult GetChatRooms()
        {
            var jsonResult = new ChatRoomResponse();
            try
            {
                var userId = Convert.ToInt32(User.Identity.GetUserId());
             
                if (!_userDao.ValidateUserById(userId))
                    throw new CustomExeption("The user does not exist invalid");

                var models = _chatRoomDao.GetAll();
                jsonResult.ChatRooms = _chatRoomViewModelMapper.Map(models).ToList();
                jsonResult.JsonResult = new JsonResult()
                {
                    HasError = false,
                    EntityResult = "Get Messages to Chat Room"
                };
                return Ok( jsonResult );
            }
            catch (CustomExeption e)
            {
                jsonResult.JsonResult = new JsonResult()
                {
                    HasError = true,
                    ErrorMessage = e.Message,
                    EntityResult = "Get Messages to Chat Room"
                };
                return Ok( jsonResult );
            }
            catch (Exception e)
            {
                jsonResult.JsonResult = new JsonResult()
                {
                    HasError = true,
                    ErrorMessage = e.Message,
                    EntityResult = "Get Messages to Chat Room"
                };
                return Ok( jsonResult );
            }
        }

        #region RabbitMQ

        public void RabbitQueue(string cola)
        {
            var factory = new ConnectionFactory() {HostName = "localhost"};
            using (var connection=factory.CreateConnection())
            {
                using (var channel=connection.CreateModel())
                {
                    channel.QueueDeclare(cola, false, false, false, null);
                    var body = Encoding.UTF8.GetBytes("APPL quote is $93.42 per share”.");
                    channel.BasicPublish("",cola,null,body);
                }

              
            }
        }

        #endregion
    }
}