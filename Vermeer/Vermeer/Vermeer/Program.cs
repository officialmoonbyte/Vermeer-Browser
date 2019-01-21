using Moonbyte.Vermeer.bin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Moonbyte.Vermeer
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Setting application visual styles
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //Running Vermeer startup events
            vermeer.ExecuteStartupEvents();

            //Opens the main form
            vermeer.Open(VermeerPages.Mainform);

            //Runs the application loop
            Application.Run();
        }
    }
}
