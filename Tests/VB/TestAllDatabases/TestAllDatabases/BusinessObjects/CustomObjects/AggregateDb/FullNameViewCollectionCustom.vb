'======================================
' Copyright EntitySpaces, LLC 2005 - 2006 
'======================================

Imports System.ComponentModel
Imports System.Collections.Generic
Imports System.Text
Imports System.Data

Imports EntitySpaces.Interfaces
Imports EntitySpaces.Core
Imports EntitySpaces.DynamicQuery

Namespace BusinessObjects
	#Region "Custom View Tests"

	Public Partial Class FullNameViewCollection
		Inherits esFullNameViewCollection
		Public Function CustomLoadFromView() As Boolean
			Dim sqlText As String = ""

			Select Case Me.es.Connection.ProviderMetadataKey
				Case "esOracle"
					sqlText = "SELECT ""FullName"", ""DepartmentID"", ""HireDate"" "
					sqlText += "FROM ""MYGENERATION"".""FullNameView"" "
					sqlText += "WHERE ""DepartmentID"" = {0} "
					sqlText += "OR ""DepartmentID"" = {1} "

					Exit Select

				Case "esPgsql"
					sqlText = "SELECT ""FullName"", ""DepartmentID"", ""HireDate"" "
					sqlText += "FROM ""FullNameView"" "
					sqlText += "WHERE ""DepartmentID"" = {0} "
					sqlText += "OR ""DepartmentID"" = {1} "

					Exit Select

				Case "esMySQL"
					sqlText = "SELECT `FullName`, `DepartmentID`, `HireDate` "
					sqlText += "FROM `FullNameView` "
					sqlText += "WHERE `DepartmentID` = {0} "
					sqlText += "OR `DepartmentID` = {1}"

					Exit Select
				Case Else

					sqlText = "SELECT [FullName], [DepartmentID], [HireDate] "
					sqlText += "FROM [FullNameView] "
					sqlText += "WHERE [DepartmentID] = {0} "
					sqlText += "OR [DepartmentID] = {1}"

					Exit Select
			End Select

			Return Me.Load(esQueryType.Text, sqlText, 1, 2)
		End Function

		Public Function CustomLoadFromViewNoParams(whereClause As String) As Boolean
			Dim sqlText As String = ""

			Select Case Me.es.Connection.ProviderMetadataKey
				Case "esOracle"
					sqlText = "SELECT ""FullName"", ""DepartmentID"", ""HireDate"" "
					sqlText += "FROM ""MYGENERATION"".""FullNameView"" "
					sqlText += whereClause

					Exit Select

				Case "esPgsql"
					sqlText = "SELECT ""FullName"", ""DepartmentID"", ""HireDate"" "
					sqlText += "FROM ""FullNameView"" "
					sqlText += whereClause

					Exit Select

				Case "esMySQL"
					sqlText = "SELECT `FullName`, `DepartmentID`, `HireDate` "
					sqlText += "FROM `FullNameView` "
					sqlText += whereClause

					Exit Select
				Case Else

					sqlText = "SELECT [FullName], [DepartmentID], [HireDate] "
					sqlText += "FROM [FullNameView] "
					sqlText += whereClause

					Exit Select
			End Select

			Return Me.Load(esQueryType.Text, sqlText)
		End Function

		Public Function CustomLoadFromViewByDept(deptID As Integer) As Boolean
			Me.Query.Where(Me.Query.DepartmentID = deptID)

			Return Me.Query.Load()
		End Function
	End Class
	#End Region
End Namespace
