using System;
using System.IO;
using System.Linq;

var lines = File.ReadAllLinesAsync(@"D:\Projects\JoobleTask\Data\de-dictionary.tsv").Result;

foreach (var line in lines.OrderByDescending(w=>w.Length))
	Console.WriteLine(line);