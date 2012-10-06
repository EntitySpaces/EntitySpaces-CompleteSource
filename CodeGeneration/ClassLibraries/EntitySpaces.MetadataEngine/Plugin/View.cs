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

namespace EntitySpaces.MetadataEngine.Plugin
{
	public class PluginView : View
    {
        private IPlugin plugin;

        public PluginView(IPlugin plugin)
        {
            this.plugin = plugin;
		}

		public override string ViewText
		{
			get
			{
				PluginViews views = this.Views as PluginViews;
				return this.GetString(views.f_viewText);
			}
		}

		override public IViews SubViews 
		{ 
			get
			{
				if(!_subViewInfoLoaded)
				{
					LoadSubViewInfo();
				}
				return _views;				
			}
		}

		override public ITables SubTables
		{ 
			get
			{
				if(!_subViewInfoLoaded)
				{
					LoadSubViewInfo();
				}
				return _tables;
			}
		}

		private void LoadSubViewInfo()
		{
			_views  = (Views)this.dbRoot.ClassFactory.CreateViews();
			_views.dbRoot = this._dbRoot;
            _views.Database = this.Views.Database;
            System.Collections.Generic.List<string> subViews = this.plugin.GetViewSubViews(this.Database.Name, this.Name);
            foreach (string entity in subViews)
            {
                View view = this.Database.Views[entity] as View;
                if (null != view) _views.AddView(view);
            }

			_tables = (Tables)this.dbRoot.ClassFactory.CreateTables();
			_tables.dbRoot = this._dbRoot;
            _tables.Database = this.Views.Database;
            System.Collections.Generic.List<string> subTables = this.plugin.GetViewSubTables(this.Database.Name, this.Name);
            foreach (string entity in subTables)
            {
                Table table = this.Database.Tables[entity] as Table;
                if (null != table) _tables.AddTable(table);
            }
        }

        public override object DatabaseSpecificMetaData(string key)
        {
            return this.plugin.GetDatabaseSpecificMetaData(this, key);
        }
	}
}
