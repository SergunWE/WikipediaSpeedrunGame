using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace WikipediaSpeedrunGame
{
    public class Page
    {
        private const string urlPageBeginning = "https://en.wikipedia.org/wiki/";
        private const string urlRandomPage = "https://en.wikipedia.org/api/rest_v1/page/random/title";
        private const string addressFragment = "wikipedia.org/wiki/";

        public static string GetPageUrl(int id)
        {
            return urlPageBeginning + id;
        }

        public static string GetPageUrl(string title)
        {
            return urlPageBeginning + title;
        }

        public static string GetPageTitle(string url)
        {
            return url.Substring(url.LastIndexOf('/') + 1);
        }

        public static bool IsWikipediaPage(string url)
        {
            return url.Contains(addressFragment);
        }

        public static string GetRandomPageTitle()
        {
            string json = new WebClient().DownloadString(urlRandomPage);
            RequestItems<PageInfo> o = JsonConvert.DeserializeObject<RequestItems<PageInfo>>(json);
            return o.Items[0].Title;
        }
    }
}
