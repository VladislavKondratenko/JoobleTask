using System;
using System.IO;

namespace JoobleTask
{
	public static class Program
	{
		private static string _sourcePath;
		private static string _directPath;
		public static void Main(string[] args)
		{
			if (args is null)
				SetPathManually();
			else
				GetPathFromArgs(args);
			
			var writer = new FileManager(_sourcePath, _directPath);
			writer.WriteSubWordsAsync().Wait();
			Console.WriteLine("Complete!");
		}

		private static void SetPathManually()
		{
			while (string.IsNullOrEmpty(_sourcePath))
				GetSourcePath();
			
			while (string.IsNullOrEmpty(_directPath))
				GetDirectPath();
		}

		private static void GetDirectPath()
		{
			Console.WriteLine("Enter the path where to record the results");
			_directPath = Console.ReadLine();
		}

		private static void GetSourcePath()
		{
			Console.WriteLine("Enter the path to the source file with words");
			_sourcePath = Console.ReadLine();
		}

		private static void GetPathFromArgs(string[] args)
		{
			if (args.Length < 2)
				SetPathManually();
			else
				SetPathFromArgs(args);
		}

		private static void SetPathFromArgs(string[] args)
		{
			_sourcePath = args[0];
			_directPath = args[1];
		}
	}
}