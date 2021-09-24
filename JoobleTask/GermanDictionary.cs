﻿using System;
using System.IO;
using System.Threading.Tasks;

namespace JoobleTask
{
	public class GermanDictionary
	{
		private static string _path;
		private static GermanDictionary _instance;

		private string[] _dictionary;

		public string[] Dictionary => _dictionary;

		private GermanDictionary(string path)
		{
			if (path is null)
				throw new ArgumentNullException(nameof(path));

			SetDictionary(path).Wait();
		}

		public static GermanDictionary GetInstance(string path)
		{
			if (IsInstanceCreated(path))
				_instance = new GermanDictionary(path);

			return _instance;
		}

		private static bool IsInstanceCreated(string path)
		{
			return string.IsNullOrEmpty(_path) || _path != path;
		}

		private async Task SetDictionary(string path)
		{
			_dictionary = await File.ReadAllLinesAsync(path);
		}
	}
}