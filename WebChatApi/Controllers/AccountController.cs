using System;
using System.Web.Http;
using System.Web.Http.Cors;
using Dominio.Personas;
using Dominio.Usuarios;
using Libreria.Execptiones;
using Microsoft.AspNet.Identity;
using Modelos.ApiModels.Peticiones;
using Modelos.ApiModels.Respuestas;
using Newtonsoft.Json;
using Persistencia.Daos.Interfaces;
using WebChatApi.JWTManager;

namespace WebChatApi.Controllers
{
    [RoutePrefix("api/account")]
    public class AccountController: BaseController
    {
        private readonly IRolDao _rolDao;
        public AccountController(IUsuarioDao userDao, IRolDao rolDao) : base(userDao)
        {
            _rolDao = rolDao;
        }
        [AllowAnonymous]
        [Route("Create")]
        [HttpPost]
        public IHttpActionResult Create(RegistroViewModel viewModel)
        {
            var createResponse = new CreateResponse();
            try
            {
                if (CheckEmail(viewModel.Email))
                    throw new CustomExeption("The email is already registered");

                if (CheckUserName(viewModel.UserName))
                    throw new CustomExeption("The user name is already in use");

             
                var passwordHasher = new PasswordHasher();
                var model = new Usuario
                {
                    UserName = viewModel.UserName,
                    UsuarioRol =_rolDao.GetRollByName("Admin"),
                    Email = viewModel.Email,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    LockoutEnabled = true,
                    Persona = new Persona()

                    {
                        Nombres = viewModel.Name,
                        Apellidos = viewModel.Name,
                        FechaAlta = DateTime.Now,
                        UsuarioAlta = 1,
                        Documento = "0000000000",
                        Activo = true
                    },
                    PasswordHash = passwordHasher.HashPassword(viewModel.Password),
                    FechaAlta = DateTime.Now,
                    UsuarioAlta = 1,
                    Activo = true
                };
                _userDao.Add(model);
                _userDao.Save();
                createResponse.UserName = model.UserName;
                createResponse.Id = model.Id;
                createResponse.Email = model.Email;
                createResponse.Name = model.NombreCompleto();
                createResponse.JsonResult=new JsonResult()
                {
                    HasError = false,
                    EntityResult = "Create"
                };
                createResponse.JwtToken= JwtManager.GenerateToken(viewModel.Email,model.Id);
                return Ok(createResponse );
            }
            catch (CustomExeption e)
            {
                createResponse.JsonResult=new JsonResult()
                {
                    HasError = true,
                    ErrorMessage = e.Message,
                    EntityResult = "Create"
                };
                return Ok( createResponse );
            }
            catch (Exception e)
            {
                createResponse.JsonResult = new JsonResult()
                {
                    HasError = true,
                    ErrorMessage = e.Message,
                    EntityResult = "Create"
                };
                return Ok( createResponse );
            }
        }

       
    }
}