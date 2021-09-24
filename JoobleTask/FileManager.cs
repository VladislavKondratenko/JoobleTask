using System;
using System.IO;
using System.Threading.Tasks;

namespace JoobleTask
{
	public class FileManager
	{
		private readonly string _sourcePath;
		private readonly string _directPath;

		public FileManager(string sourcePath, string directPath)
		{
			_sourcePath = sourcePath ?? throw new ArgumentNullException(nameof(sourcePath));
			_directPath = directPath ?? throw new ArgumentNullException(nameof(directPath));
		}

		public async Task WriteSubWordsAsync()
		{
			var dictionary = GermanDictionary.GetInstance(@"D:\Projects\JoobleTask\Data\de-dictionary.tsv");
			var words = await File.ReadAllLinesAsync(_sourcePath);
			var wordParser = new WordSeparator(dictionary.Dictionary, words);
			
			await File.WriteAllLinesAsync(_directPath, wordParser.SubWords);
		}
	}
}