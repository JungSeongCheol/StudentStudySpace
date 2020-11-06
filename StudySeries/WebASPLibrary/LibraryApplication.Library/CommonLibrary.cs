﻿using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryApplication.Library
{
    public class CommonLibrary
    {
        public string GetUrl(string paramType)
        {
            string returnValue = string.Empty;

            switch (paramType)
            {
                case "full":
                    returnValue = HttpContext.Current.Request.Url.AbsoluteUri;
                    break;
                case "path":
                    returnValue = HttpContext.Current.Request.Url.AbsolutePath;
                    break;
            }

            return returnValue;
        }

        public List<UrlParameter> UrlParameters
        {
            get
            {
                var returnValue = new List<UrlParameter>();
                //[0] http://localhost:52912/
                //[1] searchKind=Title&keyword=%EC%B6%9C%ED%8C%90
                string url = this.GetUrl("full");

                string[] urlArr = url.Split('?');

                string[] paramArr = null;

                if (urlArr.Count() > 1)
                {
                    paramArr = urlArr[1].Split('&');
                    //[0] searchKind=Title
                    //[1] keyword=%EC%B6%9C%ED%8C%90

                    foreach (var item in paramArr)
                    {
                        var urlParam = new UrlParameter()
                        {
                            Key = item.Split('=')[0],
                            Value = item.Split('=')[1]
                        };
                        returnValue.Add(urlParam);
                    }
                }
                return returnValue;
            }
        }
        public string AddUrlParameter(string paramKey, string paramValue)
        {
            // alpha = alphaValue

            string returnValue = string.Empty;

            List<UrlParameter> urlParams = this.UrlParameters;

            UrlParameter urlParameter = urlParams.Where(x => x.Key == paramKey).SingleOrDefault();

            if (urlParameter != null)
                urlParams.Remove(urlParameter);

            urlParams.Add(new UrlParameter()
            {
                Key = paramKey,
                Value = paramValue
            });

            // [0] Key = alpha, Value = alphaValue
            // [1] Key = beta, Value = betaValue
            // [2] Key = gamma, Value = gammaValue


            for (int i = 0; i < urlParams.Count(); i++)
            {
                returnValue += i == 0 ? "?" : "&";
                returnValue += urlParams[i].Key + "=" + urlParams[i].Value;
            }


            return returnValue;
        }
    }
}
