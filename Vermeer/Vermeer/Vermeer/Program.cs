using Moonbyte.Vermeer.bin;
using System;
using System.Windows.Forms;
using Vermeer.Vermeer.pages;

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
            vermeer.Open(new mainPage());

            //Runs the application loop
            Application.Run();
        }
    }
}
