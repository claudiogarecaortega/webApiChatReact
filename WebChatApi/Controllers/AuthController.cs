using System;
using System.Web.Http;
using Dominio.Usuarios;
using Libreria.Execptiones;
using Microsoft.AspNet.Identity;
using Modelos.ApiModels.Peticiones;
using Modelos.ApiModels.Respuestas;
using Persistencia.Daos.Interfaces;
using WebChatApi.JWTManager;
using Newtonsoft.Json;

namespace WebChatApi.Controllers
{
    [RoutePrefix("api/authentication")]
    public class AuthController : BaseController
    {
        public AuthController(IUsuarioDao userDao) : base(userDao)
        {

        }

        [Route("Login")]
        [HttpPost]
        [AllowAnonymous]
        public IHttpActionResult Login(LoginViewModel viewModel)
        {
            var jsonResult = new LoginResponse();
            try
            {
                if (string.IsNullOrEmpty(viewModel.Email))
                    throw new CustomExeption("The email is invalid");

                if (string.IsNullOrEmpty(viewModel.Password))
                    throw new CustomExeption("The password invalid");

                var user = CheckUser(viewModel.Email, viewModel.Password);
                if (user == null)
                    throw new CustomExeption("The user name or password are invalid");

                jsonResult.Id = user.Id;
                jsonResult.Name = user.NombreCompleto();
                jsonResult.Email = user.Email;
                jsonResult.UserName = user.UserName;
                jsonResult.JsonResult = new JsonResult()
                {
                    HasError = false,
                    EntityResult = "Create"
                };
                jsonResult.JwtToken = JwtManager.GenerateToken(user.Email,user.Id);
                return Ok(jsonResult );
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

    }
}