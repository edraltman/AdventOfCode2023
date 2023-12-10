using System.Text.RegularExpressions;

namespace AdventOfCode2023.Puzzles;

public class PuzzleTwoB : PuzzleTwoA
{
	public override string Solution()
	{
		var input = this.PuzzleInput();
		var games = input.Select(ParseGame);
		return games.Sum(g => g.Power).ToString();
	}
}
