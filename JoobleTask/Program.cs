using System;
using JoobleTask;
using JoobleTask.Core;

var helper = new ProgramHelper(args);

var writer = new FileManager(helper.SourcePath);
writer.WriteSubWordsAsync(helper.DirectPath).Wait();
Console.WriteLine("Complete!");