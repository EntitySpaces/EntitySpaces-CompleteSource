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

namespace MyMeta.VistaDB3x
{
#if ENTERPRISE
	using System.Runtime.InteropServices;
	[ComVisible(true), ClassInterface(ClassInterfaceType.AutoDual), ComDefaultInterface(typeof(IParameters))]
#endif 
	public class VistaDBParameters : Parameters
	{
		public VistaDBParameters()
		{

		}

		override internal void LoadAll()
		{
			try
			{
//				DataTable metaData = this.LoadData(OleDbSchemaGuid.Procedure_Parameters, new object[]{null, null, this.Procedure.Name});
//
//				PopulateArray(metaData);
//
//				LoadExtraData();
			}
			catch {}
		}

//		private void LoadExtraData()
//		{
//			try
//			{
//				string select = "SELECT PARMNAME, TYPENAME, CODEPAGE FROM SYSCAT.PROCPARMS WHERE PROCNAME = '" + this.Procedure.Name + "' ORDER BY ORDINAL";
//
//				OleDbDataAdapter adapter = new OleDbDataAdapter(select, this.dbRoot.ConnectionString);
//				DataTable dataTable = new DataTable();
//
//				adapter.Fill(dataTable);
//
//				if(this._array.Count > 0)
//				{
//					DataRowCollection rows = dataTable.Rows;
//					string paramName = "";
//
//					int count = this._array.Count;
//					Parameter p = null;
//
//					foreach(DataRow row in rows)
//					{
//						paramName = row["PARMNAME"] as string;
//						p = this[paramName] as Parameter;
//
//						p._row["TYPE_NAME"] = (row["TYPENAME"] as string).Trim();
//
//						int codepage = -1;
//						try
//						{
//							codepage = (short)row["CODEPAGE"];
//						}
//						catch{}
//
//						if(codepage == 0)
//						{
//							// Check for "bit data"
//							switch(p.TypeName)
//							{
//								case "CHARACTER":
//								case "VARCHAR":
//								case "LONG VARCHAR":
//
//									p._row["TYPE_NAME"] = p.TypeName + " FOR BIT DATA";
//									break;
//							}
//						}
//					}
//				}
//			}
//			catch {}
//		}
	}
}
