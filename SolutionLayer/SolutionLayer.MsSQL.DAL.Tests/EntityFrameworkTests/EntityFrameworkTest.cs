using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SolutionLayer.MsSQL.DAL.Concrete;
using SolutionLayer.MsSQL.Entities.ComplexTypes;

namespace SolutionLayer.MsSQL.DAL.Tests.EntityFrameworkTests
{
    [TestClass]
    public class EntityFrameworkTest
    {
        [TestMethod] 
            public void Check_count_all_records()
            {
            EFUserDAL efud = new EFUserDAL();
            var rs = efud.GetList();
            Assert.AreEqual(20, rs.Count); 
            }

        [TestMethod]
        public void Check_count_all_records_with_filter()
        {
            EFUserDAL efud = new EFUserDAL();
            var rs = efud.GetList(x=>x.UserName.Contains("new") && x.UserId < 4000);
            Assert.AreEqual(2, rs.Count);
        } 
    }
}