using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

using FormsDriver.Forms;
using FormsDriver.Controllers;

namespace FormsDriver
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
            //Application.Run(new DataGridTester());
            //Application.Run(new StartHere());
            CatHerder controller = new CatHerder();
            controller.HerdCats();
        }
    }
}
