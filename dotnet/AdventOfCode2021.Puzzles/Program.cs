﻿
using AdventOfCode2021.Puzzles;
using AdventOfCode.Console;

namespace AdventOfCode
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var app = AdventOfCodeConsole.Instance;

            app.StartYear(2021, year => {
                year.Submit<SonarSweepChallenge>().ForDay(1);
                year.Submit<DiveChallenge>().ForDay(2);
                year.Submit<BinaryDiagnosticChallenge>().ForDay(3);
            });

            app.Run(args);
        }
    }
}