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
        public int JumpsNumber { get; set; }

        public SpeedrunInfo()
        {
            JumpsNumber = 0;
            StartPageTitle = Page.GetRandomPageTitle();
            RequiredPageTitle = Page.GetRandomPageTitle();
            StartPageUrl = Page.GetPageUrl(StartPageTitle);
        }
    }
}
