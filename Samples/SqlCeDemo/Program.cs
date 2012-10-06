using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;

using EntitySpaces.Interfaces;

namespace SqlCeDemo
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [MTAThread]
        static void Main()
        {
            esProviderFactory.Factory = new EntitySpaces.Loader.esDataProviderFactory();

            //// Just make sure we have a hard reference to the VistaDB Compact Framework Library
            //VistaDB.TriggerAction t = TriggerAction.AfterDelete;

            string cnString = ("Data Source = " + (System.IO.Path.GetDirectoryName
             (System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase) +
             "\\ForeignKeyTest_35.sdf;"));

            // What the heck let's register a second connection
            esConnectionElement conn = new esConnectionElement();
            conn.ConnectionString = cnString;
            conn.Name = "SqlCE";
            conn.Provider = "EntitySpaces.SqlServerCeProvider.CF";
            conn.ProviderClass = "DataProvider";
            conn.SqlAccessType = esSqlAccessType.DynamicSQL;
            conn.ProviderMetadataKey = "esDefault";
            esConfigSettings.ConnectionInfo.Connections.Add(conn);

            // Assign the Default Connection
            esConfigSettings.ConnectionInfo.Default = "SqlCE";

            Application.Run(new Form1());
        }
    }
}