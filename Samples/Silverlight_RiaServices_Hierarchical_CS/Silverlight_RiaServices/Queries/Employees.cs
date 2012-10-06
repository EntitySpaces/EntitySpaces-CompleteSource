/*===============================================================================
                    EntitySpaces Studio by EntitySpaces, LLC
             Persistence Layer and Business Objects for Microsoft .NET
             EntitySpaces(TM) is a legal trademark of EntitySpaces, LLC
                          http://www.entityspaces.net
===============================================================================
EntitySpaces Version : 2012.1.0930.0
EntitySpaces Driver  : SQL
Date Generated       : 9/23/2012 6:16:16 PM
===============================================================================
*/

using System;
using System.Runtime.Serialization;

using EntitySpaces.DynamicQuery;

namespace BusinessObjects
{
	[DataContract(Name = "EmployeesQuery", Namespace = "http://www.entityspaces.net")]
	public partial class EmployeesQueryProxyStub : esDynamicQuerySerializable
	{
		public EmployeesQueryProxyStub() { }
		
		public EmployeesQueryProxyStub(string joinAlias)
		{
			this.es.JoinAlias = joinAlias;
		}

        override protected string GetQueryName()
        {
            return "EmployeesQuery";
        }	
		
        #region Implicit Casts

        public static implicit operator string(EmployeesQueryProxyStub query)
        {
            return esDynamicQuerySerializable.SerializeHelper.ToXml(query);
        }

        #endregion			

		public esQueryItem EmployeeID
		{
			get { return new esQueryItem(this, "EmployeeID", esSystemType.Int32); }
		} 
		
		public esQueryItem LastName
		{
			get { return new esQueryItem(this, "LastName", esSystemType.String); }
		} 
		
		public esQueryItem FirstName
		{
			get { return new esQueryItem(this, "FirstName", esSystemType.String); }
		} 
		
		public esQueryItem Title
		{
			get { return new esQueryItem(this, "Title", esSystemType.String); }
		} 
		
		public esQueryItem TitleOfCourtesy
		{
			get { return new esQueryItem(this, "TitleOfCourtesy", esSystemType.String); }
		} 
		
		public esQueryItem BirthDate
		{
			get { return new esQueryItem(this, "BirthDate", esSystemType.DateTime); }
		} 
		
		public esQueryItem HireDate
		{
			get { return new esQueryItem(this, "HireDate", esSystemType.DateTime); }
		} 
		
		public esQueryItem Address
		{
			get { return new esQueryItem(this, "Address", esSystemType.String); }
		} 
		
		public esQueryItem City
		{
			get { return new esQueryItem(this, "City", esSystemType.String); }
		} 
		
		public esQueryItem Region
		{
			get { return new esQueryItem(this, "Region", esSystemType.String); }
		} 
		
		public esQueryItem PostalCode
		{
			get { return new esQueryItem(this, "PostalCode", esSystemType.String); }
		} 
		
		public esQueryItem Country
		{
			get { return new esQueryItem(this, "Country", esSystemType.String); }
		} 
		
		public esQueryItem HomePhone
		{
			get { return new esQueryItem(this, "HomePhone", esSystemType.String); }
		} 
		
		public esQueryItem Extension
		{
			get { return new esQueryItem(this, "Extension", esSystemType.String); }
		} 
		
		public esQueryItem Photo
		{
			get { return new esQueryItem(this, "Photo", esSystemType.ByteArray); }
		} 
		
		public esQueryItem Notes
		{
			get { return new esQueryItem(this, "Notes", esSystemType.String); }
		} 
		
		public esQueryItem ReportsTo
		{
			get { return new esQueryItem(this, "ReportsTo", esSystemType.Int32); }
		} 
		
		public esQueryItem PhotoPath
		{
			get { return new esQueryItem(this, "PhotoPath", esSystemType.String); }
		} 
		
	}
}