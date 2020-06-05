using System;

namespace Moonbyte.Vermeer.API
{

    #region Event Classes

    public class OnLogEventArgs : EventArgs
    { 
        public string title { get; set; } 
        public string log { get; set; }
    }

    #endregion EventClasses
    public class VermeerAPI
    {
        #region Vars



        #endregion Vars

        #region Events

        public static event EventHandler<OnLogEventArgs> OnLogEvent;

        #endregion Events

        #region Log

        public static void LogEvent(object sender, string Title, string Log)
        {
            OnLogEventArgs onLogEventArgs = new OnLogEventArgs();
            onLogEventArgs.title = Title; onLogEventArgs.log = Log;
            OnLogEvent?.Invoke(sender, new OnLogEventArgs());
        }

        #endregion Log
    }
}
