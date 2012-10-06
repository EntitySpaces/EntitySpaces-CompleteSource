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
using System.Reflection;

namespace MyMeta.VistaDB3x
{
#if ENTERPRISE
	using System.Runtime.InteropServices;
	[ComVisible(true), ClassInterface(ClassInterfaceType.AutoDual), ComDefaultInterface(typeof(IForeignKeys))]
#endif 
	public class VistaDBForeignKeys : ForeignKeys
	{
		public VistaDBForeignKeys()
		{

		}

		override internal void LoadAll()
		{
			try
			{
				VistaDBDatabase db = (VistaDBDatabase)this.Table.Database;

				if(!db._FKsInLoad)
				{
					db._FKsInLoad = true;

					VistaDBForeignKeys fks = null;

					foreach(Table table in this.Table.Tables)
					{
						fks = table.ForeignKeys as VistaDBForeignKeys;
					}

					DataTable metaData = db._mh.LoadForeignKeys(this.dbRoot.ConnectionString, this.Table.Database.Name, this.Table.Name);

					PopulateArray(metaData);

					ITables tables = this.Table.Tables;
					for(int i = 0; i < tables.Count; i++)
					{
						ITable table = tables[i];
						fks = table.ForeignKeys as VistaDBForeignKeys;
						fks.AddTheOtherHalf();
					}

					db._FKsInLoad = false;
				}
				else
				{
					DataTable metaData = db._mh.LoadForeignKeys(this.dbRoot.ConnectionString, this.Table.Database.Name, this.Table.Name);

					PopulateArray(metaData);
				}
			}
			catch {}
		}

		internal void AddTheOtherHalf()
		{
			string myName = this.Table.Name;

			foreach(Table table in this.Table.Tables)
			{
				if(table.Name != myName)
				{
					foreach(VistaDBForeignKey fkey in table.ForeignKeys)
					{
						if(fkey.ForeignTable.Name == myName || fkey.PrimaryTable.Name == myName)
						{
							this.AddForeignKey(fkey);
						}
					}
				}
			}
		}

		internal void AddForeignKey(VistaDBForeignKey fkey)
		{
			if(!this._array.Contains(fkey))
			{
				this._array.Add(fkey);
			}
		}
	}
}
