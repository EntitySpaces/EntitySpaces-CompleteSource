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
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using System.Net;
using System.IO;
using System.Management;

using Microsoft.Win32;

using EntitySpaces;
using EntitySpaces.Common;
using EntitySpaces.CodeGenerator;
using EntitySpaces.MetadataEngine;

using EntitySpaces.AddIn;

namespace EntitySpaces.AddIn.ES2012
{
    public partial class MainWindow : UserControl
    {
        private object applicationObject;
        private List<esUserControl> userControlCollection = new List<esUserControl>();
        private esSettings settings = new esSettings();
        internal string esVersion = "2012.1.0930.0";

        internal OnTemplateExecute OnTemplateExecuteCallback;
        internal OnTemplateCancel OnTemplateCancelCallback;
        internal TemplateDisplaySurface CurrentTemplateDisplaySurface;

        public MainWindow()
        {
            InitializeComponent();

            NotAConstructor();
        }

        internal void NotAConstructor()
        {
            try
            {
                if (!this.DesignMode)
                {
                    TemplateDisplaySurface.Initialize(this);

                    this.Settings = esSettings.Load();
                    esPlugIn plugin = new esPlugIn(settings);

                    this.ucSettings.Settings = this.Settings;

                    userControlCollection.Add(ucProjects);
                    userControlCollection.Add(ucTemplates);
                    userControlCollection.Add(ucMetadata);
                    userControlCollection.Add(ucMappings);

                    this.ucProjects.MainWindow = this;
                    this.ucTemplates.MainWindow = this;
                    this.ucMetadata.MainWindow = this;
                    this.ucMappings.MainWindow = this;
                }
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
            finally
            {
                userControlCollection.Add(ucSettings);
                this.ucSettings.MainWindow = this;
            }
        }

        public object ApplicationObject
        {
            get { return applicationObject; }
            set { applicationObject = value; }
        }

        public esSettings Settings
        {
            get { return settings; }
            set 
            { 
                settings = value; 
            }
        }

        public void NofityControlsThatSettingsChanged()
        {
            try
            {
                Root.UnLoadPlugins();

                foreach (esUserControl control in this.userControlCollection)
                {
                    control.OnSettingsChanged();
                }
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        public void ShowError(Exception ex)
        {
            try
            {
                string errorText = string.Empty;
                string callStack = string.Empty;

                CompilerException cex = ex as CompilerException;

                if (cex != null)
                {
                    foreach (CompilerError error in cex.Results.Errors)
                    {
                        errorText += "Error Found in " + cex.Template.Header.FullFileName + " on line " +
                            cex.Template.TemplateLineFromErrorLine(error.Line) +
                            Environment.NewLine + error.ErrorText + Environment.NewLine + Environment.NewLine;
                    }
                }
                else
                {
                    Exception rootCause = ex;

                    while (rootCause.InnerException != null)
                    {
                        if (rootCause.Equals(ex.InnerException)) break;

                        rootCause = ex.InnerException;
                    }

                    errorText = rootCause.Message;
                }

                this.splitContainer.Panel2Collapsed = false;
                this.pictureBoxError.Image = Resource.error;
                this.textBoxError.Text = errorText;
                this.textBoxError.Text += Environment.NewLine + Environment.NewLine;
                this.textBoxError.Text += ex.StackTrace;
                this.textBoxError.ScrollToCaret();
            }
            catch (Exception exx)
            {
                this.ShowError(exx);
            }
        }

        public void HideErrorOrStatusMessage()
        {
            try
            {
                this.splitContainer.Panel2Collapsed = true;
                this.textBoxError.Text = string.Empty;
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        public void ShowStatusMessage(string message)
        {
            this.splitContainer.Panel2Collapsed = false;
            this.pictureBoxError.Image = Resource.info;

            this.textBoxError.Text = message;
            this.textBoxError.Text += Environment.NewLine + Environment.NewLine;
            this.textBoxError.ScrollToCaret();
        }

        public void ShowTemplateUIControl()
        {
            try
            {
                this.splitContainerTabControl.Panel1Collapsed = true;
                this.splitContainerTabControl.Panel2Collapsed = false;
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        private void buttonExecuteTemplateOk_Click(object sender, EventArgs e)
        {
            Cursor origCursor = this.Cursor;

            try
            {
                if (this.OnTemplateExecuteCallback == null) return;

                this.HideErrorOrStatusMessage();

                this.Cursor = Cursors.WaitCursor;

                if (this.OnTemplateExecuteCallback(this.CurrentTemplateDisplaySurface))
                {
                    this.tabControlTemplateUI.TabPages.Clear();

                    this.splitContainerTabControl.Panel1Collapsed = false;
                    this.splitContainerTabControl.Panel2Collapsed = true;

                    OnTemplateExecuteCallback = null;
                    OnTemplateCancelCallback = null;
                    CurrentTemplateDisplaySurface = null;
                }
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
            finally
            {
                this.Cursor = origCursor;
            }
        }

        private void buttonExecuteTemplateCancel_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.OnTemplateExecuteCallback == null) return;

                this.OnTemplateCancelCallback(this.CurrentTemplateDisplaySurface);

                this.HideErrorOrStatusMessage();

                this.tabControlTemplateUI.TabPages.Clear();

                this.splitContainerTabControl.Panel1Collapsed = false;
                this.splitContainerTabControl.Panel2Collapsed = true;
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
            finally
            {
                OnTemplateExecuteCallback = null;
                OnTemplateCancelCallback = null;
                CurrentTemplateDisplaySurface = null;
            }
        }

        private void pictureBoxError_Click(object sender, EventArgs e)
        {
            try
            {
                this.splitContainer.Panel2Collapsed = true;
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        private void TabPage_Enter(object sender, EventArgs e)
        {
            try
            {
                this.HideErrorOrStatusMessage();

                TabPage tabPage = sender as TabPage;

                if (tabPage.Name != "Projects")
                {
                    this.ucProjects.PromptForSave();
                }
            }
            catch { }
        }
    }
}
