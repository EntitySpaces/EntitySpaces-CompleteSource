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
using System.Collections;

namespace EntitySpaces.MetadataEngine
{
	/// <summary>
	/// This is a MyMeta Collection. The only two methods meant for public consumption are Count and Item.
	/// </summary>
	public interface IForeignKeys : IList, IEnumerable	
	{
		// User Meta Data
		string UserDataXPath { get; }

		/// <summary>
		/// You access items in the collect using this method. The return is the object in the collection.
		/// </summary>
		/// <param name="index">Either an integer or a string (see the remarks).
		/// </param>
		/// <remarks>
		/// The code below is using an IColumns collection, but all collections work the same way, the only difference is the return item.
		/// <list type="table">
		///		<item><term>int index</term><description>A zero based integer representing positon within the collection</description></item>
		///		<item><term>string index</term><description>A string that represents the physical name (not alias) of the item in the collection</description></item>///		
		///	</list>
		/// VBScript
		///	<code>
		/// Dim objColumn
		/// Set objColumn = objTable.Columns.Item(5)
		/// Set objColumn = objTable.Columns.Item("FirstName")
		/// 
		/// ' Loop through the collection
		/// For Each objColumn in objTable.Columns
		///	    output.writeLn objColumn.Name
		///	    output.writeLn objColumn.Alias
		///     output.writeLn objColumn.DataTypeNam
		/// Next
		///	</code>
		/// JScript
		///	<code>
		/// var objColumn;
		///	objColumn = objTable.Columns.Item(5);
		///	objColumn = objTable.Columns.Item("FirstName");
		///	
		/// for (var j = 0; j &lt; objTable.Columns.Count; j++) 
		/// {
		///	    objColumn = objTable.Columns.Item(j);
		///	    
		///	    output.writeln(objColumn.Name);
		///	    output.writeln(objColumn.Alias);
		///	    output.writeln(objColumn.DataTypeName);				
		/// }
		///	</code>
		/// </remarks>
		IForeignKey this[object index] { get; }

		// ICollection
		/// <summary>
		/// ICollection support. Not implemented.
		/// </summary>
		new bool IsSynchronized { get; }

		/// <summary>
		/// The number of items in the collection
		/// </summary>
		new int Count { get; }

		/// <summary>
		/// ICollection support. Not implemented.
		/// </summary>
		new void CopyTo(System.Array array, int index);

		/// <summary>
		/// ICollection support. Not implemented.
		/// </summary>
		new object SyncRoot { get; }

		// IEnumerable
		/// <summary>
		/// Used to support 'foreach' sytax. Do not call this directly.
		/// </summary>
		new IEnumerator GetEnumerator();
	}
}

