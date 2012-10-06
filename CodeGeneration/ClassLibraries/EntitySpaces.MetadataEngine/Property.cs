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
using System.ComponentModel;
using System.Xml;
using System.Collections;
using System.Data;
using System.Data.OleDb;

namespace EntitySpaces.MetadataEngine
{
	/// <summary>
	/// Summary description for Collection.
	/// </summary>
	/// 
	public class Property : Single, IProperty
	{
		public Property()
		{

		}

		public void QuickCreate(string key, string value, bool isGlobal)
		{
			this._key   = key;
			this._value = value;
			this._isGlobal = isGlobal;
		}

		#region XML User Data

        [Browsable(false)]
		override public string UserDataXPath
		{ 
			get
			{
				return _collection.UserDataXPath +  @"/Property[@k='" + this.Key + "']";
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
				if(this._collection.GetXmlNode(out parentNode, forceCreate))
				{
					// See if our user data already exists
					string xPath = @"./Property[@k='" + this.Key + "']";
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
			XmlNode myNode = parentNode.OwnerDocument.CreateNode(XmlNodeType.Element, "Property", null);
			parentNode.AppendChild(myNode);

			XmlAttribute attr;

			attr = parentNode.OwnerDocument.CreateAttribute("k");
			attr.Value = this.Key;
			myNode.Attributes.Append(attr);

			attr = parentNode.OwnerDocument.CreateAttribute("v");
			attr.Value = "";
			myNode.Attributes.Append(attr);
		}

		#endregion

        #region Overrides

        [Browsable(false)]
        public override string Alias
        {
            get
            {
                return base.Alias;
            }
            set
            {
                base.Alias = value;
            }
        }

        [Browsable(false)]
        public override IPropertyCollection Properties
        {
            get
            {
                return base.Properties;
            }
        }

        [Browsable(false)]
        public override string Name
        {
            get
            {
                return base.Name;
            }
        }

        #endregion

        [Browsable(false)]
		public PropertyCollection Parent
		{
			set
			{
				_collection = value;				
			}
		}

		public string Key
		{
			get
			{
				return _key;
			}
		}

		internal void SetKey(string key)
		{
			XmlNode node = null;
			if(this.GetXmlNode(out node, true))
			{
				this.SetUserData(node, "k", key);
			}

			_key = key;
		}

		public string Value
		{
			get
			{
				return _value;
			}

			set 
			{
				XmlNode node = null;
				if(this.GetXmlNode(out node, true))
				{
					this.SetUserData(node, "v", value);
				}
				_value = value;
			}
		}

        [Browsable(false)]
		public bool IsGlobal
		{
			get
			{
				return _isGlobal;
			}
		}

		private string _key;
		private string _value;
		private bool _isGlobal = false;
		private PropertyCollection _collection;
	}
}
