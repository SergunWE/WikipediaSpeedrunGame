using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using WikipediaSpeedrunGame.WikipediaPage;
using Xamarin.Forms;

namespace WikipediaSpeedrunGame
{
    public class Page
    {
        private const string urlPageBeginning = "https://en.wikipedia.org/wiki/";
        private const string urlRandomPage = "https://en.wikipedia.org/api/rest_v1/page/random/title";
        private const string addressFragment = "wikipedia.org/wiki/";

        public string Title { get; private set; }
        public PageType Type { get; private set; }

        public Page(PageType type, string title = null)
		{
            Type = type;
            if(string.IsNullOrEmpty(title))
			{
                Title = GetRandomPageTitle(Type);
                return;
            }
            Title = title;
            
		}

        public string GetPageUrl()
        {
            return urlPageBeginning + Title;
        }

        public static string GetPageTitle(string url)
        {
            return url.Substring(url.LastIndexOf('/') + 1);
        }

        public static bool IsWikipediaPage(string url)
        {
            return url.Contains(addressFragment);
        }

        private string GetRandomPageTitle()
        {
            string json = new WebClient().DownloadString(urlRandomPage);
            RequestItems<PageInfo> o = JsonConvert.DeserializeObject<RequestItems<PageInfo>>(json);
            return o.Items[0].Title;
        }

        private string GetRandomPageTitle(PageType type)
		{
            string[] titles = null;
            switch (type)
			{
				case PageType.Random:
                    return GetRandomPageTitle();
				case PageType.President:
                    titles = (string[])Application.Current.Resources["presidentPageTitle"];
                    break;
				case PageType.Country:
                    titles = (string[])Application.Current.Resources["countryPageTitle"];
                    break;
				case PageType.Simple:
                    titles = (string[])Application.Current.Resources["simplePageTitle"];
                    break;
			}
            return titles[new Random((int)DateTime.Now.Ticks).Next(0, titles.Length)];
		}
	}
}
