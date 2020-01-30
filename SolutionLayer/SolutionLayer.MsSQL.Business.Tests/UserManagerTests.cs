using FluentValidation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SolutionLayer.MsSQL.Business.Concrete.Managers;
using SolutionLayer.MsSQL.DAL.Abstaract;
using SolutionLayer.MsSQL.Entities.Concrete;

namespace SolutionLayer.MsSQL.Business.Tests
{
    [TestClass]
    public class UserManagerTests
    {
        [ExpectedException(typeof(ValidationException))]
        [TestMethod]
        public void User_validation_check()
        {
            Mock<IUserDAL> mock = new Mock<IUserDAL>();
            UserManager um = new UserManager(mock.Object);
            um.Add(new User());
        }

        [ExpectedException(typeof(ValidationException))]
        [TestMethod]
        public void User_validation_check2()
        {
            Mock<IUserDAL> mock = new Mock<IUserDAL>();
            UserManager um = new UserManager(mock.Object);
            User usr1 = new User();
            User usr2 = new User();
            um.Update(new User());
            //um.TransactionOperation(usr1, usr2);
        }
    }
} 