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
    public partial class EntitySpaces_js_Advanced : UserControl, ITemplateUI
    {
        private Root esMeta;
        private bool UseCachedSettings;
        private object applicationObject;

        public EntitySpaces_js_Advanced()
        {
            InitializeComponent();
        }

        #region ITemplateUI Members

        esTemplateInfo ITemplateUI.Init()
        {
            esTemplateInfo info = new esTemplateInfo();
            info.UserInterface = this;
            info.UserInterfaceId = new Guid("491990CE-9355-46c8-93FC-E2EC8956BC41");
            info.TabTitle = "Advanced";
            info.TabOrder = 1;
            return info;
        }

        UserControl ITemplateUI.CreateInstance(Root esMeta, bool cachedSettings, object applicationObject)
        {
            EntitySpaces_js_Advanced window = new EntitySpaces_js_Advanced();
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
                esMeta.Input["GenerateHierarchicalModel"] = chkHierarchical.Checked;

                if (chkHierarchical.Checked)
                {
                    esMeta.Input["GenerateHierarchicalModelSelectedTablesOnly"] = chkHierarchicalSelectedOnly.Checked;
                    esMeta.Input["GenerateHierarchicalLazyLoadSupport"] = chkHierarchicalLazyLoad.Checked;
                }
                else
                {
                    esMeta.Input["GenerateHierarchicalModelSelectedTablesOnly"] = false;
                    esMeta.Input["GenerateHierarchicalLazyLoadSupport"] = false;
                }

                esMeta.Input["GenerateRestAPI"] = chkRestAPI.Checked;
                esMeta.Input["ServicePath"] = txtServicePath.Text;
            }
            catch { }

            return true;
        }

        void ITemplateUI.OnCancel()
        {

        }

        #endregion

        private void EntitySpaces_js_Advanced_Load(object sender, EventArgs e)
        {
            try
            {
                if (!UseCachedSettings) return;

                if (esMeta.Input.ContainsKey("GenerateSingleFile"))
                {
                    chkSingleFile.Checked = (bool)esMeta.Input["GenerateSingleFile"];
                }

                if (esMeta.Input.ContainsKey("GenerateHierarchicalModel"))
                {
                    chkHierarchical.Checked = (bool)esMeta.Input["GenerateHierarchicalModel"];
                }

                if (esMeta.Input.ContainsKey("GenerateHierarchicalModelSelectedTablesOnly"))
                {
                    chkHierarchicalSelectedOnly.Checked = (bool)esMeta.Input["GenerateHierarchicalModelSelectedTablesOnly"];
                }

                if (esMeta.Input.ContainsKey("GenerateHierarchicalLazyLoadSupport"))
                {
                    chkHierarchicalLazyLoad.Checked = (bool)esMeta.Input["GenerateHierarchicalLazyLoadSupport"];
                }

                if (esMeta.Input.ContainsKey("GenerateRestAPI"))
                {
                    chkRestAPI.Checked = (bool)esMeta.Input["GenerateRestAPI"];
                }

                if (esMeta.Input.ContainsKey("ServicePath"))
                {
                    txtServicePath.Text = (string)esMeta.Input["ServicePath"];
                }
            }
            catch { }
        }

        private void chkHierarchical_CheckedChanged(object sender, EventArgs e)
        {
            chkHierarchicalSelectedOnly.Enabled = chkHierarchical.Checked;
            chkHierarchicalLazyLoad.Enabled = chkHierarchical.Checked;
        }
    }
}