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
using System.Xml;
using System.Xml.XPath;
using System.Data;
using System.Data.OleDb;

namespace EntitySpaces.MetadataEngine
{
	public class Single : MetaObject
	{
		public Single()
		{

		}

		#region Properties
		virtual public string Alias
		{
			get
			{
				return string.Empty;
			}

			set
			{

			}
		}

		virtual public string Name
		{
			get
			{
				return string.Empty;
			}
		}
		#endregion

		#region Property Helpers

		protected string GetString(DataColumn col)
		{
			if(null != col)
			{
				object o = _row[col];

				if(DBNull.Value != o)
				{
					string s = (string)o;
					if(dbRoot.StripTrailingNulls)
					{
						if(s.EndsWith(dbRoot.TrailingNull))
						{
							s = s.Remove(s.Length - 1, 1);
						}
					}
					return s;
				}
			}

			return string.Empty;
		}

		protected Guid GetGuid(DataColumn col)
		{
			if(null != col)
			{
				object o = _row[col];

				if(DBNull.Value != o)
					return (Guid)o;
			}

			return Guid.Empty;
		}

		protected DateTime GetDateTime(DataColumn col)
		{
			if(null != col)
			{
				object o = _row[col];

				if(DBNull.Value != o)
					return (DateTime)o;
			}

			return new DateTime(1,1,1,1,1,1,1);
		}

		protected System.Boolean GetBool(DataColumn col)
		{
			if(null != col)
			{
				object o = _row[col];

				if(DBNull.Value != o)
				{
					if(o is System.Boolean)
						return (Boolean)o;
					else
					{
						int i = Convert.ToInt32(o);
						return i == 0 ? false : true;
					}
				}
			}

			return false;
		}

		protected System.Int16 GetInt16(DataColumn col)
		{
			if(null != col)
			{
				object o = _row[col];

				if(DBNull.Value != o)
					return Convert.ToInt16(o);
			}

			return 0;
		}

		protected System.Int32 GetInt32(DataColumn col)
		{
			if(null != col)
			{
				object o = _row[col];

				if(DBNull.Value != o)
					return Convert.ToInt32(o);
			}

			return 0;
		}

		protected Decimal GetDecimal(DataColumn col)
		{
			if(null != col)
			{
				object o = _row[col];

				if(DBNull.Value != o)
					return Convert.ToDecimal(o);
			}

			return 0;
		}

		protected System.Byte[] GetByteArray(DataColumn col)
		{
			if(null != col)
			{
				object o = _row[col];

				if(DBNull.Value == o)
					return null;
				else
					return null;
			}

			return null;
		}

		#endregion

		internal DataRow Row
		{
			set
			{
				this._row = value;
			}
		}


		virtual public IPropertyCollection Properties 
		{ 
			get
			{
				if(null == _properties)
				{
					_properties = new PropertyCollection();
					_properties.Parent = this;
					_properties.LoadAll();
				}

				return _properties;
			}
		}

		virtual public object DatabaseSpecificMetaData(string key) 
		{
			return null;
		}

		protected PropertyCollection  _properties = null;
		internal  DataRow _row = null;
	}
}
