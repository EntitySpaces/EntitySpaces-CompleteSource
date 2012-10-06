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
	/// <summary>
	/// Summary description for Collection.
	/// </summary>
	/// 
    public class Collection : MetaObject, IEnumerable
	{
		public Collection()
		{

		}

		virtual public int Count
		{
			get
			{
				return _array.Count;
			}
		}

		#region ICollection Members

		public bool IsSynchronized
		{
			get	{ return false;	}
		}

		public void CopyTo(Array array, int index)
		{

		}

		public object SyncRoot
		{
			get	{ return null; }
		}

		#endregion

		#region IList Members

		public bool IsReadOnly
		{
			get	{return true; }
		}

		public void RemoveAt(int index)
		{
			
		}

		public void Insert(int index, object value)
		{
		
		}

		public void Remove(object value)
		{
			
		}

		public bool Contains(object value)
		{
			return false;
		}

		public void Clear()
		{
			
		}

		public int IndexOf(object value)
		{
			return 0;
		}

		public int Add(object value)
		{
		
			return 0;
		}

		public bool IsFixedSize
		{
			get	{ return true; 	}
		}

		#endregion

        #region IEnumerable Members

        public IEnumerator GetEnumerator()
        {
            return new Enumerator(this._array);
        }

        #endregion

		public bool CompareStrings(string s1, string s2)
		{
			return (0 == string.Compare(s1, s2, _dbRoot.IgnoreCase)) ? true : false;
		}

		protected ArrayList _array = new ArrayList();
		protected bool _fieldsBound = false;
	}
}
