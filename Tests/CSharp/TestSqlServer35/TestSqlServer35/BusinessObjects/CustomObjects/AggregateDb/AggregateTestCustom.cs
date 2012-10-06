/*
===============================================================================
                     EntitySpaces(TM) by EntitySpaces, LLC
                 A New 2.0 Architecture for the .NET Framework
                          http://www.entityspaces.net
===============================================================================
                       EntitySpaces Version # 2007.0.0730.0
                       MyGeneration Version # 1.2.0.7
                           7/30/2007 5:51:12 PM
-------------------------------------------------------------------------------
*/


using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Text;
using System.Data;

using EntitySpaces.Interfaces;
using EntitySpaces.Core;
using EntitySpaces.DynamicQuery;

namespace BusinessObjects
{
    public partial class AggregateTest : esAggregateTest
    {
        #region Custom Entity Tests

        public AggregateTest(string connectionName)
        {
            this.es.Connection.Name = connectionName;
        }

        public DataTable ExposeDataTable()
        {
            return null; // this.Table;
        }

        public void SaveUpdateOrInsert(int id, string lName)
        {
            this.Query.Where(this.Query.Id == id);
            this.Query.Load();

            this.LastName = lName;
            this.Save();
        }

        //public Int32? NewId
        //{
        //    get
        //    {
        //        return base.GetSystemInt32("NewId");
        //    }
        //    set
        //    {
        //        base.SetSystemInt32("NewId", value);
        //    }
        //}

        //public int? OrderIndex
        //{
        //    get
        //    {
        //        return base.GetSystemInt32("OrderIndex");
        //    }
        //    set
        //    {
        //        if (this.RowState == esDataRowState.Unchanged)
        //        {
        //            base.SetSystemInt32("OrderIndex", value);
        //            this.AcceptChanges();
        //        }
        //        else
        //        {
        //            base.SetSystemInt32("OrderIndex", value);
        //        }
        //    }
        //}

        public bool CustomLoadSP(int aggId)
        {
            esParameters esParams = new esParameters();
            esParams.Add("pId", aggId);
            return this.Load(esQueryType.StoredProcedure,
                "ESAGGREGATETESTLOADBYPK", esParams);
        }

