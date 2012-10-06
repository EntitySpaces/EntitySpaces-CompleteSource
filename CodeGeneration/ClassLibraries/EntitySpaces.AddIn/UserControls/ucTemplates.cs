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
using System.Drawing;
using System.IO;
using System.Windows.Forms;

using EntitySpaces.AddIn.TemplateUI;
using EntitySpaces.CodeGenerator;
using EntitySpaces.MetadataEngine;

namespace EntitySpaces.AddIn
{
    internal partial class ucTemplates : esUserControl
    {
        TemplateDisplaySurface templateDisplaySurface = new TemplateDisplaySurface();

        public ucTemplates()
        {
            try
            {
                InitializeComponent();
            }
            catch { }
        }

        private void ucTemplates_Load(object sender, EventArgs e)
        {
            if (DesignMode) return;

            Cursor origCursor = this.Cursor;

            try
            {
                this.Cursor = Cursors.WaitCursor;

                tree.LoadTemplates(templateMenu, subTemplateMenu, Settings);
            }
            finally
            {
                this.Cursor = origCursor;
            }
        }

        private void DisplayTemplateForEdit()
        {
            try
            {
                if (this.tree.SelectedNode != null)
                {
                    Template t = this.tree.SelectedNode.Tag as Template;

                    if (t != null)
                    {
                        System.Diagnostics.Process.Start(t.Header.FullFileName);
                    }
                }
            }
            catch
            {
                // If they don't have the ".est" extension mapped we'll just launch 
                // it in Notepad.exe (boring)
                try
                {
                    if (this.tree.SelectedNode != null)
                    {
                        Template t = this.tree.SelectedNode.Tag as Template;
                        System.Diagnostics.Process.Start("notepad.exe", t.Header.FullFileName);
                    }
                }
                catch { }
            }
        }

        private void DisplayTemplateUI(bool useCachedInput)
        {
            Cursor origCursor = this.Cursor;
            try
            {
                this.Cursor = Cursors.WaitCursor;

                this.MainWindow.HideErrorOrStatusMessage();

                Template template = this.tree.SelectedNode.Tag as Template;
                this.templateDisplaySurface.DisplayTemplateUI(useCachedInput, null, this.Settings, template, OnExecute, OnCancel);
            }
            catch (Exception ex)
            {
                this.MainWindow.ShowError(ex);
            }
            finally
            {
                this.Cursor = origCursor;
            }
        }

        private bool OnExecute(TemplateDisplaySurface surface)
        {
            try
            {
                if (surface.GatherUserInput())
                {
                    Template temp = new Template();
                    temp.Execute(surface.esMeta, surface.Template.Header.FullFileName);

                    surface.CacheUserInput();

                    this.MainWindow.ShowStatusMessage("Template '" + surface.Template.Header.Title + "' generated successfully.");
                }
                else return false;
            }
            catch (Exception ex)
            {
                this.MainWindow.ShowError(ex);
                return false;
            }

            return true;
        }

        private void OnCancel(TemplateDisplaySurface surface)
        {

        }

        public override void OnSettingsChanged()
        {
            try
            {
                TemplateDisplaySurface.ClearCachedSettings();

                Template.SetTemplateCachePath(esSettings.TemplateCachePath);
                Template.SetCompilerAssemblyPath(Settings.CompilerAssemblyPath);

                tree.LoadTemplates(templateMenu, subTemplateMenu, Settings);
            }
            catch { }
        }

        private void ButtonRefresh_Click(object sender, EventArgs e)
        {
            tree.LoadTemplates(templateMenu, subTemplateMenu, Settings);
        }

        private void ButtonExecute_Click(object sender, EventArgs e)
        {
            DisplayTemplateUI(false);
        }

        private void ButtonExecuteCache_Click(object sender, EventArgs e)
        {
            DisplayTemplateUI(true);
        }

        private void tree_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            try
            {
                if (e.Node != null)
                {
                    Template template = e.Node.Tag as Template;

                    if (template != null)
                    {
                        this.ButtonExecute.Enabled = !template.Header.IsSubTemplate;
                        this.ButtonExecuteCache.Enabled = !template.Header.IsSubTemplate;
                        this.ButtonRecordProject.Enabled = !template.Header.IsSubTemplate;
                        this.ButtonViewTemplate.Enabled = true;
                        return;
                    }
                }

                this.ButtonExecute.Enabled = false;
                this.ButtonExecuteCache.Enabled = false;
                this.ButtonRecordProject.Enabled = false;
                this.ButtonViewTemplate.Enabled = false;
            }
            catch { }
        }

        private void tree_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            try
            {
                if (e.Node != null)
                {
                    Template template = e.Node.Tag as Template;

                    if (template != null)
                    {
                        if (template.Header.IsSubTemplate)
                        {
                            DisplayTemplateForEdit();
                            return;
                        }

                        switch (this.Settings.DefaultTemplateDoubleClickAction)
                        {
                            case "Edit":
                                DisplayTemplateForEdit();
                                break;

                            case "Execute":
                                DisplayTemplateUI(false);
                                break;

                            case "ExecuteWithLastSettings":
                                DisplayTemplateUI(true);
                                break;

                            default:
                                DisplayTemplateUI(false);
                                break;
                        }
                    }
                }
            }
            catch { }
        }

        private void ButtonViewTemplate_Click(object sender, EventArgs e)
        {
            DisplayTemplateForEdit();
        }

        private void ButtonOpenFolder_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process p = new System.Diagnostics.Process();
                p.StartInfo.FileName = "explorer";
                p.StartInfo.Arguments = "/e," + Settings.OutputPath;
                p.StartInfo.UseShellExecute = true;
                p.Start();
            }
            catch { }
        }
    }
}
