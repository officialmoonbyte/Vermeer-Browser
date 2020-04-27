using CefSharp;
using CefSharp.WinForms;
using Moonbyte.MaterialFramework.Controls;
using Moonbyte.Vermeer.bin;
using Moonbyte.Vermeer.browser;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Windows.Forms;
using Vermeer.Controls;
using Vermeer.Vermeer.bin.Cefsharp;
using Vermeer.Vermeer.bin.GeckoFX;
using Vermeer.Vermeer.Controls;

namespace Vermeer.Vermeer.bin
{ 
    public static class IBrowser
    {

        #region MaterialTabPage
        
        public static void DeleteAllControlsOnTab(MaterialTabPage browserTab)
        { browserTab.Controls.Clear(); }
        public static void GenerateNewBrowserTab(MaterialTabPage browserPage, ISettingsManager.browserEngine BrowserEngine, string URL = null)
        { RenderTabPage(browserPage, BrowserEngine, URL); }
        public static void GenerateNewBrowserTab(MaterialTabPage browserPage)
        { RenderTabPage(browserPage, vermeer.SettingsManager.BrowserEngine); }
        public static MaterialTabPage GenerateNewBrowserTab()
        { MaterialTabPage browserPage = new MaterialTabPage(); RenderTabPage(browserPage, vermeer.SettingsManager.BrowserEngine); return browserPage; }

        private static void RenderTabPage(MaterialTabPage browserPage, ISettingsManager.browserEngine BrowserEngine, string URL = null)
        {
            browserPage.BackColor = Color.White;
            browserPage.Text = "New Tab";

            RenderBrowserUI(browserPage, BrowserEngine, URL); vermeer.ApplicationLogger.AddToLog("info", "RenderBrowserUI initialized");
            RenderHeaderUI(browserPage); vermeer.ApplicationLogger.AddToLog("info", "RenderHeaderUI initialized");
        }

        #endregion

        #region Header

        private static void RenderHeaderUI(MaterialTabPage mainPage)
        {
            VermeerBrowserInstance instance = BrowserInstance(mainPage);

            GC.WaitForPendingFinalizers();
            GC.Collect();

            // ** Back Button ** //
            BackButton backButton = new BackButton();
            backButton.Location = new Point(0, 0);
            backButton.Enabled = true;
            backButton.Click += (obj, args) =>
            {
                vermeer.ApplicationLogger.AddToLog("INFO", "Browser backButton.Click invoked");
                instance.BrowserInterface.GoBack();
            };
            mainPage.Controls.Add(backButton);

            // ** Forward Button ** //
            ForwardButton forwardButton = new ForwardButton();
            forwardButton.Location = new Point(32, 0);
            forwardButton.Click += (obj, args) =>
            {
                vermeer.ApplicationLogger.AddToLog("INFO", "Browser forwardButton.Click invoked");
                instance.BrowserInterface.GoForward();
            };
            mainPage.Controls.Add(forwardButton);

            // ** Reload Button ** //
            ReloadButton reloadButton = new ReloadButton();
            reloadButton.Enabled = true;
            reloadButton.Location = new Point(64, 0);
            reloadButton.Click += (obj, args) =>
            {
                vermeer.ApplicationLogger.AddToLog("INFO", "Browser reloadButton.Click invoked");
                instance.BrowserInterface.Reload();
            };
            mainPage.Controls.Add(reloadButton);

            BrowserChangeButton browserChangeButton = new BrowserChangeButton();
            browserChangeButton.Location = new Point(mainPage.Width - 32, 0);
            browserChangeButton.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
            browserChangeButton.onChromeChange += (obj, args) =>
            {
                MaterialTabPage tabPage = (MaterialTabPage)browserChangeButton.Parent;

                VermeerBrowserInterface NewBrowserInterface = new CefBrowserInterface();
                string url = instance.BrowserInterface.CurrentURL();

                NewBrowserInterface.OnInit(tabPage, url, ""); //"socks5://127.0.0.1:9150";

                instance.ChangeInterface(NewBrowserInterface);
                IBrowser.SetBrowserEvents(instance);
            };
            browserChangeButton.onFirefoxChange += (obj, args) =>
            {
                MaterialTabPage tabPage = (MaterialTabPage)browserChangeButton.Parent;

                VermeerBrowserInterface NewBrowserInterface = new GeckoBrowserInterface();
                string url = instance.BrowserInterface.CurrentURL();

                NewBrowserInterface.OnInit(tabPage, url, ""); //"socks5://127.0.0.1:9150";

                instance.ChangeInterface(NewBrowserInterface);
                IBrowser.SetBrowserEvents(instance);
            };
            mainPage.Controls.Add(browserChangeButton);

            // ** SearchBar ** //

            DefaultSearchBar searchBar = new DefaultSearchBar();
            searchBar.Anchor = (AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Left);
            searchBar.Location = new Point(86 + 12, 2);
            searchBar.Font = new Font("Segoe UI", 12f);
            searchBar.GetURL = "";
            searchBar.Width = mainPage.Width - 86 - 64;

            mainPage.Controls.Add(searchBar);

            SetBrowserEvents(instance);

            // ** Design Timer ** //
            DesignTimer designTimer = new DesignTimer(mainPage, BrowserInstance(mainPage), forwardButton, backButton);
            instance.BrowserInterface.OnDocumentIconChange += (obj, args) =>
            {
                DocumentIconChange e = args;
                instance.BrowserInterface.getTabPage().ChangeTabIcon(e.icon); vermeer.ApplicationLogger.AddToLog("INFO", "Changed Tab Icon");
            };
        }

