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

		public SpeedrunInfo(Page startPage, Page finishPage, int jumps = 0)
		{
			JumpsNumber = jumps;
			StartPage = startPage;
			FinishPage = finishPage;
		}
	}
}
