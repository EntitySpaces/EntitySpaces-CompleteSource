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

namespace EntitySpaces.MetadataEngine.Access
{
	public class AccessResultColumn : ResultColumn
	{
		public AccessResultColumn()
		{

		}

		#region Properties

		override public string Name
		{
			get
			{
				return name;
			}
		}

		override public string DataTypeName
		{
			get
			{
				switch(this.typeName)
				{
					case "adVarWChar":
						return "Text";
					case "adLongVarWChar":
						return "Memo";
					case "adUnsignedTinyInt":
						return "Byte";
					case "adCurrency":
						return "Currency";
					case "adDate":
						return "DateTime";
					case "adBoolean":
						return @"Yes/No";
					case "adLongVarBinary":
						return "OLE Object";
					case "adInteger":
						return "Long";
					case "adDouble":
						return "Double";
					case "adGUID":
						return "Replication ID";
					case "adSingle":
						return "Single";
					case "adNumeric":
						return "Decimal";
					case "adSmallInt":
						return "Integer";
					case "adVarBinary":
						return "Binary";
					case "Hyperlink":
						return "Hyperlink";
					default:
						return this.typeName;
				}
			}
		}

		override public string DataTypeNameComplete
		{
			get
			{
				switch(this.typeName)
				{
					case "adVarWChar":
						return "Text";
					case "adLongVarWChar":
						return "Memo";
					case "adUnsignedTinyInt":
						return "Byte";
					case "adCurrency":
						return "Currency";
					case "adDate":
						return "DateTime";
					case "adBoolean":
						//return @"Yes/No";
						return "Bit";
					case "adLongVarBinary":
						//return "OLE Object";
						return "LongBinary";
					case "adInteger":
						return "Long";
					case "adDouble":
						return "IEEEDouble";
					case "adGUID":
						//return "Replication ID";
						return "Guid";
					case "adSingle":
						return "IEEESingle";
					case "adNumeric":
						return "Decimal";
					case "adSmallInt":
						return "Integer";
					case "adVarBinary":
						return "Binary";
					case "Hyperlink":
						return "Text (255)";
					default:
						return this.typeName;
				}
			}
		}

		override public System.Int32 Ordinal
		{
			get
			{
				return ordinal;
			}
		}

		internal string name;
		internal string typeName;
		internal System.Int32 ordinal;

		#endregion
	}
}