        #endregion

        #region UpdateChangeBrowserButton

        private static void UpdateChangeBrowserButton(MaterialTabPage mainPage, VermeerBrowserInterface bInterface)
        {
            BrowserChangeButton browserChange = null;
            foreach (Control c in mainPage.Controls)
            {
                if (c is BrowserChangeButton) { browserChange = (BrowserChangeButton)c; break; }
            }

            string browserEngine = "null";

            if (browserChange == null) { return; }
            if (bInterface is CefBrowserInterface) { browserEngine = "chrome"; vermeer.ApplicationLogger.AddToLog("UPDATE", "UPDATED TO CHROME"); }
            else if (bInterface is GeckoBrowserInterface) { browserEngine = "firefox"; vermeer.ApplicationLogger.AddToLog("UPDATE", "UPDATE TO FIREFOX"); }
            else { vermeer.ApplicationLogger.AddToLog("UPDATE ERROR", "FAILED TO FIND BROWSER ENGINE INTERFACE. BROWSER ENGINE UNKNOWN!"); }

            System.Windows.Forms.Timer BrowserChangeTimer = new System.Windows.Forms.Timer();
            BrowserChangeTimer.Tick += (obj, args) =>
            {
                vermeer.ApplicationLogger.AddToLog("YEET", "1" + browserChange.aStates + " " + browserChange.state);
                if (browserEngine == "chrome") { browserChange.ChangeToChrome(); vermeer.ApplicationLogger.AddToLog("CHANGEBUTTON", "Change state to Chrome"); vermeer.ApplicationLogger.AddToLog("YEET", "2"); }
                else if (browserEngine == "firefox") { browserChange.ChangeToFirefox(); vermeer.ApplicationLogger.AddToLog("CHANGEBUTTON", "Change state to Firefox"); vermeer.ApplicationLogger.AddToLog("YEET", "3"); }
                else { vermeer.ApplicationLogger.AddToLog("CHANGEBUTTON", "FAILED TO FIND BROWSER ENGINE INTERFACE. BROWSER ENGINE UNKNOWN!"); }
                vermeer.ApplicationLogger.AddToLog("YEET", "4" + browserChange.aStates + " " + browserChange.state);
                if (browserChange.state != BrowserChangeButton.States.Changing)
                {
                    vermeer.ApplicationLogger.AddToLog("YEET", "5");
                    BrowserChangeTimer.Stop();
                }
                vermeer.ApplicationLogger.AddToLog("YEET", "6");
            };
            BrowserChangeTimer.Start();
        }

        #endregion UpdateChangeBrowserButton

        #region SetBrowserEvents

