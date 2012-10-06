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

namespace EntitySpaces.CodeGenerator
{
    public class TemplateHeader
    {
        public TemplateHeader()
        {

        }

        public string ToComment()
        {
            StringBuilder sb = new StringBuilder(300);

            sb.AppendLine(@"// Title:        " + this.Title);
            sb.AppendLine(@"// Description:  " + this.Description);
            sb.AppendLine(@"// Author:       " + this.Author);
            sb.AppendLine(@"// Version:      " + this.Version);
            sb.AppendLine(@"// Namespace:    " + this.Namespace);
            sb.AppendLine(@"// FullFileName: " + this.FullFileName);
            sb.AppendLine(@"// Compile Date: " + DateTime.Now.ToString());
            sb.AppendLine("");

            return sb.ToString();
        }

        /// <summary>
        /// The UniqueID of the current template.
        /// </summary>
        public Guid UniqueID = Guid.Empty;

        /// <summary>
        /// The Guid to match to the UI AddIn
        /// </summary>
        public Guid UserInterfaceID = Guid.Empty;

        /// <summary>
        /// The UniqueID of the current template.
        /// </summary>
        public string Namespace = String.Empty;

        /// <summary>
        /// The Author of the current template.
        /// </summary>
        public string Author = String.Empty;

        /// <summary>
        /// The Title of the current template.
        /// </summary>
        public string Title = String.Empty;

        /// <summary>
        /// The Description of the current template.
        /// </summary>
        public string Description = String.Empty;

        /// <summary>
        /// The file path of the current template.
        /// </summary>
        public string FilePath = String.Empty;

        /// <summary>
        /// The file name of the current template
        /// </summary>
        public string FileName = String.Empty;

        /// <summary>
        /// The file name and path of the current template
        /// </summary>
        public string FullFileName = String.Empty;

        /// <summary>
        /// The Version of the current template
        /// </summary>
        public string Version = String.Empty;

        /// <summary>
        /// Whether or not the template requires a UI to be excuted
        /// </summary>
        public bool RequiresUI = false;

        /// <summary>
        /// Whether or not the template is a sub template
        /// </summary>
        public bool IsSubTemplate = false;
    }
}
