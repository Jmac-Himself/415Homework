using EnterpriseSystems.Data.Mappers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EnterpriseSystems.Infrastructure.Model.Entities;
using EnterpriseSystems.Data.Hydraters;
using EnterpriseSystems.Data.DAO;
using Moq;

namespace UnitTests.Data.Mappers
{
    public class CommentMapperTest
    {
        private CommentMapper Target { get; set; }
        private Mock<IDatabase> MockDatabase { get; set; }
        private Mock<IQuery> MockQuery { get; set; }
        private Mock<IHydrater<CommentVO>> MockCommentHydrater { get; set; }

        [TestInitialize]
        public void TestInitialize()
        {
            MockDatabase = new Mock<IDatabase>();
            MockQuery = new Mock<IQuery>();
            MockCommentHydrater = new Mock<IHydrater<CommentVO>>();

            Target = new CommentMapper(MockDatabase.Object, MockCommentHydrater.Object);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            Target = null;
            MockDatabase = null;
            MockQuery = null;
            MockCommentHydrater = null;
        }

        [TestMethod]
        public void GetCommentsByCustomerRequest_SetsQueryParameter()
        {
            var actual = Target.GetCommentsByCustomerRequest(new CommentVO());

            Assert.Fail();
        }
        [TestMethod]
        public void GetCommentsByCustomerRequest_ReturnsHydratedEntities()
        {
            var actual = Target.GetCommentsByCustomerRequest(new CommentVO());

            Assert.Fail();
        }
        [TestMethod]
        public void GetCommentsByStop_SetsQueryParameter()
        {
            var actual = Target.GetCommentsByStop(new CommentVO());

            Assert.Fail();
        }
        [TestMethod]
        public void GetCommentsByStop_ReturnsHydratedEntities()
        {
            var actual = Target.GetCommentsByStop(new CommentVO());

            Assert.Fail();
        }
    }
}