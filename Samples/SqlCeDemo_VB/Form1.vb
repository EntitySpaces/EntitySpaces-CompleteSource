Imports EntitySpaces.Interfaces
Imports SqlCeDemo.BusinessObjects

Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        OneTimeInit()

        Dim coll As New EmployeeCollection()
        Dim query As EmployeeQuery = coll.Query
        ' short hand
        query.[Select](query.EmployeeID, query.LastName, query.FirstName)

        If coll.Query.Load() Then
            Me.dataGrid1.DataSource = coll
        End If

    End Sub

    Private Sub OneTimeInit()

        esProviderFactory.Factory = New EntitySpaces.Loader.esDataProviderFactory()

        Dim cnString As String = ("Data Source = " & (System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase) & "\ForeignKeyTest_35.sdf;"))

        ' What the heck let's register a second connection
        Dim conn As New esConnectionElement()
        conn.ConnectionString = cnString
        conn.Name = "SqlCE"
        conn.Provider = "EntitySpaces.SqlServerCeProvider.CF"
        conn.ProviderClass = "DataProvider"
        conn.SqlAccessType = esSqlAccessType.DynamicSQL
        conn.ProviderMetadataKey = "esDefault"
        esConfigSettings.ConnectionInfo.Connections.Add(conn)

        ' Assign the Default Connection
        esConfigSettings.ConnectionInfo.[Default] = "SqlCE"

    End Sub

End Class
