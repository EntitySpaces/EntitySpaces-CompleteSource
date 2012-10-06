//======================================
// Copyright EntitySpaces, LLC 2005 - 2006 
//======================================

using System;
using System.Data;
using NUnit.Framework;

using EntitySpaces.Interfaces;
using BusinessObjects;

namespace Tests.Base
{
    [TestFixture]
    public class CustomFieldsFixture
    {
        [Test]
        public void ServerSide()
        {
            int keyId = -1;
            CustomFieldsServerCollection coll = new CustomFieldsServerCollection();

            switch (coll.es.Connection.ProviderSignature.DataProviderName)
            {
                case "EntitySpaces.EffiProzProvider":
                    Assert.Ignore("Not implemented");
                    break;

                default:
                    using (esTransactionScope scope = new esTransactionScope())
                    {
                        // Setup
                        CustomFieldsServer entity = new CustomFieldsServer();

                        entity = new CustomFieldsServer();
                        entity.FirstName = "Test";
                        entity.LastName = "One";

                        // Insert
                        entity.Save();
                        keyId = entity.AutoKey.Value;

                        Assert.AreEqual(entity.FirstName, "Test");
                        Assert.AreEqual(entity.LastName, "One");
                        Assert.AreEqual(entity.Age.Value, 10);
                        Assert.AreEqual(entity.DateAdded.Value.Day, DateTime.UtcNow.Day);
                        Assert.AreEqual(entity.DateModified.Value.Day, DateTime.UtcNow.Day);
                        Assert.AreEqual(entity.AddedBy, "CustomUser");
                        Assert.AreEqual(entity.ModifiedBy, "CustomUser");
                        Assert.AreEqual(entity.EsVersion.Value, 1);

                        // Update
                        entity = new CustomFieldsServer();
                        entity.LoadByPrimaryKey(keyId);

                        Assert.AreEqual(entity.FirstName, "Test");
                        Assert.AreEqual(entity.LastName, "One");
                        Assert.AreEqual(entity.Age.Value, 10);
                        Assert.AreEqual(entity.DateAdded.Value.Day, DateTime.UtcNow.Day);
                        Assert.AreEqual(entity.DateModified.Value.Day, DateTime.UtcNow.Day);
                        Assert.AreEqual(entity.AddedBy, "CustomUser");
                        Assert.AreEqual(entity.ModifiedBy, "CustomUser");
                        Assert.AreEqual(entity.EsVersion.Value, 1);

                        DateTime modified = entity.DateModified.Value;
                        entity.LastName = "Two";
                        System.Threading.Thread.Sleep(4);
                        entity.Save();

                        Assert.AreEqual(entity.FirstName, "Test");
                        Assert.AreEqual(entity.LastName, "Two");
                        Assert.AreEqual(entity.Age.Value, 10);
                        Assert.AreEqual(entity.DateAdded.Value.Day, DateTime.UtcNow.Day);
                        Assert.AreEqual(entity.DateModified.Value.Day, DateTime.UtcNow.Day);
                        Assert.Greater(entity.DateModified.Value, modified);
                        Assert.AreEqual(entity.AddedBy, "CustomUser");
                        Assert.AreEqual(entity.ModifiedBy, "CustomUser");
                        Assert.AreEqual(entity.EsVersion.Value, 2);

                        // No Update
                        entity = new CustomFieldsServer();
                        entity.LoadByPrimaryKey(keyId);
                        DateTime added = entity.DateAdded.Value;
                        modified = entity.DateModified.Value;

                        entity.Save();

                        Assert.AreEqual(entity.FirstName, "Test");
                        Assert.AreEqual(entity.LastName, "Two");
                        Assert.AreEqual(entity.Age.Value, 10);
                        Assert.AreEqual(entity.DateAdded.Value, added);
                        Assert.AreEqual(entity.DateModified.Value, modified);
                        Assert.AreEqual(entity.AddedBy, "CustomUser");
                        Assert.AreEqual(entity.ModifiedBy, "CustomUser");
                        Assert.AreEqual(entity.EsVersion.Value, 2);

                        // Clean up
                        entity = new CustomFieldsServer();
                        entity.LoadByPrimaryKey(keyId);

                        Assert.AreEqual(entity.FirstName, "Test");
                        Assert.AreEqual(entity.LastName, "Two");
                        Assert.AreEqual(entity.Age.Value, 10);
                        Assert.AreEqual(entity.DateAdded.Value, added);
                        Assert.AreEqual(entity.DateModified.Value, modified);
                        Assert.AreEqual(entity.AddedBy, "CustomUser");
                        Assert.AreEqual(entity.ModifiedBy, "CustomUser");
                        Assert.AreEqual(entity.EsVersion.Value, 2);

                        entity.MarkAsDeleted();
                        entity.Save();

                        entity = new CustomFieldsServer();
                        if (entity.LoadByPrimaryKey(keyId))
                        {
                            Assert.Fail("Not deleted");
                        }
                    }
                    break;
            }
        }

