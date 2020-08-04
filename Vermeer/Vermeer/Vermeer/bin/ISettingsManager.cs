using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vermeer.Vermeer.bin
{
    public class ISettingsManager
    {
        #region Emus

        public enum browserEngine { Chromium, Firefox }

        #endregion Emus

        #region Vars

        public browserEngine BrowserEngine = browserEngine.Chromium;
        public string ApplicationDataDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Moonbyte", "Vermeer");
        public string CacheDataDirectory;

        #endregion Vars

        #region Setting Titles



        #endregion Setting Titles

        #region Startup

        public ISettingsManager()
        {
            CacheDataDirectory = Path.Combine(ApplicationDataDirectory, "Cache");
        }

        #endregion Startup
    }
}
