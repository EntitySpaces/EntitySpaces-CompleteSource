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
using System.Data;
using System.Data.OleDb;

namespace EntitySpaces.MetadataEngine.Plugin
{
	public class PluginResultColumns : ResultColumns
    {
        private IPlugin plugin;

        public PluginResultColumns(IPlugin plugin)
        {
            this.plugin = plugin;
		}

		override internal void LoadAll()
        {
            DataTable metaData = this.plugin.GetProcedureResultColumns(this.Procedure.Database.Name, this.Procedure.Name);
            this.PopulateArray(metaData);
		}

        #region DataColumn Binding Stuff

        internal DataColumn f_Name = null;
        internal DataColumn f_Ordinal = null;
        internal DataColumn f_DataType = null;
        internal DataColumn f_DataTypeName = null;
        internal DataColumn f_DataTypeNameComplete = null;


        private void BindToColumns(DataTable metaData)
        {
            if (false == _fieldsBound)
            {
                // Fix k3b 20070709: PluginResultColumns.BindToColumns and 
                //      MyMetaPluginContext.CreateResultColumnsDataTable
                //      ColumnNames were different
                if (metaData.Columns.Contains("COLUMN_NAME")) f_Name = metaData.Columns["COLUMN_NAME"];
                if (metaData.Columns.Contains("ORDINAL_POSITION")) f_Ordinal = metaData.Columns["ORDINAL_POSITION"];
                if (metaData.Columns.Contains("DATA_TYPE")) f_DataType = metaData.Columns["DATA_TYPE"];
                if (metaData.Columns.Contains("TYPE_NAME")) f_DataTypeName = metaData.Columns["TYPE_NAME"];
                if (metaData.Columns.Contains("TYPE_NAME_COMPLETE")) f_DataTypeNameComplete = metaData.Columns["TYPE_NAME_COMPLETE"];
            }
        }

        internal void PopulateArray(DataTable metaData)
        {
            BindToColumns(metaData);

            ResultColumn column = null;

            if (metaData.DefaultView.Count > 0)
            {
                IEnumerator enumerator = metaData.DefaultView.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    DataRowView rowView = enumerator.Current as DataRowView;

                    column = this.dbRoot.ClassFactory.CreateResultColumn() as ResultColumn;
                    column.dbRoot = this.dbRoot;
                    column.ResultColumns = this;

                    column.Row = rowView.Row;
                    this._array.Add(column);
                }
            }
        }
        #endregion

	}
}
