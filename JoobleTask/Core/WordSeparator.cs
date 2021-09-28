using System;
using System.Collections.Generic;
using System.Linq;

namespace JoobleTask.Core
{
	internal class WordSeparator
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

			return dictionary.OrderByDescending(w => w.Length)
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
			var copy = word;
			var subWords = new List<string>();

			foreach (var s in _dictionary)
			{
				if (word.Contains(s) is not true)
					continue;

				subWords.Add(s);
				word = word.Replace(s, string.Empty);
			}

			if (word.Length > 0 || subWords.Any() is not true)
				return new[] {copy};

			return  subWords.ToArray();
		}
	}
}