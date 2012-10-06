//======================================
// Copyright EntitySpaces, LLC 2005 - 2006 
//======================================

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
	#region Custom View Tests

	public partial class FullNameViewCollection : esFullNameViewCollection
	{
		public bool CustomLoadFromView()
		{
			string sqlText = "";

			switch (this.es.Connection.ProviderMetadataKey)
			{
				case "esOracle":
					sqlText = "SELECT \"FullName\", \"DepartmentID\", \"HireDate\" ";
					sqlText += "FROM \"MYGENERATION\".\"FullNameView\" ";
					sqlText += "WHERE \"DepartmentID\" = {0} ";
					sqlText += "OR \"DepartmentID\" = {1} ";

                    break;

                case "esPgsql":
                    sqlText = "SELECT \"FullName\", \"DepartmentID\", \"HireDate\" ";
                    sqlText += "FROM \"FullNameView\" ";
                    sqlText += "WHERE \"DepartmentID\" = {0} ";
                    sqlText += "OR \"DepartmentID\" = {1} ";

                    break;

                case "esMySQL":
					sqlText = "SELECT `FullName`, `DepartmentID`, `HireDate` ";
					sqlText += "FROM `FullNameView` ";
					sqlText += "WHERE `DepartmentID` = {0} ";
					sqlText += "OR `DepartmentID` = {1}";

                    break;

				default:
					sqlText = "SELECT [FullName], [DepartmentID], [HireDate] ";
					sqlText += "FROM [FullNameView] ";
					sqlText += "WHERE [DepartmentID] = {0} ";
					sqlText += "OR [DepartmentID] = {1}";

                    break;
            }

            return this.Load(esQueryType.Text, sqlText, 1, 2);
        }

		public bool CustomLoadFromViewNoParams(string whereClause)
		{
			string sqlText = "";

			switch (this.es.Connection.ProviderMetadataKey)
			{
				case "esOracle":
					sqlText = "SELECT \"FullName\", \"DepartmentID\", \"HireDate\" ";
					sqlText += "FROM \"MYGENERATION\".\"FullNameView\" ";
					sqlText += whereClause;

                    break;

                case "esPgsql":
                    sqlText = "SELECT \"FullName\", \"DepartmentID\", \"HireDate\" ";
                    sqlText += "FROM \"FullNameView\" ";
                    sqlText += whereClause;

                    break;

                case "esMySQL":
					sqlText = "SELECT `FullName`, `DepartmentID`, `HireDate` ";
					sqlText += "FROM `FullNameView` ";
					sqlText += whereClause;

                    break;

				default:
					sqlText = "SELECT [FullName], [DepartmentID], [HireDate] ";
					sqlText += "FROM [FullNameView] ";
					sqlText += whereClause;

                    break;
            }

            return this.Load(esQueryType.Text, sqlText);
        }

        public bool CustomLoadFromViewByDept(int deptID)
        {
            this.Query.Where(
                this.Query.DepartmentID == deptID);

            return this.Query.Load();
        }
	}
	#endregion
}
