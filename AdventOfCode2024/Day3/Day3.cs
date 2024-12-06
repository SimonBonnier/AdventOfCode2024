namespace AdventOfCode2024.Day1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

public class Day3
{
    public async Task<decimal> RunPart1()
    {
        var formula = await File.ReadAllTextAsync("C:\\Users\\Simon\\source\\repos\\AdventOfCode2024\\AdventOfCode2024\\Day3\\day3Input.txt");

        // xmul(2,4)%&mul[3,7]!@^do_not_mul(5,5)+mul(32,64]then(mul(11,8)mul(8,5))

        var multiplications = Regex.Matches(formula, @"(mul\(\d+,\d+\))");

        decimal sum = 0;
        foreach (Group multiplication in multiplications)
        {
            var parts = Regex.Match(multiplication.Value, @"(\d+),(\d+)");
            var numbers = parts.Value.Split(',').Select(int.Parse).ToArray();

            sum += (numbers[1] * numbers[0]);

        }


        return sum;
    }

    public async Task<decimal> RunPart2()
    {
        return await Task.FromResult(0M);
    }

}