        [Test]
        public void ServerSideAliased()
        {
            int keyId = -1;
            CustomServerAliasedCollection coll = new CustomServerAliasedCollection();

            switch (coll.es.Connection.ProviderSignature.DataProviderName)
            {
                case "EntitySpaces.EffiProzProvider":
                    Assert.Ignore("Not implemented");
                    break;

                default:
                    using (esTransactionScope scope = new esTransactionScope())
                    {
                        // Setup
                        CustomServerAliased entity = new CustomServerAliased();

                        entity = new CustomServerAliased();
                        entity.FirstName = "Test";
                        entity.LastName = "One";

                        // Insert
                        entity.Save();
                        keyId = entity.AutoKey.Value;

                        Assert.AreEqual(entity.FirstName, "Test");
                        Assert.AreEqual(entity.LastName, "One");
                        Assert.AreEqual(entity.Age.Value, 30);
                        Assert.AreEqual(entity.DateAdded.Value.Day, DateTime.UtcNow.Day);
                        Assert.AreEqual(entity.DateModifiedAlias.Value.Day, DateTime.UtcNow.Day);
                        Assert.AreEqual(entity.AddedByAlias, "CustomUser");
                        Assert.AreEqual(entity.ModifiedBy, "CustomUser");
                        Assert.AreEqual(entity.EsVersion.Value, 1);

                        // Update
                        entity = new CustomServerAliased();
                        entity.LoadByPrimaryKey(keyId);

                        Assert.AreEqual(entity.FirstName, "Test");
                        Assert.AreEqual(entity.LastName, "One");
                        Assert.AreEqual(entity.Age.Value, 30);
                        Assert.AreEqual(entity.DateAdded.Value.Day, DateTime.UtcNow.Day);
                        Assert.AreEqual(entity.DateModifiedAlias.Value.Day, DateTime.UtcNow.Day);
                        Assert.AreEqual(entity.AddedByAlias, "CustomUser");
                        Assert.AreEqual(entity.ModifiedBy, "CustomUser");
                        Assert.AreEqual(entity.EsVersion.Value, 1);

                        DateTime modified = entity.DateModifiedAlias.Value;
                        entity.LastName = "Two";
                        System.Threading.Thread.Sleep(4);
                        entity.Save();

                        Assert.AreEqual(entity.FirstName, "Test");
                        Assert.AreEqual(entity.LastName, "Two");
                        Assert.AreEqual(entity.Age.Value, 30);
                        Assert.AreEqual(entity.DateAdded.Value.Day, DateTime.UtcNow.Day);
                        Assert.AreEqual(entity.DateModifiedAlias.Value.Day, DateTime.UtcNow.Day);
                        Assert.Greater(entity.DateModifiedAlias.Value, modified);
                        Assert.AreEqual(entity.AddedByAlias, "CustomUser");
                        Assert.AreEqual(entity.ModifiedBy, "CustomUser");
                        Assert.AreEqual(entity.EsVersion.Value, 2);

                        // No Update
                        entity = new CustomServerAliased();
                        entity.LoadByPrimaryKey(keyId);
                        DateTime added = entity.DateAdded.Value;
                        modified = entity.DateModifiedAlias.Value;

                        entity.Save();

                        Assert.AreEqual(entity.FirstName, "Test");
                        Assert.AreEqual(entity.LastName, "Two");
                        Assert.AreEqual(entity.Age.Value, 30);
                        Assert.AreEqual(entity.DateAdded.Value, added);
                        Assert.AreEqual(entity.DateModifiedAlias.Value, modified);
                        Assert.AreEqual(entity.AddedByAlias, "CustomUser");
                        Assert.AreEqual(entity.ModifiedBy, "CustomUser");
                        Assert.AreEqual(entity.EsVersion.Value, 2);

                        // Clean up
                        entity = new CustomServerAliased();
                        entity.LoadByPrimaryKey(keyId);

                        Assert.AreEqual(entity.FirstName, "Test");
                        Assert.AreEqual(entity.LastName, "Two");
                        Assert.AreEqual(entity.Age.Value, 30);
                        Assert.AreEqual(entity.DateAdded.Value, added);
                        Assert.AreEqual(entity.DateModifiedAlias.Value, modified);
                        Assert.AreEqual(entity.AddedByAlias, "CustomUser");
                        Assert.AreEqual(entity.ModifiedBy, "CustomUser");
                        Assert.AreEqual(entity.EsVersion.Value, 2);

                        entity.MarkAsDeleted();
                        entity.Save();

                        entity = new CustomServerAliased();
                        if (entity.LoadByPrimaryKey(keyId))
                        {
                            Assert.Fail("Not deleted");
                        }
                    }
                    break;
            }
        }

