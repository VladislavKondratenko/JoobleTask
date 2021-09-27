using System;
using System.IO;
using System.Text.RegularExpressions;

namespace JoobleTask
{
	public class ProgramHelper
	{
		private string _sourcePath;
		private string _directPath;

		public string SourcePath => _sourcePath;
		public string DirectPath => _directPath;

		public ProgramHelper(string[] args)
		{
			if (args is null)
				SetPathManually();
			else
				GetPathFromArgs(args);
		}

		private void SetPathManually()
		{
			const string wrongMessage = "The path is wrong, try again...";

			while (TrySetSourcePath() is not true)
				Console.WriteLine(wrongMessage);

			while (TrySetDirectPath() is not true)
				Console.WriteLine(wrongMessage);
		}

		private bool TrySetSourcePath()
		{
			Console.WriteLine("Enter the path to the source file with words");
			_sourcePath = Console.ReadLine();

			return File.Exists(_sourcePath);
		}

		private bool TrySetDirectPath()
		{
			Console.WriteLine("Enter the path where to record the results");
			_directPath = Console.ReadLine();

			return _directPath is not null && Regex.IsMatch(_directPath, @"^[A-Z]:[/|\\]\w.+");
		}

		private void GetPathFromArgs(string[] args)
		{
			const int minArgsNumber = 2;

			if (args.Length < minArgsNumber)
				SetPathManually();
			else
				SetPathFromArgs(args);
		}

		private void SetPathFromArgs(string[] args)
		{
			_sourcePath = args[0];
			_directPath = args[1];
		}
	}
}