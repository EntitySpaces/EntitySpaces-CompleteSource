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

	<MetadataType(GetType(OrderDetailsValidation))> _
	Public Partial Class OrderDetails

	End Class

    Friend Class OrderDetailsValidation
    

		<KeyAttribute()> _
		<Required> _
		Public Property OrderID As Nullable(Of System.Int32)

		<KeyAttribute()> _
		<Required> _
		Public Property ProductID As Nullable(Of System.Int32)

		Public Property UnitPrice As Nullable(Of System.Decimal)

		Public Property Quantity As Nullable(Of System.Int16)

		Public Property Discount As Nullable(Of System.Single)
    
	End Class
End Namespace