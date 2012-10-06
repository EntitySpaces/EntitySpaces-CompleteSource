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

	<MetadataType(GetType(EmployeeTerritoriesValidation))> _
	Public Partial Class EmployeeTerritories

	End Class

    Friend Class EmployeeTerritoriesValidation
    

		<KeyAttribute()> _
		<Required> _
		Public Property EmployeeID As Nullable(Of System.Int32)

		<KeyAttribute()> _
		<StringLength(20)> _
		<Required> _
		Public Property TerritoryID As System.String
    
	End Class
End Namespace