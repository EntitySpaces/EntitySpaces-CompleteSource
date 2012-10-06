'
'===============================================================================
'                     EntitySpaces(TM) by EntitySpaces, LLC
'                 A New 2.0 Architecture for the .NET Framework
'                          http://www.entityspaces.net
'===============================================================================
'                       EntitySpaces Version # 2007.0.0730.0
'                       MyGeneration Version # 1.2.0.7
'                           7/30/2007 5:51:12 PM
'-------------------------------------------------------------------------------
'



Imports System.ComponentModel
Imports System.Collections.Generic
Imports System.Text
Imports System.Data

Imports EntitySpaces.Interfaces
Imports EntitySpaces.Core

Namespace BusinessObjects
	Public Partial Class ComputedTest
		Inherits esComputedTest
#Region "Custom Entity Tests"

        Public Function GetDescriptionDoubleQuoteTest() As String
            Return Me.Meta.Columns("DateAdded").Description
        End Function

        Public Function GetDescriptionBackSlashTest() As String
            Return Me.Meta.Columns("SomeDate").Description
        End Function
#End Region
    End Class

End Namespace
