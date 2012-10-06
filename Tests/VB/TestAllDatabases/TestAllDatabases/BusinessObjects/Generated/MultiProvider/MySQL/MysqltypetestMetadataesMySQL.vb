'===============================================================================
'                   EntitySpaces Studio by EntitySpaces, LLC
'            Persistence Layer and Business Objects for Microsoft .NET
'            EntitySpaces(TM) is a legal trademark of EntitySpaces, LLC
'                         http://www.entityspaces.net
'===============================================================================
' EntitySpaces Version : 2012.1.0319.0
' EntitySpaces Driver  : MySql
' Date Generated       : 3/17/2012 4:52:09 AM
'===============================================================================

Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Data

Imports EntitySpaces.Interfaces
Imports EntitySpaces.Core

Namespace BusinessObjects

	Partial Public Class MysqltypetestMetadata 
		Inherits esMetadata
		Implements IMetadata
		
        Private Shared Function RegisterDelegateesMySQL() As Integer
		
            ' This is only executed once per the life of the application
            SyncLock GetType(MysqltypetestMetadata)
			
				If MysqltypetestMetadata.mapDelegates Is Nothing Then
					MysqltypetestMetadata.mapDelegates = New Dictionary(Of String, MapToMeta)
				End If			

                If MysqltypetestMetadata._meta Is Nothing Then
                    MysqltypetestMetadata._meta = New MysqltypetestMetadata()
                End If

                Dim mapMethod As New MapToMeta(AddressOf _meta.esMySQL)
                mapDelegates.Add("esMySQL", mapMethod)
                mapMethod("esMySQL")
                Return 0

            End SyncLock			
		
        End Function

        Private Function esMySQL(ByVal mapName As String) As esProviderSpecificMetadata

            If (Not m_providerMetadataMaps.ContainsKey(mapName)) Then		

				Dim meta As esProviderSpecificMetadata = new esProviderSpecificMetadata()
			

				meta.AddTypeMap("Id", new esTypeMap("INT", "System.Int32"))
				meta.AddTypeMap("BigIntType", new esTypeMap("BIGINT", "System.Int64"))
				meta.AddTypeMap("IntType", new esTypeMap("INT", "System.Int32"))
				meta.AddTypeMap("MedIntType", new esTypeMap("MEDIUMINT", "System.Int32"))
				meta.AddTypeMap("SmallIntType", new esTypeMap("SMALLINT", "System.Int16"))
				meta.AddTypeMap("TinyIntType", new esTypeMap("TINYINT", "System.SByte"))
				meta.AddTypeMap("BigIntUType", new esTypeMap("BIGINT UNSIGNED", "System.UInt64"))
				meta.AddTypeMap("IntUType", new esTypeMap("INT UNSIGNED", "System.UInt32"))
				meta.AddTypeMap("MedIntUType", new esTypeMap("MEDIUMINT UNSIGNED", "System.UInt32"))
				meta.AddTypeMap("SmallIntUType", new esTypeMap("SMALLINT UNSIGNED", "System.UInt16"))
				meta.AddTypeMap("TinyIntUType", new esTypeMap("TINYINT UNSIGNED", "System.Byte"))
				meta.AddTypeMap("FloatType", new esTypeMap("FLOAT", "System.Single"))
				meta.AddTypeMap("FloatUType", new esTypeMap("FLOAT UNSIGNED", "System.Single"))
				meta.AddTypeMap("DecType", new esTypeMap("DECIMAL", "System.Decimal"))
				meta.AddTypeMap("DecUType", new esTypeMap("DECIMAL UNSIGNED", "System.Decimal"))
				meta.AddTypeMap("NumType", new esTypeMap("DECIMAL", "System.Decimal"))
				meta.AddTypeMap("NumUType", new esTypeMap("DECIMAL UNSIGNED", "System.Decimal"))
				meta.AddTypeMap("DblType", new esTypeMap("DOUBLE", "System.Double"))
				meta.AddTypeMap("DblUType", new esTypeMap("DOUBLE UNSIGNED", "System.Double"))
				meta.AddTypeMap("RealType", new esTypeMap("DOUBLE", "System.Double"))
				meta.AddTypeMap("RealUType", new esTypeMap("DOUBLE UNSIGNED", "System.Double"))
				meta.AddTypeMap("BitType", new esTypeMap("BIT", "System.SByte"))				
				meta.Catalog = "aggregatedb"
				
				
				meta.Source = "mysqltypetest"
				meta.Destination = "mysqltypetest"
				
				meta.spInsert = "proc_mysqltypetestInsert"
				meta.spUpdate = "proc_mysqltypetestUpdate"
				meta.spDelete = "proc_mysqltypetestDelete"
				meta.spLoadAll = "proc_mysqltypetestLoadAll"
				meta.spLoadByPrimaryKey = "proc_mysqltypetestLoadByPrimaryKey"
				
                m_providerMetadataMaps.Add("esMySQL", meta)

            End If

            Return m_providerMetadataMaps("esMySQL")

        End Function
		
		Private Shared _esMySQL As Integer = RegisterDelegateesMySQL()	
		
	End Class
	
End Namespace	
