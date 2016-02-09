using EnterpriseSystems.Data.Mappers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EnterpriseSystems.Infrastructure.Model.Entities;
using EnterpriseSystems.Data.Hydraters;
using EnterpriseSystems.Data.DAO;
using Moq;

namespace UnitTests.Data.Mappers
{
    public class AppointmentMapperTest
    {
        private AppointmentMapper Target { get; set; }
        private Mock<IDatabase> MockDatabase { get; set; }
        private Mock<IQuery> MockQuery { get; set; }
        private Mock<IHydrater<AppointmentVO>> MockAppointmentHydrater { get; set; }

        [TestInitialize]
        public void TestInitialize()
        {
            MockDatabase = new Mock<IDatabase>();
            MockQuery = new Mock<IQuery>();
            MockAppointmentHydrater = new Mock<IHydrater<AppointmentVO>>();

            Target = new AppointmentMapper(MockDatabase.Object, MockAppointmentHydrater.Object);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            Target = null;
            MockDatabase = null;
            MockQuery = null;
            MockAppointmentHydrater = null;
        }

        [TestMethod]
        public void GetAppointmentsByCustomerRequest_SetsQueryParameter()
        {
            var actual = Target.GetAppointmentsByCustomerRequest(new AppointmentVO());

            Assert.Fail();
        }
        [TestMethod]
        public void GetAppointmentsByCustomerRequest_ReturnsHydratedEntities()
        {
            var actual = Target.GetAppointmentsByCustomerRequest(new AppointmentVO());

            Assert.Fail();
        }
        [TestMethod]
        public void GetAppointmentsByStop_SetsQueryParameter()
        {
            var actual = Target.GetAppointmentsByStop(new AppointmentVO());

            Assert.Fail();
        }
        [TestMethod]
        public void GetAppointmentsByStop_ReturnsHydratedEntities()
        {
            var actual = Target.GetAppointmentsByStop(new AppointmentVO());

            Assert.Fail();
        }
    }
}
