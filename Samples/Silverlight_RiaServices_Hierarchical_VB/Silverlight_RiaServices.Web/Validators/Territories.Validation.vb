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

	<MetadataType(GetType(TerritoriesValidation))> _
	Public Partial Class Territories

	End Class

    Friend Class TerritoriesValidation
    

		<KeyAttribute()> _
		<StringLength(20)> _
		<Required> _
		Public Property TerritoryID As System.String

		<StringLength(50)> _
		<Required> _
		Public Property TerritoryDescription As System.String

		<Required> _
		Public Property RegionID As Nullable(Of System.Int32)
    
	End Class
End Namespace