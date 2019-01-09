using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Persistencia.Contextos;
using Persistencia.Daos;
using Persistencia.UnitsOfWork;
using Utilidades.Activadores;

namespace Persistencia.Test.ChatRoom
{
    [TestClass]
    public class ChatRoomDaoTest
    {
        [TestMethod]
        public void CreateChatRoom()
        {
            var uow = new UnitOfWorkHelper {SessionContext = new ApplicationDbContext()};
            var chatRoomDao = new ChatRoomDao(uow, new ActivatorWrapper());
            var userDao = new UsuarioDao(uow, new ActivatorWrapper());
            var chatRoom = chatRoomDao.Create();
            chatRoom.Creator = userDao.Get(1);
            chatRoom.Name = "Unit Test";
            chatRoom.Description = "Description unit test";
            chatRoomDao.Add(chatRoom);
            chatRoomDao.Save();
            Assert.AreNotEqual(chatRoom.Id, 0);
        }
        [TestMethod]
        public void CreateChatRoom_Error()
        {
            try
            {
                var uow = new UnitOfWorkHelper {SessionContext = new ApplicationDbContext()};
                var chatRoomDao = new ChatRoomDao(uow, new ActivatorWrapper());
                var chatRoom = chatRoomDao.Create();
                chatRoom.Name = "Unit Test";
                chatRoom.Description = "Description unit test";
                chatRoomDao.Add(chatRoom);
                chatRoomDao.Save();
               
            }
            catch (Exception e)
            {
                Assert.AreNotEqual(e.Message,"");
            }
        }
       
    }
}
