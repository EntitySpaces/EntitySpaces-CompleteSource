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
using EntitySpaces.Common;
using EntitySpaces.MetadataEngine;

using EntitySpaces.AddIn.ES2012;

namespace EntitySpaces.AddIn
{
    internal delegate bool OnTemplateExecute(TemplateDisplaySurface surface);
    internal delegate void OnTemplateCancel(TemplateDisplaySurface surface);

    internal class TemplateDisplaySurface
    {
        static private TemplateUICollection coll = new TemplateUICollection();
        static private MainWindow MainWindow;

        static public Dictionary<Guid, Hashtable> CachedInput = new Dictionary<Guid, Hashtable>();
        public SortedList<int, UserControl> CurrentUIControls = new SortedList<int, UserControl>();
        public Root esMeta = null;
        public Template Template;


        static internal void Initialize(MainWindow mainWindow)
        {
            TemplateDisplaySurface.MainWindow = mainWindow;
        }

        internal TemplateDisplaySurface()
        {

        }

        public void DisplayTemplateUI
        (
            bool useCachedInput, 
            Hashtable input,
            esSettings settings,
            Template template, 
            OnTemplateExecute OnExecuteCallback, 
            OnTemplateCancel OnCancelCallback
        )
        {
            try
            {
                this.Template = template;

                TemplateDisplaySurface.MainWindow.OnTemplateExecuteCallback = OnExecuteCallback;
                TemplateDisplaySurface.MainWindow.OnTemplateCancelCallback = OnCancelCallback;
                TemplateDisplaySurface.MainWindow.CurrentTemplateDisplaySurface = this;

                if (template != null)
                {
                    CurrentUIControls.Clear();
                    PopulateTemplateInfoCollection();

                    SortedList<int, esTemplateInfo> templateInfoCollection = coll.GetTemplateUI(template.Header.UserInterfaceID);

                    if (templateInfoCollection == null || templateInfoCollection.Count == 0)
                    {
                        MainWindow.ShowError(new Exception("Template UI Assembly Cannot Be Located"));
                    }

                    this.esMeta = esMetaCreator.Create(settings);

                    esMeta.Input["OutputPath"] = settings.OutputPath;

                    if (useCachedInput)
                    {
                        if (CachedInput.ContainsKey(template.Header.UniqueID))
                        {
                            Hashtable cachedInput = CachedInput[template.Header.UniqueID];

                            if (cachedInput != null)
                            {
                                foreach (string key in cachedInput.Keys)
                                {
                                    esMeta.Input[key] = cachedInput[key];
                                }
                            }
                        }
                    }

                    if (input != null)
                    {
                        esMeta.Input = input;
                    }

                    MainWindow.tabControlTemplateUI.SuspendLayout();

                    foreach (esTemplateInfo info in templateInfoCollection.Values)
                    {
                        UserControl userControl = info.UserInterface.CreateInstance(esMeta, useCachedInput, MainWindow.ApplicationObject);
                        CurrentUIControls.Add(info.TabOrder, userControl);

                        TabPage page = new TabPage(info.TabTitle);
                        page.Controls.Add(userControl);

                        userControl.Dock = DockStyle.Fill;

                        MainWindow.tabControlTemplateUI.TabPages.Add(page);

                        MainWindow.ShowTemplateUIControl();
                    }

                    MainWindow.tabControlTemplateUI.ResumeLayout();

                    if (CurrentUIControls.Count > 0)
                    {
                        MainWindow.ShowTemplateUIControl();
                    }
                }
            }
            catch (Exception ex)
            {
                MainWindow.ShowError(ex);
            }
        }

        private void PopulateTemplateInfoCollection()
        {
            try
            {
                if (!coll.IsLoaded)
                {
                    coll.RegisterAssemblies(TemplateDisplaySurface.MainWindow.Settings.UIAssemblyPath);
                }
            }
            catch (Exception ex)
            {
                MainWindow.ShowError(ex);
            }
        }

        public bool GatherUserInput()
        {
            try
            {
                foreach (UserControl userControl in this.CurrentUIControls.Values)
                {
                    ITemplateUI templateUI = userControl as ITemplateUI;

                    if (!templateUI.OnExecute())
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                MainWindow.ShowError(ex);
            }

            return true;
        }

        public Hashtable CacheUserInput()
        {
            Hashtable settings = (Hashtable)esMeta.Input.Clone();
            CachedInput[Template.Header.UniqueID] = settings;
            return settings;
        }

        static public void ClearCachedSettings()
        {
            CachedInput = new Dictionary<Guid, Hashtable>();
        }
    }
}
