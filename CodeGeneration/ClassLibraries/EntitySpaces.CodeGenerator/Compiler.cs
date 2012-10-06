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
using System.Text;
using System.Reflection;
using System.CodeDom.Compiler;
using System.Collections.Generic;

namespace EntitySpaces.CodeGenerator
{
    /// <summary>
    /// This class Compiles a parsed template in the form of a CodeBuilder object and returns the compiler results.
    /// </summary>
    internal class Compiler
    {
        internal static string TemplateCachePath = string.Empty;
        internal static string CompilerAssemblyPath = string.Empty;

        /// <summary>
        /// Compiles a parsed template in the form of a CodeBuilder object and returns the compiler results.
        /// </summary>
        /// <param name="code">A parsed template in the form of a CodeBuilder object</param>
        /// <returns>The results of compilation.</returns>
        internal static CompilerResults Compile(CodeBuilder code)
        {
            CompilerResults results = null; 
            CodeDomProvider codeProvider = CodeDomProvider.CreateProvider("C#");
            CompilerParameters compilerParams = new CompilerParameters();
            compilerParams.CompilerOptions = "/target:library /optimize";

            string assembly = "";

            foreach (string reference in code.References)
            {
                assembly = CompilerAssemblyPath + reference + ".dll";

                if(File.Exists(assembly))
                    compilerParams.ReferencedAssemblies.Add(assembly);
                else
                    compilerParams.ReferencedAssemblies.Add(reference + ".dll");
            }

            if (code.CompileInMemory)
            {
                compilerParams.GenerateExecutable = false;
                compilerParams.IncludeDebugInformation = false;
                compilerParams.GenerateInMemory = true;

                results = codeProvider.CompileAssemblyFromSource(compilerParams, code.ToString());
            }
            else
            {
                string baseName = "esCompiledTemplate_" + Guid.NewGuid().ToString().Replace("-", "");
                string codeFileName = TemplateCachePath + baseName + ".cs";
                string assemblyName = TemplateCachePath + baseName + ".dll";
                File.WriteAllText(codeFileName, code.ToString());
                string[] files = new string[] { codeFileName };
                

                compilerParams.GenerateExecutable = false;
                compilerParams.IncludeDebugInformation = true;
                compilerParams.GenerateInMemory = false;
                compilerParams.OutputAssembly = assemblyName;
                

                results = codeProvider.CompileAssemblyFromFile(compilerParams, files);
            }

            return results;
        }
    }
}
