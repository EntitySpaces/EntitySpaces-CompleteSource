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
using System.IO;
using System.Reflection;
using System.Windows.Forms;

using EntitySpaces.AddIn.TemplateUI;


namespace EntitySpaces.AddIn
{
    internal class TemplateUICollection
    {
        private List<esTemplateInfo> templateUserInterfaces = new List<esTemplateInfo>();
        private bool isLoaded = false;

        public TemplateUICollection()
        {

        }

        public void Clear()
        {
            this.templateUserInterfaces.Clear();
            isLoaded = false;
        }

        public bool IsLoaded
        {
            get
            {
                return this.isLoaded;
            }
        }

        public SortedList<int, esTemplateInfo> GetTemplateUI(Guid userInterfaceID)
        {
            SortedList<int, esTemplateInfo> list = new SortedList<int, esTemplateInfo>();

            foreach (esTemplateInfo info in templateUserInterfaces)
            {
                if (info.UserInterfaceId == userInterfaceID)
                {
                    list.Add(info.TabOrder, info);
                }
            }

            return list;
        }

        public void RegisterAssemblies(string path)
        {
            isLoaded = true;

            string[] assemblies = Directory.GetFiles(path, "*.dll");

            foreach (string assemblyName in assemblies)
            {
                Assembly assembly = Assembly.LoadFile(assemblyName);

                Type[] types = assembly.GetExportedTypes();

                foreach (Type type in types)
                {
                    if (type.IsSubclassOf(typeof(UserControl)))
                    {
                        UserControl userControl = Activator.CreateInstance(type) as UserControl;

                        ITemplateUI templateUI = userControl as ITemplateUI;

                        if (templateUI != null)
                        {
                            esTemplateInfo templateInfo = templateUI.Init();

                            if (templateInfo != null)
                            {
                                templateUserInterfaces.Add(templateInfo);
                            }
                        }
                    }
                }
            }
        }
    }
}
