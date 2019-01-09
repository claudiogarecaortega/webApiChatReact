using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using Modelos.ApiModels.Peticiones;
using Modelos.ApiModels.Respuestas;
using Persistencia.Contextos;
using Persistencia.Daos;
using Persistencia.UnitsOfWork;
using Utilidades.Activadores;
using WebChatApi.Controllers;

namespace WebChatApi.Tests.Common
{
    public class BaseApiTest
    {
        public  string GetAuthorizationHeader(UsuarioDao userdao)
        {
           
            //token 
            var controllerAuth = new AuthController(userdao)
            {
                Request = new HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };
            // Act
            var responseAuth = controllerAuth.Login(new LoginViewModel() { Email = "c@c.com", Password = "clave123" });

            // Assert
            var contentResult = responseAuth as OkNegotiatedContentResult<LoginResponse>;
            return $"{contentResult.Content.JwtToken}";
        }
    }
}
