using AdventOfCode2023.Puzzles;

namespace AdventOfCode2023;

internal class Program
{
	static void Main(string[] args)
	{
		var oneA = new PuzzleOneA();
		var oneB = new PuzzleOneB();
		var twoA = new PuzzleTwoA();
		var twoB = new PuzzleTwoB();
		Console.WriteLine(oneA.Solution());
		Console.WriteLine(oneB.Solution());
		Console.WriteLine(twoA.Solution());
		Console.WriteLine(twoB.Solution());
	}
}
