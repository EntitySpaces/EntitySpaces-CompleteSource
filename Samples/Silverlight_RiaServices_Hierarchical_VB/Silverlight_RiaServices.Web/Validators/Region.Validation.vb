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

	<MetadataType(GetType(RegionValidation))> _
	Public Partial Class Region

	End Class

    Friend Class RegionValidation
    

		<KeyAttribute()> _
		<Required> _
		Public Property RegionID As Nullable(Of System.Int32)

		<StringLength(50)> _
		<Required> _
		Public Property RegionDescription As System.String
    
	End Class
End Namespace