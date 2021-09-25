using System;
using System.Collections.Generic;
using System.Linq;

namespace JoobleTask.Separator
{
	public class WordSeparator
	{
		private readonly string[] _dictionary;
		private readonly string[] _words;
		private string[] _subWords;

		public string[] SubWords => _subWords;

		public WordSeparator(IEnumerable<string> dictionary, string[] words)
		{
			_dictionary = SortDictionary(dictionary);
			_words = words ?? throw new ArgumentNullException(nameof(words));

			SplitWords();
		}

		private static string[] SortDictionary(IEnumerable<string> dictionary)
		{
			if (dictionary is null)
				throw new ArgumentNullException(nameof(dictionary));

			const int minLengthWord = 2;

			return dictionary.Where(w => w.Length > minLengthWord)
							.OrderByDescending(w => w.Length)
							.Select(w => w.ToLower())
							.ToArray();
		}

		private void SplitWords()
		{
			_subWords = _words.Select(w => w.ToLower())
							.Select(FindMatchedWords)
							.Select(a => string.Join(", ", a))
							.ToArray();
		}

		private string[] FindMatchedWords(string word)
		{
			var subWords = new List<string>();

			foreach (var s in _dictionary)
			{
				if (word.Contains(s) is not true)
					continue;

				subWords.Add(s);
				word = word.Replace(s, string.Empty);
			}

			return subWords.Any() ? subWords.ToArray() : new[] {word};
		}
	}
}