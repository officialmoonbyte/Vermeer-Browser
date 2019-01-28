using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using CefSharp;
using CefSharp.Structs;
using IndieGoat.MaterialFramework.Controls;
using Moonbyte.Vermeer.bin;

namespace Vermeer.Vermeer.bin.Engine
{
    public class displayhandler : IDisplayHandler
    {
        public event EventHandler<IconChangedEventArgs> OnIconChanged;
        public MaterialTabPage mainPage;
        public class IconChangedEventArgs : EventArgs
        { public Image icon; }

        public displayhandler(MaterialTabPage mainpage) { this.mainPage = mainpage; }

        public void OnAddressChanged(IWebBrowser chromiumWebBrowser, AddressChangedEventArgs addressChangedArgs)
        {
            
        }

        public bool OnAutoResize(IWebBrowser chromiumWebBrowser, CefSharp.IBrowser browser, CefSharp.Structs.Size newSize)
        {
            return false;
        }

        public bool OnConsoleMessage(IWebBrowser chromiumWebBrowser, ConsoleMessageEventArgs consoleMessageArgs)
        {
            return false;
        }

        public void OnFaviconUrlChange(IWebBrowser chromiumWebBrowser, CefSharp.IBrowser browser, IList<string> urls)
        {
            string FaviconDirectory = Environment.CurrentDirectory + "\\Website Favicons\\";

            string IconName = urls[0];

            foreach(char c in Path.GetInvalidFileNameChars())
            {
                IconName = IconName.Replace(c, ' ');
            }

            if (!Directory.Exists(FaviconDirectory)) { Directory.CreateDirectory(FaviconDirectory); vermeer.ApplicationLogger.AddToLog("INFO", "Created FaviconDirectory, Directory did not exist!"); }

            if (!File.Exists(FaviconDirectory + IconName))
            {
                vermeer.ApplicationLogger.AddToLog("INFO", "Icon file does not exist! Downloading from " + IconName + ", " + urls[0]);
                using (WebClient webclient = new WebClient())
                { webclient.DownloadFile(urls[0], FaviconDirectory + IconName); }
            }

            vermeer.ApplicationLogger.AddToLog("INFO", "Invoking OnIconChanged from DisplayHandler");
            OnIconChanged?.Invoke(this, new IconChangedEventArgs { icon = Image.FromFile(FaviconDirectory + IconName) });
        }

        public void OnFullscreenModeChange(IWebBrowser chromiumWebBrowser, CefSharp.IBrowser browser, bool fullscreen)
        {
            
        }

        public void OnStatusMessage(IWebBrowser chromiumWebBrowser, StatusMessageEventArgs statusMessageArgs)
        {
            
        }

        public void OnTitleChanged(IWebBrowser chromiumWebBrowser, TitleChangedEventArgs titleChangedArgs)
        {
            
        }

        public bool OnTooltipChanged(IWebBrowser chromiumWebBrowser, ref string text)
        {
            return false;
        }

    }
}
