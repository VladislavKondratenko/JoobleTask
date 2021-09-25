using System;
using JoobleTask;
using JoobleTask.Separator;

var helper = new ProgramHelper(args);

var writer = new FileManager(helper.SourcePath, helper.DirectPath);
writer.WriteSubWordsAsync().Wait();
Console.WriteLine("Complete!");