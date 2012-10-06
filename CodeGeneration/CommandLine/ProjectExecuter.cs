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
using System.Linq;
using System.Text;

using EntitySpaces;
using EntitySpaces.MetadataEngine;
using EntitySpaces.CodeGenerator;
using EntitySpaces.Common;

namespace EntitySpaces.CommandLine
{
    internal class ProjectExecuter
    {
        private esProject project = null;
        private esSettings userSettings;
        private List<Exception> errors = new List<Exception>();

        private ProjectExecuter() 
        {
       
        }

        public ProjectExecuter(string projectFile, esSettings mainSettings)
        {
            userSettings = mainSettings;
            project = new esProject();
            project.Load(projectFile, userSettings);
        }

        public List<Exception> ExecuteFromNode(string nodeName)
        {
            try
            {
                esProjectNode startNode = project.RootNode;

                if (nodeName != null && startNode.Name != nodeName)
                {
                    string[] nodes = nodeName.Split(new char[] { '\\' });

                    if (startNode.Name != nodes[0])
                    {
                        throw new Exception("Node '" + nodes[0] + "' " + "Not Found in Project File");
                    }

                    for (int i = 1; i < nodes.Length; i++)
                    {
                        esProjectNode nextNode = null;
                        string node = nodes[i];

                        foreach (esProjectNode childNode in startNode.Children)
                        {
                            if (node == childNode.Name)
                            {
                                nextNode = childNode;
                                break;
                            }
                        }

                        if (nextNode == null)
                        {
                            throw new Exception("Node '" + node + "' " + "Not Found in Project File");
                        }

                        startNode = nextNode;
                    }
                }

                ExecuteRecordedTemplates(startNode);
            }
            catch(Exception ex)
            {
                errors.Add(ex);
            }

            return errors;
        }

        private void ExecuteRecordedTemplates(esProjectNode node)
        {
            try
            {
                ExecuteRecordedTemplate(node);

                foreach (esProjectNode childNode in node.Children)
                {
                    ExecuteRecordedTemplates(childNode);
                }
            }
            catch (Exception ex)
            {
                errors.Add(ex); 
            }
        }

        private void ExecuteRecordedTemplate(esProjectNode node)
        {
            try
            {
                if (node != null && !node.IsFolder)
                {
                    Root esMeta = Create(node.Settings as esSettings);
                    esMeta.Input = node.Input;

                    Template template = new Template();
                    template.Execute(esMeta, node.Template.Header.FullFileName);
                }
            }
            catch (Exception ex)
            {
                errors.Add(ex);
            }
        }

        internal Root Create(esSettings settings)
        {
            Root esMeta = new Root(settings);
            if (!esMeta.Connect(settings.Driver, settings.ConnectionString))
            {
                throw new Exception("Unable to Connect to Database: " + settings.Driver);
            }
            esMeta.Language = "C#";

            return esMeta;
        }
    }
}
