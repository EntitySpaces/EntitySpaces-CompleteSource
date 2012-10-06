/*  New BSD License
-------------------------------------------------------------------------------
Copyright (c) 2006-2012, EntitySpaces, LLC
All rights reserved.

Redistribution and use in source and binary forms, with or without
modification, are permitted provided that the following conditions are met:
    * Redistributions of source code must retain the above copyright
      notice, this list of conditions and the following disclaimer.
    * Redistributions in binary form must reproduce the above copyright
      notice, this list of conditions and the following disclaimer in the
      documentation and/or other materials provided with the distribution.
    * Neither the name of the EntitySpaces, LLC nor the
      names of its contributors may be used to endorse or promote products
      derived from this software without specific prior written permission.

THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND
ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED
WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
DISCLAIMED. IN NO EVENT SHALL EntitySpaces, LLC BE LIABLE FOR ANY
DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES
(INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES;
LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND
ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT
(INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS
SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
-------------------------------------------------------------------------------
*/

namespace EntitySpaces.TemplateUI
{
    partial class MultiProviderMap_Advanced
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.chkIgnoreCatalog = new System.Windows.Forms.CheckBox();
            this.chkIgnoreSchema = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // chkIgnoreCatalog
            // 
            this.chkIgnoreCatalog.AutoSize = true;
            this.chkIgnoreCatalog.Checked = true;
            this.chkIgnoreCatalog.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIgnoreCatalog.Location = new System.Drawing.Point(17, 45);
            this.chkIgnoreCatalog.Name = "chkIgnoreCatalog";
            this.chkIgnoreCatalog.Size = new System.Drawing.Size(207, 17);
            this.chkIgnoreCatalog.TabIndex = 2;
            this.chkIgnoreCatalog.Text = "Metadata Class Should Ignore Catalog";
            this.chkIgnoreCatalog.UseVisualStyleBackColor = true;
            // 
            // chkIgnoreSchema
            // 
            this.chkIgnoreSchema.AutoSize = true;
            this.chkIgnoreSchema.Checked = true;
            this.chkIgnoreSchema.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIgnoreSchema.Location = new System.Drawing.Point(17, 22);
            this.chkIgnoreSchema.Name = "chkIgnoreSchema";
            this.chkIgnoreSchema.Size = new System.Drawing.Size(210, 17);
            this.chkIgnoreSchema.TabIndex = 1;
            this.chkIgnoreSchema.Text = "Metadata Class Should Ignore Schema";
            this.chkIgnoreSchema.UseVisualStyleBackColor = true;
            // 
            // MultiProviderMap_Advanced
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.chkIgnoreCatalog);
            this.Controls.Add(this.chkIgnoreSchema);
            this.Name = "MultiProviderMap_Advanced";
            this.Size = new System.Drawing.Size(271, 299);
            this.Load += new System.EventHandler(this.MultiProviderMap_Advanced_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkIgnoreCatalog;
        private System.Windows.Forms.CheckBox chkIgnoreSchema;
    }
}
