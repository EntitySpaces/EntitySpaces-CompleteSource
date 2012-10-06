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

using EntitySpaces.MetadataEngine;

namespace EntitySpaces.MetadataEngine.Access
{
	public class ClassFactory : IClassFactory
	{
        public ClassFactory()
		{

		}

		public ITables CreateTables()
		{
			return new Access.AccessTables();
		}

		public ITable CreateTable()
		{
			return new Access.AccessTable();
		}

		public IColumn CreateColumn()
		{
			return new Access.AccessColumn();
		}

		public IColumns CreateColumns()
		{
			return new Access.AccessColumns();
		}

		public IDatabase CreateDatabase()
		{
			return new Access.AccessDatabase();
		}

		public IDatabases CreateDatabases()
		{
			return new Access.AccessDatabases();
		}

		public IProcedure CreateProcedure()
		{
			return new Access.AccessProcedure();
		}

		public IProcedures CreateProcedures()
		{
			return new Access.AccessProcedures();
		}

		public IView CreateView()
		{
			return new Access.AccessView();
		}

		public IViews CreateViews()
		{
			return new Access.AccessViews();
		}

		public IParameter CreateParameter()
		{
			return new Access.AccessParameter();
		}

		public IParameters CreateParameters()
		{
			return new Access.AccessParameters();
		}

		public IForeignKey CreateForeignKey()
		{
			return new Access.AccessForeignKey();
		}

		public IForeignKeys CreateForeignKeys()
		{
			return new Access.AccessForeignKeys();
		}

		public IIndex CreateIndex()
		{
			return new Access.AccessIndex();
		}

		public IIndexes CreateIndexes()
		{
			return new Access.AccessIndexes();
		}

		public IResultColumn CreateResultColumn()
		{
			return new Access.AccessResultColumn();
		}

		public IResultColumns CreateResultColumns()
		{
			return new Access.AccessResultColumns();
		}

		public IDomain CreateDomain()
		{
			return new AccessDomain();
		}

		public IDomains CreateDomains()
		{
			return new AccessDomains();;
		}

		public IProviderType CreateProviderType()
		{
			return new ProviderType();
		}

		public IProviderTypes CreateProviderTypes()
		{
			return new ProviderTypes();
		}
        public System.Data.IDbConnection CreateConnection()
        {
            return new System.Data.OleDb.OleDbConnection();
        }
    }
}
