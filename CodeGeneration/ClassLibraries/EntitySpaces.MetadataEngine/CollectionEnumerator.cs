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

namespace MyMeta
{
	/// <summary>
	/// Summary description for CollectionEnumerator.
	/// </summary>
	/// 
#if ENTERPRISE
	using System.Runtime.InteropServices;
	using System.EnterpriseServices;
	[GuidAttribute("3c35ad55-7c6a-4f5f-af6f-340cf4e8b4ea"),ClassInterface(ClassInterfaceType.AutoDual)]
	public class CollectionEnumerator : ServicedComponent, IEnumerator
#else
	public class CollectionEnumerator : IEnumerator
#endif 
	{
		public CollectionEnumerator()
		{

		}

		public void Reset()
		{
			_index = 0;
		}

		// Get's the next object 
		public object Current
		{
			get
			{
				return _array[_index];
			}
		}

		public bool MoveNext()
		{
			if(++_index < _count)
				return true;
			else
				return false;
		}

		public void SetArrayList(ArrayList arrayList)
		{
			_array = new ArrayList();

			foreach(object o in arrayList)
			{
				_array.Add(o);
			}
			_count = _array.Count;
		}

		private ArrayList _array = null;
		private int _index = -1;
		private int _count = 0;
	}
}

