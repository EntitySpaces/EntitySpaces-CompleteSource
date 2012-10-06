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
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.IO;

namespace EntitySpaces.QuerySandbox
{
    public partial class ReferencesForm : DevExpress.XtraEditors.XtraForm
    {
        private ReferenceList referenceList;

        public ReferencesForm(ReferenceList refList)
        {
            InitializeComponent();

            this.referenceList = refList;
            UpdateReferencesList();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = true;
            openFileDialog.Title = "Open .NET Assembly";
            openFileDialog.Filter = ".NET assembly (*.dll;*.exe)|*.dll;*.exe";

            if (openFileDialog.ShowDialog() == DialogResult.Cancel) return;

            try
            {
                string dstPath = System.Reflection.Assembly.GetEntryAssembly().Location;
                dstPath = dstPath.Replace("esQuerySandbox.exe", "");

                List<string> newAssemblies = new List<string>();

                foreach (string sPath in openFileDialog.FileNames)
                {
                    string dPath = Path.Combine(dstPath, Path.GetFileName(sPath));

                    File.Delete(dPath);
                    File.Copy(sPath, dPath);

                    referenceList.AssemblyPaths.Add(dPath);
                    newAssemblies.Add(dPath);
                }

                foreach (string assembly in newAssemblies)
                {
                    referenceList.ProjectResolver.AddExternalReference(assembly);
                }

                this.UpdateReferencesList();
                listBox.SelectedIndex = listBox.ItemCount - 1;
            }
            catch (Exception ex)
            {
                string innerExceptionMessage = String.Empty;
                if (ex.InnerException != null)
                    innerExceptionMessage = "\r\n\r\nInner exception: " + ex.InnerException.Message;
                MessageBox.Show(this, "An exception occurred while loading the assembly: " + ex.Message 
                    + "\r\n\r\nPlease make sure that any referenced assemblies are in the same folder." + innerExceptionMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void UpdateReferencesList()
        {
            listBox.BeginUpdate();
            listBox.Items.Clear();
            foreach (string assemblyName in referenceList.ProjectResolver.ExternalReferences)
                listBox.Items.Add(assemblyName);
            listBox.EndUpdate();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (listBox.SelectedIndex != -1)
            {
                int index = listBox.SelectedIndex;

                string assemblyName = listBox.SelectedItem.ToString();

                string[] parts = assemblyName.Split(',');
                string assemblyDll = parts[0] + ".dll";
                assemblyDll = assemblyDll.ToLower();

                bool found = false;
                string assemblyToDelete = string.Empty;

                foreach (string name in referenceList.AssemblyPaths)
                {
                    string filename = Path.GetFileName(name);

                    if (filename.ToLower() == assemblyDll)
                    {
                        assemblyToDelete = name;
                        found = true;
                        break;
                    }
                }

                if (found)
                {
                    referenceList.AssemblyPaths.Remove(assemblyToDelete);
                }

                referenceList.ProjectResolver.RemoveExternalReference(listBox.SelectedItem.ToString());
                this.UpdateReferencesList();

                listBox.SelectedIndex = Math.Min(index, listBox.ItemCount - 1);
            }
        }
    }
}