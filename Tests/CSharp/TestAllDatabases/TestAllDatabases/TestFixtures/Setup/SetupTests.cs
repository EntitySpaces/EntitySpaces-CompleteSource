//======================================
// Copyright EntitySpaces, LLC 2005 - 2006 
//======================================

using System;
using System.Data;

using NUnit.Framework;
using BusinessObjects;
using EntitySpaces.Core;
using EntitySpaces.Interfaces;
using EntitySpaces.Profiler;

namespace Tests.Base
{
    [SetUpFixture]
	public class SetupTests
	{
        static object esEntity_ModifiedByHandler()
        {
            return "ModifiedBy Client User";
        }

        static object esEntity_AddedByEventHandler()
        {
            return "AddedBy Client User";
        }

        [SetUp]
        public void Init()
		{
            //esProviderFactory.Factory = new EntitySpaces.LoaderMT.esDataProviderFactory();
            esProviderFactory.Factory = new EntitySpaces.Loader.esDataProviderFactory();

            //ProfilerListener.BeginProfiling("EntitySpaces.SqlClientProvider",
            //    ProfilerListener.Channels.Channel_1);

            esEntity.AddedByEventHandler +=
                      new ModifiedByEventHandler(esEntity_AddedByEventHandler);

            esEntity.ModifiedByEventHandler +=
                      new ModifiedByEventHandler(esEntity_ModifiedByHandler);

            UnitTestBase.RefreshDatabase();
            UnitTestBase.RefreshForeignKeyTest();
        }
	}
}
