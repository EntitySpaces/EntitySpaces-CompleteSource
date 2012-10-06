'===============================================================================
'                   EntitySpaces Studio by EntitySpaces, LLC
'            Persistence Layer and Business Objects for Microsoft .NET
'            EntitySpaces(TM) is a legal trademark of EntitySpaces, LLC
'                         http://www.entityspaces.net
'===============================================================================
' EntitySpaces Version : 2012.1.0930.0
' EntitySpaces Driver  : SQL
' Date Generated       : 9/23/2012 6:16:25 PM
'===============================================================================

Imports System
Imports System.ComponentModel.DataAnnotations

Namespace BusinessObjects

	<MetadataType(GetType(OrdersValidation))> _
	Public Partial Class Orders

	End Class

    Friend Class OrdersValidation
    

		<KeyAttribute()> _
		<Editable(false)> _
		Public Property OrderID As Nullable(Of System.Int32)

		<StringLength(5)> _
		Public Property CustomerID As System.String

		Public Property EmployeeID As Nullable(Of System.Int32)

		Public Property OrderDate As Nullable(Of System.DateTime)

		Public Property RequiredDate As Nullable(Of System.DateTime)

		Public Property ShippedDate As Nullable(Of System.DateTime)

		Public Property ShipVia As Nullable(Of System.Int32)

		Public Property Freight As Nullable(Of System.Decimal)

		<StringLength(40)> _
		Public Property ShipName As System.String

		<StringLength(60)> _
		Public Property ShipAddress As System.String

		<StringLength(15)> _
		Public Property ShipCity As System.String

		<StringLength(15)> _
		Public Property ShipRegion As System.String

		<StringLength(10)> _
		Public Property ShipPostalCode As System.String

		<StringLength(15)> _
		Public Property ShipCountry As System.String
    
	End Class
End Namespace