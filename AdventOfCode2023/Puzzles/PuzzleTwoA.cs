using System.Text.RegularExpressions;

namespace AdventOfCode2023.Puzzles;

public class PuzzleTwoA : BasePuzzle
{
	public override string FileName() => "2a.txt";

	private static readonly Regex NumberRegex = new(@"\d+");
	private const int RedLimit = 12;
	private const int GreenLimit = 13;
	private const int BlueLimit = 14;

	public override string Solution()
	{
		var input = this.PuzzleInput();
		var games = input.Select(ParseGame);
		var possibleGames = games.Where(
			g => g.RedMax <= RedLimit
			&& g.GreenMax <= GreenLimit
			&& g.BlueMax <= BlueLimit);
		return possibleGames.Sum(g => g.GameNumber).ToString();
	}

	public GameSummary ParseGame(string gameInput)
	{
		var gameNumber = int.Parse(NumberRegex.Match(gameInput).Value);
		var rawSets = gameInput.Substring(gameInput.IndexOf(':') + 1).Split(';');
		var sets = rawSets.Select(ParseSet);

		var redMax = sets.Select(s => s.Red).Max();
		var greenMax = sets.Select(s => s.Green).Max();
		var blueMax = sets.Select(s => s.Blue).Max();

		return new GameSummary(gameNumber, redMax, greenMax, blueMax);
	}

	public Set ParseSet(string setInput)
	{
		var ballPulls = setInput.Split(',');
		var red = 0;
		var green = 0;
		var blue = 0;
		foreach (var ball in ballPulls)
		{
			var ballTrimmed = ball.TrimStart().TrimEnd();
			var count = int.Parse(ballTrimmed.Split(' ')[0]);
			var colour = ballTrimmed.Split(' ')[1];

			switch (colour)
			{
				case "red":
					red += count;
					break;
				case "green":
					green += count;
					break;
				case "blue":
					blue += count;
					break;
			}
		}
		return new Set(red, green, blue);
	}

	public record Set(int Red, int Green, int Blue);

	public record GameSummary(int GameNumber, int RedMax, int GreenMax, int BlueMax)
	{
		public int Power => RedMax * GreenMax * BlueMax;
	}
}
