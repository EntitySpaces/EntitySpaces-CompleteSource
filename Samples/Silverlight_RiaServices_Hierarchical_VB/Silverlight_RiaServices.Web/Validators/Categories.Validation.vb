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

	<MetadataType(GetType(CategoriesValidation))> _
	Public Partial Class Categories

	End Class

    Friend Class CategoriesValidation
    

		<KeyAttribute()> _
		<Editable(false)> _
		Public Property CategoryID As Nullable(Of System.Int32)

		<StringLength(15)> _
		<Required> _
		Public Property CategoryName As System.String

		<StringLength(1073741823)> _
		Public Property Description As System.String

		Public Property Picture As System.Byte()
    
	End Class
End Namespace