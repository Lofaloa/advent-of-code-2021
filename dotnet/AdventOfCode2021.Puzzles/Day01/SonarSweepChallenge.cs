﻿using AdventOfCode.Console.Core;

namespace AdventOfCode2021.Puzzles
{
    public class SonarSweepChallenge : Puzzle
    {
        private static int CountDepthIncrements(int[] depths)
        {
            int count = 0;
            int previous = depths[0];
            for (int i = 1; i < depths.Length; i++)
            {
                if (depths[i] > previous)
                {
                    count++;
                }
                previous = depths[i];
            }
            return count;
        }

        private static int[] SumDepthsByWindow(int[] depths, int windowSize)
        {
            List<int> sums = new List<int>();
            for (int step = 0; step + windowSize - 1 < depths.Length; step++)
            {
                int currentSum = 0;
                for (int i = 0; i < windowSize; i++)
                {
                    currentSum += depths[step + i];
                }
                sums.Add(currentSum);
            }

            return sums.ToArray();
        }

        public static int CountDepthIncrements(string[] depths)
        {
            int[] convertedDepths = Array.ConvertAll(depths, d => int.Parse(d));
            return CountDepthIncrements(convertedDepths);
        }

        public static int CountDepthIncrements(string[] depths, int windowSize)
        {
            int[] convertedDepths = Array.ConvertAll(depths, d => int.Parse(d));
            int[] sums = SumDepthsByWindow(convertedDepths, windowSize);
            return CountDepthIncrements(sums);
        }

        public override (Answer First, Answer Second) Run(string[] lines)
        {
            return (
                new() { Description = "depth increments", Value = CountDepthIncrements(lines) },
                new() { Description = "windowed increments", Value = CountDepthIncrements(lines, 3) }
            );
        }

    }
}