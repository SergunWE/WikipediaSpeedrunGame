using System;
using System.Collections.Generic;
using System.Text;

namespace WikipediaSpeedrunGame
{
    class SpeedrunInfo
    {
        public string StartPageUrl { get; set; }
        public string StartPageTitle { get; set; }
        public string RequiredPageTitle { get; set; }

        public SpeedrunInfo()
        {
            StartPageTitle = Page.GetRandomPageTitle();
            RequiredPageTitle = Page.GetRandomPageTitle();
            StartPageUrl = Page.GetPageUrl(StartPageTitle);
        }
    }
}
