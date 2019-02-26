using System;
using System.Net;
using System.Security.Cryptography.X509Certificates;

namespace Moonbyte.Vermeer.browser
{
    public class Ssl
    {

        #region GetSSLCerfificate

        public static X509Certificate2 GetSSLCertificate(string URL)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                response.Close();

                X509Certificate cert = request.ServicePoint.Certificate;
                return new X509Certificate2(cert);
            } catch { return null; }
        }

        #endregion

        #region VerifySSLCerfificate

        public static bool VerifySSLCertificate(string URL)
        { return VerifySSLCertificate(GetSSLCertificate(URL)); }
        public static bool VerifySSLCertificate(X509Certificate2 cert2)
        { try { return cert2.Verify(); } catch { return false; } }

        #endregion

    }
}
