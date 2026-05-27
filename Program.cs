using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using McClean_Teeth.Database;

namespace McClean_Teeth
{
    internal static class Program
    {
        public static McClean_Teeth.Database.Database database;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            database = new McClean_Teeth.Database.Database();
            Application.Run(new AuthForm());
        }
    }
}
