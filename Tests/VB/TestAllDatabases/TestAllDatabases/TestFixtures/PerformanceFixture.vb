'======================================
' Copyright EntitySpaces, LLC 2005 - 2006 
'======================================

Imports System.Data
Imports System.Linq
Imports NUnit.Framework

Imports EntitySpaces.Interfaces
Imports BusinessObjects

Namespace Tests.Base
	<TestFixture> _
	Public Class PerformanceFixture

		'[Test]
		'public void TestBulkInserts()
		'{
		'    AggregateTestCollection coll = new AggregateTestCollection();
		'    System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();

		'    coll.Query.Where(coll.Query.Age < 100);
		'    sw.Start();
		'    coll.Query.Load();
		'    sw.Stop();
		'    Console.WriteLine("Initial Load: " + sw.Elapsed.ToString());

		'    coll.MarkAllAsDeleted();

		'    sw.Start();
		'    coll.Save();
		'    sw.Stop();
		'    Console.WriteLine("Deleted Save: " + sw.Elapsed.ToString());

		'    coll = new AggregateTestCollection();

		'    sw.Start();
		'    for (int i = 0; i < 50000; i++)
		'    {
		'        AggregateTest entity = coll.AddNew();
		'        entity.LastName = "BulkTest";
		'        entity.FirstName = "SomeName";
		'        entity.HireDate = DateTime.Now;
		'        entity.Age = 50;
		'        entity.IsActive = false;
		'    }
		'    sw.Stop();
		'    Console.WriteLine("Loop: " + sw.Elapsed.ToString());

		'    sw.Start();
		'    coll.Save();
		'    sw.Stop();
		'    Console.WriteLine("Added Save: " + sw.Elapsed.ToString());

		'    coll = new AggregateTestCollection();

		'    coll.Query.Load();

		'    string lq = coll.Query.es.LastQuery;

		'    //UnitTestBase.RefreshDatabase();

		'}

		<Test> _
		Public Sub LoadJoined()
			Dim cq As New CustomerQuery("c")
			Dim eq As New EmployeeQuery("e")
			Dim eq2 As New EmployeeQuery("e2")
			Dim oq As New OrderQuery("o")
			Dim oiq As New OrderItemQuery("oi")
			Dim pq As New ProductQuery("p")

			cq.[Select](cq.CustomerID, cq.CustomerSub, cq.CustomerName, eq, eq2.LastName.[As]("ReportsTo"), oq.PlacedBy, _
				oq.OrderDate, oiq, pq.ProductName, pq.Discontinued)
			cq.LeftJoin(eq).[On](eq.EmployeeID = cq.Manager)
			cq.LeftJoin(eq2).[On](eq.Supervisor = eq2.EmployeeID)
			cq.LeftJoin(oq).[On](cq.CustomerID = oq.CustID AndAlso cq.CustomerSub = oq.CustSub)
			cq.LeftJoin(oiq).[On](oq.OrderID = oiq.OrderID)
			cq.LeftJoin(pq).[On](oiq.ProductID = pq.ProductID)

			Dim coll As New CustomerCollection()
			coll.es.Connection.Name = "ForeignKeyTest"

            Assert.IsTrue(coll.Load(cq))
            Assert.AreEqual(69, coll.Count)
		End Sub
	End Class
End Namespace