        [Test]
        public void ClientSide()
        {
            int keyId = -1;
            CustomFieldsClientCollection coll = new CustomFieldsClientCollection();

            switch (coll.es.Connection.ProviderSignature.DataProviderName)
            {
                case "EntitySpaces.EffiProzProvider":
                    Assert.Ignore("Not implemented");
                    break;

                default:
                    using (esTransactionScope scope = new esTransactionScope())
                    {
                        // Setup
                        CustomFieldsClient entity = new CustomFieldsClient();

                        entity = new CustomFieldsClient();
                        entity.FirstName = "Test";
                        entity.LastName = "One";

                        // Insert
                        entity.Save();
                        keyId = entity.AutoKey.Value;

                        Assert.AreEqual(entity.FirstName, "Test");
                        Assert.AreEqual(entity.LastName, "One");
                        Assert.AreEqual(entity.Age.Value, 20);
                        Assert.AreEqual(entity.DateAdded.Value.Day, DateTime.UtcNow.Day);
                        Assert.AreEqual(entity.DateModified.Value.Day, DateTime.UtcNow.Day);
                        Assert.AreEqual(entity.AddedBy, "AddedBy Client User");
                        Assert.AreEqual(entity.ModifiedBy, "ModifiedBy Client User");
                        Assert.AreEqual(entity.EsVersion.Value, 1);

                        // Update
                        entity = new CustomFieldsClient();
                        entity.LoadByPrimaryKey(keyId);

                        Assert.AreEqual(entity.FirstName, "Test");
                        Assert.AreEqual(entity.LastName, "One");
                        Assert.AreEqual(entity.Age.Value, 20);
                        Assert.AreEqual(entity.DateAdded.Value.Day, DateTime.UtcNow.Day);
                        Assert.AreEqual(entity.DateModified.Value.Day, DateTime.UtcNow.Day);
                        Assert.AreEqual(entity.AddedBy, "AddedBy Client User");
                        Assert.AreEqual(entity.ModifiedBy, "ModifiedBy Client User");
                        Assert.AreEqual(entity.EsVersion.Value, 1);

                        DateTime modified = entity.DateModified.Value;
                        entity.LastName = "Two";
                        System.Threading.Thread.Sleep(4);
                        entity.Save();

                        Assert.AreEqual(entity.FirstName, "Test");
                        Assert.AreEqual(entity.LastName, "Two");
                        Assert.AreEqual(entity.Age.Value, 20);
                        Assert.AreEqual(entity.DateAdded.Value.Day, DateTime.UtcNow.Day);
                        Assert.AreEqual(entity.DateModified.Value.Day, DateTime.UtcNow.Day);
                        Assert.Greater(entity.DateModified.Value, modified);
                        Assert.AreEqual(entity.AddedBy, "AddedBy Client User");
                        Assert.AreEqual(entity.ModifiedBy, "ModifiedBy Client User");
                        Assert.AreEqual(entity.EsVersion.Value, 2);

                        // No Update
                        entity = new CustomFieldsClient();
                        entity.LoadByPrimaryKey(keyId);
                        DateTime added = entity.DateAdded.Value;
                        modified = entity.DateModified.Value;

                        entity.Save();

                        Assert.AreEqual(entity.FirstName, "Test");
                        Assert.AreEqual(entity.LastName, "Two");
                        Assert.AreEqual(entity.Age.Value, 20);
                        Assert.AreEqual(entity.DateAdded.Value, added);
                        Assert.AreEqual(entity.DateModified.Value, modified);
                        Assert.AreEqual(entity.AddedBy, "AddedBy Client User");
                        Assert.AreEqual(entity.ModifiedBy, "ModifiedBy Client User");
                        Assert.AreEqual(entity.EsVersion.Value, 2);

                        // Clean up
                        entity = new CustomFieldsClient();
                        entity.LoadByPrimaryKey(keyId);

                        Assert.AreEqual(entity.FirstName, "Test");
                        Assert.AreEqual(entity.LastName, "Two");
                        Assert.AreEqual(entity.Age.Value, 20);
                        Assert.AreEqual(entity.DateAdded.Value, added);
                        Assert.AreEqual(entity.DateModified.Value, modified);
                        Assert.AreEqual(entity.AddedBy, "AddedBy Client User");
                        Assert.AreEqual(entity.ModifiedBy, "ModifiedBy Client User");
                        Assert.AreEqual(entity.EsVersion.Value, 2);

                        entity.MarkAsDeleted();
                        entity.Save();

                        entity = new CustomFieldsClient();
                        if (entity.LoadByPrimaryKey(keyId))
                        {
                            Assert.Fail("Not deleted");
                        }
                    }
                    break;
            }
        }

