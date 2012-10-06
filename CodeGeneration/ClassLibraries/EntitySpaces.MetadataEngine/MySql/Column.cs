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

namespace EntitySpaces.MetadataEngine.MySql
{
	public class MySqlColumn : Column
	{
		static char[] chars = new char[] {' ', '('};

		private int numericScale = 0;
		private int precision = 0;
		private int characterLength = 0;
		private string dataType = "";

		public MySqlColumn()
		{

		}

		override internal Column Clone()
		{
			Column c = base.Clone();

			return c;
		}

		public override Boolean IsNullable
		{
			get
			{
				MySqlColumns cols = Columns as MySqlColumns;
				string s = this.GetString(cols.f_IsNullable);
				return (s == "YES") ? true : false;
			}
		}

		public override Boolean HasDefault
		{
			get
			{
				return (this.Default == "") ? false : true;
			}
		}

		override public string DataTypeName
		{
			get
			{
				if(dataType == "")
				{
					MySqlColumns cols = Columns as MySqlColumns;
					string type = this.GetString(cols.f_DataType).ToUpper();

					string[] data = type.Split(new char[]{' '});
					string[] typeandsize = data[0].Split(new char[]{'(',')',','});

					dataType = typeandsize[0];

					if(dataType != "ENUM")
					{
						if(-1 != type.IndexOf("UNSIGNED"))
						{
							dataType += " UNSIGNED";
						}

						int parts = typeandsize.Length;

						if(parts >= 2)
						{
							if(dataType == "VARCHAR" || dataType == "CHAR")
							{
								this.characterLength = Convert.ToInt32(typeandsize[1]);
							}
							else
							{
								this.precision = Convert.ToInt32(typeandsize[1]);
							}
						}

						if(parts >= 3)
						{
							if(typeandsize[2].Length > 0)
							{
								this.numericScale = Convert.ToInt32(typeandsize[2]);
							}
						}
					}
				}

				return dataType;
			}
		}

		override public string DataTypeNameComplete
		{
			get
			{
                string dataTypeNameComplete = "";

				try
				{
					MySqlColumns cols = Columns as MySqlColumns;
					string origType = GetString(cols.f_DataType);
					string type = origType.ToUpper();

					string[] data = type.Split(new char[]{' '});

					if(data[0].StartsWith("ENUM"))
					{
						dataTypeNameComplete = "ENUM" + origType.Substring(4, origType.Length - 4);
					}
					else
					{
						if(-1 != type.IndexOf("UNSIGNED"))
						{
							dataTypeNameComplete = data[0] + " UNSIGNED";
						}
						else
						{
							dataTypeNameComplete = data[0];
						}
					}
				}
				catch
				{
					dataTypeNameComplete = "ERROR";
				}

                return dataTypeNameComplete.Replace("\'", string.Empty);
			}
		}

		public override Int32 NumericPrecision
		{
			get
			{
				return this.precision;
			}
		}

		public override Int32 NumericScale
		{
			get
			{
				return this.numericScale;
			}
		}

		public override Int32 CharacterMaxLength
		{
			get
			{
				return this.characterLength;
			}
		}
	}
}
