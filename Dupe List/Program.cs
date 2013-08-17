using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace DupeList
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            BrowseFolder bf = new BrowseFolder();
            bf.Show();
            Application.Run();
        }
    }
}
