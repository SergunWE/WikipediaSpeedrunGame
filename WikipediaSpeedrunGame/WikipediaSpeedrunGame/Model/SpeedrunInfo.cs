using System;
using System.Collections.Generic;
using System.Text;
using WikipediaSpeedrunGame.WikipediaPage;

namespace WikipediaSpeedrunGame
{
    public class SpeedrunInfo
    {
        public Page StartPage { get; set; }
        public Page FinishPage { get; set; }
        public int JumpsNumber { get; set; }

        public SpeedrunInfo(PageType startType = PageType.Random, 
            PageType finishType = PageType.Random)
		{
            JumpsNumber = 0;
            StartPage = new Page(startType);
            FinishPage = new Page(finishType);
        }
    }
}
