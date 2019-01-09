using System.Web.Http;
using Dominio.Usuarios;
using Microsoft.AspNet.Identity;
using Persistencia.Daos.Interfaces;

namespace WebChatApi.Controllers
{
    public class BaseController:ApiController
    {
        public readonly IUsuarioDao _userDao;

        public BaseController(IUsuarioDao userDao)
        {
            _userDao = userDao;
        }

        public Usuario CheckUser(string username, string password)
        {
            var passwordHasher = new PasswordHasher();
            var user = _userDao.GetUsuario(username);
            if (user == null) return null;
            var result = passwordHasher.VerifyHashedPassword(user.PasswordHash, password);
            return result == PasswordVerificationResult.Success ? user : null;
        }
        public bool CheckEmail(string email)
        {
            return _userDao.CheckEmailUser(email);
        }
        public bool CheckUserName(string userName)
        {
            return _userDao.CheckUserName(userName);
        }

      
    }
}