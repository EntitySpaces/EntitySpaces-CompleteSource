using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using EntitySpaces.Core;
using EntitySpaces.Profiler;

namespace TestSqlServer35
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
            EntitySpaces.Interfaces.esProviderFactory.Factory =
                new EntitySpaces.Loader.esDataProviderFactory();

            //ProfilerListener.BeginProfiling("EntitySpaces.SqlClientProvider",
            //    ProfilerListener.Channels.Channel_1);

            esEntity.AddedByEventHandler +=  
                      new ModifiedByEventHandler(esEntity_AddedByEventHandler); 
             
            esEntity.ModifiedByEventHandler +=  
                      new ModifiedByEventHandler(esEntity_ModifiedByHandler);
             
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormMain());
        }
    }
}
