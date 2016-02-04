using System;
using Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EnterpriseSystems.Data.DAO;
using System.Data;

namespace UnitTests.Data
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Mock<IDatabase> mockDatabase = new Mock<IDatabase>();
            Mock<IQuery> mockQuery1 = new Mock<IQuery>();
            Mock<IQuery> mockQuery2 = new Mock<IQuery>();
            Mock<IQuery> mockQuery3 = new Mock<IQuery>();

            DataTable expected = new DataTable();

            mockDatabase.Setup(m => m.CreateQuery("1")).Returns(mockQuery1.Object);
            mockDatabase.Setup(m => m.CreateQuery("2")).Returns(mockQuery2.Object);
            mockDatabase.Setup(m => m.CreateQuery("3")).Returns(mockQuery3.Object);

            IDatabase db = mockDatabase.Object;
            IQuery actual = db.CreateQuery(null);
            
            Assert.AreEqual(null, actual);
            
        }
    }
}
