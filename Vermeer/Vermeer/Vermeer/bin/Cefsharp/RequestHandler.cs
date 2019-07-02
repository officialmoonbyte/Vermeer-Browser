using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using CefSharp;
using Moonbyte.Vermeer.bin;

namespace Vermeer.Vermeer.bin.Cefsharp
{
    public class RequestHandler : IRequestHandler
    {
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
            string URL = request.Url;

            List<string> blockedUrls = new List<string>();

            //General ad services
            blockedUrls.Add("doubleclick.net");
            blockedUrls.Add("googleadservices.com");
            blockedUrls.Add("googlesyndication.com");
            blockedUrls.Add("moat.com");

            //Youtube blocked ads
            blockedUrls.Add("www.youtube.com/api/stats/ads");
            blockedUrls.Add("adservice.google.com");
            blockedUrls.Add("www.google.com/pagead");
            blockedUrls.Add("youtube.com/get_midroll_info");

            returnRequest = CheckURL(URL, blockedUrls);

            if (returnRequest == CefReturnValue.Continue)
            {
                if (URL.Contains("ads")) { vermeer.ApplicationLogger.AddToLog("adblock Warn", "URL is suspected to be a ad. URL : " + URL); }
                if (URL.Contains("pagead")) { vermeer.ApplicationLogger.AddToLog("adblock Warn", "URL is suspected to be a ad. URL : " + URL); }
                if (URL.Contains("ad")) { vermeer.ApplicationLogger.AddToLog("adblock Warn", "URL is suspected to be a ad. URL : " + URL); }
            }

            callback.Dispose();
            return returnRequest; ;
        }

        private CefReturnValue CheckURL(string mainURL, List<string> blockedURLs)
        {
            foreach (string s in blockedURLs)
            {
                if (mainURL.Contains(s))
                {
                    //vermeer.ApplicationLogger.AddToLog("adblock", "Blocked " + mainURL);
                    return CefReturnValue.Cancel; }
            }
            vermeer.ApplicationLogger.AddToLog("adblock", "Allowing " + mainURL + " to load.");
            return CefReturnValue.Continue;
        }

        public bool OnCertificateError(IWebBrowser chromiumWebBrowser, CefSharp.IBrowser browser, CefErrorCode errorCode, string requestUrl, ISslInfo sslInfo, IRequestCallback callback)
        {
            return false;
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
    }
}
