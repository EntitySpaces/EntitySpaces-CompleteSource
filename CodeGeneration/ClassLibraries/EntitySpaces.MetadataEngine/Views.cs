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
	public class Views : Collection, IViews, IEnumerable, ICollection
	{
		public Views()
		{

		}

		override public string UserDataXPath
		{ 
			get
			{
				return Database.UserDataXPath + @"/Views";
			} 
		}

		internal DataColumn f_Catalog			= null;
		internal DataColumn f_Schema			= null;
		internal DataColumn f_Name				= null;
		internal DataColumn f_ViewDefinition    = null;
		internal DataColumn f_CheckOption       = null;
		internal DataColumn f_IsUpdateable      = null;
		internal DataColumn f_Type				= null;
		internal DataColumn f_Guid				= null;
		internal DataColumn f_Description		= null;
		internal DataColumn f_PropID			= null;
		internal DataColumn f_DateCreated		= null;
		internal DataColumn f_DateModified		= null;


		private void BindToColumns(DataTable metaData)
		{
			if(false == _fieldsBound)
			{
				if(metaData.Columns.Contains("TABLE_CATALOG"))		f_Catalog		 = metaData.Columns["TABLE_CATALOG"];
				if(metaData.Columns.Contains("TABLE_SCHEMA"))		f_Schema		 = metaData.Columns["TABLE_SCHEMA"];
				if(metaData.Columns.Contains("TABLE_NAME"))			f_Name			 = metaData.Columns["TABLE_NAME"];
				if(metaData.Columns.Contains("TABLE_TYPE"))			f_Type			 = metaData.Columns["TABLE_TYPE"];
				if(metaData.Columns.Contains("VIEW_DEFINITION"))	f_ViewDefinition = metaData.Columns["VIEW_DEFINITION"];
				if(metaData.Columns.Contains("CHECK_OPTION"))		f_CheckOption	 = metaData.Columns["CHECK_OPTION"];
				if(metaData.Columns.Contains("IS_UPDATABLE"))		f_IsUpdateable	 = metaData.Columns["IS_UPDATABLE"];
				if(metaData.Columns.Contains("TABLE_GUID"))			f_Guid			 = metaData.Columns["TABLE_GUID"];
				if(metaData.Columns.Contains("DESCRIPTION"))		f_Description	 = metaData.Columns["DESCRIPTION"];
				if(metaData.Columns.Contains("TABLE_PROPID"))		f_PropID		 = metaData.Columns["TABLE_PROPID"];
				if(metaData.Columns.Contains("DATE_CREATED"))		f_DateCreated	 = metaData.Columns["DATE_CREATED"];
				if(metaData.Columns.Contains("DATE_MODIFIED"))		f_DateModified	 = metaData.Columns["DATE_MODIFIED"];
			}
		}

		virtual internal void LoadAll()
		{

		}

		internal virtual void PopulateArray(DataTable metaData)
		{
			BindToColumns(metaData);

			View view = null;

			int count = metaData.Rows.Count;
			for(int i = 0; i < count; i++)
			{
				view = (View)this.dbRoot.ClassFactory.CreateView();
				view.dbRoot = this.dbRoot;
				view.Views = this;
				view.Row = metaData.Rows[i];
				this._array.Add(view);
			}
		}

		internal void AddView(View view)
		{
			this._array.Add(view);
		}

		#region indexers

		virtual public IView this[object index]
		{
			get
			{
				if(index.GetType() == Type.GetType("System.String"))
				{
					return GetByPhysicalName(index as String);
				}
				else
				{
					int idx = Convert.ToInt32(index);
					return this._array[idx] as View;
				}
			}
		}

		public View GetByName(string name)
		{
			View obj = null;
			View tmp = null;

			int count = this._array.Count;
			for(int i = 0; i < count; i++)
			{
				tmp = this._array[i] as View;

				if(this.CompareStrings(name,tmp.Name))
				{
					obj = tmp;
					break;
				}
			}

			return obj;
		}

		internal View GetByPhysicalName(string name)
		{
			View obj = null;
			View tmp = null;

			int count = this._array.Count;
			for(int i = 0; i < count; i++)
			{
				tmp = this._array[i] as View;

				if(this.CompareStrings(name,tmp.Name))
				{
					obj = tmp;
					break;
				}
                else if (this.CompareStrings(name, tmp.FullName))
                {
                    obj = tmp;
                    break;
                }
			}

			return obj;
		}

		#endregion

		#region IEnumerable Members

		public IEnumerator GetEnumerator()
		{
			return new Enumerator(this._array);
		}

		#endregion

		#region XML User Data

		override internal bool GetXmlNode(out XmlNode node, bool forceCreate)
		{
			node = null;
			bool success = false;

			if(null == _xmlNode)
			{
				// Get the parent node
				XmlNode parentNode = null;
				if(this.Database.GetXmlNode(out parentNode, forceCreate))
				{
					// See if our user data already exists
					string xPath = @"./Views";
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
			XmlNode myNode = parentNode.OwnerDocument.CreateNode(XmlNodeType.Element, "Views", null);
			parentNode.AppendChild(myNode);
		}

		#endregion

		#region IList Members

		object System.Collections.IList.this[int index]
		{
			get	{ return this[index];}
			set	{ }
		}

		#endregion

		internal Database Database = null;
	}
}
