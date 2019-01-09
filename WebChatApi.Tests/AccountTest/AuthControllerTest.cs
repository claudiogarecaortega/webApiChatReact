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
    public class AuthControllerTest
    {
        [TestMethod]
        public void AuthenticationSuccess()
        {
            // Arrange
            var uow = new UnitOfWorkHelper {SessionContext = new ApplicationDbContext()};
            var userDao = new UsuarioDao(uow, new ActivatorWrapper());
            var controller = new AuthController(userDao)
            {
                Request = new HttpRequestMessage(), Configuration = new HttpConfiguration()
            };
            var random = new Random();
            // Act
            var response = controller.Login(new LoginViewModel() { Email = "c@c.com", Password = "clave123" });

            // Assert
            var contentResult = response as OkNegotiatedContentResult<LoginResponse>;
            Assert.IsNotNull(contentResult);
            Assert.IsFalse(contentResult.Content.JsonResult.HasError);
            Assert.AreNotEqual(contentResult.Content.JwtToken, "");
        }
        [TestMethod]
        public void AuthenticationError()
        {
            // Arrange
            var uow = new UnitOfWorkHelper { SessionContext = new ApplicationDbContext() };
            var userDao = new UsuarioDao(uow, new ActivatorWrapper());
            var controller = new AuthController(userDao)
            {
                Request = new HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };
            var random = new Random();
            // Act
            var response = controller.Login(new LoginViewModel() { Email = "c@c.com", Password = "clave122223" });

            // Assert
            var contentResult = response as OkNegotiatedContentResult<LoginResponse>;
            Assert.IsNotNull(contentResult);
            Assert.IsTrue(contentResult.Content.JsonResult.HasError);
            Assert.IsNull(contentResult.Content.JwtToken);
            Assert.AreEqual(contentResult.Content.JsonResult.ErrorMessage, "The user name or password are invalid");
        }
        [TestMethod]
        public void AuthenticationErrorEmail()
        {
            // Arrange
            var uow = new UnitOfWorkHelper { SessionContext = new ApplicationDbContext() };
            var userDao = new UsuarioDao(uow, new ActivatorWrapper());
            var controller = new AuthController(userDao)
            {
                Request = new HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };
            var random = new Random();
            // Act
            var response = controller.Login(new LoginViewModel() { Email = "", Password = "clave122223" });

            // Assert
            var contentResult = response as OkNegotiatedContentResult<LoginResponse>;
            Assert.IsNotNull(contentResult);
            Assert.IsTrue(contentResult.Content.JsonResult.HasError);
            Assert.IsNull(contentResult.Content.JwtToken);
            Assert.AreEqual(contentResult.Content.JsonResult.ErrorMessage, "The email is invalid");
        }
        [TestMethod]
        public void AuthenticationErrorPassword()
        {
            // Arrange
            var uow = new UnitOfWorkHelper { SessionContext = new ApplicationDbContext() };
            var userDao = new UsuarioDao(uow, new ActivatorWrapper());
            var controller = new AuthController(userDao)
            {
                Request = new HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };
            var random = new Random();
            // Act
            var response = controller.Login(new LoginViewModel() { Email = "c@c.com", Password = "" });

            // Assert
            var contentResult = response as OkNegotiatedContentResult<LoginResponse>;
            Assert.IsNotNull(contentResult);
            Assert.IsTrue(contentResult.Content.JsonResult.HasError);
            Assert.IsNull(contentResult.Content.JwtToken);
            Assert.AreEqual(contentResult.Content.JsonResult.ErrorMessage, "The password invalid");
        }
    }
}
