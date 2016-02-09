using EnterpriseSystems.Data.Hydraters;
using EnterpriseSystems.Data.Model.Constants;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Data;
using System.Linq;

namespace UnitTests.Data.Hydraters
{
    [TestClass]
    public class CommentHydraterTest
    {
        private CommentHydrater Target { get; set; }
        private DataTable TestDataTable { get; set; }

        [TestInitialize]
        public void TestInitialize()
        {
            InitializeTestDataTable();
            InitializeTarget();
        }

        private void InitializeTarget()
        {
            Target = new CommentHydrater();
        }

        

        private void InitializeTestDataTable()
        {
            TestDataTable = new DataTable();
            TestDataTable.Columns.Add(CommentColumnNames.Identity, typeof(int));
            TestDataTable.Columns.Add(CommentColumnNames.EntityName, typeof(string));
            TestDataTable.Columns.Add(CommentColumnNames.EntityID, typeof(int));
            TestDataTable.Columns.Add(CommentColumnNames.SequenceNum, typeof(int));
            TestDataTable.Columns.Add(CommentColumnNames.CommentType, typeof(string));
            TestDataTable.Columns.Add(CommentColumnNames.Comment, typeof(string));
            TestDataTable.Columns.Add(CommentColumnNames.CreatedDate, typeof(DateTime));
            TestDataTable.Columns.Add(CommentColumnNames.CreatedUID, typeof(string));
            TestDataTable.Columns.Add(CommentColumnNames.CreatedCode, typeof(string));
            TestDataTable.Columns.Add(CommentColumnNames.LastUpdatedDate, typeof(DateTime));
            TestDataTable.Columns.Add(CommentColumnNames.LastUpdatedUID, typeof(string));
            TestDataTable.Columns.Add(CommentColumnNames.LastUpdatedCode, typeof(string));
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
        public void Hydrate_HydratesCommentsSuccessfully()
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
            Assert.AreEqual("CommentType", firstElement.CommentType);
            Assert.AreEqual("Comment", firstElement.Comment);
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
            Assert.AreEqual("CommentType", secondElement.CommentType);
            Assert.AreEqual("Comment", secondElement.Comment);
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

            testDataRow[CommentColumnNames.Identity] = 1 + (increment ?? 0);
            testDataRow[CommentColumnNames.EntityName] = "EntityName" + (increment.HasValue ? increment.Value.ToString() : String.Empty);
            testDataRow[CommentColumnNames.EntityID] = 2 + (increment ?? 0);
            testDataRow[CommentColumnNames.SequenceNum] = 3 + (increment ?? 0);
            testDataRow[CommentColumnNames.CommentType] = "CommentType" + (increment.HasValue ? increment.Value.ToString() : String.Empty);
            testDataRow[CommentColumnNames.Comment] = "Comment" + (increment.HasValue ? increment.Value.ToString() : String.Empty);
            testDataRow[CommentColumnNames.CreatedDate] = new DateTime(1 + (increment ?? 0));
            testDataRow[CommentColumnNames.CreatedUID] = "CreatedUserId" + (increment.HasValue ? increment.Value.ToString() : String.Empty);
            testDataRow[CommentColumnNames.CreatedCode] = "CreatedProgramCode" + (increment.HasValue ? increment.Value.ToString() : String.Empty);
            testDataRow[CommentColumnNames.LastUpdatedDate] = new DateTime(2 + (increment ?? 0));
            testDataRow[CommentColumnNames.LastUpdatedUID] = "LastUpdatedUserId" + (increment.HasValue ? increment.Value.ToString() : String.Empty);
            testDataRow[CommentColumnNames.LastUpdatedCode] = "LastUpdatedProgramCode" + (increment.HasValue ? increment.Value.ToString() : String.Empty);

            return testDataRow;
        }
    }
}
