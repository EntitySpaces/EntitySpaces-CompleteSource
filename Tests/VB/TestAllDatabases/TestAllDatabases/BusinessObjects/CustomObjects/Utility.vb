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
	Class Utility
		Inherits esEntity
		Public Function GetFullName(ID As Integer) As String
			Dim cn As esConnection = Me.es.Connection
			cn.Catalog = "AggregateDb"
			cn.Schema = "dbo"

			Dim parms As New esParameters()

			parms.Add("ID", ID)
			parms.Add("FullName", esParameterDirection.Output, DbType.[String], 40)

			Me.ExecuteNonQuery(esQueryType.StoredProcedure, "proc_GetEmployeeFullName", parms)

			Return TryCast(parms("FullName").Value, String)
		End Function

		Protected Overloads Overrides ReadOnly Property Meta() As IMetadata
			Get
				Return md
			End Get
		End Property

		Private Shared md As New MetaData()

		Protected Class MetaData
            Inherits esMetadata
            Implements IMetadata

            Public ReadOnly Property DataID() As Guid
                Get
                    Return Guid.NewGuid()
                End Get
            End Property

            Public ReadOnly Property MultiProviderMode() As Boolean
                Get
                    Return True
                End Get
            End Property

            Public ReadOnly Property Columns() As esColumnMetadataCollection
                Get
                    Return Nothing
                End Get
            End Property

            Public Function GetProviderMetadata(ByVal mapName As String) As esProviderSpecificMetadata
                Return Nothing
            End Function

            Public ReadOnly Property Columns1() As EntitySpaces.Interfaces.esColumnMetadataCollection Implements EntitySpaces.Interfaces.IMetadata.Columns
                Get

                End Get
            End Property

            Public ReadOnly Property DataID1() As System.Guid Implements EntitySpaces.Interfaces.IMetadata.DataID
                Get

                End Get
            End Property

            Public Function GetProviderMetadata1(ByVal key As String) As EntitySpaces.Interfaces.esProviderSpecificMetadata Implements EntitySpaces.Interfaces.IMetadata.GetProviderMetadata

            End Function

            Public ReadOnly Property MultiProviderMode1() As Boolean Implements EntitySpaces.Interfaces.IMetadata.MultiProviderMode
                Get

                End Get
            End Property
        End Class
	End Class
End Namespace
