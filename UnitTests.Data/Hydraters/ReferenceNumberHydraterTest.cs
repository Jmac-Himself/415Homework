using EnterpriseSystems.Data.Hydraters;
using EnterpriseSystems.Data.Model.Constants;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Data;
using System.Linq;

namespace UnitTests.Data.Hydraters
{
    [TestClass]
    public class ReferenceNumberHydraterTest
    {
        private ReferenceNumberHydrater Target { get; set; }
        private DataTable TestDataTable { get; set; }

        [TestInitialize]
        public void TestInitialize()
        {
            InitializeTestDataTable();
            InitializeTarget();
        }

        private void InitializeTarget()
        {
            Target = new ReferenceNumberHydrater();
        }



        private void InitializeTestDataTable()
        {
            TestDataTable = new DataTable();
            TestDataTable.Columns.Add(ReferenceNumberColumnNames.Identity, typeof(int));
            TestDataTable.Columns.Add(ReferenceNumberColumnNames.EntityName, typeof(string));
            TestDataTable.Columns.Add(ReferenceNumberColumnNames.EntityID, typeof(int));
            TestDataTable.Columns.Add(ReferenceNumberColumnNames.SELURefNumber, typeof(string));
            TestDataTable.Columns.Add(ReferenceNumberColumnNames.ReferenceNumber, typeof(string));
            TestDataTable.Columns.Add(ReferenceNumberColumnNames.CreatedDate, typeof(DateTime));
            TestDataTable.Columns.Add(ReferenceNumberColumnNames.CreatedUID, typeof(string));
            TestDataTable.Columns.Add(ReferenceNumberColumnNames.CreatedCode, typeof(string));
            TestDataTable.Columns.Add(ReferenceNumberColumnNames.LastUpdatedDate, typeof(DateTime));
            TestDataTable.Columns.Add(ReferenceNumberColumnNames.LastUpdatedUID, typeof(string));
            TestDataTable.Columns.Add(ReferenceNumberColumnNames.LastUpdatedCode, typeof(string));
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
        public void Hydrate_HydratesReferenceNumbersSuccessfully()
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
            Assert.AreEqual("SELURefNumber", firstElement.SELURefNumber);
            Assert.AreEqual("ReferenceNumber", firstElement.ReferenceNumber);
            Assert.AreEqual(new DateTime(1), firstElement.CreatedDate);
            Assert.AreEqual("CreatedUID", firstElement.CreatedUID);
            Assert.AreEqual("CreatedCode", firstElement.CreatedCode);
            Assert.AreEqual(new DateTime(2), firstElement.LastUpdatedDate);
            Assert.AreEqual("LastUpdatedUID", firstElement.LastUpdatedUID);
            Assert.AreEqual("LastUpdatedCode", firstElement.LastUpdatedCode);

            var secondElement = actual.ElementAt(1);
            Assert.AreEqual("EntityName", secondElement.EntityName);
            Assert.AreEqual("EntityID", secondElement.EntityID);
            Assert.AreEqual("SELURefNumber", secondElement.SELURefNumber);
            Assert.AreEqual("ReferenceNumber", secondElement.ReferenceNumber);
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

            testDataRow[ReferenceNumberColumnNames.Identity] = 1 + (increment ?? 0);
            testDataRow[ReferenceNumberColumnNames.EntityName] = "EntityName" + (increment.HasValue ? increment.Value.ToString() : String.Empty);
            testDataRow[ReferenceNumberColumnNames.EntityID] = 2 + (increment ?? 0);
            testDataRow[ReferenceNumberColumnNames.SELURefNumber] = "SELURefNumber" + (increment.HasValue ? increment.Value.ToString() : String.Empty);
            testDataRow[ReferenceNumberColumnNames.ReferenceNumber] = "ReferenceNumber" + (increment.HasValue ? increment.Value.ToString() : String.Empty);
            testDataRow[ReferenceNumberColumnNames.CreatedDate] = new DateTime(1 + (increment ?? 0));
            testDataRow[ReferenceNumberColumnNames.CreatedUID] = "CreatedUserId" + (increment.HasValue ? increment.Value.ToString() : String.Empty);
            testDataRow[ReferenceNumberColumnNames.CreatedCode] = "CreatedProgramCode" + (increment.HasValue ? increment.Value.ToString() : String.Empty);
            testDataRow[ReferenceNumberColumnNames.LastUpdatedDate] = new DateTime(2 + (increment ?? 0));
            testDataRow[ReferenceNumberColumnNames.LastUpdatedUID] = "LastUpdatedUserId" + (increment.HasValue ? increment.Value.ToString() : String.Empty);
            testDataRow[ReferenceNumberColumnNames.LastUpdatedCode] = "LastUpdatedProgramCode" + (increment.HasValue ? increment.Value.ToString() : String.Empty);

            return testDataRow;
        }
    }
}
