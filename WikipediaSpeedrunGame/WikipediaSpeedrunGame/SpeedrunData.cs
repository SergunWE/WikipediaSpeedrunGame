using System;
using System.Collections.Generic;
using System.Text;

namespace WikipediaSpeedrunGame
{
    class SpeedrunData
    {
        public string StartPage { get; set; }
        public string CurrentPage { get; set; }
        public string RequiredPage { get; set; }


        public SpeedrunData()
        {
            StartPage = "https://en.wikipedia.org/wiki/Independent_agencies_of_the_United_States_government";
            CurrentPage = "https://en.wikipedia.org/wiki/Independent_agencies_of_the_United_States_government";
            RequiredPage = "https://en.wikipedia.org/wiki/United_States_Congress";
        }
    }
}
