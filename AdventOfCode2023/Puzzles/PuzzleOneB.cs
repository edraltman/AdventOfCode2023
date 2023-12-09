using System.Text.RegularExpressions;
using AdventOfCode2023.Utilities;

namespace AdventOfCode2023.Puzzles;
internal class PuzzleOneB : PuzzleOneA
{
	private readonly Regex RegexStandard = RegexUtilities.RegexMatchAnyInstanceOf(AllNumbers());
	private readonly Regex RegexReversed = RegexUtilities.RegexMatchAnyInstanceOf(AllNumbers().StringReverse());

	private static Dictionary<string, string> NumbersToIntsDictionary = new()
	{
		{"one", "1"},
		{"two", "2"},
		{"three", "3"},
		{"four", "4"},
		{"five", "5"},
		{"six", "6"},
		{"seven", "7"},
		{"eight", "8"},
		{"nine", "9"},
	};

	private static string[] AllNumbers() => NumbersToIntsDictionary.Keys.Concat(NumbersToIntsDictionary.Values).ToArray();

	public override string Solution()
	{
		var input = this.PuzzleInput();
		return input.Select(GetValueOfLine).Sum().ToString();
	}

	private int GetValueOfLine(string line)
	{
		// Get the first number/int match, and then the last by working from the end of the string by working in reverse
		var firstMatch = RegexStandard.Match(line).Value;
		var lastMatch = RegexReversed.Match(line.StringReverse()).Value.StringReverse();

		// Convert any numbers to ints
		var firstInt = ConvertNumberToInt(firstMatch);
		var lastInt = ConvertNumberToInt(lastMatch);

		// Concat the numbers and return the final value
		return int.Parse(string.Concat(firstInt, lastInt));
	}

	private static string ConvertNumberToInt(string match)
	{
		// Replace the match with the corresponding value from the dictionary
		if (NumbersToIntsDictionary.TryGetValue(match, out var replacement))
		{
			return replacement;
		}

		// If not found, return the original match
		return match;
	}
}
