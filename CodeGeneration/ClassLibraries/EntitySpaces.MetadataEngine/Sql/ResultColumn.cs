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

namespace EntitySpaces.MetadataEngine.Sql
{
	public class SqlResultColumn : ResultColumn
	{
		public SqlResultColumn()
		{

		}

		#region Properties
        //ColumnName ColumnOrdinal ColumnSize NumericPrecision NumericScale IsUnique IsKey BaseServerName BaseCatalogName BaseColumnName BaseSchemaName BaseTableName DataType AllowDBNull ProviderType IsAliased IsExpression IsIdentity IsAutoIncrement IsRowVersion IsHidden IsLong IsReadOnly ProviderSpecificDataType DataTypeName XmlSchemaCollectionDatabase XmlSchemaCollectionOwningSchema XmlSchemaCollectionName UdtAssemblyQualifiedName NonVersionedProviderType 
		override public string Name
		{
			get
			{
                if (_row != null)
                {
                    return _row["ColumnName"].ToString();
                }
                else
                {
                    return this._column.ColumnName;
                }
			}
        }

        override public string DataTypeName
        {
            get
            {
                if (_row != null)
                {
                    return _row["DataTypeName"].ToString();
                }
                else
                {
                    return _column.DataType.ToString();
                }
            }
        }

        override public string DataTypeNameComplete
		{
			get
			{
                return SqlColumn.GetFullDataTypeName(DataTypeName, CharacterMaxLength, NumericPrecision, NumericScale);
			}
		}

		override public System.Int32 Ordinal
		{
			get
            {
                if (_row != null)
                {
                    return Convert.ToInt32(_row["ColumnOrdinal"]);
                }
                else
                {
                    return this._column.Ordinal;
                }
			}
        }

        public System.Int32 CharacterMaxLength
        {
            get
            {
                try
                {
                    return Convert.ToInt32(_row["ColumnSize"]);
                }
                catch { }
                return 0;
            }
        }

        public System.Int32 CharacterOctetLength
        {
            get
            {
                if (DataTypeName.StartsWith("n", StringComparison.CurrentCultureIgnoreCase))
                {
                    return CharacterMaxLength * 2;
                }
                else
                {
                    return CharacterMaxLength;
                }
            }
        }

        public System.Int32 NumericPrecision
        {
            get
            {
                try
                {
                    int i = Convert.ToInt32(_row["NumericPrecision"]);
                    if (i < 255) return i;
                }
                catch { }
                return 0;
            }
        }

        public System.Int32 NumericScale
        {
            get
            {
                try
                {
                    int i = Convert.ToInt32(_row["NumericScale"]);
                    if (i < 255) return i;
                }
                catch { }
                return 0;
            }
        }

		#endregion

        internal DataRow _row = null;
        internal DataColumn _column = null;
	}
}
