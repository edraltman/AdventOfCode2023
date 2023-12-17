using System.Text.RegularExpressions;

namespace AdventOfCode2023.Puzzles;
internal class PuzzleThreeA : BasePuzzle
{
	public override string FileName() => "3a.txt";
	public static Regex Symbols() => new Regex(@"[^\.\w\d]");
	public static Regex PartNumbers() => new Regex(@"\d+");
	public override string Solution()
	{
		var input = this.PuzzleInput();
		var columns = input[0].Length;
		var rows = input.Length;

		var mask = new Mask(rows, columns);
		mask.Create(input);

		var validPartNumbers = new List<int>();

		var rowIndex = 0;
		foreach (var row in input)
		{
			var matches = PartNumbers().Matches(row);
			foreach (var match in matches.DefaultIfEmpty())
			{
				var number = int.Parse(match!.Value);

				if (mask.NumberIsInMask(number, rowIndex, match.Index))
				{
					validPartNumbers.Add(number);
				}
			}
			rowIndex++;
		}
		return validPartNumbers.Sum().ToString();
	}

	private sealed class Mask
	{
		// Parts should only affect cells 1 cell away. Set to const in case this is increased in part 2
		private const int NeighbourFactor = 1;
		public Mask(int rows, int columns)
		{
			this.Rows = rows;
			this.Columns = columns;
			this.Elements = new int[rows, columns];
		}

		public int Rows { get; }
		public int Columns { get; }
		private int[,] Elements { get; }

		public void Create(string[] input)
		{
			var rowIndex = 0;
			foreach (var row in input)
			{
				var matches = Symbols().Matches(row);
				if (matches.Count > 0)
				{
					foreach (var match in matches.DefaultIfEmpty())
					{
						SetPartMask(rowIndex, match!.Index);
					}
				}
				rowIndex++;
			}
		}

		public void SetPartMask(int row, int column)
		{
			for (int i = row - NeighbourFactor; i <= row + NeighbourFactor; i++)
			{
				for (int j = column - NeighbourFactor; j <= column + NeighbourFactor; j++)
				{
					if (i >= 0 && i < this.Rows && j >= 0 && j < this.Columns)
					{
						this.Elements[i, j] = 1;
					}
				}
			}
		}

		public bool NumberIsInMask(int number, int row, int column)
		{
			var len = number.ToString().Length;
			for (int i = column; i <= column + len - 1; i++)
			{
				if (Elements[row, i] == 1)
				{
					return true;
				}
			}
			return false;
		}
	}
}
