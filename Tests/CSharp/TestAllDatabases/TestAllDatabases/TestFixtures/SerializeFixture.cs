//======================================
// Copyright EntitySpaces, LLC 2005 - 2006 
//======================================

using System;
using System.Linq;
using System.Data;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

using NUnit.Framework;
//using Adapdev.UnitTest;
using BusinessObjects;

namespace Tests.Base
{
	[TestFixture]
	public class SerializeFixture
	{
        AggregateTestCollection aggTestColl = new AggregateTestCollection();
        AggregateTest aggTest = new AggregateTest();
        AggregateTestQuery aggTestQuery = new AggregateTestQuery();
        AggregateTestCollection aggCloneColl = new AggregateTestCollection();
        AggregateTest aggClone = new AggregateTest();
        AggregateTestQuery aggCloneQuery = new AggregateTestQuery();
		
		[TestFixtureSetUp]
		public void Init()
		{
		}

		[SetUp]
		public void Init2()
		{
            aggTestColl = new AggregateTestCollection();
            aggTest = new AggregateTest();
            aggTestQuery = new AggregateTestQuery();
			aggCloneColl = new AggregateTestCollection();
			aggClone = new AggregateTest();
			aggCloneQuery = new AggregateTestQuery();
		}

		[Test]
		public void SerializeDeserializeNewEntityBinary()
		{
            if (aggTest.es.Connection.Name == "SqlCe")
            {
                Assert.Ignore("Not tested for SqlCe.");
            }
            else
            {
                aggTest.LastName = "Griffinski";

                BinaryFormatter bf = new BinaryFormatter();
                MemoryStream ms = new MemoryStream();
                bf.Serialize(ms, aggTest);

                ms.Position = 0;
                aggClone = (AggregateTest)bf.Deserialize(ms);
                ms.Close();

                Assert.AreEqual("Griffinski", aggClone.str().LastName);
            }
		}

		[Test]
		public void SerializeDeserializeLoadEntityBinary()
		{
            if (aggTest.es.Connection.Name == "SqlCe")
            {
                Assert.Ignore("Not tested for SqlCe.");
            }
            else
            {
                int key = 0;
                aggTest.Query.Where(
                    aggTest.Query.LastName == "Douglas",
                    aggTest.Query.FirstName == "Fred");
                aggTest.Query.Load();
                key = aggTest.Id.Value;

                aggTest = new AggregateTest();
                aggTest.LoadByPrimaryKey(key);

                BinaryFormatter bf = new BinaryFormatter();
                MemoryStream ms = new MemoryStream();
                bf.Serialize(ms, aggTest);

                ms.Position = 0;
                aggClone = (AggregateTest)bf.Deserialize(ms);
                ms.Close();

                Assert.AreEqual("Douglas", aggClone.str().LastName);
            }
		}

		[Test]
		public void SerializeDeserializeFindEntityBinary()
		{
            int key = 0;
            aggTestColl.LoadAll();
            foreach (AggregateTest test in aggTestColl)
            {
                if (test.LastName == "Doe")
                {
                    key = test.Id.Value;
                    break;
                }
            }
            aggTest = aggTestColl.FindByPrimaryKey(key);

            BinaryFormatter bf = new BinaryFormatter();
            MemoryStream ms = new MemoryStream();
            bf.Serialize(ms, aggTest);

            ms.Position = 0;
            aggClone = (AggregateTest)bf.Deserialize(ms);
            ms.Close();

            Assert.AreEqual("Doe", aggClone.str().LastName);
		}

		[Test]
		public void SerializeDeserializeCollectionBinary()
		{
            if (aggTestColl.es.Connection.Name == "SqlCe")
            {
                Assert.Ignore("Not tested for SqlCe.");
            }
            else
            {
                aggTestColl.LoadAll();

                BinaryFormatter bf = new BinaryFormatter();
                MemoryStream ms = new MemoryStream();
                bf.Serialize(ms, aggTestColl);

                ms.Position = 0;
                aggCloneColl = (AggregateTestCollection)bf.Deserialize(ms);
                ms.Close();

                Assert.AreEqual(30, aggCloneColl.Count);
            }
		}

