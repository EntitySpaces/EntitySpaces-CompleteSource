//======================================
// Copyright EntitySpaces, LLC 2005 - 2006 
//======================================

using System;
using System.Data;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Runtime.Serialization.Json;
using System.Linq;

using NUnit.Framework;


using EntitySpaces.Interfaces;
using EntitySpaces.DynamicQuery;

using BusinessObjects;

namespace Tests.Base
{
    [TestFixture]
    public class DataContractSerializationFixture
    {
        [Test]
        public void TestSerializeQuery()
        {
            EmployeeQuery query = new EmployeeQuery("e");
            query.Where(query.EmployeeID.In(1, 2, 3, new List<object>() { 1, 2, 3 }));

            string qq = EmployeeQuery.SerializeHelper.ToXml(query);

            List<Type> types = new List<Type>();
            types.Add(typeof(EmployeeQuery));

            EmployeeQuery employeeQuery = EmployeeQuery.SerializeHelper.FromXml(
                qq, typeof(EmployeeQuery), types) as EmployeeQuery;

            EmployeeCollection c = new EmployeeCollection();
            c.es.Connection.Name = "ForeignKeyTest";
            c.Load(employeeQuery);

            Assert.IsTrue(c.Count == 3);
        }

        [Test]
        public void TestJSONSerialization()
        {
            //---------------------------------------------------------------
            // Server Side
            //---------------------------------------------------------------
            Employee emp = new Employee();
            emp.es.Connection.Name = "ForeignKeyTest";

            emp.Query.es.Top = 1;
            emp.Query.Select
            (
                emp.Query.EmployeeID,
                emp.Query.FirstName,
                emp.Query.LastName,
                emp.Query.Age,
                (emp.Query.LastName + ", " + emp.Query.FirstName).As("Fullname")
            );
            emp.Query.Load();

            // Modifiy the first name ...
            emp.FirstName = "Freddy";

            //=======================

            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(EmployeeProxyStub));
            MemoryStream ms = new MemoryStream();
            ser.WriteObject(ms, (EmployeeProxyStub)emp);

            string json = Encoding.Default.GetString(ms.ToArray());
            ms.Close();

            ms = new MemoryStream(Encoding.Unicode.GetBytes(json));
            ser = new DataContractJsonSerializer(typeof(EmployeeProxyStub));
            EmployeeProxyStub empProxy = ser.ReadObject(ms) as EmployeeProxyStub;
            ms.Close();

            Employee emp2 = empProxy.Entity;
        }

        [Test]
        public void TestProxiesDirtyRowsOnly()
        {
            EmployeeCollection coll = new EmployeeCollection();

            Employee e = coll.AddNew();
            e.EmployeeID = 1;
            e.FirstName = "unchanged";
            e.LastName = "unchanged";

            e = coll.AddNew();
            e.EmployeeID = 2;
            e.FirstName = "unchanged";
            e.LastName = "unchanged";

            e = coll.AddNew();
            e.EmployeeID = 3;
            e.FirstName = "deleted";
            e.LastName = "deleted";

            coll.AcceptChanges();

            coll[2].MarkAsDeleted();

            e = coll.AddNew();
            e.EmployeeID = 4;
            e.FirstName = "Added";
            e.LastName = "Added";

            EmployeeCollectionProxyStub proxy = new EmployeeCollectionProxyStub(coll);

            string qq = esDataContractSerializer.ToXml(proxy);
        }
    }
}
