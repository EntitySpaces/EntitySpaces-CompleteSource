<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Hierarchical
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.dataGrid1 = New System.Windows.Forms.DataGrid
        CType(Me.dataGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dataGrid1
        '
        Me.dataGrid1.AlternatingBackColor = System.Drawing.Color.Lavender
        Me.dataGrid1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.dataGrid1.BackgroundColor = System.Drawing.Color.LightGray
        Me.dataGrid1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dataGrid1.CaptionBackColor = System.Drawing.Color.LightSteelBlue
        Me.dataGrid1.CaptionForeColor = System.Drawing.Color.MidnightBlue
        Me.dataGrid1.DataMember = ""
        Me.dataGrid1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dataGrid1.FlatMode = True
        Me.dataGrid1.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.dataGrid1.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dataGrid1.GridLineColor = System.Drawing.Color.Gainsboro
        Me.dataGrid1.GridLineStyle = System.Windows.Forms.DataGridLineStyle.None
        Me.dataGrid1.HeaderBackColor = System.Drawing.Color.MidnightBlue
        Me.dataGrid1.HeaderFont = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.dataGrid1.HeaderForeColor = System.Drawing.Color.WhiteSmoke
        Me.dataGrid1.LinkColor = System.Drawing.Color.Teal
        Me.dataGrid1.Location = New System.Drawing.Point(0, 0)
        Me.dataGrid1.Name = "dataGrid1"
        Me.dataGrid1.ParentRowsBackColor = System.Drawing.Color.Gainsboro
        Me.dataGrid1.ParentRowsForeColor = System.Drawing.Color.MidnightBlue
        Me.dataGrid1.SelectionBackColor = System.Drawing.Color.CadetBlue
        Me.dataGrid1.SelectionForeColor = System.Drawing.Color.WhiteSmoke
        Me.dataGrid1.Size = New System.Drawing.Size(787, 492)
        Me.dataGrid1.TabIndex = 3
        '
        'Hierarchical
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(787, 492)
        Me.Controls.Add(Me.dataGrid1)
        Me.Name = "Hierarchical"
        Me.Text = "Hierarchical"
        CType(Me.dataGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents dataGrid1 As System.Windows.Forms.DataGrid
End Class
