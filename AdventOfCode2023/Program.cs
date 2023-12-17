using AdventOfCode2023.Puzzles;

namespace AdventOfCode2023;

internal class Program
{
	static void Main(string[] args)
	{
		var oneA = new PuzzleOneA();
		Console.WriteLine(oneA.Solution());
		var oneB = new PuzzleOneB();
		Console.WriteLine(oneB.Solution());
		var twoA = new PuzzleTwoA();
		Console.WriteLine(twoA.Solution());
		var twoB = new PuzzleTwoB();
		Console.WriteLine(twoB.Solution());
		var threeA = new PuzzleThreeA();
		Console.WriteLine(threeA.Solution());
	}
}
