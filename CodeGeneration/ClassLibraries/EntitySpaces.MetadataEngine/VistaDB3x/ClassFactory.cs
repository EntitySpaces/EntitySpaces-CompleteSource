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

using MyMeta;

namespace MyMeta.VistaDB3x
{
#if ENTERPRISE
	using System.EnterpriseServices;
	using System.Runtime.InteropServices;
	[ComVisible(false)]
#endif
	public class ClassFactory : IClassFactory
	{
		public ClassFactory()
		{

		}

		public ITables CreateTables()
		{
			return new VistaDB3x.VistaDBTables();
		}

		public ITable CreateTable()
		{
			return new VistaDB3x.VistaDBTable();
		}

		public IColumn CreateColumn()
		{
			return new VistaDB3x.VistaDBColumn();
		}

		public IColumns CreateColumns()
		{
			return new VistaDB3x.VistaDBColumns();
		}

		public IDatabase CreateDatabase()
		{
			return new VistaDB3x.VistaDBDatabase();
		}

		public IDatabases CreateDatabases()
		{
			return new VistaDB3x.VistaDBDatabases();
		}

		public IProcedure CreateProcedure()
		{
			return new VistaDB3x.VistaDBProcedure();
		}

		public IProcedures CreateProcedures()
		{
			return new VistaDB3x.VistaDBProcedures();
		}

		public IView CreateView()
		{
			return new VistaDB3x.VistaDBView();
		}

		public IViews CreateViews()
		{
			return new VistaDB3x.VistaDBViews();
		}

		public IParameter CreateParameter()
		{
			return new VistaDB3x.VistaDBParameter();
		}

		public IParameters CreateParameters()
		{
			return new VistaDB3x.VistaDBParameters();
		}

		public IForeignKey CreateForeignKey()
		{
			return new VistaDB3x.VistaDBForeignKey();
		}

		public IForeignKeys CreateForeignKeys()
		{
			return new VistaDB3x.VistaDBForeignKeys();
		}

		public IIndex CreateIndex()
		{
			return new VistaDB3x.VistaDBIndex();
		}

		public IIndexes CreateIndexes()
		{
			return new VistaDB3x.VistaDBIndexes();
		}

		public IDomain CreateDomain()
		{
			return new VistaDBDomain();
		}

		public IDomains CreateDomains()
		{
			return new VistaDBDomains();
		}

		public IResultColumn CreateResultColumn()
		{
			return new VistaDB3x.VistaDBResultColumn();
		}

		public IResultColumns CreateResultColumns()
		{
			return new VistaDB3x.VistaDBResultColumns();
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
            return new Provider.VistaDB.VistaDBConnection();
        }

    }
}
