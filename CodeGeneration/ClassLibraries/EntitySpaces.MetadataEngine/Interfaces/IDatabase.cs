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

namespace EntitySpaces.MetadataEngine
{
	/// <summary>
	/// IDatabase represents a databaase in your DBMS.
	/// </summary>
	/// <remarks>
	///	IDatabase has 5 Collections:
	/// <list type="table">
	///		<item><term>Tables</term><description>Contains all of the tables for the databaase</description></item>
	///		<item><term>Views</term><description>Contains all of the views the databaase</description></item>
	///		<item><term>Procedures</term><description>Contains all of the procedures for the databaase</description></item>
	///		<item><term>Domains</term><description>Contains all of the domains for the database</description></item>
	///		<item><term>Properties</term><description>A collection that can hold key/value pairs of your choosing</description></item>
	///	</list>
	/// </remarks>
	/// <example>
	/// VBScript
	/// <code>
	/// Dim objDatabase
	/// For Each objDatabase in esMetadataEngine.Databases
	///     output.writeLn objDatabase.Name
	///	    output.writeLn objDatabase.Alias
	/// Next
	/// </code>
	/// JScript
	/// <code>
	/// var objDatabase;
	/// for (var j = 0; j &lt; esMetadataEngine.Databases.Count; j++) 
	/// {
	///	    objDatabase = esMetadataEngine.Databases.Item(j);
	///	    
	///	    output.writeln(objDatabase.Name);
	///	    output.writeln(objDatabase.Alias);
	/// }
	/// </code>
	/// </example>
	public interface IDatabase
	{
		// Collections
		/// <summary>
		/// Contains all of the tables for the databaase
		/// </summary>
		ITables Tables { get; }

		/// <summary>
		/// Contains all of the views the databaase
		/// </summary>
		IViews Views { get; }

		/// <summary>
		/// Contains all of the procedures for the databaase
		/// </summary>
		IProcedures Procedures { get; }

		/// <summary>
		/// A link back to the dbRoot object
		/// </summary>
		Root Root { get; }

		/// <summary>
		/// Contains all of the domains for the databaase
		/// </summary>
		IDomains Domains { get; }

		/// <summary>
		/// The Properties for this Database. These are user defined and are typically stored in 'UserMetaData.xml' unless changed in the Default Settings dialog.
		/// Properties consist of key/value pairs.  You can populate this collection during your script or via the Dockable window. 
		/// To save any data added to this collection call esMetadataEngine.SaveUserMetaData(). See <see cref="IProperty"/>
		/// </summary>
		IPropertyCollection Properties { get; }


		// User Meta Data
		string UserDataXPath { get; }

		/// <summary>
		/// You can override the physical name of the Column. If you do not provide an Alias the value of 'Column.Name' is returned.
		/// If your column in your DBMS is 'TXT_FIRST_NAME' you might want to give it an Alias of 'FirstName' so that your business object property will be a nice name.
		/// You can provide an Alias the User Meta Data window. You can also set this during a script and then call esMetadataEngine.SaveUserMetaData().
		/// See <see cref="Name"/>
		/// </summary>
		string Alias { get; set; }
	
		/// <summary>
		/// This is the physical column name as stored in your DBMS system. See <see cref="Alias"/>
		/// </summary>
		string Name { get; }

		/// <summary>
		/// Human-readable description of the database.
		/// </summary>
		string Description { get; }

		/// <summary>
		/// Unqualified schema name.
		/// </summary>
		string SchemaName { get; }

		/// <summary>
		/// User that owns the schemas.
		/// </summary>
		string SchemaOwner { get; }

		/// <summary>
		/// Catalog name of the default character set for columns and domains in the schemas. 
		/// Blank if the provider does not support catalogs or different character sets.
		/// </summary>
		string DefaultCharSetCatalog { get; }

		/// <summary>
		/// Unqualified schema name of the default character set for columns and domains in the schemas. 
		/// Blank if the provider does not support different character sets.
		/// </summary>
		string DefaultCharSetSchema { get; }

		/// <summary>
		/// Default character set name. Blank if the provider does not support different character sets.
		/// </summary>
		string DefaultCharSetName { get; }

		// Methods
		/// <summary>
		/// This method can execute any SQL statement against your DBMS system, including SELECT, INSERT, UPDATE, DELETE and more.  
		/// </summary>
		/// <param name="sql">Raw SQL statement to be executed. Regardless of your DBMS system the result set will be converted into an ADO (pre .NET) recordset. 
		/// WARNING, you should test your query in your DMBS software before using.</param>
		/// <returns></returns>
		/// <remarks>
		/// <code>
		/// /* JScript taken from 'SQL_DataReplication.jgen' */
		/// var sql = "SELECT * FROM [" + tablename + "];";
		/// var rs = objDatabase.ExecuteSQL(sql);
		/// 
		/// // Loop through the recordset and write out all the data into the sproc.
		/// if (rs != null)
		/// {
		///	    while (!rs.Eof)
		///	    {
		///		    output.writeln(rs("FirstName").Value);
		///		    rs.MoveNext();
		///     }
		///	}
		///	
		///	' VBScript Accessing a Firebird System Table
		/// dim rs
		/// set rs = database.ExecuteSQL("SELECT * FROM RDB$FIELDS")
		///
		///	If Not rs is Nothing then
		///     Do
		///	        For i = 0 To (rs.Fields.Count - 1)
		///             output.writeLn rs(i).Name
		///         Next
		///         rs.MoveNext()
		///     Loop Until rs.Eof
		/// End If
		/// </code>
		/// </remarks>
        ADODB.Recordset ExecuteSql(string sql);

        /// <summary>
        /// Fetch any database specific meta data through this generic interface by key. The keys will have to be defined by the specific database provider
        /// </summary>
        /// <param name="key">A key identifying the type of meta data desired.</param>
        /// <returns>A meta-data object or collection.</returns>
        object DatabaseSpecificMetaData(string key);
	}
}