        public static void SetBrowserEvents(VermeerBrowserInstance instance)
        {

            MaterialTabPage mainPage = instance.BrowserInterface.getTabPage();
            ForwardButton forwardButton = null;
            BackButton backButton = null;
            DefaultSearchBar searchBar = null;

            foreach(Control c in mainPage.Controls)
            {
                if (c is DefaultSearchBar) { searchBar = (DefaultSearchBar)c; }
                else if (c is ForwardButton) { forwardButton = (ForwardButton)c; }
                else if (c is BackButton) { backButton = (BackButton)c; }
            }

            if (forwardButton == null || backButton == null || searchBar == null)
            { vermeer.ApplicationLogger.AddToLog("ERROR", "Couldn't find the searchbarm forward button, or back button while setting the browser events!"); return; }

            //Setting browser instance events
            instance.BrowserInterface.OnDocumentTitleChange += (obj, Args) =>
            {
                DocumentTitleChange args = (DocumentTitleChange)Args;
                if (mainPage.InvokeRequired)
                {
                    mainPage.Invoke((MethodInvoker)delegate
                    { OnDocumentTitleChange(args); });
                }
                else { OnDocumentTitleChange(args); }
            };

            instance.BrowserInterface.OnDocumentURLChange += (obj, Args) =>
            {
                DocumentURLChange args = (DocumentURLChange)Args;
                if (mainPage.InvokeRequired)
                {
                    mainPage.Invoke((MethodInvoker)delegate
                    { 
                        OnDocumentURLChange(args, searchBar);

                        VermeerBrowserInstance browserInstance = GetBrowserInstance(mainPage);

                        if (!browserInstance.BrowserInterface.FirstNavigateCheck())
                        {
                            UpdateChangeBrowserButton(mainPage, browserInstance.BrowserInterface);
                            browserInstance.BrowserInterface.SetFirstNavigateCheck(true);
                            vermeer.ApplicationLogger.AddToLog("INFO", "Ran UpdateChangeBrowserButton method via invoked");
                        }
                    });
                }
                else 
                { 
                    OnDocumentURLChange(args, searchBar);

                    VermeerBrowserInstance browserInstance = GetBrowserInstance(mainPage);
                    if (!browserInstance.BrowserInterface.FirstNavigateCheck())
                    {
                        UpdateChangeBrowserButton(mainPage, browserInstance.BrowserInterface);
                        browserInstance.BrowserInterface.SetFirstNavigateCheck(true);
                        vermeer.ApplicationLogger.AddToLog("INFO", "Ran UpdateChangeBrowserButton method via non-invoked");
                    }
                    Console.WriteLine(5);
                }
            };

            instance.BrowserInterface.OnDocumentIconChange += (obj, Args) =>
            {
                DocumentIconChange rArgs = (DocumentIconChange)Args;

                if (mainPage.InvokeRequired)
                {
                    mainPage.Invoke((MethodInvoker)delegate
                    { OnDocumentIconChange(rArgs); });
                }
                else
                { OnDocumentIconChange(rArgs); }
            };

            instance.BrowserInterface.OnDocumentLoadChange += (obj, Args) =>
            {
                DocumentLoadingChange args = (DocumentLoadingChange)Args;

                if (mainPage.InvokeRequired)
                {
                    mainPage.Invoke((MethodInvoker)delegate
                    { OnDocumentLoadChange(forwardButton, backButton, instance); });
                }
                else
                { OnDocumentLoadChange(forwardButton, backButton, instance); }
            };
        }

        #endregion SetBrowserEvents

        #region Interface Menthods

        #region OnDocumentTitleChange

        private static void OnDocumentTitleChange(DocumentTitleChange args)
        {
            try
            {
                if (args.DocumentTitle != "")
                {
                    GetTabPage(args.VermeerVars.Instance).Text = args.DocumentTitle;
                    vermeer.ApplicationLogger.AddToLog("INFO", "Changed mainPage text from args.DocumentTitle, DocumentTitle : " + args.DocumentTitle);
                }
            }
            catch (Exception e)
            {
                vermeer.ApplicationLogger.AddToLog("ERROR", "Exception : " + e.Message); vermeer.ApplicationLogger.AddToLog("EROR", e.StackTrace); vermeer.ApplicationLogger.AddToLog("WARN", "Last two error's can be natural if the browser was closed by the header.");
            }
        }

        #endregion OnDocumentTitleChange

        #region OnDocumentURLChange

        private static void OnDocumentURLChange(DocumentURLChange args, DefaultSearchBar searchBar)
        {
            BackgroundWorker sslCertChecker = new BackgroundWorker();
            sslCertChecker.DoWork += (obj, bgwargs) =>
            {
                try
                {
                    X509Certificate2 cert2 = Ssl.GetSSLCertificate(args.DocumentURL);
                    searchBar.secureButton.SecureLogo = Ssl.VerifySSLCertificate(cert2);
                }
                catch
                {
                    vermeer.ApplicationLogger.AddToLog("INFO", "Failed to find local ssl encryption. Assuming there's no tls / ssl.");
                    searchBar.secureButton.SecureLogo = false;
                }
            };
            sslCertChecker.RunWorkerAsync();

            searchBar.baseTextBox.Text = args.DocumentURL;
        }

