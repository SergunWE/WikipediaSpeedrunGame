using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace WikipediaSpeedrunGame
{
	public static class SpeedrunJsonSaver
	{
		private static string _folderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
		private static string _fileName = "speedruninfo.json";
		public static List<SpeedrunInfo> SavedList { get; private set; }

		static SpeedrunJsonSaver()
		{
			if (string.IsNullOrEmpty(_fileName)) return;
			if (File.Exists(Path.Combine(_folderPath, _fileName)))
			{
				string json = File.ReadAllText(Path.Combine(_folderPath, _fileName));
				SavedList = JsonConvert.DeserializeObject<List<SpeedrunInfo>>(json);
				return;
			}
			SavedList = new List<SpeedrunInfo>();
		}

		public static void AddToList(SpeedrunInfo info)
		{
			SavedList.Add(info);
			SaveList();
		}

		private static void SaveList()
		{
			File.WriteAllText(Path.Combine(_folderPath, _fileName), JsonConvert.SerializeObject(SavedList));
		}
	}
}
