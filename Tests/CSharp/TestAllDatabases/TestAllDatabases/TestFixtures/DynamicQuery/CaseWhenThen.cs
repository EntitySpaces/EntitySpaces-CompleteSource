//======================================
// Copyright EntitySpaces, LLC 2005 - 2006 
//======================================

using System;
using System.Data;

using NUnit.Framework;
using BusinessObjects;
using EntitySpaces.Interfaces;
using EntitySpaces.DynamicQuery;

namespace Tests.Base
{
  	[TestFixture]
	public class CaseWhenThen
    {
		[TestFixtureSetUp]
		public void Init()
		{
        }

        [SetUp]
        public void Init2()
        {

        }

        [Test]
        public void SimpleSyntaxCheck()
        {
            OrderItemQuery oq = new OrderItemQuery();
            oq.es2.Connection.Name = "ForeignKeyTest";

            oq.Select
            (
                oq.UnitPrice
                    .Case()
                        .When(oq.Quantity < 50).Then(oq.UnitPrice)
                        .When(oq.Quantity >= 50 && oq.Quantity < 70).Then(oq.UnitPrice * .90)
                        .When(oq.Quantity >= 70 && oq.Quantity < 99).Then(oq.UnitPrice * .80)
                        .Else(oq.UnitPrice * .70)
                    .End()
            );

            OrderItemCollection coll = new OrderItemCollection();
            coll.es.Connection.Name = "ForeignKeyTest";
            coll.Load(oq);
        }

        [Test]
        public void SimpleSyntaxCheckWithLike()
        {
            EmployeeQuery q = new EmployeeQuery();
            q.es2.Connection.Name = "ForeignKeyTest";

            q.Select
            (
                q.LastName
                    .Case()
                        .When(q.LastName.Like("%a")).Then("Last Name Contains an A")
                        .Else("Last Name Doesnt Contain an A")
                    .End().As("SpecialLastName")
            );

            EmployeeCollection coll = new EmployeeCollection();
            coll.es.Connection.Name = "ForeignKeyTest";
            coll.Load(q);
        }
    }
}
