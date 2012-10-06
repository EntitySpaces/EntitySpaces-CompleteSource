using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using EntitySpaces.Core;
using EntitySpaces.Interfaces;
using EntitySpaces.Profiler;

namespace TestAllDatabases
{
    static class Program
    {
        static object esEntity_ModifiedByHandler()
        {
            return "ModifiedBy Client User";
        }

        static object esEntity_AddedByEventHandler()
        {
            return "AddedBy Client User";
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //esProviderFactory.Factory = new EntitySpaces.LoaderMT.esDataProviderFactory();
            esProviderFactory.Factory = new EntitySpaces.Loader.esDataProviderFactory();

            //ProfilerListener.BeginProfiling("EntitySpaces.SqlClientProvider",
            //    ProfilerListener.Channels.Channel_1);
            ProfilerListener.BeginProfiling("EntitySpaces.SQLiteProvider",
                ProfilerListener.Channels.Channel_2);

            esEntity.AddedByEventHandler +=
                      new ModifiedByEventHandler(esEntity_AddedByEventHandler);

            esEntity.ModifiedByEventHandler +=
                      new ModifiedByEventHandler(esEntity_ModifiedByHandler);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
