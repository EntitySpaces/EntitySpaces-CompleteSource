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
using System.Windows;
using System.Windows.Forms;

using EntitySpaces.AddIn.TemplateUI;
using EntitySpaces.MetadataEngine;

namespace EntitySpaces.TemplateUI
{
    public partial class MultiProviderMap_Basic : UserControl, ITemplateUI
    {
        private Root esMeta;
        private bool UseCachedSettings;
        private object applicationObject;

        public MultiProviderMap_Basic()
        {
            InitializeComponent();
        }

        #region ITemplateUI Members

        esTemplateInfo ITemplateUI.Init()
        {
            esTemplateInfo info = new esTemplateInfo();
            info.UserInterface = this;
            info.UserInterfaceId = new Guid("DF64D8BE-865C-449c-B43A-FB8B6A1DC3B9");
            info.TabTitle = "Basic Information";
            info.TabOrder = 0;
            return info;
        }

        UserControl ITemplateUI.CreateInstance(Root esMeta, bool cachedSettings, object applicationObject)
        {
            MultiProviderMap_Basic window = new MultiProviderMap_Basic();
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
                esMeta.Input["Namespace"] = txtNamespace.Text;
                esMeta.Input["MapName"] = txtMapName.Text;
                esMeta.Input["Database"] = ((IDatabase)this.cboDatabase.SelectedItem).Name;

                ArrayList list = new ArrayList();

                esMeta.Input["EntityType"] = ShowTables() == true ? "Tables" : "Views";

                foreach (ITableView tv in this.lboxTablesViews.SelectedItems)
                {
                    list.Add(tv.FullName);
                }

                esMeta.Input["Entities"] = list;
            }
            catch { }

            return true;
        }

        void ITemplateUI.OnCancel()
        {

        }

        #endregion

        private void MultiProviderMap_Basic_Load(object sender, EventArgs e)
        {
            try
            {
                //-----------------------------------------------------------
                // OutputPath
                //-----------------------------------------------------------
                if (UseCachedSettings && esMeta.Input.ContainsKey("OutputPath"))
                {
                    this.txtOutputPath.Text = (string)esMeta.Input["OutputPath"];
                }
                else
                {
                    this.txtOutputPath.Text = (string)esMeta.Input["OutputPath"];

                    if (!this.txtOutputPath.Text.EndsWith(@"\"))
                        this.txtOutputPath.Text += @"\";

                    this.txtOutputPath.Text += @"Generated\";
                }

                //-----------------------------------------------------------
                // Namespace
                //-----------------------------------------------------------
                if (UseCachedSettings && esMeta.Input.ContainsKey("Namespace"))
                {
                    this.txtNamespace.Text = (string)esMeta.Input["Namespace"];
                }


                //-----------------------------------------------------------
                // MapName
                //-----------------------------------------------------------
                if (UseCachedSettings && esMeta.Input.ContainsKey("MapName"))
                {
                    this.txtMapName.Text = (string)esMeta.Input["MapName"];
                }
                else
                {
                    this.txtMapName.Text = esMeta.DriverString;
                }

                //-----------------------------------------------------------
                // ConnectionName
                //-----------------------------------------------------------
                if (UseCachedSettings && esMeta.Input.ContainsKey("ConnectionName"))
                {
                    this.txtMapName.Text = (string)esMeta.Input["ConnectionName"];
                }

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
                // EntityType
                //-----------------------------------------------------------
                index = this.cboTablesViews.Items.Add("Tables");
                this.cboTablesViews.Items.Add("Views");

                if (UseCachedSettings && esMeta.Input.ContainsKey("EntityType"))
                {
                    index = this.cboTablesViews.FindString((string)esMeta.Input["EntityType"]);
                }

                this.cboTablesViews.SelectedIndex = index;

                //-----------------------------------------------------------
                // Entities
                //-----------------------------------------------------------
                // NOTE: Setting the "cboTablesViews.SelectedIndex" causes the lboxTablesViews
                //       to be bound
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
            }
            catch { }
        }

        private void cboDatabase_SelectionChangeCommitted(object sender, EventArgs e)
        {
            BindTablesOrViews();
        }

        private void cboTablesViews_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindTablesOrViews();
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

        private bool ShowTables()
        {
            return this.cboTablesViews.SelectedIndex == 0;
        }

        private void BindTablesOrViews()
        {
            try
            {
                IDatabase database = this.cboDatabase.SelectedItem as IDatabase;

                if (database != null)
                {
                    this.lboxTablesViews.DataSource = null;

                    if (ShowTables())
                    {
                        this.lboxTablesViews.DataSource = database.Tables;
                        this.lboxTablesViews.DisplayMember = "FullName";
                    }
                    else
                    {
                        this.lboxTablesViews.DataSource = database.Views;
                        this.lboxTablesViews.DisplayMember = "FullName";
                    }
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
