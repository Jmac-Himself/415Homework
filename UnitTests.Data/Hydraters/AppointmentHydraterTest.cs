using EnterpriseSystems.Data.Hydraters;
using EnterpriseSystems.Data.Model.Constants;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Data;
using System.Linq;

namespace UnitTests.Data.Hydraters
{
    [TestClass]
    public class AppointmentHydraterTest
    {
        private AppointmentHydrater Target { get; set; }
        private DataTable TestDataTable { get; set; }

        [TestInitialize]
        public void TestInitialize()
        {
            InitializeTestDataTable();
            InitializeTarget();
        }

        private void InitializeTarget()
        {
            Target = new AppointmentHydrater();
        }

        private void InitializeTestDataTable()
        {
            TestDataTable = new DataTable();
            TestDataTable.Columns.Add(AppointmentColumnNames.Identity, typeof(int));
            TestDataTable.Columns.Add(AppointmentColumnNames.EntityName, typeof(string));
            TestDataTable.Columns.Add(AppointmentColumnNames.EntityID, typeof(int));
            TestDataTable.Columns.Add(AppointmentColumnNames.SequenceNum, typeof(int));
            TestDataTable.Columns.Add(AppointmentColumnNames.FunctionType, typeof(string));
            TestDataTable.Columns.Add(AppointmentColumnNames.AppointmentStart, typeof(DateTime));
            TestDataTable.Columns.Add(AppointmentColumnNames.AppointmentEnd, typeof(DateTime));
            TestDataTable.Columns.Add(AppointmentColumnNames.Timezone, typeof(string));
            TestDataTable.Columns.Add(AppointmentColumnNames.Status, typeof(string));
            TestDataTable.Columns.Add(AppointmentColumnNames.CreatedDate, typeof(DateTime));
            TestDataTable.Columns.Add(AppointmentColumnNames.CreatedUID, typeof(string));
            TestDataTable.Columns.Add(AppointmentColumnNames.CreatedCode, typeof(string));
            TestDataTable.Columns.Add(AppointmentColumnNames.LastUpdatedDate, typeof(DateTime));
            TestDataTable.Columns.Add(AppointmentColumnNames.LastUpdatedUID, typeof(string));
            TestDataTable.Columns.Add(AppointmentColumnNames.LastUpdatedCode, typeof(string));
        }

        [TestCleanup]
        public void TestCleanup()
        {
            Target = null;
            TestDataTable = null;
        }
        [TestMethod]
        public void Hydrate_ReturnsEmptyWhenDataTableEmpty()
        {
            var actual = Target.Hydrate(TestDataTable);

            Assert.AreEqual(0, actual.Count());
        }
        [TestMethod]
        public void Hydrate_HydratesAppointmentsSuccessfully()
        {
            DataRow testDataRow = GetTestDataRow();
            TestDataTable.Rows.Add(testDataRow);

            testDataRow = GetTestDataRow(1);
            TestDataTable.Rows.Add(testDataRow);

            var actual = Target.Hydrate(TestDataTable);

            var firstElement = actual.ElementAt(0);
            Assert.AreEqual(1, firstElement.Identity);
            Assert.AreEqual("EntityName", firstElement.EntityName);
            Assert.AreEqual("EntityID", firstElement.EntityID);
            Assert.AreEqual("SequenceNum", firstElement.SequenceNum);
            Assert.AreEqual("FunctionType", firstElement.FunctionType);
            Assert.AreEqual("AppointmentStart", firstElement.AppointmentStart);
            Assert.AreEqual("AppointmentEnd", firstElement.AppointmentEnd);
            Assert.AreEqual("Timezone", firstElement.Timezone);
            Assert.AreEqual("Status", firstElement.Status);
            Assert.AreEqual(new DateTime(1), firstElement.CreatedDate);
            Assert.AreEqual("CreatedUID", firstElement.CreatedUID);
            Assert.AreEqual("CreatedCode", firstElement.CreatedCode);
            Assert.AreEqual(new DateTime(2), firstElement.LastUpdatedDate);
            Assert.AreEqual("LastUpdatedUID", firstElement.LastUpdatedUID);
            Assert.AreEqual("LastUpdatedCode", firstElement.LastUpdatedCode);

            var secondElement = actual.ElementAt(1);
            Assert.AreEqual("EntityName", secondElement.EntityName);
            Assert.AreEqual("EntityID", secondElement.EntityID);
            Assert.AreEqual("SequenceNum", secondElement.SequenceNum);
            Assert.AreEqual("FunctionType", secondElement.FunctionType);
            Assert.AreEqual("AppointmentStart", secondElement.AppointmentStart);
            Assert.AreEqual("AppointmentEnd", secondElement.AppointmentEnd);
            Assert.AreEqual("Timezone", secondElement.Timezone);
            Assert.AreEqual("Status", secondElement.Status);
            Assert.AreEqual(new DateTime(3), secondElement.CreatedDate);
            Assert.AreEqual("CreatedUID", secondElement.CreatedUID);
            Assert.AreEqual("CreatedCode", secondElement.CreatedCode);
            Assert.AreEqual(new DateTime(4), secondElement.LastUpdatedDate);
            Assert.AreEqual("LastUpdatedUID", secondElement.LastUpdatedUID);
            Assert.AreEqual("LastUpdatedCode", secondElement.LastUpdatedCode);
        }

        private DataRow GetTestDataRow(int? increment = null)
        {
            DataRow testDataRow = TestDataTable.NewRow();

            testDataRow[AppointmentColumnNames.Identity] = 1 + (increment ?? 0);
            testDataRow[AppointmentColumnNames.EntityName] = "EntityName" + (increment.HasValue ? increment.Value.ToString() : String.Empty);
            testDataRow[AppointmentColumnNames.EntityID] = 2 + (increment ?? 0);
            testDataRow[AppointmentColumnNames.SequenceNum] = 3 + (increment ?? 0);
            testDataRow[AppointmentColumnNames.FunctionType] = "FunctionType" + (increment.HasValue ? increment.Value.ToString() : String.Empty);
            testDataRow[AppointmentColumnNames.AppointmentStart] = new DateTime(1 + (increment ?? 0));
            testDataRow[AppointmentColumnNames.AppointmentEnd] = new DateTime(3 + (increment ?? 0));
            testDataRow[AppointmentColumnNames.Timezone] = "Timezone" + (increment.HasValue ? increment.Value.ToString() : String.Empty);
            testDataRow[AppointmentColumnNames.Status] = "Status" + (increment.HasValue ? increment.Value.ToString() : String.Empty);
            testDataRow[AppointmentColumnNames.CreatedDate] = new DateTime(3 + (increment ?? 0));
            testDataRow[AppointmentColumnNames.CreatedUID] = "CreatedUserId" + (increment.HasValue ? increment.Value.ToString() : String.Empty);
            testDataRow[AppointmentColumnNames.CreatedCode] = "CreatedProgramCode" + (increment.HasValue ? increment.Value.ToString() : String.Empty);
            testDataRow[AppointmentColumnNames.LastUpdatedDate] = new DateTime(4 + (increment ?? 0));
            testDataRow[AppointmentColumnNames.LastUpdatedUID] = "LastUpdatedUserId" + (increment.HasValue ? increment.Value.ToString() : String.Empty);
            testDataRow[AppointmentColumnNames.LastUpdatedCode] = "LastUpdatedProgramCode" + (increment.HasValue ? increment.Value.ToString() : String.Empty);

            return testDataRow;
        }
    }
}
