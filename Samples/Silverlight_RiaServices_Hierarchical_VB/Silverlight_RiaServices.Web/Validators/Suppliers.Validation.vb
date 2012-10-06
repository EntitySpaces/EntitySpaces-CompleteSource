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

	<MetadataType(GetType(SuppliersValidation))> _
	Public Partial Class Suppliers

	End Class

    Friend Class SuppliersValidation
    

		<KeyAttribute()> _
		<Editable(false)> _
		Public Property SupplierID As Nullable(Of System.Int32)

		<StringLength(40)> _
		<Required> _
		Public Property CompanyName As System.String

		<StringLength(30)> _
		Public Property ContactName As System.String

		<StringLength(30)> _
		Public Property ContactTitle As System.String

		<StringLength(60)> _
		Public Property Address As System.String

		<StringLength(15)> _
		Public Property City As System.String

		<StringLength(15)> _
		Public Property Region As System.String

		<StringLength(10)> _
		Public Property PostalCode As System.String

		<StringLength(15)> _
		Public Property Country As System.String

		<StringLength(24)> _
		Public Property Phone As System.String

		<StringLength(24)> _
		Public Property Fax As System.String

		<StringLength(1073741823)> _
		Public Property HomePage As System.String
    
	End Class
End Namespace