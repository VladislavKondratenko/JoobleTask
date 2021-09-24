using System.IO;
using Xunit;

namespace JoobleTask.Tests
{
	public class WordSeparatorTests
	{
		private readonly string[] _dictionary;

		public WordSeparatorTests()
		{
			_dictionary = File.ReadAllLinesAsync(@"D:\Projects\JoobleTask\Data\de-dictionary.tsv").Result;
		}

		[Fact]
		public void WordSeparator_krankenhaus_krankenHaus_true()
		{
			var word = "krankenhaus";

			var expected = new[]
			{
				"kranken, haus"
			};

			var parser = new WordSeparator(_dictionary, new[] {word});

			Assert.Equal(expected, parser.SubWords);
		}

		[Fact]
		public void WordSeparator_krankenhaus_krankEnHaus_false()
		{
			var word = "krankenhaus";

			var expected = new[]
			{
				"krank, en, haus"
			};

			var parser = new WordSeparator(_dictionary, new[] {word});

			Assert.NotEqual(expected, parser.SubWords);
		}

		[Fact]
		public void WordSeparator_psychologie_psychologie()
		{
			var word = "psychologie";

			var expected = new[]
			{
				"psychologie"
			};

			var parser = new WordSeparator(_dictionary, new[] {word});

			Assert.Equal(expected, parser.SubWords);
		}
	}
}