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

	<MetadataType(GetType(ProductsValidation))> _
	Public Partial Class Products

	End Class

    Friend Class ProductsValidation
    

		<KeyAttribute()> _
		<Editable(false)> _
		Public Property ProductID As Nullable(Of System.Int32)

		<StringLength(40)> _
		<Required> _
		Public Property ProductName As System.String

		Public Property SupplierID As Nullable(Of System.Int32)

		Public Property CategoryID As Nullable(Of System.Int32)

		<StringLength(20)> _
		Public Property QuantityPerUnit As System.String

		Public Property UnitPrice As Nullable(Of System.Decimal)

		Public Property UnitsInStock As Nullable(Of System.Int16)

		Public Property UnitsOnOrder As Nullable(Of System.Int16)

		Public Property ReorderLevel As Nullable(Of System.Int16)

		Public Property Discontinued As Nullable(Of System.Boolean)
    
	End Class
End Namespace