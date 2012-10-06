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

	<MetadataType(GetType(CustomerDemographicsValidation))> _
	Public Partial Class CustomerDemographics

	End Class

    Friend Class CustomerDemographicsValidation
    

		<KeyAttribute()> _
		<StringLength(10)> _
		<Required> _
		Public Property CustomerTypeID As System.String

		<StringLength(1073741823)> _
		Public Property CustomerDesc As System.String
    
	End Class
End Namespace