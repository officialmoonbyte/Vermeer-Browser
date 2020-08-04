using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using System.Windows.Forms;
using CefSharp;
using Moonbyte.MaterialFramework.Controls;
using Moonbyte.Vermeer.bin;
using Vermeer.Vermeer.pages;

namespace Vermeer.Vermeer.bin.Cefsharp
{
    public class RequestHandler : IRequestHandler
    {

        #region Vars

        CefBrowserInterface BrowserInterface;

        #endregion Vars

        #region Initialization

        public RequestHandler(CefBrowserInterface Interface) 
        {
            BrowserInterface = Interface;
        }


        #endregion Initialization
        public bool CanGetCookies(IWebBrowser chromiumWebBrowser, CefSharp.IBrowser browser, IFrame frame, IRequest request)
        {
            return true;
        }

        public bool CanSetCookie(IWebBrowser chromiumWebBrowser, CefSharp.IBrowser browser, IFrame frame, IRequest request, Cookie cookie)
        {
            return true;
        }

        public bool GetAuthCredentials(IWebBrowser chromiumWebBrowser, CefSharp.IBrowser browser, IFrame frame, bool isProxy, string host, int port, string realm, string scheme, IAuthCallback callback)
        {
            return false;
        }

        public IResponseFilter GetResourceResponseFilter(IWebBrowser chromiumWebBrowser, CefSharp.IBrowser browser, IFrame frame, IRequest request, IResponse response)
        { 
            return null;
        }

        public bool OnBeforeBrowse(IWebBrowser chromiumWebBrowser, CefSharp.IBrowser browser, IFrame frame, IRequest request, bool userGesture, bool isRedirect)
        {
            return false;
        }

        public CefReturnValue OnBeforeResourceLoad(IWebBrowser chromiumWebBrowser, CefSharp.IBrowser browser, IFrame frame, IRequest request, IRequestCallback callback)
        {
            CefReturnValue returnRequest = CefReturnValue.Continue;

            return returnRequest;
        }

        private CefReturnValue CheckURL(string mainURL, List<string> blockedURLs)
        {
            return CefReturnValue.Continue;
        }

        public bool OnCertificateError(IWebBrowser chromiumWebBrowser, CefSharp.IBrowser browser, CefErrorCode errorCode, string requestUrl, ISslInfo sslInfo, IRequestCallback callback)
        {
            Task.Run(() =>
            {
                //NOTE: When executing the callback in an async fashion need to check to see if it's disposed
                if (!callback.IsDisposed)
                {
                    using (callback)
                    {
                        bool Allowed = false; string requestedURL = requestUrl.ToLower();
                        foreach (string s in vermeer.IgnoredSSLErrorSites)
                        {
                            if (requestedURL.Contains(s.ToLower()))
                            { callback.Continue(true); Allowed = true;
                                break; }
                        }

                        if (!Allowed)
                        {
                            MaterialTabPage tabPage = BrowserInterface.getTabPage();

                            if (tabPage.InvokeRequired)
                            {
                                tabPage.Invoke((MethodInvoker)delegate
                                {
                                    IBrowser.DisplayForm(BrowserInterface.getTabPage(), new CertError(BrowserInterface, requestedURL));
                                });
                            }
                            callback.Continue(false);
                        }
                    }
                }
            });

            return true;
        }

        public bool OnOpenUrlFromTab(IWebBrowser chromiumWebBrowser, CefSharp.IBrowser browser, IFrame frame, string targetUrl, WindowOpenDisposition targetDisposition, bool userGesture)
        {
            return false;
        }

        public void OnPluginCrashed(IWebBrowser chromiumWebBrowser, CefSharp.IBrowser browser, string pluginPath)
        {
            
        }

        public bool OnProtocolExecution(IWebBrowser chromiumWebBrowser, CefSharp.IBrowser browser, string url)
        {
            return true;
        }

        public bool OnQuotaRequest(IWebBrowser chromiumWebBrowser, CefSharp.IBrowser browser, string originUrl, long newSize, IRequestCallback callback)
        {
            callback.Dispose();
            return false;
        }

        public void OnRenderProcessTerminated(IWebBrowser chromiumWebBrowser, CefSharp.IBrowser browser, CefTerminationStatus status)
        {
            
        }

        public void OnRenderViewReady(IWebBrowser chromiumWebBrowser, CefSharp.IBrowser browser)
        {
            
        }

        public void OnResourceLoadComplete(IWebBrowser chromiumWebBrowser, CefSharp.IBrowser browser, IFrame frame, IRequest request, IResponse response, UrlRequestStatus status, long receivedContentLength)
        {
            
        }

        public void OnResourceRedirect(IWebBrowser chromiumWebBrowser, CefSharp.IBrowser browser, IFrame frame, IRequest request, IResponse response, ref string newUrl)
        {
            
        }

        public bool OnResourceResponse(IWebBrowser chromiumWebBrowser, CefSharp.IBrowser browser, IFrame frame, IRequest request, IResponse response)
        {
            return false;
        }

        public bool OnSelectClientCertificate(IWebBrowser chromiumWebBrowser, CefSharp.IBrowser browser, bool isProxy, string host, int port, X509Certificate2Collection certificates, ISelectClientCertificateCallback callback)
        {
            callback.Dispose();
            return false;
        }

        public IResourceRequestHandler GetResourceRequestHandler(IWebBrowser chromiumWebBrowser, CefSharp.IBrowser browser, IFrame frame, IRequest request, bool isNavigation, bool isDownload, string requestInitiator, ref bool disableDefaultHandling)
        {
            return null;
        }

        public bool GetAuthCredentials(IWebBrowser chromiumWebBrowser, CefSharp.IBrowser browser, string originUrl, bool isProxy, string host, int port, string realm, string scheme, IAuthCallback callback)
        {
            return false;
        }

        public void OnDocumentAvailableInMainFrame(IWebBrowser chromiumWebBrowser, CefSharp.IBrowser browser)
        {
            
        }
    }
}
