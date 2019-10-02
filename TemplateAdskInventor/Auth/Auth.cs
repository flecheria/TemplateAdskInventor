//////////////////////////////////////////////////////////////////////
//
// DO NOT CANCEL THIS PART
// Author: Paolo Cappelletto
// e-mail: p.cappelletto@maffeis.it
// skype4B: p.cappelletto@maffeis.it
//
// Copyright:
// Maffeis Enginnering
// Via Mignano 26 
// 36020 Solagna (VI) - ITALY
// http://www.maffeis.it/ - info@maffeis.it
//
//////////////////////////////////////////////////////////////////////

using System;
using System.Linq;

namespace TemplateAdskInventor.Auth
{
    class Auth
    {
        public static bool IsAuthorized(string app_name)
        {
            try
            {
                string macAddr = (
                        from nic in System.Net.NetworkInformation.NetworkInterface.GetAllNetworkInterfaces()
                        where nic.OperationalStatus == System.Net.NetworkInformation.OperationalStatus.Up
                        select nic.GetPhysicalAddress().ToString()).FirstOrDefault();

                string username = System.Environment.UserName;
                string domain = System.Net.NetworkInformation.IPGlobalProperties.GetIPGlobalProperties().DomainName;

                string url = $"https://manager.maffeis.it/index.php?/api/license/authorized/app/{app_name}/mac/{macAddr}/username/{username}/domain/{domain}";
                System.Net.HttpWebRequest _webRequest = System.Net.HttpWebRequest.CreateHttp(url);
                if (_webRequest.Headers == null)
                    _webRequest.Headers = new System.Net.WebHeaderCollection();
                _webRequest.IfModifiedSince = DateTime.UtcNow;
                System.Net.WebResponse response = _webRequest.GetResponse();
                using (System.IO.StreamReader streamReader = new System.IO.StreamReader(response.GetResponseStream()))
                {
                    string result = streamReader.ReadToEnd();
                    if (result.StartsWith("{\"Enabled\":true,"))
                        return true;
                }
            }
            catch (System.Net.WebException e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message + "\n" + e.StackTrace);
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message + "\n" + e.StackTrace);
            }

            return false;
        }

    }
}
