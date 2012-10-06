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
using System.Data.OleDb;

namespace EntitySpaces.MetadataEngine.PostgreSQL
{
	public class PostgreSQLColumn : Column
	{
		internal bool _isAutoKey = false;
		internal int _autoInc   = 0;
		internal int _autoSeed  = 0;

		public PostgreSQLColumn()
		{

		}

		override internal Column Clone()
		{
			Column c = base.Clone();

			return c;
		}

		override public System.Boolean IsNullable
		{
			get
			{
				string s = this.GetString(Columns.f_IsNullable);

				if(s == "YES") 
					return true;
				else
					return false;
			}
		}

		override public System.Boolean HasDefault
		{
			get
			{
				object o = this._row[Columns.f_Default];

				if(o == DBNull.Value)
				{
					return false;
				}
				else
				{
					return true;
				}
			}
		}


		public override System.Boolean IsAutoKey
		{
			get
			{
				return this._isAutoKey;
			}
		}

		public override Int32 AutoKeyIncrement
		{
			get
			{
				return this._autoInc;
			}
		}

		public override Int32 AutoKeySeed
		{
			get
			{
				return this._autoSeed;
			}
		}

		override public string DataTypeName
		{
			get
			{
				PostgreSQLColumns cols = Columns as PostgreSQLColumns;
				return this.GetString(cols.f_TypeName);
			}
		}

		override public string DataTypeNameComplete
		{
			get
			{
				PostgreSQLColumns cols = Columns as PostgreSQLColumns;
                return this.GetString(cols.f_TypeNameComplete).Replace("\'", string.Empty);
			}
		}
	}
}
