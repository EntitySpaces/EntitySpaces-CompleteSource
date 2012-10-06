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
	public interface IProviderType 
	{
		string Type { get; }
		System.Int32 DataType { get; }
		System.Int32 ColumnSize { get; }
		string LiteralPrefix { get; }
		string LiteralSuffix { get; }
		string CreateParams { get; }
		System.Boolean IsNullable { get; }
		System.Boolean IsCaseSensitive { get; }
		string Searchable { get; } // convert
		System.Boolean IsUnsigned { get; }
		System.Boolean HasFixedPrecScale { get; }
		System.Boolean CanBeAutoIncrement { get; }
		string LocalType { get; }
		System.Int32 MinimumScale { get; }
		System.Int32 MaximumScale { get; }
		Guid TypeGuid { get; }
		string TypeLib { get; }
		string Version { get; }
		System.Boolean IsLong { get; }
		System.Boolean BestMatch { get; }
		System.Boolean IsFixedLength { get; }
	}
}

