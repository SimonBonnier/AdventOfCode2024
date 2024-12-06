namespace AdventOfCode2024.Day1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Day1
{
    public async Task<int> RunPart1()
    {
        var data = await File.ReadAllLinesAsync("C:\\Users\\Simon\\source\\repos\\AdventOfCode2024\\AdventOfCode2024\\Day1\\day1TestData.txt");
        // C:\Users\Simon\source\repos\AdventOfCode2024\AdventOfCode2024\Day1\day1Input.txt
        // "C:\\Users\\Simon\\source\\repos\\AdventOfCode2024\\AdventOfCode2024\\Day1\\day1TestData.txt"

        var listOne = new List<int>();
        var listTwo = new List<int>();

        foreach (var line in data)
        {
            var values = line.Split("   ");
            listOne.Add(int.Parse(values[0]));
            listTwo.Add(int.Parse(values[1]));
        }

        listOne.Sort();
        listTwo.Sort();

        var entries = listOne.Zip(listTwo)
            .Select(x => new Entries(x.First, x.Second));

        var sum = entries.Sum(x => x.GetDiff());

        return sum;
    }

    public async Task<decimal> RunPart2()
    {
        var data = await File.ReadAllLinesAsync("C:\\Users\\Simon\\source\\repos\\AdventOfCode2024\\AdventOfCode2024\\Day1\\day1Input.txt");


        List<int> listOne = [];
        Dictionary<int, int> occurances = [];

        foreach (var line in data)
        {
            var parts = line.Split("   ");
            listOne.Add(int.Parse(parts[0]));

            var secondVal = int.Parse(parts[1]);

            if (occurances.ContainsKey(secondVal))
            {
                occurances[secondVal]++;
            }
            else
            {
                occurances[secondVal] = 1;
            }
        }

        decimal sum = 0;
        foreach (var val in listOne)
        {
            sum += val * (occurances.TryGetValue(val, out int times) ? times : 0);
        }

        return sum;
    }

    record Entries(int FirstVal, int SecVal)
    {
        public int GetDiff()
        {
            return Math.Abs(SecVal - FirstVal);
        }
    };
}


