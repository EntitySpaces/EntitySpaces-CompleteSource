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

	<MetadataType(GetType(CustomerCustomerDemoValidation))> _
	Public Partial Class CustomerCustomerDemo

	End Class

    Friend Class CustomerCustomerDemoValidation
    

		<KeyAttribute()> _
		<StringLength(5)> _
		<Required> _
		Public Property CustomerID As System.String

		<KeyAttribute()> _
		<StringLength(10)> _
		<Required> _
		Public Property CustomerTypeID As System.String
    
	End Class
End Namespace