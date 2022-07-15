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


        const string urlPage = "https://en.wikipedia.org/?curid=";
        const string randomApi = "https://en.wikipedia.org/api/rest_v1/page/random/title";

        public static string GetPageUrl(int id)
        {
            return urlPage + id;
        }

        public static string GetPageUrl(string title)
        {
            return "https://en.wikipedia.org/wiki/" + title;
        }

        public static string GetPageTitle(string url)
        {
            return url.Substring(url.LastIndexOf('/') + 1);
        }

        public static string GetRandomPageTitle()
        {
            string json = new WebClient().DownloadString("https://en.wikipedia.org/api/rest_v1/page/random/title");
            Console.WriteLine(json);

            RequestItems<PageInfo> o = JsonConvert.DeserializeObject<RequestItems<PageInfo>>(json);
            return o.Items[0].Title;
        }
    }
}
