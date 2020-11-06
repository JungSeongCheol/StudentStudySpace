using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace EddyNewHome.Controllers
{
    public class Commons
    {
        public static string GetIpAddress()
        {
            string strHostName = Dns.GetHostName();
            IPHostEntry ipEntry = Dns.GetHostEntry(strHostName);
            IPAddress[] addrs = ipEntry.AddressList;

            return addrs[7].ToString();

            //string whatisMyIp = "http://www.whatismyip.com/";
            //string IpRex = @"(?@<=a>.*)\d*\.\d*\.\d*\.\d*(?<=</a>)";
            //WebClient wc = new WebClient();
            //UTF8Encoding utf8 = new UTF8Encoding();
            //string requestHtml = "";

            //try{
            //    requestHtml = utf8.GetString(wc.DownloadData(whatisMyIp));
            //}
            //catch (WebException)
            //{

            //}

            //Regex regex = new Regex(IpRex);
            //Match m = regex.Match(requestHtml);
            //IPAddress ipAddress = null;
            //if (m.Success)
            //{
            //    ipAddress = IPAddress.Parse(m.Value);
            //}
            //return ipAddress;
        }

    }
}