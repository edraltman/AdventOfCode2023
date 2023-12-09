using AdventOfCode2023.Utilities;

namespace AdventOfCode2023.Puzzles;
internal class PuzzleOneA : BasePuzzle
{
	public override string FileName() => "1a.txt";

	public override string Solution()
	{
		var input = this.PuzzleInput();
		return input.Select(GetValueOfLine).Sum().ToString();
	}

	private static int GetValueOfLine(string line)
	{
		var matches = RegexUtilities.Integers().Matches(line);
		var firstInt = matches.First().Value;
		var lastInt = matches.Last().Value;
		var firstAndLast = string.Concat(firstInt, lastInt);
		return int.Parse(firstAndLast);
	}
}
