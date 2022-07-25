using Newtonsoft.Json;
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
		public DateTime StartTime { get; set; }
		public DateTime FinishTime { get; set; }

		public SpeedrunInfo(Page startPage, Page finishPage)
		{
			JumpsNumber = 0;
			StartPage = startPage;
			FinishPage = finishPage;
			StartTime = DateTime.Now;
		}

		[JsonConstructor]
		public SpeedrunInfo(Page startPage, Page finishPage,int jumpsNumber, DateTime startTime, DateTime finishTime)
		{
			JumpsNumber = jumpsNumber;
			StartPage = startPage;
			FinishPage = finishPage;
			StartTime = startTime;
			FinishTime = finishTime;
		}
	}
}