        [Test]
        public void CollectionChangesBinary()
        {
            if (aggTestColl.es.Connection.Name == "SqlCe")
            {
                Assert.Ignore("Not tested for SqlCe.");
            }
            else
            {
                aggTestColl.LoadAll();
                Assert.AreEqual(30, aggTestColl.Count, "Old");
                aggTestColl.Filter = aggTestColl.AsQueryable().OrderBy(s => s.Id);

                aggTestColl[0].MarkAsDeleted();
                foreach (AggregateTest entity in aggTestColl)
                {
                    if (entity.LastName == "Doe")
                    {
                        entity.LastName = "Changed";
                    }
                }
                aggTest = aggTestColl.AddNew();
                aggTest.LastName = "New";

                int rowCount = 0;
                foreach (AggregateTest r in aggTestColl)
                {
                    if (r.es.IsAdded || r.es.IsModified)
                    {
                        rowCount++;
                    }
                }
                foreach (AggregateTest r in aggTestColl.es.DeletedEntities)
                {
                    rowCount++;
                }
                //aggTestColl.RowStateFilter = DataViewRowState.ModifiedCurrent |
                //    DataViewRowState.Deleted |
                //    DataViewRowState.Added;

                Assert.AreEqual(4, rowCount, "OldFiltered");

                BinaryFormatter bf = new BinaryFormatter();
                MemoryStream ms = new MemoryStream();
                bf.Serialize(ms, aggTestColl);

                ms.Position = 0;
                aggCloneColl = (AggregateTestCollection)bf.Deserialize(ms);
                ms.Close();

                Assert.AreEqual(30, aggCloneColl.Count, "New");

                rowCount = 0;
                foreach (AggregateTest r in aggTestColl)
                {
                    if (r.es.IsAdded|| r.es.IsModified)
                    {
                        rowCount++;
                    }
                }
                foreach (AggregateTest r in aggTestColl.es.DeletedEntities)
                {
                    rowCount++;
                }
                //aggCloneColl.RowStateFilter = DataViewRowState.ModifiedCurrent |
                //    DataViewRowState.Deleted |
                //    DataViewRowState.Added;

                Assert.AreEqual(4, rowCount, "NewFiltered");
            }
        }

        [Test]
        public void SerializeDeserializeProxyStubCollection()
        {
            if (aggTest.es.Connection.Name == "SqlCe")
            {
                Assert.Ignore("Not tested for SqlCe.");
            }
            else
            {
                // Load all 5 Employees
                EmployeeCollection collection = new EmployeeCollection();
                collection.es.Connection.Name = "ForeignKeyTest";

                collection.LoadAll();

                // Create a Proxy and Serialize into a string named "Packet"
                EmployeeCollectionProxyStub proxy =
                    new EmployeeCollectionProxyStub(collection);

                XmlSerializer sf =
                    new XmlSerializer(typeof(EmployeeCollectionProxyStub));
                StringWriter sw = new StringWriter();
                sf.Serialize(sw, proxy);

                string packet = sw.ToString();

                // Now let's DeSerialize it
                XmlSerializer xs =
                    new XmlSerializer(typeof(EmployeeCollectionProxyStub));
                StringReader sr = new StringReader(packet);

                proxy = xs.Deserialize(sr) as EmployeeCollectionProxyStub;

                // Count should = 5
                Assert.AreEqual(5, proxy.GetCollection().Count);
                Assert.AreEqual("Smith", proxy.Collection[0].LastName);
            }
        }

        [Test]
        public void SerializeDeserializeProxyStubEntity()
        {
            if (aggTest.es.Connection.Name == "SqlCe")
            {
                Assert.Ignore("Not tested for SqlCe.");
            }
            else
            {
                // Load an Employee
                Employee emp = new Employee();
                emp.es.Connection.Name = "ForeignKeyTest";

                emp.LoadByPrimaryKey(1);

                // Create a Proxy and Serialize into a string named "Packet"
                EmployeeProxyStub proxy =
                    new EmployeeProxyStub(emp);

                XmlSerializer sf =
                    new XmlSerializer(typeof(EmployeeProxyStub));
                StringWriter sw = new StringWriter();
                sf.Serialize(sw, proxy);

                string packet = sw.ToString();

                // Now let's DeSerialize it
                XmlSerializer xs =
                    new XmlSerializer(typeof(EmployeeProxyStub));
                StringReader sr = new StringReader(packet);

                proxy = xs.Deserialize(sr) as EmployeeProxyStub;

                Assert.AreEqual("Unchanged", proxy.Entity.es.RowState.ToString());
                Assert.AreEqual("Smith", proxy.Entity.LastName);
            }
        }

