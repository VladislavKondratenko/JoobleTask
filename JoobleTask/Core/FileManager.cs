using System;
using System.IO;
using System.Threading.Tasks;

namespace JoobleTask.Core
{
	public class FileManager
	{
		private readonly Task<WordSeparator> _separatorTask;

		public FileManager(string sourcePath)
		{
			if (sourcePath is null)
				throw new ArgumentNullException(nameof(sourcePath));

			_separatorTask = SetSeparatorAsync(sourcePath);
		}

		public async Task WriteSubWordsAsync(string directPath)
		{
			if (directPath is null)
				throw new ArgumentNullException(nameof(directPath));

			var separator = await _separatorTask;

			await File.WriteAllLinesAsync(directPath, separator.SubWords);
		}

		private static async Task<WordSeparator> SetSeparatorAsync(string sourcePath)
		{
			var dictionary = GermanDictionary.GetInstance(Path.GetFullPath(@"../../../../Data/de-dictionary.tsv"));
			var words = await File.ReadAllLinesAsync(sourcePath);

			return new WordSeparator(dictionary.Dictionary, words);
		}
	}
}