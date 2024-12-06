namespace AdventOfCode2024.Day1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

public class Day2
{
    public async Task<decimal> RunPart1()
    {
        var data = await File.ReadAllLinesAsync("C:\\Users\\Simon\\source\\repos\\AdventOfCode2024\\AdventOfCode2024\\Day2\\day2Input.txt");
        // C:\Users\Simon\source\repos\AdventOfCode2024\AdventOfCode2024\Day2\day2Input.txt

        List<Report> report = [];
        foreach (var line in data)
        {
            var parts = line.Split(' ').Select(int.Parse).ToArray();
            report.Add(new Report(parts));
        }

        return report.Sum(x => x.IsSafe() ? 1 : 0);
        
    }

    public async Task<decimal> RunPart2()
    {
        var data = await File.ReadAllLinesAsync("C:\\Users\\Simon\\source\\repos\\AdventOfCode2024\\AdventOfCode2024\\Day2\\day2Input.txt");

        List<Report> report = [];
        foreach (var line in data)
        {
            var parts = line.Split(' ').Select(int.Parse).ToArray();
            report.Add(new Report(parts));
        }

        return report.Sum(x => x.IsSafeCount() ? 1 : 0);
    }


    class Report
    {
        private readonly int[] _levels;

        public Report(int[] levels) 
        {
            _levels = levels;
        }

        public bool IsSafe()
        {
            return IsSafeInternal(_levels);
        }

        public bool IsSafeCount()
        {
            var safeCount = 0;

            safeCount += (IsSafeInternal(_levels) ? 1 : 0);

            for (int i = 0; i < _levels.Length; i++)
            {
                var subSet = new List<int>();
                for (int j = 0; j < _levels.Length; j++)
                {
                    if (j != i)
                    {
                        subSet.Add(_levels[j]);
                    }
                }

                safeCount += (IsSafeInternal([.. subSet]) ? 1 : 0);
            }

            return safeCount > 0;
        }

        private bool IsSafeInternal(int[] levels)
        {
            bool isOnlyDecreasing = true;
            bool isOnlyIncreasing = true;
            bool violateDiff = false;

            for (int i = 0; i < levels.Length - 1; i++)
            {
                if (levels[i + 1] > levels[i])
                {
                    isOnlyDecreasing = false;
                }
                else if (levels[i + 1] < levels[i])
                {
                    isOnlyIncreasing = false;
                }
                decimal diff = Math.Abs(levels[i + 1] - levels[i]);
                if (diff > 3 || diff < 1)
                {
                    violateDiff = true;
                }
            }

            return (isOnlyDecreasing || isOnlyIncreasing) && !violateDiff;
        }
    }

    class Level
    {

    }
    
}


