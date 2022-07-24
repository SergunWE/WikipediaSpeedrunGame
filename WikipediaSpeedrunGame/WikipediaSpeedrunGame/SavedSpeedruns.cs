using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using Xamarin.Forms;

namespace WikipediaSpeedrunGame
{
	public static class SavedSpeedruns
	{
		private static string _folderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
		private const string _fileName = "speedruninfo.json";
		public static ObservableCollection<SpeedrunInfo> SavedList { get; private set; }

		static SavedSpeedruns()
		{
			if (string.IsNullOrEmpty(_fileName))
			{
				throw new ArgumentException("Saving file name is not set", _fileName);
			}
			if (File.Exists(Path.Combine(_folderPath, _fileName)))
			{
				string json = File.ReadAllText(Path.Combine(_folderPath, _fileName));
				SavedList = JsonConvert.DeserializeObject<ObservableCollection<SpeedrunInfo>>(json);
				return;
			}
			SavedList = new ObservableCollection<SpeedrunInfo>();
		}

		public static void SaveList()
		{
			File.WriteAllText(Path.Combine(_folderPath, _fileName), JsonConvert.SerializeObject(SavedList));
		}
	}
}
