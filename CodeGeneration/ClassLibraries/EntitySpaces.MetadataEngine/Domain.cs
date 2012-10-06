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
	public class Domain : Single, IDomain, INameValueItem
	{
		public Domain()
		{

		}

		#region Objects

		#endregion

		#region Properties

		override public string Alias
		{
			get
			{
				XmlNode node = null;
				if(this.GetXmlNode(out node, false))
				{
					string niceName = null;

					if(this.GetUserData(node, "Alias", out niceName))
					{
						if(string.Empty != niceName)
							return niceName;
					}
				}

				// There was no nice name
				return this.Name;
			}

			set
			{
				XmlNode node = null;
				if(this.GetXmlNode(out node, true))
				{
					this.SetUserData(node, "Alias", value);
				}
			}
		}

		override public string Name
		{
			get
			{
				return this.GetString(Domains.f_DomainName);
			}
		}

		virtual public System.Boolean HasDefault
		{
			get
			{
				if(this.Default.Length > 0) 
					return true;
				else
					return false;
			}
		}

		virtual public string Default
		{
			get
			{
				return this.GetString(Domains.f_Default);
			}
		}

		virtual public System.Boolean IsNullable
		{
			get
			{
				return this.GetBool(Domains.f_IsNullable);
			}
		}

		virtual public System.Int32 CharacterMaxLength
		{
			get
			{
				return this.GetInt32(Domains.f_MaxLength);
			}
		}

		virtual public System.Int32 CharacterOctetLength
		{
			get
			{
				return this.GetInt32(Domains.f_OctetLength);
			}
		}

		virtual public System.Int32 NumericPrecision
		{
			get
			{
				return this.GetInt32(Domains.f_NumericPrecision);
			}
		}

		virtual public System.Int32 NumericScale
		{
			get
			{
				return this.GetInt32(Domains.f_NumericScale);
			}
		}

		virtual public System.Int32 DateTimePrecision
		{
			get
			{
				return this.GetInt32(Domains.f_DatetimePrecision);
			}
		}

		virtual public string CharacterSetCatalog
		{
			get
			{
				return this.GetString(Domains.f_CharSetCatalog);
			}
		}

		virtual public string CharacterSetSchema
		{
			get
			{
				return this.GetString(Domains.f_CharSetSchema);
			}
		}

		virtual public string CharacterSetName
		{
			get
			{
				return this.GetString(Domains.f_CharSetName);
			}
		}

		virtual public string DomainCatalog
		{
			get
			{
				return this.GetString(Domains.f_DomainCatalog);
			}
		}

		virtual public string DomainSchema
		{
			get
			{
				return this.GetString(Domains.f_DomainSchema);
			}
		}

		virtual public string DomainName
		{
			get
			{
				return this.GetString(Domains.f_DomainName);
			}
		}

		virtual public string DataTypeName
		{
			get
			{
				return this.GetString(Domains.f_DataType);
			}
		}

		virtual public string LanguageType
		{
			get
			{
				if(dbRoot.LanguageNode != null)
				{
					string xPath = @"./Type[@From='" + this.DataTypeName + "']";

					XmlNode node = dbRoot.LanguageNode.SelectSingleNode(xPath, null);

					if(node != null)
					{
						string languageType = "";
						if(this.GetUserData(node, "To", out languageType))
						{
							return languageType;
						}
					}
				}

				return "Unknown";
			}
		}

		virtual public string DataTypeNameComplete
		{
			get
			{
				return "Unknown";
			}
		}

		#endregion

		#region XML User Data

		override public string UserDataXPath
		{ 
			get
			{
				return Domains.UserDataXPath + @"/Domain[@Name='" + this.Name + "']";
			} 
		}

		override internal bool GetXmlNode(out XmlNode node, bool forceCreate)
		{
			node = null;
			bool success = false;

			if(null == _xmlNode)
			{
				// Get the parent node
				XmlNode parentNode = null;
				if(this.Domains.GetXmlNode(out parentNode, forceCreate))
				{
					// See if our user data already exists
					string xPath = @"./Domain[@Name='" + this.Name + "']";
					if(!GetUserData(xPath, parentNode, out _xmlNode) && forceCreate)
					{
						// Create it, and try again
						this.CreateUserMetaData(parentNode);
						GetUserData(xPath, parentNode, out _xmlNode);
					}
				}
			}

			if(null != _xmlNode)
			{
				node = _xmlNode;
				success = true;
			}

			return success;
		}

		override public void CreateUserMetaData(XmlNode parentNode)
		{
			XmlNode myNode = parentNode.OwnerDocument.CreateNode(XmlNodeType.Element, "Column", null);
			parentNode.AppendChild(myNode);

			XmlAttribute attr;

			attr = parentNode.OwnerDocument.CreateAttribute("Name");
			attr.Value = this.Name;
			myNode.Attributes.Append(attr);
		}

		#endregion

		#region INameValueCollection Members

		public string ItemName
		{
			get
			{
				return this.Name;
			}
		}

		public string ItemValue
		{
			get
			{
				return this.Name;
			}
		}

		#endregion

		internal Domains Domains = null;
	}
}
