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
using System.ComponentModel;
using System.Collections.Generic;
using System.Reflection;

using EntitySpaces.Core;
using EntitySpaces.Interfaces;

namespace EntitySpaces.Web.Design
{
    internal class esReflectionHelper : MarshalByRefObject
    {
        public esReflectionHelper()
        {
            AppDomain.CurrentDomain.ReflectionOnlyAssemblyResolve += new ResolveEventHandler(ResolveEventHandler);
        }

        public Dictionary<string, esEntityCollectionBase> GetAllCollections()
        {
            Dictionary<string, esEntityCollectionBase> collections = new Dictionary<string, esEntityCollectionBase>();

            LoadAllAssemblies();

            Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();

            foreach (Assembly assembly in assemblies)
            {
                try
                {
                    Type[] types = assembly.GetExportedTypes();

                    foreach (Type type in types)
                    {
                        if (type.IsClass && !type.IsAbstract)
                        {
                            if(type.IsSubclassOf(typeof(esEntityCollectionBase)))
                            {
                                esEntityCollectionBase coll = Activator.CreateInstance(type) as esEntityCollectionBase;
                                collections[type.Name] = coll;                                
                            }
                        }
                    }
                }
                catch { }
            }

            return collections;
        }

        public Dictionary<string, esEntityCollectionBase> GetCollections(string assemblyName)
        {
            Dictionary<string, esEntityCollectionBase> collections = new Dictionary<string, esEntityCollectionBase>();

            Assembly asm = Assembly.LoadFile(assemblyName);

            Type[] types = asm.GetExportedTypes();

            foreach (Type type in types)
            {
                if (type.IsClass && !type.IsAbstract)
                {
                    if (type.IsSubclassOf(typeof(esEntityCollectionBase)))
                    {
                        esEntityCollectionBase coll = Activator.CreateInstance(type) as esEntityCollectionBase;
                        collections[type.Name] = coll;
                    }
                }
            }
 

            return collections;
        }

        public Dictionary<string, esEntityCollectionBase> GetCollectionsFromAppCode()
        {
            Dictionary<string, esEntityCollectionBase> collections = new Dictionary<string, esEntityCollectionBase>();

            Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();

            foreach (Assembly assembly in assemblies)
            {
                try
                {
                    Type[] types = assembly.GetExportedTypes();

                    foreach (Type type in types)
                    {
                        if (type.IsClass && !type.IsAbstract)
                        {
                            if (type.IsSubclassOf(typeof(esEntityCollectionBase)))
                            {
                                esEntityCollectionBase coll = Activator.CreateInstance(type) as esEntityCollectionBase;
                                collections[type.Name] = coll;
                            }
                        }
                    }
                }
                catch { }
            }

            return collections;
        }


        private void LoadAllAssemblies()
        {
            AppDomain.CurrentDomain.ReflectionOnlyAssemblyResolve += new ResolveEventHandler(ResolveEventHandler);
            AppDomain.CurrentDomain.ReflectionOnlyGetAssemblies();

            Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();

            foreach (Assembly assembly in assemblies)
            {
                try
                {
               //   Assembly.ReflectionOnlyLoad(name.Name);
                    Assembly.Load(assembly.GetName());
                }
                catch { }
            }
        }

        public esColumnMetadataCollection GetColumns(esEntityCollectionBase collection)
        {
            collection.EnableHierarchicalBinding = false;

            PropertyDescriptorCollection props = null;

            try
            {
                MethodInfo GetEntity = collection.GetType().GetMethod("CreateEntity", BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);
                esEntity entity = GetEntity.Invoke(collection, null) as esEntity;

                MethodInfo GetProperties = collection.GetType().GetMethod("GetProperties", BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);
                props = GetProperties.Invoke(collection, new object[] { entity }) as PropertyDescriptorCollection;
            }
            catch { }

            MethodInfo get_Meta = collection.GetType().GetMethod("get_Meta", BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);
            IMetadata meta = get_Meta.Invoke(collection, null) as IMetadata;
            esColumnMetadataCollection esColumns =  meta.Columns;

            esColumnMetadataCollection esCollection = new esColumnMetadataCollection();
            try
            {
                foreach (esColumnMetadata col in esColumns)
                {
                    esCollection.Add(col);
                }
            }
            catch { }

            try
            {
                if (props != null)
                {
                    esExtendedPropertyAttribute att = new esExtendedPropertyAttribute();
                    foreach (PropertyDescriptor prop in props)
                    {
                        if (esColumns.FindByPropertyName(prop.Name) == null)
                        {
                            if (prop.Attributes.Contains(att))
                            {
                                esColumnMetadata col = new esColumnMetadata(prop.Name, 1000, prop.PropertyType);
                                col.PropertyName = prop.Name;
                                esCollection.Add(col);
                            }
                        }
                    }
                }
            }
            catch { }

            return esCollection;
        }

        Assembly ResolveEventHandler(object o, ResolveEventArgs args)
        {
            return Assembly.Load(args.Name);
        }
    }
}
