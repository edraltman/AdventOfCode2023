using System;
using System.Reflection;

namespace AdventOfCode2023.Puzzles;

public abstract class BasePuzzle : IPuzzle
{
	private const string PuzzleInputDirectory = "input";

	public abstract string FileName();

	public string[] PuzzleInput()
	{
		string path = Path.Combine(
			Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!, PuzzleInputDirectory, FileName());

		return File.ReadAllLines(path);
	}
	public abstract string Solution();
}