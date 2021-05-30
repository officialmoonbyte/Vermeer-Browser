using CefSharp;
using CefSharp.Enums;
using CefSharp.Structs;
using Moonbyte.Vermeer.bin;
using System;
using System.Collections.Generic;

namespace Vermeer.Vermeer.bin.Cefsharp
{
    public class DisplayHandler : IDisplayHandler
    {

        #region Vars

        CefBrowserInterface browserInterface;

        #endregion Vars

        #region Initialization

        public DisplayHandler(CefBrowserInterface Interface)
        { browserInterface = Interface; }

        #endregion Initialization

        public void OnAddressChanged(IWebBrowser chromiumWebBrowser, AddressChangedEventArgs addressChangedArgs)
        {
            
        }

        public bool OnAutoResize(IWebBrowser chromiumWebBrowser, CefSharp.IBrowser browser, Size newSize)
        {
            return true;
        }

        public bool OnConsoleMessage(IWebBrowser chromiumWebBrowser, ConsoleMessageEventArgs consoleMessageArgs)
        {
            return true;
        }

        public bool OnCursorChange(IWebBrowser chromiumWebBrowser, CefSharp.IBrowser browser, IntPtr cursor, CursorType type, CursorInfo customCursorInfo)
        {
            return false;
        }

        public void OnFaviconUrlChange(IWebBrowser chromiumWebBrowser, CefSharp.IBrowser browser, IList<string> urls)
        { browserInterface.ChangeTabIcon(urls[0]); vermeer.ApplicationLogger.AddToLog("ICON", urls[0]); }

        public void OnFullscreenModeChange(IWebBrowser chromiumWebBrowser, CefSharp.IBrowser browser, bool fullscreen)
        {
            
        }

        public void OnLoadingProgressChange(IWebBrowser chromiumWebBrowser, CefSharp.IBrowser browser, double progress)
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
            return true;
        }
    }
}
