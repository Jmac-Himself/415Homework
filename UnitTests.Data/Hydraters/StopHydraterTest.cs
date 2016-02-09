using EnterpriseSystems.Data.Hydraters;
using EnterpriseSystems.Data.Model.Constants;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Data;
using System.Linq;

namespace UnitTests.Data.Hydraters
{
    [TestClass]
    public class StopHydraterTest
    {
        private StopHydrater Target { get; set; }
        private DataTable TestDataTable { get; set; }

        [TestInitialize]
        public void TestInitialize()
        {
            InitializeTestDataTable();
            InitializeTarget();
        }

        private void InitializeTarget()
        {
            Target = new StopHydrater();
        }



        private void InitializeTestDataTable()
        {
            TestDataTable = new DataTable();
            TestDataTable.Columns.Add(StopColumnNames.Identity, typeof(int));
            TestDataTable.Columns.Add(StopColumnNames.EntityName, typeof(string));
            TestDataTable.Columns.Add(StopColumnNames.EntityID, typeof(int));
            TestDataTable.Columns.Add(StopColumnNames.RoleType, typeof(string));
            TestDataTable.Columns.Add(StopColumnNames.StopNumber, typeof(string));
            TestDataTable.Columns.Add(StopColumnNames.CustomerAlias, typeof(string));
            TestDataTable.Columns.Add(StopColumnNames.OrganizationName, typeof(string));
            TestDataTable.Columns.Add(StopColumnNames.AddressLine1, typeof(string));
            TestDataTable.Columns.Add(StopColumnNames.AddressLine2, typeof(string));
            TestDataTable.Columns.Add(StopColumnNames.CityName, typeof(string));
            TestDataTable.Columns.Add(StopColumnNames.StateCode, typeof(string));
            TestDataTable.Columns.Add(StopColumnNames.CountryCode, typeof(string));
            TestDataTable.Columns.Add(StopColumnNames.PostalCode, typeof(string));
            TestDataTable.Columns.Add(StopColumnNames.CreatedDate, typeof(DateTime));
            TestDataTable.Columns.Add(StopColumnNames.CreatedUID, typeof(string));
            TestDataTable.Columns.Add(StopColumnNames.CreatedCode, typeof(string));
            TestDataTable.Columns.Add(StopColumnNames.LastUpdatedDate, typeof(DateTime));
            TestDataTable.Columns.Add(StopColumnNames.LastUpdatedUID, typeof(string));
            TestDataTable.Columns.Add(StopColumnNames.LastUpdatedCode, typeof(string));
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
        public void Hydrate_HydratesStopsSuccessfully()
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
            Assert.AreEqual("RoleType", firstElement.RoleType);
            Assert.AreEqual("StopNumber", firstElement.StopNumber);
            Assert.AreEqual("CustomerAlias", firstElement.CustomerAlias);
            Assert.AreEqual("OrganizationName", firstElement.OrganizationName);
            Assert.AreEqual("AddressLine1", firstElement.AddressLine1);
            Assert.AreEqual("AddressLine2", firstElement.AddressLine2);
            Assert.AreEqual("CityName", firstElement.CityName);
            Assert.AreEqual("StateCode", firstElement.StateCode);
            Assert.AreEqual("CountryCode", firstElement.CountryCode);
            Assert.AreEqual("PostalCode", firstElement.PostalCode);
            Assert.AreEqual(new DateTime(1), firstElement.CreatedDate);
            Assert.AreEqual("CreatedUID", firstElement.CreatedUID);
            Assert.AreEqual("CreatedCode", firstElement.CreatedCode);
            Assert.AreEqual(new DateTime(2), firstElement.LastUpdatedDate);
            Assert.AreEqual("LastUpdatedUID", firstElement.LastUpdatedUID);
            Assert.AreEqual("LastUpdatedCode", firstElement.LastUpdatedCode);

            var secondElement = actual.ElementAt(1);
            Assert.AreEqual("EntityName", secondElement.EntityName);
            Assert.AreEqual("EntityID", secondElement.EntityID);
            Assert.AreEqual("RoleType", secondElement.RoleType);
            Assert.AreEqual("StopNumber", secondElement.StopNumber);
            Assert.AreEqual("CustomerAlias", secondElement.CustomerAlias);
            Assert.AreEqual("OrganizationName", secondElement.OrganizationName);
            Assert.AreEqual("AddressLine1", secondElement.AddressLine1);
            Assert.AreEqual("AddressLine2", secondElement.AddressLine2);
            Assert.AreEqual("CityName", secondElement.CityName);
            Assert.AreEqual("StateCode", secondElement.StateCode);
            Assert.AreEqual("CountryCode", secondElement.CountryCode);
            Assert.AreEqual("PostalCode", secondElement.PostalCode);
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

            testDataRow[StopColumnNames.Identity] = 1 + (increment ?? 0);
            testDataRow[StopColumnNames.EntityName] = "EntityName" + (increment.HasValue ? increment.Value.ToString() : String.Empty);
            testDataRow[StopColumnNames.EntityID] = 2 + (increment ?? 0);
            testDataRow[StopColumnNames.RoleType] = "RoleType" + (increment.HasValue ? increment.Value.ToString() : String.Empty);
            testDataRow[StopColumnNames.StopNumber] = "StopNumber" + (increment.HasValue ? increment.Value.ToString() : String.Empty);
            testDataRow[StopColumnNames.CustomerAlias] = "CustomerAlias" + (increment.HasValue ? increment.Value.ToString() : String.Empty);
            testDataRow[StopColumnNames.OrganizationName] = "OrganizationName" + (increment.HasValue ? increment.Value.ToString() : String.Empty);
            testDataRow[StopColumnNames.AddressLine1] = "AddressLine1" + (increment.HasValue ? increment.Value.ToString() : String.Empty);
            testDataRow[StopColumnNames.AddressLine2] = "AddressLine2" + (increment.HasValue ? increment.Value.ToString() : String.Empty);
            testDataRow[StopColumnNames.CityName] = "CityName" + (increment.HasValue ? increment.Value.ToString() : String.Empty);
            testDataRow[StopColumnNames.StateCode] = "StateCode" + (increment.HasValue ? increment.Value.ToString() : String.Empty);
            testDataRow[StopColumnNames.CountryCode] = "CountryCode" + (increment.HasValue ? increment.Value.ToString() : String.Empty);
            testDataRow[StopColumnNames.PostalCode] = "PostalCode" + (increment.HasValue ? increment.Value.ToString() : String.Empty);
            testDataRow[StopColumnNames.CreatedDate] = new DateTime(1 + (increment ?? 0));
            testDataRow[StopColumnNames.CreatedUID] = "CreatedUserId" + (increment.HasValue ? increment.Value.ToString() : String.Empty);
            testDataRow[StopColumnNames.CreatedCode] = "CreatedProgramCode" + (increment.HasValue ? increment.Value.ToString() : String.Empty);
            testDataRow[StopColumnNames.LastUpdatedDate] = new DateTime(2 + (increment ?? 0));
            testDataRow[StopColumnNames.LastUpdatedUID] = "LastUpdatedUserId" + (increment.HasValue ? increment.Value.ToString() : String.Empty);
            testDataRow[StopColumnNames.LastUpdatedCode] = "LastUpdatedProgramCode" + (increment.HasValue ? increment.Value.ToString() : String.Empty);

            return testDataRow;
        }
    }
}
