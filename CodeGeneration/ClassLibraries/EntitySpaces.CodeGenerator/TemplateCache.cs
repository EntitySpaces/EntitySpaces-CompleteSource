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
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.CodeDom.Compiler;
using System.Reflection;

namespace EntitySpaces.CodeGenerator
{
    internal class TemplateCache
    {
        internal static CachedTemplate GetCachedTemplate(string templateName, CompileAction action)
        {
            if (_cache.Count == 0)
            {
                CleanupOldTemplates();
            }

            CachedTemplate cachedTemplate = null;

            if (_cache.ContainsKey(templateName))
            {
                cachedTemplate = _cache[templateName];

                DateTime lastUpdate = File.GetLastWriteTime(templateName);

                // Has the file changed since we last cached it?
                if (lastUpdate > cachedTemplate.CompileTime)
                {
                    // Update it
                    cachedTemplate.CodeBuilder = Parser.ParseMarkup(templateName);

                    cachedTemplate.CompiledAssembly = null;
                    cachedTemplate.CompilerResults = null;
                }

                if (action == CompileAction.Compile && cachedTemplate.CompiledAssembly == null)
                {
                    cachedTemplate.CompilerResults = Compiler.Compile(cachedTemplate.CodeBuilder);

                    if (!cachedTemplate.CompilerResults.Errors.HasErrors)
                    {
                        cachedTemplate.CompiledAssembly = cachedTemplate.CompilerResults.CompiledAssembly;
                    }
                }

                cachedTemplate.CompileTime = DateTime.Now;
            }
            else
            {
                cachedTemplate = new CachedTemplate();
                cachedTemplate.Name = templateName;
                cachedTemplate.CodeBuilder = Parser.ParseMarkup(templateName);

                if (action == CompileAction.Compile)
                {
                    CompilerResults results = Compiler.Compile(cachedTemplate.CodeBuilder);
                    cachedTemplate.CompiledAssembly = results.CompiledAssembly;
                    cachedTemplate.CompilerResults = results;
                }

                cachedTemplate.CompileTime = DateTime.Now;
                _cache[templateName] = cachedTemplate;
            }

            return cachedTemplate;
        }

        internal static void CleanupOldTemplates()
        {
            FileInfo entryPath = new FileInfo(Compiler.TemplateCachePath);
            DirectoryInfo di = entryPath.Directory;
            FileInfo[] files = di.GetFiles("esCompiledTemplate_*.*");

            foreach (FileInfo f in files)
            {
                try
                {
                    f.Delete();
                }
                catch { }
            }
        }

        private static Dictionary<string, CachedTemplate> _cache = new Dictionary<string, CachedTemplate>();
    }

    internal class CachedTemplate
    {
        public string Name;
        public Assembly CompiledAssembly;
        public CodeBuilder CodeBuilder;
        public DateTime CompileTime;
        public CompilerResults CompilerResults;
    }

    internal enum CompileAction
    {
        ParseOnly = 0,
        Compile
    }
}

