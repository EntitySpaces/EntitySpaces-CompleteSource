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
    public partial class GeneratedMaster_Advanced : UserControl, ITemplateUI
    {
        private Root esMeta;
        private bool UseCachedSettings;
        private object applicationObject;

        public GeneratedMaster_Advanced()
        {
            InitializeComponent();
        }

        #region ITemplateUI Members

        esTemplateInfo ITemplateUI.Init()
        {
            esTemplateInfo info = new esTemplateInfo();
            info.UserInterface = this;
            info.UserInterfaceId = new Guid("2216AB4F-BDB4-47de-8412-8560C1F2F420");
            info.TabTitle = "Advanced";
            info.TabOrder = 1;
            return info;
        }

        UserControl ITemplateUI.CreateInstance(Root esMeta, bool cachedSettings, object applicationObject)
        {
            GeneratedMaster_Advanced window = new GeneratedMaster_Advanced();
            window.esMeta = esMeta;
            window.applicationObject = applicationObject;
            window.UseCachedSettings = cachedSettings;

            return window;
        }

        bool ITemplateUI.OnExecute()
        {
            try
            {
                esMeta.Input["GenerateSingleFile"] = chkSingleFile.Checked;
                esMeta.Input["UseCustomBaseClass"] = chkUseCustomBase.Checked;
                esMeta.Input["TargetMultipleDatabases"] = chkProvIndependent.Checked;
                esMeta.Input["MetadataClassShouldIgnoreSchema"] = chkIgnoreSchema.Checked;
                esMeta.Input["MetadataClassShouldIgnoreCatalog"] = chkIgnoreCatalog.Checked;
                esMeta.Input["GenerateHierarchicalModel"] = chkHierarchical.Checked;
                esMeta.Input["GenerateHierarchicalModelSelectedTablesOnly"] = chkHierarchicalSelectedOnly.Checked;
                esMeta.Input["GenerateHierarchicalRiaServicesSupport"] = chkRiaServicesSupport.Checked;
                esMeta.Input["GenerateHierarchicalDataContracts"] = chkHierarchicalDataContractSupport.Checked;
                esMeta.Input["TargetTheCompactFramework"] = chkCompactFramework.Checked;
                esMeta.Input["SupportINotifyChanged"] = chkINotifyPropertyChanged.Checked;
                esMeta.Input["GenerateStrProperties"] = chkGenerateStrProperties.Checked;
                esMeta.Input["UseDnnObjectQualifier"] = chkUseDNNObjectQualifier.Checked;
                esMeta.Input["LINQtoSQL"] = chkLINQtoSQL.Checked;
                esMeta.Input["SerializableQueries"] = chkSerializableQueries.Checked;
                esMeta.Input["DebuggerDisplay"] = chkDebuggerDisplay.Checked;
                esMeta.Input["DebugVisualizer"] = chkDebugVisualizer.Checked;
            }
            catch { }

            return true;
        }

        void ITemplateUI.OnCancel()
        {

        }

        #endregion

        private void GeneratedMaster_Advanced_Load(object sender, EventArgs e)
        {
            try
            {
                if (!UseCachedSettings) return;

                if (esMeta.Input.ContainsKey("GenerateSingleFile"))
                {
                    chkSingleFile.Checked = (bool)esMeta.Input["GenerateSingleFile"];
                }

                if (esMeta.Input.ContainsKey("UseCustomBaseClass"))
                {
                    chkUseCustomBase.Checked = (bool)esMeta.Input["UseCustomBaseClass"];
                }

                if (esMeta.Input.ContainsKey("TargetMultipleDatabases"))
                {
                    chkProvIndependent.Checked = (bool)esMeta.Input["TargetMultipleDatabases"];
                }

                if (esMeta.Input.ContainsKey("MetadataClassShouldIgnoreSchema"))
                {
                    chkIgnoreSchema.Checked = (bool)esMeta.Input["MetadataClassShouldIgnoreSchema"];
                }

                if (esMeta.Input.ContainsKey("MetadataClassShouldIgnoreCatalog"))
                {
                    chkIgnoreCatalog.Checked = (bool)esMeta.Input["MetadataClassShouldIgnoreCatalog"];
                }

                if (esMeta.Input.ContainsKey("GenerateHierarchicalModel"))
                {
                    chkHierarchical.Checked = (bool)esMeta.Input["GenerateHierarchicalModel"];
                }

                if (esMeta.Input.ContainsKey("GenerateHierarchicalModelSelectedTablesOnly"))
                {
                    chkHierarchicalSelectedOnly.Checked = (bool)esMeta.Input["GenerateHierarchicalModelSelectedTablesOnly"];
                }

                if (esMeta.Input.ContainsKey("GenerateHierarchicalRiaServicesSupport"))
                {
                    chkRiaServicesSupport.Checked = (bool)esMeta.Input["GenerateHierarchicalRiaServicesSupport"];
                }

                if (esMeta.Input.ContainsKey("GenerateHierarchicalDataContracts"))
                {
                    chkHierarchicalDataContractSupport.Checked = (bool)esMeta.Input["GenerateHierarchicalDataContracts"];
                }

                if (esMeta.Input.ContainsKey("TargetTheCompactFramework"))
                {
                    chkCompactFramework.Checked = (bool)esMeta.Input["TargetTheCompactFramework"];
                }

                if (esMeta.Input.ContainsKey("SupportINotifyChanged"))
                {
                    chkINotifyPropertyChanged.Checked = (bool)esMeta.Input["SupportINotifyChanged"];
                }

                if (esMeta.Input.ContainsKey("GenerateStrProperties"))
                {
                    chkGenerateStrProperties.Checked = (bool)esMeta.Input["GenerateStrProperties"];
                }

                if (esMeta.Input.ContainsKey("UseDnnObjectQualifier"))
                {
                    chkUseDNNObjectQualifier.Checked = (bool)esMeta.Input["UseDnnObjectQualifier"];
                }

                if (esMeta.Input.ContainsKey("LINQtoSQL"))
                {
                    chkLINQtoSQL.Checked = (bool)esMeta.Input["LINQtoSQL"];
                }

                if (esMeta.Input.ContainsKey("LINQtoSQL"))
                {
                    chkSerializableQueries.Checked = (bool)esMeta.Input["SerializableQueries"];
                }

                if (esMeta.Input.ContainsKey("DebuggerDisplay"))
                {
                    chkDebuggerDisplay.Checked = (bool)esMeta.Input["DebuggerDisplay"];
                }

                if (esMeta.Input.ContainsKey("DebugVisualizer"))
                {
                    chkDebugVisualizer.Checked = (bool)esMeta.Input["DebugVisualizer"];
                }
            }
            catch { }
        }

        private void chkCompactFramework_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCompactFramework.Checked)
            {
                chkDebuggerDisplay.Checked = false;
                chkDebugVisualizer.Checked = false;

                chkDebuggerDisplay.Enabled = false;
                chkDebugVisualizer.Enabled = false;
            }
            else
            {
                chkDebuggerDisplay.Enabled = true;
                chkDebugVisualizer.Enabled = true;
            }
        }

        private void chkHierarchical_CheckedChanged(object sender, EventArgs e)
        {
            chkHierarchicalSelectedOnly.Enabled = chkHierarchical.Checked;
            chkRiaServicesSupport.Enabled = chkHierarchical.Checked;
            chkHierarchicalDataContractSupport.Enabled = chkHierarchical.Checked;
        }
    }
}