        public bool GetAutoKey()
        {
            if (this.Meta.Columns["ID"].IsAutoIncrement)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void ToggleAutoKey()
        {
            if (this.Meta.Columns["ID"].IsAutoIncrement)
            {
                this.Meta.Columns["ID"].IsAutoIncrement = false;
            }
            else
            {
                this.Meta.Columns["ID"].IsAutoIncrement = true;
            }
        }

        public void WriteMetadata()
        {
            esProviderSpecificMetadata spec = this.Meta.GetProviderMetadata("esDefault");

            foreach (esColumnMetadata col in this.Meta.Columns)
            {
                Console.WriteLine("PropertyName: " + col.PropertyName);
                Console.WriteLine("ColumnName : " + col.Name);
                Console.WriteLine("CharLength : " + col.CharacterMaxLength.ToString());

                esTypeMap map = spec.GetTypeMap(col.Name);

                Console.WriteLine("Native Type : " + map.NativeType);
                Console.WriteLine("System Type : " + map.SystemType);
                Console.WriteLine("---------------------------------");
            }
        }

        public void SetSchema(string schemaName)
        {
            esProviderSpecificMetadata spec = this.Meta.GetProviderMetadata("esDefault");
            spec.Schema = schemaName;
        }

        public bool AllColumnsAreDirty(esDataRowState state)
        {
            if (this.es.ModifiedColumns.Count == 8 &&
                this.RowState == state)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool AllColumnsAreNotDirty()
        {
            if (this.es.ModifiedColumns.Count == 0 && this.RowState == esDataRowState.Unchanged)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void EntityInsert(bool useES)
        {
            esParameters esParams = new esParameters();
            esParams.Add("ID", this.Id, esParameterDirection.Output,
                DbType.Int32, 0);
            esParams.Add("DepartmentID", this.DepartmentID);
            esParams.Add("LastName", this.LastName);
            esParams.Add("FirstName", this.FirstName);
            esParams.Add("Age", this.Age);
            esParams.Add("HireDate", this.HireDate);
            esParams.Add("Salary", this.Salary);
            esParams.Add("IsActive", this.IsActive);

            if (useES)
            {
                this.ExecuteNonQuery(esQueryType.StoredProcedure,
                    "proc_AggregateTestInsert", esParams);
            }
            else
            {
                this.ExecuteNonQuery(esQueryType.StoredProcedure,
                    "proc_AggregateTestEntityInsert", esParams);
            }
        }

        //public class MaxLength
        //{
        //    static public long LastName
        //    {
        //        get
        //        {
        //            AggregateTest _entity = new AggregateTest();
        //            return _entity.Meta.Columns["LastName"].CharacterMaxLength;
        //        }
        //    }

        //    static public long FirstName
        //    {
        //        get
        //        {
        //            AggregateTest _entity = new AggregateTest();
        //            return _entity.Meta.Columns["FirstName"].CharacterMaxLength;
        //        }
        //    }
        //}

        public override void Save()
        {
            if (this.es.IsDirty)
            {
                if (this.Validate())
                {
                    base.Save();
                }
                else
                {
                    // Do something
                }
            }
        }

        public bool Validate()
        {
            if (this.Age > 100)
            {
                return false;
            }
            else
            {
                return true;
            }

            //if (entity.es.IsDeleted)
            //{
            //    // Do something
            //    bool didWeReachthis = true;
            //}

            //if (entity.RowState == esDataRowState.Added)
            //{
            //    if (entity.Age >= 18)
            //    {
            //        entity.IsActive = true;
            //    }
            //    else
            //    {
            //        entity.IsActive = false;
            //    }

                //if (entity.Salary.HasValue)
                //{
                //    AggregateTestCollection collection = new AggregateTestCollection();
                //    collection.Query.Where(collection.Query.Salary.Equal(entity.Salary.Value));
                //    collection.Query.Load();
                //    if (collection.Count > 0)
                //    {
                //        throw new Exception("Sorry, that salary has been taken.");
                //    }
                //}
            //}
        }

        //public override System.Decimal? Salary 
        //{
        //    get { return base.Salary; } 
        //    set 
        //    {
        //        if (value.HasValue)
        //        {
        //            AggregateTestCollection collection = new AggregateTestCollection();
        //            collection.Query.Where(collection.Query.Salary.Equal(value.Value));
        //            collection.Query.Load();
        //            if (collection.Count > 0)
        //            {
        //                throw new Exception("Sorry, that salary has been taken.");
        //            }
        //        }
        //        base.Salary = value;
        //    } 
        //}

        //public override string LastName
        //{
        //    get
        //    {
        //        return base.LastName;
        //    }
        //    set
        //    {
        //        long len = this.Meta.Columns["LastName"].CharacterMaxLength;
        //        if (value == null || value.Length <= len)
        //        {
        //            base.LastName = value;
        //        }
        //        else
        //        {
        //            // Too much data
        //            base.LastName = value.Substring(0, (int)len);
        //        }
        //    }
        //}

        //public override void AddNew()
        //{
        //    base.AddNew();
        //}
    }

        #endregion

    #region Test read-only property template
    //public new System.Int32? Id
    //{
    //    get
    //    {
    //        return base.Id;
    //    }
    //}
    //public new System.Int32? DepartmentID
    //{
    //    get
    //    {
    //        return base.DepartmentID;
    //    }
    //}
    //public new System.String FirstName
    //{
    //    get
    //    {
    //        return base.FirstName;
    //    }
    //}
    //public new System.String LastName
    //{
    //    get
    //    {
    //        return base.LastName;
    //    }
    //}
    //public new System.Int32? Age
    //{
    //    get
    //    {
    //        return base.Age;
    //    }
    //}
    //public new System.DateTime? HireDate
    //{
    //    get
    //    {
    //        return base.HireDate;
    //    }
    //}
    //public new System.Decimal? Salary
    //{
    //    get
    //    {
    //        return base.Salary;
    //    }
    //}
    //public new System.Boolean? IsActive
    //{
    //    get
    //    {
    //        return base.IsActive;
    //    }
    //}

    # endregion
}
