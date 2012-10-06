<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.components = New System.ComponentModel.Container
        Me._bindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.btnRefresh = New System.Windows.Forms.Button
        Me.btnDynamicQuery = New System.Windows.Forms.Button
        Me.btnChangeFirstName = New System.Windows.Forms.Button
        Me.btnDelete = New System.Windows.Forms.Button
        Me.btnAdd = New System.Windows.Forms.Button
        Me.btnFilterSort = New System.Windows.Forms.Button
        Me.btnFilter = New System.Windows.Forms.Button
        Me.btnSort = New System.Windows.Forms.Button
        Me.lblError = New System.Windows.Forms.Label
        Me.btnSave = New System.Windows.Forms.Button
        Me.dataGridView1 = New System.Windows.Forms.DataGridView
        Me.btnEndProfiling = New System.Windows.Forms.Button
        Me.btnBeginProfiling = New System.Windows.Forms.Button
        CType(Me._bindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnRefresh
        '
        Me.btnRefresh.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnRefresh.Location = New System.Drawing.Point(12, 364)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(112, 23)
        Me.btnRefresh.TabIndex = 8
        Me.btnRefresh.Text = "Reload Data"
        Me.btnRefresh.UseVisualStyleBackColor = True
        '
        'btnDynamicQuery
        '
        Me.btnDynamicQuery.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDynamicQuery.Location = New System.Drawing.Point(338, 364)
        Me.btnDynamicQuery.Name = "btnDynamicQuery"
        Me.btnDynamicQuery.Size = New System.Drawing.Size(112, 23)
        Me.btnDynamicQuery.TabIndex = 11
        Me.btnDynamicQuery.Text = "Dynamic Query"
        Me.btnDynamicQuery.UseVisualStyleBackColor = True
        '
        'btnChangeFirstName
        '
        Me.btnChangeFirstName.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnChangeFirstName.Location = New System.Drawing.Point(456, 365)
        Me.btnChangeFirstName.Name = "btnChangeFirstName"
        Me.btnChangeFirstName.Size = New System.Drawing.Size(112, 23)
        Me.btnChangeFirstName.TabIndex = 10
        Me.btnChangeFirstName.Text = "Change First Name"
        Me.btnChangeFirstName.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDelete.Location = New System.Drawing.Point(574, 393)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(75, 23)
        Me.btnDelete.TabIndex = 12
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnAdd
        '
        Me.btnAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAdd.Location = New System.Drawing.Point(574, 364)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(75, 23)
        Me.btnAdd.TabIndex = 14
        Me.btnAdd.Text = "Add"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'btnFilterSort
        '
        Me.btnFilterSort.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnFilterSort.Location = New System.Drawing.Point(655, 423)
        Me.btnFilterSort.Name = "btnFilterSort"
        Me.btnFilterSort.Size = New System.Drawing.Size(75, 23)
        Me.btnFilterSort.TabIndex = 13
        Me.btnFilterSort.Text = "Filter/Sort"
        Me.btnFilterSort.UseVisualStyleBackColor = True
        '
        'btnFilter
        '
        Me.btnFilter.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnFilter.Location = New System.Drawing.Point(655, 394)
        Me.btnFilter.Name = "btnFilter"
        Me.btnFilter.Size = New System.Drawing.Size(75, 23)
        Me.btnFilter.TabIndex = 9
        Me.btnFilter.Text = "Filter"
        Me.btnFilter.UseVisualStyleBackColor = True
        '
        'btnSort
        '
        Me.btnSort.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSort.Location = New System.Drawing.Point(655, 365)
        Me.btnSort.Name = "btnSort"
        Me.btnSort.Size = New System.Drawing.Size(75, 23)
        Me.btnSort.TabIndex = 7
        Me.btnSort.Text = "Sort"
        Me.btnSort.UseVisualStyleBackColor = True
        '
        'lblError
        '
        Me.lblError.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblError.ForeColor = System.Drawing.Color.Red
        Me.lblError.Location = New System.Drawing.Point(13, 16)
        Me.lblError.Name = "lblError"
        Me.lblError.Size = New System.Drawing.Size(799, 35)
        Me.lblError.TabIndex = 6
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSave.Location = New System.Drawing.Point(736, 365)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 23)
        Me.btnSave.TabIndex = 5
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'dataGridView1
        '
        Me.dataGridView1.AllowUserToOrderColumns = True
        Me.dataGridView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dataGridView1.AutoGenerateColumns = False
        Me.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dataGridView1.DataSource = Me._bindingSource
        Me.dataGridView1.Location = New System.Drawing.Point(13, 93)
        Me.dataGridView1.Name = "dataGridView1"
        Me.dataGridView1.Size = New System.Drawing.Size(799, 265)
        Me.dataGridView1.TabIndex = 4
        '
        'btnEndProfiling
        '
        Me.btnEndProfiling.Location = New System.Drawing.Point(127, 64)
        Me.btnEndProfiling.Name = "btnEndProfiling"
        Me.btnEndProfiling.Size = New System.Drawing.Size(108, 23)
        Me.btnEndProfiling.TabIndex = 16
        Me.btnEndProfiling.Text = "End Profiling"
        Me.btnEndProfiling.UseVisualStyleBackColor = True
        '
        'btnBeginProfiling
        '
        Me.btnBeginProfiling.Location = New System.Drawing.Point(13, 64)
        Me.btnBeginProfiling.Name = "btnBeginProfiling"
        Me.btnBeginProfiling.Size = New System.Drawing.Size(108, 23)
        Me.btnBeginProfiling.TabIndex = 15
        Me.btnBeginProfiling.Text = "Begin Profiling"
        Me.btnBeginProfiling.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(824, 462)
        Me.Controls.Add(Me.btnEndProfiling)
        Me.Controls.Add(Me.btnBeginProfiling)
        Me.Controls.Add(Me.btnRefresh)
        Me.Controls.Add(Me.btnDynamicQuery)
        Me.Controls.Add(Me.btnChangeFirstName)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.btnFilterSort)
        Me.Controls.Add(Me.btnFilter)
        Me.Controls.Add(Me.btnSort)
        Me.Controls.Add(Me.lblError)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.dataGridView1)
        Me.Name = "Form1"
        Me.Text = "EntitySpaces 2010 VB Sample"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me._bindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents _bindingSource As System.Windows.Forms.BindingSource
    Private WithEvents btnRefresh As System.Windows.Forms.Button
    Private WithEvents btnDynamicQuery As System.Windows.Forms.Button
    Private WithEvents btnChangeFirstName As System.Windows.Forms.Button
    Private WithEvents btnDelete As System.Windows.Forms.Button
    Private WithEvents btnAdd As System.Windows.Forms.Button
    Private WithEvents btnFilterSort As System.Windows.Forms.Button
    Private WithEvents btnFilter As System.Windows.Forms.Button
    Private WithEvents btnSort As System.Windows.Forms.Button
    Private WithEvents lblError As System.Windows.Forms.Label
    Private WithEvents btnSave As System.Windows.Forms.Button
    Private WithEvents dataGridView1 As System.Windows.Forms.DataGridView
    Private WithEvents btnEndProfiling As System.Windows.Forms.Button
    Private WithEvents btnBeginProfiling As System.Windows.Forms.Button

End Class
