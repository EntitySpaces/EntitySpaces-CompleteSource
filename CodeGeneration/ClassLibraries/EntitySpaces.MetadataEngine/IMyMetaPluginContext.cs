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
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace EntitySpaces.MetadataEngine
{
    public interface IContext
    {
        /// <summary>
        /// Should the system tables, views, etc be included when calling the plugin for MetaData?
        /// </summary>
        bool IncludeSystemEntities { get; }

        /// <summary>
        /// Is the DatabaseName required to make a connection?
        /// </summary>
        string ProviderName { get; }

        /// <summary>
        /// Is the DatabaseName required to make a connection?
        /// </summary>
        string ConnectionString { get; }

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
        DataTable CreateDatabasesDataTable();

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
        DataTable CreateForeignKeysDataTable();

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
        DataTable CreateTablesDataTable();

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		DataTable CreateViewsDataTable();

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		DataTable CreateColumnsDataTable();

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		DataTable CreateIndexesDataTable();

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		DataTable CreateProceduresDataTable();

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		DataTable CreateParametersDataTable();

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		DataTable CreateResultColumnsDataTable();

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		DataTable CreateDomainsDataTable();
    }
}
