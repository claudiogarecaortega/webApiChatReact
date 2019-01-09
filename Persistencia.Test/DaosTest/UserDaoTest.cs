using Microsoft.VisualStudio.TestTools.UnitTesting;
using Persistencia.Contextos;
using Persistencia.Daos;
using Persistencia.UnitsOfWork;
using Utilidades.Activadores;

namespace Persistencia.Test.DaosTest
{
    [TestClass]
    public class UserDaoTest
    {
        [TestMethod]
        public void GetUsuarioTest()
        {
            var uow = new UnitOfWorkHelper {SessionContext = new ApplicationDbContext()};
            var userDao = new UsuarioDao(uow, new ActivatorWrapper());
            var user = userDao.GetUsuario("test");
            Assert.AreNotEqual(user, null);
        }
        [TestMethod]
        public void GetUsuarioTest_Error()
        {
            var uow = new UnitOfWorkHelper {SessionContext = new ApplicationDbContext()};
            var userDao = new UsuarioDao(uow, new ActivatorWrapper());
            var user = userDao.GetUsuario("NoUsuario");
            Assert.AreEqual(user, null);
        }
        [TestMethod]
        public void CheckEmailUser()
        {
            var userDao = new UsuarioDao(new UnitOfWorkHelper(), new ActivatorWrapper());
            var result = userDao.CheckEmailUser("test@test.com");
            Assert.AreEqual(result, true);
        }
        [TestMethod]
        public void CheckEmailUser_Error()
        {
            var userDao = new UsuarioDao(new UnitOfWorkHelper(), new ActivatorWrapper());
            var result = userDao.CheckEmailUser("testwrong@test.com");
            Assert.AreEqual(result, false);
        }
        [TestMethod]
        public void CheckUserName()
        {
            var userDao = new UsuarioDao(new UnitOfWorkHelper(), new ActivatorWrapper());
            var result = userDao.CheckUserName("test");
            Assert.AreEqual(result, true);
        }
        [TestMethod]
        public void CheckUserName_Error()
        {
            var userDao = new UsuarioDao(new UnitOfWorkHelper(), new ActivatorWrapper());
            var result = userDao.CheckUserName("testWrong");
            Assert.AreEqual(result, false);
        }
        [TestMethod]
        public void ValidateUserById()
        {
            var userDao = new UsuarioDao(new UnitOfWorkHelper(), new ActivatorWrapper());
            var result = userDao.ValidateUserById(1);
            Assert.AreNotEqual(result, false);
        }
        [TestMethod]
        public void ValidateUserById_Error()
        {
            var userDao = new UsuarioDao(new UnitOfWorkHelper(), new ActivatorWrapper());
            var result = userDao.ValidateUserById(1000);
            Assert.AreEqual(result, false);
        }
    }
}
