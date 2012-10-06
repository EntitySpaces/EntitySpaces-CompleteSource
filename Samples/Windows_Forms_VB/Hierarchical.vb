Imports WindowsFormsVB.BusinessObjects

Imports EntitySpaces.Interfaces
Imports EntitySpaces.Loader

Public Class Hierarchical

    Private Sub Hierarchical_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' This only needs to be done once per the entire application
        esProviderFactory.Factory = New esDataProviderFactory()

        Dim q As New EmployeesQuery()
        q.es.Top = 15
        q.Select(q.EmployeeID, q.FirstName, q.LastName, q.BirthDate.As("ExtraColumn"))

        Dim coll As New EmployeesCollection()
        coll.Load(q)

        dataGrid1.DataSource = coll

    End Sub
End Class