        [Test]
        public void ClientSideAliased()
        {
            int keyId = -1;
            CustomClientAliasedCollection coll = new CustomClientAliasedCollection();

            switch (coll.es.Connection.ProviderSignature.DataProviderName)
            {
                case "EntitySpaces.EffiProzProvider":
                    Assert.Ignore("Not implemented");
                    break;

                default:
                    using (esTransactionScope scope = new esTransactionScope())
                    {
                        // Setup
                        CustomClientAliased entity = new CustomClientAliased();

                        entity = new CustomClientAliased();
                        entity.FirstName = "Test";
                        entity.LastName = "One";

                        // Insert
                        entity.Save();
                        keyId = entity.AutoKey.Value;

                        Assert.AreEqual(entity.FirstName, "Test");
                        Assert.AreEqual(entity.LastName, "One");
                        Assert.AreEqual(entity.Age.Value, 40);
                        Assert.AreEqual(entity.DateAddedAlias.Value.Day, DateTime.UtcNow.Day);
                        Assert.AreEqual(entity.DateModified.Value.Day, DateTime.UtcNow.Day);
                        Assert.AreEqual(entity.AddedBy, "AddedBy Client User");
                        Assert.AreEqual(entity.ModifiedByAlias, "ModifiedBy Client User");
                        Assert.AreEqual(entity.EsVersion.Value, 1);

                        // Update
                        entity = new CustomClientAliased();
                        entity.LoadByPrimaryKey(keyId);

                        Assert.AreEqual(entity.FirstName, "Test");
                        Assert.AreEqual(entity.LastName, "One");
                        Assert.AreEqual(entity.Age.Value, 40);
                        Assert.AreEqual(entity.DateAddedAlias.Value.Day, DateTime.UtcNow.Day);
                        Assert.AreEqual(entity.DateModified.Value.Day, DateTime.UtcNow.Day);
                        Assert.AreEqual(entity.AddedBy, "AddedBy Client User");
                        Assert.AreEqual(entity.ModifiedByAlias, "ModifiedBy Client User");
                        Assert.AreEqual(entity.EsVersion.Value, 1);

                        DateTime modified = entity.DateModified.Value;
                        entity.LastName = "Two";
                        System.Threading.Thread.Sleep(4);
                        entity.Save();

                        Assert.AreEqual(entity.FirstName, "Test");
                        Assert.AreEqual(entity.LastName, "Two");
                        Assert.AreEqual(entity.Age.Value, 40);
                        Assert.AreEqual(entity.DateAddedAlias.Value.Day, DateTime.UtcNow.Day);
                        Assert.AreEqual(entity.DateModified.Value.Day, DateTime.UtcNow.Day);
                        Assert.Greater(entity.DateModified.Value, modified);
                        Assert.AreEqual(entity.AddedBy, "AddedBy Client User");
                        Assert.AreEqual(entity.ModifiedByAlias, "ModifiedBy Client User");
                        Assert.AreEqual(entity.EsVersion.Value, 2);

                        // No Update
                        entity = new CustomClientAliased();
                        entity.LoadByPrimaryKey(keyId);
                        DateTime added = entity.DateAddedAlias.Value;
                        modified = entity.DateModified.Value;

                        entity.Save();

                        Assert.AreEqual(entity.FirstName, "Test");
                        Assert.AreEqual(entity.LastName, "Two");
                        Assert.AreEqual(entity.Age.Value, 40);
                        Assert.AreEqual(entity.DateAddedAlias.Value, added);
                        Assert.AreEqual(entity.DateModified.Value, modified);
                        Assert.AreEqual(entity.AddedBy, "AddedBy Client User");
                        Assert.AreEqual(entity.ModifiedByAlias, "ModifiedBy Client User");
                        Assert.AreEqual(entity.EsVersion.Value, 2);

                        // Clean up
                        entity = new CustomClientAliased();
                        entity.LoadByPrimaryKey(keyId);

                        Assert.AreEqual(entity.FirstName, "Test");
                        Assert.AreEqual(entity.LastName, "Two");
                        Assert.AreEqual(entity.Age.Value, 40);
                        Assert.AreEqual(entity.DateAddedAlias.Value, added);
                        Assert.AreEqual(entity.DateModified.Value, modified);
                        Assert.AreEqual(entity.AddedBy, "AddedBy Client User");
                        Assert.AreEqual(entity.ModifiedByAlias, "ModifiedBy Client User");
                        Assert.AreEqual(entity.EsVersion.Value, 2);

                        entity.MarkAsDeleted();
                        entity.Save();

                        entity = new CustomClientAliased();
                        if (entity.LoadByPrimaryKey(keyId))
                        {
                            Assert.Fail("Not deleted");
                        }
                    }
                    break;
            }
        }
    }
}
