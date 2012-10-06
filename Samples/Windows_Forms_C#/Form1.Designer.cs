namespace WindowsForms
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this._bindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnSave = new System.Windows.Forms.Button();
            this.lblError = new System.Windows.Forms.Label();
            this.btnSort = new System.Windows.Forms.Button();
            this.btnFilter = new System.Windows.Forms.Button();
            this.btnFilterSort = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnChangeFirstName = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnDynamicQuery = new System.Windows.Forms.Button();
            this.btnBeginProfiling = new System.Windows.Forms.Button();
            this.btnEndProfiling = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._bindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.DataSource = this._bindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(13, 81);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(799, 266);
            this.dataGridView1.TabIndex = 0;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(736, 354);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblError
            // 
            this.lblError.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblError.ForeColor = System.Drawing.Color.Red;
            this.lblError.Location = new System.Drawing.Point(13, 5);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(799, 35);
            this.lblError.TabIndex = 2;
            // 
            // btnSort
            // 
            this.btnSort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSort.Location = new System.Drawing.Point(655, 354);
            this.btnSort.Name = "btnSort";
            this.btnSort.Size = new System.Drawing.Size(75, 23);
            this.btnSort.TabIndex = 3;
            this.btnSort.Text = "Sort";
            this.btnSort.UseVisualStyleBackColor = true;
            this.btnSort.Click += new System.EventHandler(this.btnSort_Click);
            // 
            // btnFilter
            // 
            this.btnFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFilter.Location = new System.Drawing.Point(655, 383);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(75, 23);
            this.btnFilter.TabIndex = 3;
            this.btnFilter.Text = "Filter";
            this.btnFilter.UseVisualStyleBackColor = true;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // btnFilterSort
            // 
            this.btnFilterSort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFilterSort.Location = new System.Drawing.Point(655, 412);
            this.btnFilterSort.Name = "btnFilterSort";
            this.btnFilterSort.Size = new System.Drawing.Size(75, 23);
            this.btnFilterSort.TabIndex = 3;
            this.btnFilterSort.Text = "Filter/Sort";
            this.btnFilterSort.UseVisualStyleBackColor = true;
            this.btnFilterSort.Click += new System.EventHandler(this.btnFilterSort_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Location = new System.Drawing.Point(574, 353);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Location = new System.Drawing.Point(574, 382);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnChangeFirstName
            // 
            this.btnChangeFirstName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnChangeFirstName.Location = new System.Drawing.Point(456, 354);
            this.btnChangeFirstName.Name = "btnChangeFirstName";
            this.btnChangeFirstName.Size = new System.Drawing.Size(112, 23);
            this.btnChangeFirstName.TabIndex = 3;
            this.btnChangeFirstName.Text = "Change First Name";
            this.btnChangeFirstName.UseVisualStyleBackColor = true;
            this.btnChangeFirstName.Click += new System.EventHandler(this.btnChangeFirstName_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRefresh.Location = new System.Drawing.Point(12, 353);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(112, 23);
            this.btnRefresh.TabIndex = 3;
            this.btnRefresh.Text = "Reload Data";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnDynamicQuery
            // 
            this.btnDynamicQuery.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDynamicQuery.Location = new System.Drawing.Point(338, 353);
            this.btnDynamicQuery.Name = "btnDynamicQuery";
            this.btnDynamicQuery.Size = new System.Drawing.Size(112, 23);
            this.btnDynamicQuery.TabIndex = 3;
            this.btnDynamicQuery.Text = "Dynamic Query";
            this.btnDynamicQuery.UseVisualStyleBackColor = true;
            this.btnDynamicQuery.Click += new System.EventHandler(this.btnDynamicQuery_Click);
            // 
            // btnBeginProfiling
            // 
            this.btnBeginProfiling.Location = new System.Drawing.Point(13, 52);
            this.btnBeginProfiling.Name = "btnBeginProfiling";
            this.btnBeginProfiling.Size = new System.Drawing.Size(108, 23);
            this.btnBeginProfiling.TabIndex = 4;
            this.btnBeginProfiling.Text = "Begin Profiling";
            this.btnBeginProfiling.UseVisualStyleBackColor = true;
            this.btnBeginProfiling.Click += new System.EventHandler(this.btnBeginProfiling_Click);
            // 
            // btnEndProfiling
            // 
            this.btnEndProfiling.Location = new System.Drawing.Point(127, 52);
            this.btnEndProfiling.Name = "btnEndProfiling";
            this.btnEndProfiling.Size = new System.Drawing.Size(108, 23);
            this.btnEndProfiling.TabIndex = 4;
            this.btnEndProfiling.Text = "End Profiling";
            this.btnEndProfiling.UseVisualStyleBackColor = true;
            this.btnEndProfiling.Click += new System.EventHandler(this.btnEndProfiling_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(824, 462);
            this.Controls.Add(this.btnEndProfiling);
            this.Controls.Add(this.btnBeginProfiling);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnDynamicQuery);
            this.Controls.Add(this.btnChangeFirstName);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnFilterSort);
            this.Controls.Add(this.btnFilter);
            this.Controls.Add(this.btnSort);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dataGridView1);
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EntitySpaces 2010 Demo";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._bindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource _bindingSource;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.Button btnSort;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.Button btnFilterSort;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnChangeFirstName;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnDynamicQuery;
        private System.Windows.Forms.Button btnBeginProfiling;
        private System.Windows.Forms.Button btnEndProfiling;


    }
}