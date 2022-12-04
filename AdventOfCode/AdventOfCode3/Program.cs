﻿using AdventOfCode3;
using System.Collections;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Net;

const int lowercaseAdjust = 'a' - 1;
const int uppercaseAdjust = 'A' - 27;
List<string> backpacks = await BackpackManager.LoadBackpack("PuzzleInput.txt");

Console.WriteLine("\n\nDay 3:");
Console.WriteLine("======Part 1======");
Stopwatch stopwatch = Stopwatch.StartNew();
Console.WriteLine($"Priority sum was: {Part1(backpacks)}");
stopwatch.Stop();
Console.WriteLine($"Execution time (ticks): {stopwatch.ElapsedTicks}");
Console.WriteLine("\n======Part 2======");
stopwatch = Stopwatch.StartNew();
Console.WriteLine($"Priority sum was: {Part2(backpacks)}");
stopwatch.Stop();
Console.WriteLine($"Execution time (ticks): {stopwatch.ElapsedTicks}");
Console.ReadKey();


static string Part2(List<string> backpacks)
{
    int backpackIndex = 0;
    int prioritySum = 0;

    do
    {
        List<int[]> groupBps = new()
        {
            new int[52],
            new int[52],
            new int[52]
        };


        for (int i = 0; i < 3; i++)
        {
            var T = i;
            foreach (char letter in backpacks[backpackIndex + i])
            {
                int letterIndex = letter is >= 'a' and <= 'z' ? letter - lowercaseAdjust : letter - uppercaseAdjust;
                groupBps[i][letterIndex - 1]++;
            }
        }



        int[] result = new int[52];
        for (int i = 0; i < groupBps[0].Count(); i++)
        {
            if (groupBps[0][i] > 0 && groupBps[1][i] > 0 && groupBps[2][i] > 0)
                result[i] = 1;
        }
        List<int> resultAsList = new(result);

        if (resultAsList.Count(item => item > 0) > 1)
            throw new ArgumentException();

        if (!resultAsList.Contains(1))
            throw new ArgumentException();

        prioritySum += resultAsList.IndexOf(1) + 1;

        backpackIndex += 3;
    } while (backpackIndex < backpacks.Count);


    return prioritySum.ToString();
}

static string Part1(List<string> backpacks)
{
    int prioritySum = 0;


    foreach (string backpackrow in backpacks)
    {
        // Get the compartments
        int compartmentSize = backpackrow.Length / 2;
        string left = backpackrow.Substring(0, compartmentSize);
        string right = backpackrow.Substring(compartmentSize);

        foreach (char letter in left)
        {
            if (right.Contains(letter))
            {
                if (letter is >= 'a' and <= 'z')
                    prioritySum += (letter - lowercaseAdjust);
                else
                    prioritySum += letter - uppercaseAdjust;

                break;
            }
        }
    }


    return prioritySum.ToString();
}