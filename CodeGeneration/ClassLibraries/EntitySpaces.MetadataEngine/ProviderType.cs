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
using System.Data;
using System.Data.OleDb;

namespace EntitySpaces.MetadataEngine
{
	public class ProviderType : Single, IProviderType, INameValueItem
	{
		public ProviderType()
		{

		}

		#region Properties

		virtual public string Type
		{ 
			get
			{
				return this.GetString(ProviderTypes.f_Type);
			}
		}

		virtual public System.Int32 DataType 
		{ 
			get
			{
				return this.GetInt32(ProviderTypes.f_DataType);
			}
		}

		virtual public System.Int32 ColumnSize
		{ 
			get
			{
				return this.GetInt32(ProviderTypes.f_ColumnSize);
			}
		}

		virtual public string LiteralPrefix 
		{ 
			get
			{
				return this.GetString(ProviderTypes.f_LiteralPrefix);
			}
		}

		virtual public string LiteralSuffix
		{ 
			get
			{
				return this.GetString(ProviderTypes.f_LiteralSuffix);
			}
		}

		virtual public string CreateParams
		{ 
			get
			{
				return this.GetString(ProviderTypes.f_CreateParams);
			}
		}

		virtual public System.Boolean IsNullable
		{ 
			get
			{
				return this.GetBool(ProviderTypes.f_IsNullable);
			}
		}

		virtual public System.Boolean IsCaseSensitive
		{ 
			get
			{
				return this.GetBool(ProviderTypes.f_IsCaseSensitive);
			}
		}

		virtual public string Searchable
		{ 
			get
			{
				return this.GetString(ProviderTypes.f_Searchable);
			}
		}

		virtual public System.Boolean IsUnsigned
		{ 
			get
			{
				return this.GetBool(ProviderTypes.f_IsUnsigned);
			}
		}

		virtual public System.Boolean HasFixedPrecScale
		{ 
			get
			{
				return this.GetBool(ProviderTypes.f_HasFixedPrecScale);
			}
		}

		virtual public System.Boolean CanBeAutoIncrement
		{ 
			get
			{
				return this.GetBool(ProviderTypes.f_CanBeAutoIncrement);
			}
		}

		virtual public string LocalType
		{ 
			get
			{
				return this.GetString(ProviderTypes.f_LocalType);
			}
		}

		virtual public System.Int32 MinimumScale
		{ 
			get
			{
				return this.GetInt32(ProviderTypes.f_MinimumScale);
			}
		}

		virtual public System.Int32 MaximumScale
		{ 
			get
			{
				return this.GetInt32(ProviderTypes.f_MaximumScale);
			}
		}

		virtual public Guid TypeGuid
		{ 
			get
			{
				return this.GetGuid(ProviderTypes.f_TypeGuid);
			}
		}

		virtual public string TypeLib
		{ 
			get
			{
				return this.GetString(ProviderTypes.f_TypeLib);
			}
		}

		virtual public string Version
		{ 
			get
			{
				return this.GetString(ProviderTypes.f_Version);
			}
		}

		virtual public System.Boolean IsLong
		{ 
			get
			{
				return this.GetBool(ProviderTypes.f_IsLong);
			}
		}

		virtual public System.Boolean BestMatch
		{ 
			get
			{
				return this.GetBool(ProviderTypes.f_BestMatch);
			}
		}

		virtual public System.Boolean IsFixedLength
		{ 
			get
			{
				return this.GetBool(ProviderTypes.f_IsFixedLength);
			}
		}

		#endregion

		#region INameValueCollection Members

		public string ItemName
		{
			get
			{
				return this.Type;
			}
		}

		public string ItemValue
		{
			get
			{
				return this.Type;
			}
		}

		#endregion

		internal ProviderTypes ProviderTypes = null;
	}
}
