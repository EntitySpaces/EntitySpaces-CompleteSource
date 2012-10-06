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

using EntitySpaces.MetadataEngine;
using EntitySpaces.CodeGenerator;
using EntitySpaces.Common;

namespace EntitySpaces.CommandLine
{
    class Program
    {
        static int Main(string[] args)
        {
            List<Exception> errors = new List<Exception>();

            bool silentMode = false;

            try
            {
                if (args == null || args.Length == 0 || args[0] == "/?")
                {
                    Console.WriteLine();
                    Console.WriteLine("Usage: EntitySpaces.CommandLine {project file} {project node} /S");
                    Console.WriteLine();
                    Console.ReadKey();
                    return 0;
                }

                string projectName = null;
                string projectNode = null;

                #region Parse Arguments

                // I feel lazy, so I'm doing this the poor mans way
                if (args.Length == 1) projectName = args[0];

                if (args.Length == 2)
                {
                    projectName = args[0];

                    if (args[1] == "/s" || args[1] == "/S")
                    {
                        silentMode = true;
                    }
                    else
                    {
                        projectNode = args[1];
                    }
                }

                if (args.Length == 3)
                {
                    projectName = args[0];
                    projectNode = args[1];

                    if (args[2] == "/s" || args[2] == "/S")
                    {
                        silentMode = true;
                    }
                }

                #endregion Arguments

                if (projectName != null)
                {
                    esSettings settings = esSettings.Load();

                    Template.SetTemplateCachePath(esSettings.TemplateCachePath);
                    Template.SetCompilerAssemblyPath(settings.CompilerAssemblyPath);

                    ProjectExecuter exe = new ProjectExecuter(projectName, settings);
                    List<Exception> moreErrors = exe.ExecuteFromNode(projectNode);

                    if (moreErrors.Count > 0)
                    {
                        errors.AddRange(moreErrors);
                    }
                }
            }
            catch (Exception ex)
            {
                errors.Add(ex);
            }

            if (!silentMode && errors.Count > 0)
            {
                Console.WriteLine();

                foreach (Exception ex in errors)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine();
                }

                Console.ReadKey();
            }

            return errors.Count == 0 ? 0 : 1;
        }
    }
}
