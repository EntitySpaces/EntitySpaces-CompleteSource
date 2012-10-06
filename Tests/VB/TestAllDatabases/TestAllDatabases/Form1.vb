Imports BusinessObjects
Imports EntitySpaces.Interfaces
Imports EntitySpaces.Core
Imports EntitySpaces.DynamicQuery

Public Class Form1

    Dim coll As EmployeesCollection = New EmployeesCollection()

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        EntitySpaces.Interfaces.esProviderFactory.Factory = New EntitySpaces.Loader.esDataProviderFactory

    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Dim entity As New OrderDetails()
        'If (entity.LoadByPrimaryKey(10248, 11)) Then
        '    Dim i As Integer = -1
        'End If

        '' Dropdown combobox
        'Dim emps As EmployeesCollection = New EmployeesCollection()

        'With emps.Query
        '    .Select(.EmployeeID, (.LastName + ", " + .FirstName).As("FullName"))
        '    .Load()
        'End With

        'Me.ComboBox1.DisplayMember = "FullName"
        'Me.ComboBox1.ValueMember = "EmployeeID"
        'Me.ComboBox1.DataSource = emps

        ' DataGridView

    End Sub

    Private Sub ButtonLoad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonLoad.Click
        coll = New EmployeesCollection()
        coll.LoadAll()

        BindingSource1.DataSource = coll
        DataGridView1.DataSource = BindingSource1

    End Sub

    Private Sub ButtonUndo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonUndo.Click
        BindingSource1.CancelEdit()
        coll.RejectChanges()
        coll.Filter = coll.AsQueryable.OrderBy(Function(x) x.EmployeeID)
    End Sub

    Private Sub ButtonSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSave.Click
        Try
            BindingSource1.EndEdit()
            coll.Save()
        Catch ex As Exception
            coll.Filter = Nothing
            coll.RejectChanges()
            coll.Filter = coll.AsQueryable.OrderBy(Function(x) x.LastName)
            MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class
