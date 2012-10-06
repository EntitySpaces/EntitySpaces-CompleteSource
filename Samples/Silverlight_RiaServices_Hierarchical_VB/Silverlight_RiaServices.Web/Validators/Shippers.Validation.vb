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

	<MetadataType(GetType(ShippersValidation))> _
	Public Partial Class Shippers

	End Class

    Friend Class ShippersValidation
    

		<KeyAttribute()> _
		<Editable(false)> _
		Public Property ShipperID As Nullable(Of System.Int32)

		<StringLength(40)> _
		<Required> _
		Public Property CompanyName As System.String

		<StringLength(24)> _
		Public Property Phone As System.String
    
	End Class
End Namespace