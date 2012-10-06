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
using Microsoft.Win32;

namespace AddInInstaller
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\EntitySpaces 2012", false);
                if (key != null)
                {
                    string basePath = (string)key.GetValue("Install_Dir");

                    if (!basePath.EndsWith(@"\"))
                    {
                        basePath += @"\";
                    }

                    string source = basePath + @"CodeGeneration\Bin\EntitySpaces2012.AddIn";

                    string dest = System.Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);

                    string text = "";

                    using (TextReader reader = new StreamReader(source))
                    {
                        text = reader.ReadToEnd();
                    }

                    text = text.Replace("[PATH]", basePath);

                    string dir = dest + @"\Microsoft\MSEnvShared\AddIns\";

                    if (!Directory.Exists(dir))
                    {
                        Directory.CreateDirectory(dir);
                    }

                    dest += @"\Microsoft\MSEnvShared\AddIns\EntitySpaces2012.AddIn";
                    using (StreamWriter writer = new StreamWriter(dest, false, Encoding.BigEndianUnicode))
                    {
                        writer.Write(text);
                    }

                    using (StreamWriter writer = new StreamWriter(source, false, Encoding.BigEndianUnicode))
                    {
                        writer.Write(text);
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.Read();
            }
        }
    }
}
