using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Modelos.ApiModels.Peticiones;
using Modelos.ApiModels.Peticiones.ChatRooms;
using Modelos.ApiModels.Respuestas;
using Modelos.ViewModelMappers;
using Persistencia.Contextos;
using Persistencia.Daos;
using Persistencia.UnitsOfWork;
using Utilidades.Activadores;
using WebChatApi.Controllers;
using WebChatApi.Tests.Common;

namespace WebChatApi.Tests.AccountTest
{

    [TestClass]
    public class ChatRoomControllerTest:BaseApiTest
    {
        
        [TestMethod]
        public void CreateChatRoom()
        {
            var uow = new UnitOfWorkHelper { SessionContext = new ApplicationDbContext() };
            var userDao = new UsuarioDao(uow, new ActivatorWrapper());
            // Arrange

            var chatRoomDao = new ChatRoomDao(uow, new ActivatorWrapper());
            var messageDao = new MessageDao(uow, new ActivatorWrapper());
            var chatRoomParticipantDao = new ChatRoomParticipantDao(uow, new ActivatorWrapper());

            var messageViewModelMapper = new MessageViewModelMapper();
            var chatRoomViewModelMapper = new ChatRoomViewModelMapper(userDao);
            var chatRoomParticipantViewModelMapper = new ChatRoomParticipantViewModelMapper();
            var controller = new ChatRoomController(userDao,chatRoomDao,chatRoomViewModelMapper,chatRoomParticipantDao,messageDao,messageViewModelMapper,chatRoomParticipantViewModelMapper)
            {
                Request = new HttpRequestMessage(){Headers = { Authorization =new AuthenticationHeaderValue("bearer",base.GetAuthorizationHeader(userDao)) }},
                
                Configuration = new HttpConfiguration()
            };
            var random = new Random();
            // Act
            var response = controller.CreateChatRoom(new ChatRoomViewModel() { Name = $"chat room test api {random.Next(1,8958)}", Description = "test from api" });

            // Assert
            var contentResult = response as OkNegotiatedContentResult<ChatRoomResponse>;
            Assert.IsNotNull(contentResult);
            Assert.IsFalse(contentResult.Content.JsonResult.HasError);
            Assert.AreNotEqual(contentResult.Content.Id, 0);
        }
        [TestMethod]
        public void AddParticipantToChatRoom()
        {
            
            var uow = new UnitOfWorkHelper { SessionContext = new ApplicationDbContext() };
            var userDao = new UsuarioDao(uow, new ActivatorWrapper());
            // Arrange

            var chatRoomDao = new ChatRoomDao(uow, new ActivatorWrapper());
            var messageDao = new MessageDao(uow, new ActivatorWrapper());
            var rollDao = new RolDao(uow, new ActivatorWrapper());
            var chatRoomParticipantDao = new ChatRoomParticipantDao(uow, new ActivatorWrapper());
            var token= base.GetAuthorizationHeader(userDao);
            var messageViewModelMapper = new MessageViewModelMapper();
            var chatRoomViewModelMapper = new ChatRoomViewModelMapper(userDao);
            var chatRoomParticipantViewModelMapper = new ChatRoomParticipantViewModelMapper();
            var controller = new ChatRoomController(userDao, chatRoomDao, chatRoomViewModelMapper, chatRoomParticipantDao, messageDao, messageViewModelMapper, chatRoomParticipantViewModelMapper)
            {
                Request = new HttpRequestMessage() ,
                
                Configuration = new HttpConfiguration() 
            };
            controller.Request.Headers.Add("Authorization", $"Bearer {token}");
            controller.Request.Headers.Authorization=new AuthenticationHeaderValue("Bearer", $" {token}");
            var random = new Random();
            var chatRoom=chatRoomDao.GetAll().FirstOrDefault(m => m.Name == "unittest");
            var usercontroller=new AccountController(userDao,rollDao);
            var responseUser = usercontroller.Create(new RegistroViewModel() { Email = $"testApi{random.Next(0, 10000)}@tes.com", Name = "test Api", Password = "Test", UserName = $"TestUserNAme{random.Next(0, 10000)}" });

            // Assert
            var contentResultUser = responseUser as OkNegotiatedContentResult<CreateResponse>;
            // Act
            var response = controller.AddParticipantToChatRoom(new AddParticipantChatRoom() { IdChatRoom =chatRoom.Id , IdUser =contentResultUser.Content.Id });

            // Assert
            var contentResult = response as OkNegotiatedContentResult<ChatRoomResponse>;
            Assert.IsNotNull(contentResult);
            Assert.IsFalse(contentResult.Content.JsonResult.HasError);
            Assert.AreNotEqual(contentResult.Content.Id, 0);
        }
    }
}
