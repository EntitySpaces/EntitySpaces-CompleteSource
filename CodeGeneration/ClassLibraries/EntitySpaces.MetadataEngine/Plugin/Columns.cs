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
using System.Data;
using System.Collections;
using System.Data.OleDb;

namespace EntitySpaces.MetadataEngine.Plugin
{
	public class PluginColumns : Columns
	{
        private IPlugin plugin;

		#region DataColumn Binding Stuff

		// Added for 3rd party providers
		internal DataColumn f_extTypeName	      = null;	
		internal DataColumn f_extTypeNameComplete = null;

		private void BindToColumns(DataTable metaData)
		{
			if(false == _fieldsBound)
			{
				if(metaData.Columns.Contains("TYPE_NAME"))
					f_extTypeName = metaData.Columns["TYPE_NAME"];

				if(metaData.Columns.Contains("TYPE_NAME_COMPLETE"))
					f_extTypeNameComplete = metaData.Columns["TYPE_NAME_COMPLETE"];
			}																		
		}
		#endregion

        public PluginColumns(IPlugin plugin)
        {
            this.plugin = plugin;
        }

		override internal void LoadForTable()
        {
            DataTable metaData = this.plugin.GetTableColumns(this.Table.Database.Name, this.Table.Name);
			BindToColumns(metaData);
            PopulateArray(metaData);
	    }

		override internal void LoadForView()
        {
            DataTable metaData = this.plugin.GetViewColumns(this.View.Database.Name, this.View.Name);
			BindToColumns(metaData);
            PopulateArray(metaData);
		}
	}
}
