using System;
using System.Collections.Generic;
using System.IO;
using Xunit;

namespace JoobleTask.Tests
{
	public class WordParserTests
	{
		private string[] _dictionary;

		public WordParserTests()
		{
			_dictionary = File.ReadAllLinesAsync(@"D:\Projects\JoobleTask\Data\de-dictionary.tsv").Result;
		}

		[Fact]
		public void WordParser_krankenhaus_krankenHaus_true()
		{
			var word = "krankenhaus";

			var expected = new[]
			{
				new [] {"kranken", "haus"}
			};
			
			var parser = new WordParser(_dictionary, new[] {word});
			
			Assert.Equal(expected, parser.SubWords);
		}
		
		[Fact]
		public void WordParser_krankenhaus_krankEnHaus_false()
		{
			var word = "krankenhaus";

			var expected = new[]
			{
				new [] {"krank", "en", "haus"}
			};
			
			var parser = new WordParser(_dictionary, new[] {word});
			
			Assert.NotEqual(expected, parser.SubWords);
		}
		
		[Fact]
		public void WordParser_psychologie_psychologie()
		{
			var word = "psychologie";

			var expected = new[]
			{
				new [] {"psychologie"}
			};
			
			var parser = new WordParser(_dictionary, new[] {word});
			
			Assert.Equal(expected, parser.SubWords);
		}
	}
}