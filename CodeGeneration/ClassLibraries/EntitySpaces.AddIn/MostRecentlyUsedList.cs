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

using Microsoft.Win32;

namespace EntitySpaces.AddIn
{
    internal class MostRecentlyUsedList : IEnumerable<string>
    {
        private List<string> list = new List<string>(10);

        public MostRecentlyUsedList()
        {
            for (int i = 0; i < 10; i++)
            {
                list.Add(null);
            }
        }

        public void Push(string keyValue)
        {
            if (keyValue != null)
            {
                // Make sure it doesn't already exist
                for (int i = 0; i < 10; i++)
                {
                    if (list[i] != null)
                    {
                        if (list[i].ToLower() == keyValue.ToLower())
                        {
                            Remove(keyValue);
                            break;
                        }
                    }
                }
            }

            // Shift everybody down one
            for (int i = 9; i > 0; i--)
            {
                list[i] = list[i - 1];
            }

            // Add our new guy
            list[0] = keyValue == string.Empty ? null : keyValue;
        }

        public void Remove(string keyValue)
        {
            int index = -1;

            for (int i = 0; i < 10; i++)
            {
                if (list[i] != null)
                {
                    if (list[i].ToLower() == keyValue.ToLower())
                    {
                        index = i;
                        break;
                    }
                }
            }

            if (index != -1)
            {
                for (int i = index; i < 9; i++)
                {
                    list[i] = list[i + 1];
                }

                list[9] = null;
            }
        }

        public void Load(RegistryKey key, string subKey)
        {
            for (int i = 10; i > 0; i--)
            {
                Push((string)key.GetValue(subKey + i.ToString()));
            }
        }

        public void Save(RegistryKey key, string subKey)
        {
            string temp = string.Empty;

            for (int i = 0; i < 10; i++)
            {
                temp = subKey + (i + 1).ToString();
                key.CreateSubKey(temp, RegistryKeyPermissionCheck.ReadWriteSubTree);
                key.SetValue(temp, list[i] == null ? "" : list[i]);
            }
        }

        #region IEnumerable<string> Members

        IEnumerator<string> IEnumerable<string>.GetEnumerator()
        {
            return this.list.GetEnumerator();
        }

        #endregion

        #region IEnumerable Members

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.list.GetEnumerator();
        }

        #endregion
    }
}