        #endregion OnDocumentURLChange

        #region OnDocumentIconChange

        private static void OnDocumentIconChange(DocumentIconChange rArgs)
        {
            MaterialTabPage Page = GetTabPage(rArgs.VermeerVars.Instance);
            Page.ChangeTabIcon(rArgs.icon);
        }

        #endregion OnDocumentIconChange

        #region OnDocumentLoadChange

        private static void OnDocumentLoadChange(ForwardButton forwardButton, BackButton backButton, VermeerBrowserInstance instance)
        {
            forwardButton.Enabled = instance.BrowserInterface.IsForwardAvailable();
            backButton.Enabled = instance.BrowserInterface.IsBackEnabled();
        }

        #endregion OnDocumentLoadChange

        #endregion Interface Methods

        #region Browser Comp

        private static void RenderBrowserUI(MaterialTabPage mainPage, ISettingsManager.browserEngine BrowserEngine, string URL = null)
        {
            //vermeer.InitializeTorConnection();
            VermeerBrowserInterface Interface;
            if (BrowserEngine == ISettingsManager.browserEngine.Chromium)
            { Interface = new CefBrowserInterface(); }
            else if (BrowserEngine == ISettingsManager.browserEngine.Firefox)
            { Interface = new GeckoBrowserInterface(); }
            else
            { Interface = new CefBrowserInterface(); }

            if (URL == null) { URL = vermeer.HomeWebsite; }

            Interface.OnInit(mainPage, URL, ""); //"socks5://127.0.0.1:9150";

            VermeerBrowserInstance browserInstance = new VermeerBrowserInstance(Interface);

            browserInstance.Location = new Point(0, 32);
            browserInstance.Size = new Size(mainPage.Width, mainPage.Height - 32);

            mainPage.Controls.Add(browserInstance);
        }

        #endregion

        #region Display Form

        public static void DisplayForm(MaterialTabPage tabPage, Form form)
        {
            Panel panel = new Panel();

            panel.Width = tabPage.Width;
            panel.Height = tabPage.Height - 32;
            panel.Location = new Point(0, 32);
            panel.BackColor = Color.Black;
            panel.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right );

            tabPage.Controls.Add(panel);
            panel.BringToFront();

            form.TopLevel = false;
            form.AutoScroll = true;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
            form.Size = panel.Size;
            panel.Controls.Add(form);
            form.Show();
        }

        #endregion Display Form

        #region Remove Displayed Form

        public static void RemoveDisplayedForm(MaterialTabPage tabPage)
        {
            foreach(Control c in tabPage.Controls)
            {
                if (c is Panel)
                {
                    Panel tempPan = (Panel)c;
                    if (tempPan.Controls[0] is Form)
                    {
                        Form tempForm = (Form)tempPan.Controls[0];
                        tempPan.Controls.Remove(tempForm);
                    }

                    tabPage.Controls.Remove(tempPan);
                    tempPan.Dispose();
                }
            }
        }

        #endregion Remove Displayed Form

        #region Getting Usercontrols

        /// <summary>
        /// Gets the Panel of a MaterialTabPage
        /// </summary>
        public static VermeerBrowserInstance BrowserInstance(MaterialTabPage mainPage) { return GetBrowserInstance(mainPage); }
        public static VermeerBrowserInstance GetBrowserInstance(MaterialTabPage mainPage)
        {
            //Initialize the return panel
            VermeerBrowserInstance returnPanel = null;

            //Gets Panel control on the TabPage
            foreach(Control userControl in mainPage.Controls)
            { if (userControl is VermeerBrowserInstance) { returnPanel = (VermeerBrowserInstance)userControl; } }

            //Returns the panel
            if (returnPanel == null) { vermeer.ApplicationLogger.AddToLog("WARN", "TabPanel was not found!"); return null; } else { return returnPanel; }
        }
        public static MaterialTabPage GetTabPage(VermeerBrowserInstance instance) { return (MaterialTabPage)instance.Parent; }


        #endregion

    }
}
