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
using System.Collections;
using System.Data;
using System.Data.OleDb;

namespace EntitySpaces.MetadataEngine
{
	public class MetaObject
	{
		public MetaObject()
		{

		}

		virtual protected DataTable LoadData(Guid oleDbSchemaGuid, object[] filter)
		{
			try
			{
				OleDbConnection cn = dbRoot.TheConnection;
				DataTable metaData = cn.GetOleDbSchemaTable(oleDbSchemaGuid, filter);
				return metaData;
			}
			catch(Exception ex)
			{
				string s = ex.Message;
				return new DataTable();
			}
		}

		#region XML User Data

		virtual internal bool GetXmlNode(out XmlNode node, bool forceCreate)
		{
			node = null;
			return false;
		}

		virtual public string UserDataXPath
		{
			get
			{
				return string.Empty;
			}
		}

		virtual public void CreateUserMetaData(XmlNode parentNode)
		{

		}

		virtual public void CreateUserMetaData()
		{

		}

		protected bool GetUserData(string xPath, XmlNode startingNode, out XmlNodeList data)
		{
			data = null;
			bool success = false;

			XmlNodeList nodeList = null;
		
			if(null == startingNode)
			{
				nodeList = dbRoot.UserData.SelectNodes(xPath, null);
			}
			else
			{
				nodeList = startingNode.SelectNodes(xPath, null);
			}

			if(null != nodeList)
			{
				data = nodeList;
				success = true;
			}

			return success;
		}

		protected bool GetUserData(string xPath, XmlNode startingNode, out XmlNode data)
		{
			data = null;
			bool success = false;

			XmlNode node = null;

			if(null == startingNode)
			{
				node = dbRoot.UserData.SelectSingleNode(xPath, null);
			}
			else
			{
				node = startingNode.SelectSingleNode(xPath, null);
			}

			if(null != node)
			{
				data = node;
				success = true;
			}

			return success;
		}

		protected bool GetUserData(string xPath, XmlNode startingNode, string attribute, out string data)
		{
			data = string.Empty;
			bool success = false;

			XmlNode node = null;

			if(null == startingNode)
			{
				node = dbRoot.UserData.SelectSingleNode(xPath, null);
			}
			else
			{
				node = startingNode.SelectSingleNode(xPath, null);
			}

			if(null != node)
			{
				XmlAttributeCollection coll = node.Attributes;
				if(null != coll)
				{
					if(null != coll[attribute])
					{
						data = coll[attribute].Value;
						success = true;
					}
				}
			}

			return success;
		}

		protected bool GetUserData(XmlNode startingNode, string attribute, out string data)
		{
			data = string.Empty;
			bool success = false;

			if(null != startingNode)
			{
				XmlAttributeCollection coll = startingNode.Attributes;
				if(null != coll)
				{
					if(null != coll[attribute])
					{
						data = coll[attribute].Value;
						success = true;
					}
				}
			}

			return success;
		}
		
		protected void SetUserData(XmlNode node, string attribute, string data)
		{
			if(null != node)
			{
                if (data == null || data.Length == 0)
                {
                    node.Attributes.RemoveNamedItem(attribute);
                    return;
                }

                if (node.Attributes[attribute] == null)
                {
                    XmlAttribute attr = node.OwnerDocument.CreateAttribute(attribute);
                    attr.Value = data;
                    node.Attributes.Append(attr);
                }

				node.Attributes[attribute].Value = data;
			}
		}


		#endregion

		internal Root dbRoot
		{
			get
			{
				return _dbRoot;
			}

			set
			{
				_dbRoot = value;
			}
		}

		internal  Root _dbRoot = null;
		protected XmlNode _xmlNode = null;
	}
}
