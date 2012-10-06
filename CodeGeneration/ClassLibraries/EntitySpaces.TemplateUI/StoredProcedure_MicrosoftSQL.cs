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

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using EntitySpaces.AddIn.TemplateUI;
using EntitySpaces.MetadataEngine;

namespace EntitySpaces.TemplateUI
{
    public partial class StoredProcedure_MicrosoftSQL : UserControl, ITemplateUI
    {
        private Root esMeta;
        private bool UseCachedSettings;
        private object applicationObject;

        public StoredProcedure_MicrosoftSQL()
        {
            InitializeComponent();
        }

        #region ITemplateUI Members

        esTemplateInfo ITemplateUI.Init()
        {
            esTemplateInfo info = new esTemplateInfo();
            info.UserInterface = this;
            info.UserInterfaceId = new Guid("14846E0F-98D3-4ca0-89E9-54A1F4B332E3");
            info.TabTitle = "Microsoft SQL";
            info.TabOrder = 1;
            return info;
        }

        UserControl ITemplateUI.CreateInstance(Root esMeta, bool cachedSettings, object applicationObject)
        {
            StoredProcedure_MicrosoftSQL window = new StoredProcedure_MicrosoftSQL();
            window.esMeta = esMeta;
            window.applicationObject = applicationObject;
            window.UseCachedSettings = cachedSettings;

            return window;
        }

        bool ITemplateUI.OnExecute()
        {
            try
            {
                esMeta.Input["OutputPath"] = txtOutputPath.Text;
                esMeta.Input["Database"] = ((IDatabase)this.cboDatabase.SelectedItem).Name;
                esMeta.Input["EntityType"] = "Tables";

                ArrayList list = new ArrayList();

                foreach (ITable table in this.lboxTablesViews.SelectedItems)
                {
                    list.Add(table.FullName);
                }

                esMeta.Input["Entities"] = list;

                esMeta.Input["UseAlter"] = checkBoxUseAlter.Checked;
                esMeta.Input["GenerateDocumentation"] = checkBoxGenDocumentation.Checked;
                esMeta.Input["SqlServer2005"] = checkBox2005andUp.Checked;
                esMeta.Input["UseSchema"] = checkBoxUseSchema.Checked;
            }
            catch { }

            return true;   
        }

        void ITemplateUI.OnCancel()
        {
            // Nothing to do really
        }

        #endregion

        private void StoredProcedure_MicrosoftSQL_Load(object sender, EventArgs e)
        {
            try
            {
                //-----------------------------------------------------------
                // OutputPath
                //-----------------------------------------------------------
                this.txtOutputPath.Text = (string)esMeta.Input["OutputPath"];

                //-----------------------------------------------------------
                // Database
                //-----------------------------------------------------------
                this.cboDatabase.DataSource = esMeta.Databases;
                this.cboDatabase.DisplayMember = "Name";

                string database = "";

                if (UseCachedSettings && esMeta.Input.ContainsKey("Database"))
                {
                    database = (string)esMeta.Input["Database"];
                }
                else if (esMeta.DefaultDatabase != null)
                {
                    database = esMeta.DefaultDatabase.Name;
                }

                int index = this.cboDatabase.FindString(database);
                if (index != -1)
                {
                    this.cboDatabase.SelectedIndex = index;
                }

                //-----------------------------------------------------------
                // Entities
                //-----------------------------------------------------------
                this.lboxTablesViews.DataSource = esMeta.Databases[database].Tables;
                this.lboxTablesViews.DisplayMember = "FullName";

                if (UseCachedSettings && esMeta.Input.ContainsKey("Entities"))
                {
                    this.lboxTablesViews.SelectedItems.Clear();

                    ArrayList entities = (ArrayList)esMeta.Input["Entities"];

                    foreach (string entity in entities)
                    {
                        index = this.lboxTablesViews.FindString(entity);

                        if (index != -1)
                        {
                            this.lboxTablesViews.SetSelected(index, true);
                        }
                    }
                }

                if (esMeta.Input.ContainsKey("UseAlter"))
                {
                    checkBoxUseAlter.Checked = (bool)esMeta.Input["UseAlter"];
                }

                if (esMeta.Input.ContainsKey("GenerateDocumentation"))
                {
                    checkBoxGenDocumentation.Checked = (bool)esMeta.Input["GenerateDocumentation"];
                }

                if (esMeta.Input.ContainsKey("SqlServer2005"))
                {
                    checkBox2005andUp.Checked = (bool)esMeta.Input["SqlServer2005"];
                }

                if (esMeta.Input.ContainsKey("UseSchema"))
                {
                    checkBoxUseSchema.Checked = (bool)esMeta.Input["UseSchema"];
                }
            }
            catch { }
        }

        private void cboDatabase_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                IDatabase database = this.cboDatabase.SelectedValue as IDatabase;

                this.lboxTablesViews.DataSource = database.Tables;
                this.lboxTablesViews.DisplayMember = "FullName";
            }
            catch { }
        }

        private void btnOutputPath_Click(object sender, EventArgs e)
        {
            try
            {
                FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
                folderBrowserDialog1.Description = "Select the Output Folder";
                folderBrowserDialog1.SelectedPath = txtOutputPath.Text;

                if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                {
                    txtOutputPath.Text = folderBrowserDialog1.SelectedPath;
                }
            }
            catch { }
        }

        private void lboxTablesViews_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A)
            {
                if ((ModifierKeys & Keys.Control) == Keys.Control)
                {
                    for (int i = 0; i < this.lboxTablesViews.Items.Count; i++)
                    {
                        this.lboxTablesViews.SetSelected(i, true);
                    }
                }
            }
        }
    }
}