        [Test]
        public void SerializeDeserializeProxyStubEntityQuery()
        {
            if (aggTest.es.Connection.Name == "SqlCe")
            {
                Assert.Ignore("Not tested for SqlCe.");
            }
            else
            {
                // Client-side query to load an Employee
                Employee emp = new Employee();
                emp.es.Connection.Name = "ForeignKeyTest";

                emp.Query.Where(emp.Query.EmployeeID == 1);

                // Use binary serialization to include the query
                BinaryFormatter bf = new BinaryFormatter();
                MemoryStream ms = new MemoryStream();
                bf.Serialize(ms, emp);
                byte[] query = ms.ToArray();

                // Send it to the server over the wire

                // Server-side deserialize
                bf = new BinaryFormatter();
                ms = new MemoryStream(query);
                Employee newEmp = bf.Deserialize(ms) as Employee;
                newEmp.es.Connection.Name = "ForeignKeyTest";
                newEmp.Query.es2.Connection.Name = "ForeignKeyTest";

                // Now load it 
                Assert.IsTrue(newEmp.Query.Load());
                Assert.AreEqual(1, newEmp.EmployeeID.Value);

                //  Server-side Create a Proxy and Serialize to XML string
                EmployeeProxyStub proxy =
                    new EmployeeProxyStub(newEmp);

                XmlSerializer sf =
                    new XmlSerializer(typeof(EmployeeProxyStub));
                StringWriter sw = new StringWriter();
                sf.Serialize(sw, proxy);

                string packet = sw.ToString();

                // Send it back to the client over the wire

                // Client-side Proxy XML string deserialize
                XmlSerializer xs =
                    new XmlSerializer(typeof(EmployeeProxyStub));
                StringReader sr = new StringReader(packet);

                proxy = xs.Deserialize(sr) as EmployeeProxyStub;
                emp = proxy.Entity;

                Assert.AreEqual("Unchanged", emp.es.RowState.ToString());
                Assert.AreEqual(1, emp.EmployeeID.Value);
            }
        }

        [Test]
        public void SerializeDeserializeDynamicQuery()
        {
            if (aggTest.es.Connection.Name == "SqlCe")
            {
                Assert.Ignore("Not tested for SqlCe.");
            }
            else
            {
                // Test serializing a DynamicQuery
                // Must use binary serialization
                // Xml serialization doesn't serialize all of your private properties
                // 1) Create our Query on the client
                EmployeeQuery q = new EmployeeQuery("E");
                //q.es.Connection.Name = "ForeignKeyTest";

                q.Select(q.FirstName, q.LastName);
                q.Where(q.LastName.Like("S%"));

                // 2) Serialize it in binary
                BinaryFormatter bf = new BinaryFormatter();
                MemoryStream ms = new MemoryStream();
                bf.Serialize(ms, q);
                byte[] query = ms.ToArray();

                // 3) Send it over the wire

                // 4) Deserialize it on the Server
                bf = new BinaryFormatter();
                ms = new MemoryStream(query);
                EmployeeQuery newQuery = bf.Deserialize(ms) as EmployeeQuery;

                // Now load it 
                EmployeeCollection collection = new EmployeeCollection();
                collection.es.Connection.Name = "ForeignKeyTest";

                collection.Load(newQuery);

                Assert.AreEqual(2, collection.Count);
                Assert.AreEqual("S", collection[0].LastName.Substring(0, 1));
            }
        }

        [Test]
        public void SerializeDeserializeJoin()
        {
            if (aggTest.es.Connection.Name == "SqlCe")
            {
                Assert.Ignore("Not tested for SqlCe.");
            }
            else
            {
                // Test serializing a DynamicQuery
                // Must use binary serialization
                // Xml serialization doesn't serialize all of your private properties
                // 1) Create our Query on the client
                EmployeeQuery emp = new EmployeeQuery("eq");
                //emp.es.Connection.Name = "ForeignKeyTest";
                EmployeeTerritoryQuery et = new EmployeeTerritoryQuery("etq");
                //et.es.Connection.Name = "ForeignKeyTest";
                emp.Select(emp.FirstName, emp.LastName, et.TerrID);
                emp.InnerJoin(et).On(emp.EmployeeID == et.EmpID);
                emp.Where(emp.LastName.Like("S%"));

                // 2) Serialize it in binary
                BinaryFormatter bf = new BinaryFormatter();
                MemoryStream ms = new MemoryStream();
                bf.Serialize(ms, emp);
                byte[] query = ms.ToArray();

                // 3) Send it over the wire

                // 4) Deserialize it on the Server
                bf = new BinaryFormatter();
                ms = new MemoryStream(query);
                EmployeeQuery newQuery = bf.Deserialize(ms) as EmployeeQuery;

                // Now load it 
                EmployeeCollection collection = new EmployeeCollection();
                collection.es.Connection.Name = "ForeignKeyTest";

                collection.Load(newQuery);

                Assert.AreEqual(5, collection.Count);
                Assert.AreEqual("S", collection[0].LastName.Substring(0, 1));
            }
        }

    }
}
