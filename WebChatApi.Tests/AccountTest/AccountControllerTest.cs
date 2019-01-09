using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Modelos.ApiModels.Peticiones;
using Modelos.ApiModels.Respuestas;
using Persistencia.Contextos;
using Persistencia.Daos;
using Persistencia.UnitsOfWork;
using Utilidades.Activadores;
using WebChatApi.Controllers;

namespace WebChatApi.Tests.AccountTest
{
    [TestClass]
    public class AccountControllerTest
    {
        [TestMethod]
        public void AccountCreate()
        {
            // Arrange
            var uow = new UnitOfWorkHelper();
            uow.SessionContext = new ApplicationDbContext();
            var chatRoomDao = new ChatRoomDao(uow, new ActivatorWrapper());
            var userDao = new UsuarioDao(uow, new ActivatorWrapper());
            var rollDao = new RolDao(uow, new ActivatorWrapper());
            var controller = new AccountController(userDao, rollDao);
            controller.Request = new HttpRequestMessage();
            
            
            controller.Configuration = new HttpConfiguration();
            Random random = new Random();
            // Act
            var response = controller.Create(new RegistroViewModel() { Email = $"testApi{random.Next(0, 10000)}@tes.com", Name = "test Api", Password = "Test", UserName = $"TestUserNAme{random.Next(0, 10000)}" });

            // Assert
            var contentResult = response as OkNegotiatedContentResult<CreateResponse>;
            Assert.IsNotNull(contentResult);
            Assert.AreNotEqual(contentResult.Content.Id, 0);

            Assert.IsFalse(contentResult.Content.JsonResult.HasError);
            Assert.AreNotEqual(contentResult.Content.JwtToken, "");
        }
        [TestMethod]
        public void AccountCreate_Error_Email_Exist()
        {
            // Arrange
            var uow = new UnitOfWorkHelper();
            uow.SessionContext = new ApplicationDbContext();
            var userDao = new UsuarioDao(uow, new ActivatorWrapper());
            var rollDao = new RolDao(uow, new ActivatorWrapper());
            var controller = new AccountController(userDao, rollDao);
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();
            Random random = new Random();
            // Act
            var response = controller.Create(new RegistroViewModel() { Email = "c@c.com", Name = "test Api", Password = "Test", UserName = $"TestUserNAme{random.Next(0, 10000)}" });

            // Assert
            var contentResult = response as OkNegotiatedContentResult<CreateResponse>;
            Assert.IsNotNull(contentResult);
            Assert.AreEqual(contentResult.Content.JsonResult.ErrorMessage, "The email is already registered");

            Assert.IsTrue(contentResult.Content.JsonResult.HasError);
        }
        [TestMethod]
        public void AccountCreate_Error_UserName_Exist()
        {
            // Arrange
            var uow = new UnitOfWorkHelper();
            uow.SessionContext = new ApplicationDbContext();
            var userDao = new UsuarioDao(uow, new ActivatorWrapper());
            var rollDao = new RolDao(uow, new ActivatorWrapper());
            var controller = new AccountController(userDao, rollDao);
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();
            Random random = new Random();
            // Act
            var response = controller.Create(new RegistroViewModel() { Email = $"testApi{random.Next(0, 10000)}@tes.com", Name = "test Api", Password = "Test", UserName = "c@c.com" });

            // Assert
            var contentResult = response as OkNegotiatedContentResult<CreateResponse>;
            Assert.IsNotNull(contentResult);
            Assert.AreEqual(contentResult.Content.JsonResult.ErrorMessage, "The user name is already in use");

            Assert.IsTrue(contentResult.Content.JsonResult.HasError);
        }
    }
}
