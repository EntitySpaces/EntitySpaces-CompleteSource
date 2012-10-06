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
	public class KeyValuePair : IProperty
	{
		private string key = string.Empty;
		private string val = string.Empty;

		public KeyValuePair(string key, string val) 
		{
			this.key = key;
			this.val = val;
		}

		public string Key
		{
			get { return key; }
		}

		public string Value
		{
			get { return val; }
			set { val = value; }
		}

		public bool IsGlobal
		{
			get { return true; }
		}
	}


	/// <summary>
	/// Summary description for KeyValueCollection.
	/// </summary>
	public class KeyValueCollection : IPropertyCollection, IEnumerable, ICollection, IEnumerator
	{
		IEnumerator enumerator;
		Hashtable hash = new Hashtable();

		public KeyValueCollection() {}

		public IProperty this[string key]
		{
			get
			{
				return hash[key] as IProperty;
			}
		}

		public IProperty AddKeyValue(string key, string value)
		{
			KeyValuePair pair = new KeyValuePair(key, value);
			hash[key] = pair;
			return pair;
		}

		public void RemoveKey(string key)
		{
			hash.Remove(key);
		}

		public bool ContainsKey(string key)
		{
			return hash.ContainsKey(key);
		}

		public void Clear()
		{
			hash.Clear();
		}

		
		public void Reset()
		{
			enumerator = null;
		}

		public object Current
		{
			get
			{
				if (enumerator == null) enumerator = this.GetEnumerator();
				IProperty entry =  (IProperty)enumerator.Current;
				return entry; 
			}
		}

		public bool MoveNext()
		{
			if (enumerator == null) enumerator = this.GetEnumerator();
			return enumerator.MoveNext();
		}

		public bool IsSynchronized
		{
			get { return hash.Values.IsSynchronized; }
		}

		public int Count
		{
			get { return hash.Count; }
		}

		public void CopyTo(Array array, int index)
		{
			hash.Values.CopyTo(array, index);
		}

		public object SyncRoot
		{
			get { return hash.Values.SyncRoot; }
		}

		public System.Collections.IEnumerator GetEnumerator()
		{
			return hash.Values.GetEnumerator();
		}
	}
}
