using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vermeer.Vermeer.bin
{
    public class ILogger
    {
        public string Log;

        public ILogger()
        {
            SetLoggingEvents(); this.AddToLog("INFO", "Finished Initializing ILogger");
        }

        #region Adding to the log

        public void AddToLog(string Header, string Value)
        {
            string value = "[" + DateTime.Now.ToString("HH:mm") + "] " + "[" + Header.ToUpper() + "] " + Value;
            if (Log != null) Log = Log + "\r\n" + value;
            if (Log == null) Log = value;

            Console.WriteLine(value);
        }

        public void AddWhitespace() { if (Log != null) Log += "\r\n"; Console.WriteLine(" "); }

        #endregion

        #region Writing Log

        public void WriteLog()
        {
            string exeDirectory = AppDomain.CurrentDomain.BaseDirectory;

            if (this.Log != null)
            {
                if (File.Exists(exeDirectory + "\\Log.log")) File.Delete(exeDirectory + "\\Log.log");
                File.Create(exeDirectory + "\\Log.log").Close();
                File.WriteAllText(exeDirectory + "\\Log.log", this.Log);
            }
        }

        #endregion

        #region Set Logging Events

        public void SetLoggingEvents()
        {
            AppDomain.CurrentDomain.UnhandledException += ((obj, args) =>
            {
                UnhandledExceptionEventArgs e = args;

                this.AddToLog("Current Domain Error", "Error with App Domain");

                Exception ex = (Exception)e.ExceptionObject;

                this.AddToLog("Current Domain", "Message : " + ex.Message);
                this.AddToLog("Current Domain Error", "StackTrace : " + ex.StackTrace);
                this.AddToLog("Current Domain Error", "Source : " + ex.Source);

                this.WriteLog();
            });
            AppDomain.CurrentDomain.ProcessExit += ((obj, args) =>
            {
                this.WriteLog();
            });
        }

        #endregion

    }
}
