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
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

using Microsoft.Win32;

namespace EntitySpaces.MetadataEngine
{
    public interface ISettings
    {
        void AdjustPathsForTravelMode(Module executingAssembly);
        esSettings Clone();
        string DriverName(string driver);

        void Save();
        void Save(string pathAndFileName);
        void Save(XmlTextWriter xwriter);

        // Properties
        string AbstractPrefix { get; set; }
        string CollectionSuffix { get; set; }
        string CompilerAssemblyPath { get; set; }
        string ConnectionString { get; set; }
        string DefaultTemplateDoubleClickAction { get; set; }
        string Driver { get; set; }
        string EntitySuffix { get; set; }
        string InstallPath { get; }
        string LanguageMappingFile { get; set; }
        string LicenseProxyDomainName { get; set; }
        bool LicenseProxyEnable { get; set; }
        string LicenseProxyPassword { get; set; }
        string LicenseProxyUrl { get; set; }
        string LicenseProxyUserName { get; set; }
        string ManyPrefix { get; set; }
        string ManySeparator { get; set; }
        string ManySuffix { get; set; }
        string MetadataSuffix { get; set; }
        string OnePrefix { get; set; }
        string OneSeparator { get; set; }
        string OneSuffix { get; set; }
        string OutputPath { get; set; }
        bool PrefixWithSchema { get; set; }
        bool PreserveUnderscores { get; set; }
        string ProcDelete { get; set; }
        string ProcInsert { get; set; }
        string ProcLoadAll { get; set; }
        string ProcLoadByPK { get; set; }
        string ProcPrefix { get; set; }
        string ProcSuffix { get; set; }
        string ProcUpdate { get; set; }
        bool ProcVerbFirst { get; set; }
        string ProxyStubSuffix { get; set; }
        string QuerySuffix { get; set; }
        bool SelfOnly { get; set; }
        bool SwapNames { get; set; }
        string TemplatePath { get; set; }
        bool TurnOffDateTimeInClassHeaders { get; set; }
        string UIAssemblyPath { get; set; }
        bool UseAssociativeName { get; set; }
        bool UseNullableTypesAlways { get; set; }
        bool UseRawNames { get; set; }
        string UserMetadataFile { get; set; }
        bool UseUpToPrefix { get; set; }
    }
}
