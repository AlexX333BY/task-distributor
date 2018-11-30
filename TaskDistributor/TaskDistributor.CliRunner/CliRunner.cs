using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TaskDistributor.CliRunner
{
    class CliRunner
    {
        static void Main(string[] args)
        {
            if (args.Length < 2)
            {
                Console.WriteLine("usage: dotnet {0} <filename> <number of tasks>", AppDomain.CurrentDomain.FriendlyName);
                return;
            }

            try
            {
                foreach (KeyValuePair<string, List<int>> personTasks in TaskDistributor.Distribute(File.ReadAllLines(args[0]), int.Parse(args[1])))
                {
                    Console.WriteLine("{0}: {1}", personTasks.Key, string.Join(", ", personTasks.Value.Select((task) => task.ToString())));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
        }
    }
}
