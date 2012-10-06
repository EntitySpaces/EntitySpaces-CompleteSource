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
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.ComponentModel.DataAnnotations
Imports System.Linq
Imports System.Runtime.Serialization

Imports EntitySpaces.DynamicQuery

Namespace BusinessObjects

	Public Partial Class EmployeeTerritories

#If (SILVERLIGHT) Then

		<Display(AutoGenerateField:=False)> _
		Public ReadOnly Property esExtraColumns() As Dictionary(Of String, Object)
			Get
				If _esExtraColumns Is Nothing Then
					If Me.esExtendedData IsNot Nothing Then
						_esExtraColumns = TryCast(esDataContractSerializer.FromXml(Me.esExtendedData, GetType(Dictionary(Of String, Object))), Dictionary(Of String, Object))
					Else
						_esExtraColumns = New Dictionary(Of String, Object)()
					End If
				End If

				Return _esExtraColumns
			End Get
		End Property
		Private _esExtraColumns As Dictionary(Of String, Object)

#End If

	End Class

End Namespace
