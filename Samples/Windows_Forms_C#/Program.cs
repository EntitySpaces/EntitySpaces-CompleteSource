using System;
using System.Collections.Generic;
#if (LINQ)
using System.Linq;
#endif
using System.Windows.Forms;

using EntitySpaces.Interfaces;
using EntitySpaces.Loader;

namespace WindowsForms
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Register the loader
            esProviderFactory.Factory = new esDataProviderFactory();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

    //      Application.Run(new Hierarchical());
            Application.Run(new Form1());
        }
    }
}
