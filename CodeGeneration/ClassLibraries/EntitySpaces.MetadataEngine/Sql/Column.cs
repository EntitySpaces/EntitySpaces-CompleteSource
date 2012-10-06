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
	public class SqlColumn : Column
	{
		public SqlColumn()
		{

		}

		override internal Column Clone()
		{
			Column c = base.Clone();

			return c;
		}

		override public System.Boolean IsComputed
		{
			get
			{
				if(this.DataTypeName == "timestamp") return true;

				return base.IsComputed;
			}
		}

        public override bool IsConcurrency
        {
            get
            {
			    if(this.DataTypeName.ToLower() == "timestamp")
			    {
    				return true;
			    }

                return false;
            }
        }

        public override string LanguageType
        {
            get
            {
               return base.LanguageType;
            }
        }


		override public string DataTypeName
		{
			get
			{
				if(this.dbRoot.DomainOverride)
				{
					if(this.HasDomain)
					{
						if(this.Domain != null)
						{
							return this.Domain.DataTypeName;
						}
					}
				}

				SqlColumns cols = Columns as SqlColumns;
				return this.GetString(cols.f_TypeName);
			}
		}

		override public string DataTypeNameComplete
		{
			get
			{
				if(this.dbRoot.DomainOverride)
				{
					if(this.HasDomain)
					{
						if(this.Domain != null)
						{
							return this.Domain.DataTypeNameComplete;
						}
					}
				}

                return GetFullDataTypeName(DataTypeName, CharacterMaxLength, NumericPrecision, NumericScale).Replace("\'", string.Empty);
			}
		}

		public override object DatabaseSpecificMetaData(string key)
		{
			return SqlDatabase.DBSpecific(key, this);
		}

        internal static string GetFullDataTypeName(string name, int charMaxLen, int precision, int scale)
        {
            string dtnf = null;
            switch (name)
            {
                case "varchar":
                case "nvarchar":
                case "varbinary":
                    if (charMaxLen > 1000000)
                        dtnf = name + "(MAX)";
                    else
                        dtnf = name + "(" + charMaxLen + ")";
                    break;
                case "binary":
                case "char":
                case "nchar":

                    dtnf = name + "(" + charMaxLen + ")";
                    break;

                case "decimal":
                case "numeric":

                    dtnf = name + "(" + precision + "," + scale + ")";
                    break;

                default:

                    dtnf = name;
                    break;
            }

            return dtnf;
        }
	}
}
