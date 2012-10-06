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
    public interface ITableView
    {
        // Collections

        /// <summary>
        /// The Columns collection for this table in ordinal order. See <see cref="IColumn"/>
        /// </summary>
        IColumns Columns { get; }

        /// <summary>
        /// The Properties for this table. These are user defined and are typically stored in 'UserMetaData.xml' unless changed in the Default Settings dialog.
        /// Properties consist of key/value pairs.  You can populate this collection during your script or via the Dockable window. 
        /// To save any data added to this collection call esMetadataEngine.SaveUserMetaData(). See <see cref="IProperty"/>
        /// </summary>
        IPropertyCollection Properties { get; }

        // Objects

        /// <summary>
        /// Parent Database of this Table
        /// </summary>
        IDatabase Database { get; }

        // User Meta Data
        string UserDataXPath { get; }

        /// <summary>
        /// You can override the physical name of the Table. If you do not provide an Alias the value of 'Table.Name' is returned.
        /// If your table in your DBMS is 'Q99AAB' you might want to give it an Alias of 'Employees' so that your business object names will make sense.
        /// You can provide an Alias the User Meta Data window. You can also set this during a script and then call esMetadataEngine.SaveUserMetaData().
        /// See <see cref="Name"/>
        /// </summary>
        string Alias { get; set; }

        /// <summary>
        /// This is the physical table name as stored in your DBMS system. See <see cref="Alias"/>
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Schema.TableName
        /// </summary>
        string FullName { get; }

        /// <summary>
        /// This is the schema of the Table.
        /// </summary>
        string Schema { get; }

        /// <summary>
        /// The table type, 'TABLE' if not provided.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        ///		<item>VIEW</item>
        ///		<item>SYSTEM VIEW</item>
        /// </list>
        ///</remarks>
        string Type { get; }

        /// <summary>
        /// Tab;e GUID. For Providers that do not use GUIDs to identify tables 'Guid.Empty' is returned.
        /// </summary>
        Guid Guid { get; }

        /// <summary>
        /// Human-readable description of the table. Blank if there is no description associated with the table.
        /// </summary>
        string Description { get; }

        /// <summary>
        /// Column property ID. For Providers that do not associate PROPIDs with columns 0 is returned.
        /// </summary>
        System.Int32 PropID { get; }

        /// <summary>
        /// Date when the table was created or '1/1/0001' if the provider does not have this information. 
        /// </summary>
        DateTime DateCreated { get; }

        /// <summary>
        /// Date when the table definition was last modified or '1/1/0001' if the provider does not have this information. 
        /// </summary>
        DateTime DateModified { get; }

        /// <summary>
        /// Fetch any database specific meta data through this generic interface by key. The keys will have to be defined by the specific database provider
        /// </summary>
        /// <param name="key">A key identifying the type of meta data desired.</param>
        /// <returns>A meta-data object or collection.</returns>
        object DatabaseSpecificMetaData(string key);
    }
}
